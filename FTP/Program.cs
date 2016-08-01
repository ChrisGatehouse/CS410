using System;
using System.IO;
using NDesk.Options;
using CS410Project;

namespace FTP
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Option default values.
			bool help = false;
			bool version = false;
			int verbose = 0;
			bool graphical = false;

			// Option definitions.
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
				Console.Write("FTP: ");
				Console.WriteLine(e.Message);
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


			// Option implementations.
			if (help)
				p.WriteOptionDescriptions(Console.Out);
			if (version)
				Console.WriteLine("NDesk.Options Localizer Demo 1.0");
			if (verbose > 0)
				Console.WriteLine("Message level: {0}", verbose);
			if (graphical)
			{
				if (verbose > 0)
					Console.WriteLine("*** starting gui...");
				
				Console.WriteLine("Start GUI...");

				// TODO open gui
			}
		}
	}
}
