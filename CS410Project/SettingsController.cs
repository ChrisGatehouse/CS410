using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS410Project
{
    class SettingsController
    {
        //Grabs a list of all components for all parent windows
        public static List<Control> getAllControls(Form window)
        {
            List<Control> output = new List<Control>();
            if (window.Owner != null)
            {
                output.AddRange(getAllControls(window.Owner));
            }
            foreach (Control c in window.Controls)
            {
                output.Add(c);
            }
            return output;
        }

        //Grabs all components of a given window
        public static List<Control> getControls(Form window)
        {
            List<Control> output = new List<Control>();
            foreach (Control c in window.Controls)
            {
                output.Add(c);
            }
            return output;
        }
    }
}
