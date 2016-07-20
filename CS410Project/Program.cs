using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        static void Main()
        {
            //log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Window());
            
        }
    }
}
