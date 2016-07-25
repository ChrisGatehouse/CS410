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
        //Grabs a list of all MenuStrips for all parent windows
        public static List<Control> getAllBackgroundControls(Form window)
        {
            List<Control> output = new List<Control>();
            if (window.Owner != null)
            {
                output.AddRange(getAllBackgroundControls(window.Owner));
            }
            output.Add(window);
            return output;
        }
        //Grabs a list of all MenuStrips for all parent windows
        public static List<Control> getAllMenuStripControls(Form window)
        {
            List<Control> output = new List<Control>();
            if (window.Owner != null)
            {
                output.AddRange(getAllMenuStripControls(window.Owner));
            }
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(MenuStrip))
                {
                    output.Add(c);
                }
            }
            return output;
        }
        //Grabs a list of all buttons for all parent windows
        public static List<Control> getAllButtonControls(Form window)
        {
            List<Control> output = new List<Control>();
            if (window.Owner != null)
            {
                output.AddRange(getAllButtonControls(window.Owner));
            }
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    output.Add(c);
                }
            }
            return output;
        }
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
