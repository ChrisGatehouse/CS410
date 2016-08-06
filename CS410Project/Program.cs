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
			string path = ".cred";
			string server = null;
			string user = null;
			string pass = null;

			if (!File.Exists(path))
			{
				StreamWriter credentials = File.CreateText(path);

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
				StreamReader credentials = File.OpenText(path);

				server = credentials.ReadLine();
				user = credentials.ReadLine();
				pass = credentials.ReadLine();
				credentials.Close();
			}

			// TODO login to server using credentials.
			if (verbose > 0)
				Console.WriteLine("*** connecting to {0}...", server);

			// connect to server.


			// Options - Implementations.
			if (help)
				p.WriteOptionDescriptions(Console.Out);
			if (version)
				Console.WriteLine("Dragon FTP - Version 1.0");
			if (verbose > 0)
				Console.WriteLine("Message level: {0}", verbose);
        }
    }
}
