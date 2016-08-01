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

        public static void initializeSettings(Form window)
        {
            List<Control> thisWindowFont = SettingsController.getControls(window);
            thisWindowFont.ForEach(x => x.Font = CS410Project.Properties.Settings.Default.SysFont);
            List<Control> thisWindowButtons = SettingsController.getButtonControls(window);
            thisWindowButtons.ForEach(x => x.BackColor = CS410Project.Properties.Settings.Default.ButtonColor);
            List<Control> thisWindowMenuStrip = SettingsController.getMenuStripControls(window);
            thisWindowMenuStrip.ForEach(x => x.BackColor = CS410Project.Properties.Settings.Default.ToolbarColor);
            List<Control> thisWindow = SettingsController.getBackgroundControls(window);
            thisWindow.ForEach(x => x.BackColor = CS410Project.Properties.Settings.Default.BackgroundColor);
            List<Control> thisTextbox = SettingsController.getTextboxControls(window);
            thisTextbox.ForEach(x => x.BackColor = CS410Project.Properties.Settings.Default.TextboxColor);
            List<Control> thisWindowFontColor = SettingsController.getControls(window);
            thisWindowFontColor.ForEach(x => x.ForeColor = CS410Project.Properties.Settings.Default.FontColor);
        }

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
        //Grabs a list of all Textbox for all parent windows
        public static List<Control> getAllTextboxControls(Form window)
        {
            List<Control> output = new List<Control>();
            if (window.Owner != null)
            {
                output.AddRange(getAllTextboxControls(window.Owner));
            }
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    output.Add(c);
                }
            }
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
        //Grabs a list of all MenuStrips for a given window
        public static List<Control> getBackgroundControls(Form window)
        {
            List<Control> output = new List<Control>();
            output.Add(window);
            return output;
        }
        //Grabs a list of all MenuStrips for a given window
        public static List<Control> getMenuStripControls(Form window)
        {
            List<Control> output = new List<Control>();
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(MenuStrip))
                {
                    output.Add(c);
                }
            }
            return output;
        }
        //Grabs a list of all buttons for a given window
        public static List<Control> getButtonControls(Form window)
        {
            List<Control> output = new List<Control>();
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    output.Add(c);
                }
            }
            return output;
        }
        //Grabs a list of all Textbox for a given window
        public static List<Control> getTextboxControls(Form window)
        {
            List<Control> output = new List<Control>();
            foreach (Control c in window.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    output.Add(c);
                }
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
