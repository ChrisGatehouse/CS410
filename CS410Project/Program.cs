using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NDesk.Options;
using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace CS410Project
{
    static class Program
    {
		private static Loginout loginManager = new Loginout();
		private static FTPClient client;
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main(string[] args)
        {
			int count = args.Count();

			// Options - Default Values.
			bool help = false;
			bool version = false;
			int verbose = 0;
			bool graphical = false;
			string download = null;
			string upload = null;
			string path = "";

			// Options - Definitions.
			var p = new OptionSet() {
				{ "h|?|help", "show this message and exit.", 
					v => help = v != null },
				{ "v|verbose", "increase message verbosity.",
					v => { ++verbose; } },
				{ "V|version", "output version information and exit.",
					v => version = v != null },
				{ "g|graphical", "initializes the graphical user interface.",
					v => graphical = v != null },
				{ "d|download=", "download a {FILE} from the server.",
					v => download = v },
				{ "u|upload=", "upload a {FILE} to the server.",
					v => upload = v },
				{ "p|path=", "specify a {PATH} to download/upload files to\n(must end in \"\\\").",
					v => path = v },
			};

			// Parse options, throw error otherwise.
			try {
				p.Parse(args);
			}
			catch(OptionException e) {
				// TODO log error
				Console.Write("FTP: ");
				Console.WriteLine(e.Message);
				return;
			}


			// Check for Defualt or Graphical
			if (count < 1 || graphical)
			{
				if (verbose > 0)
					Console.WriteLine("*** starting gui...");

				//log4net.Config.XmlConfigurator.Configure();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Login());

				return;
			}


			// Check for existing credentials, otherwise create them.
			string filePath = ".cred";
			string server = null;
			string user = null;
			string pass = null;

			if (!File.Exists(filePath))
			{
				StreamWriter credentials = File.CreateText(filePath);

				Console.WriteLine("Enter FTP url (e.g. ftp://serverurl): ");
				server = Console.ReadLine();
				Console.WriteLine("Enter username: ");
				user = Console.ReadLine();
				Console.WriteLine("Enter password: ");
				pass = Console.ReadLine();

				credentials.WriteLine(server);
				credentials.WriteLine(user);
				credentials.WriteLine(pass);
				credentials.Flush();
				credentials.Close();
			}
			else
			{
				StreamReader credentials = File.OpenText(filePath);

				server = credentials.ReadLine();
				user = credentials.ReadLine();
				pass = credentials.ReadLine();
				credentials.Close();
			}


			if (verbose > 0)
				Console.WriteLine("*** connecting to {0}...", server);

			// Connect to server.
			client = new FTPClient();
			if (loginManager.Login(client, user, pass, server))
			{
				if (verbose > 0)
					Console.WriteLine("*** login successful...");
			}
			else
			{
				if (verbose > 0)
					Console.WriteLine("*** login failed...");
			}


			// Options - Implementations.
			if (help)
				p.WriteOptionDescriptions(Console.Out);
			if (version)
				Console.WriteLine("Dragon FTP - Version 1.0");
			if (download != null) {
				Boolean success = false;

				if (verbose > 0)
					Console.WriteLine("*** downloading file: {0}", download);

				getFile fileHandler = new getFile(download, path);
				fileHandler.saveFiles(client, success);

				if (verbose > 0 && success)
					Console.WriteLine("*** file successfully downloaded...");
				if (verbose > 0 && !success)
					Console.WriteLine("*** file failed to download...");
			}
			if (upload != null) {
				if (verbose > 0)
					Console.WriteLine("*** uploading file: {0}", upload);
				
				client.putFile(upload, path);

				if (verbose > 0)
					Console.WriteLine("*** file successfully uploaded...");
			}
        }
    }
}
