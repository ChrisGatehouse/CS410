using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS410Project
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SettingsController.initializeSettings(this);
        }

        private void fontColorButton_Click(object sender, EventArgs e)
        {
            DialogResult fontColorResult = fontColorDiag.ShowDialog();
            if (fontColorResult == DialogResult.OK)
            {
                Color color = fontColorDiag.Color;
                CS410Project.Properties.Settings.Default.FontColor = color;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllControls(this);
                allWindows.ForEach(x => x.ForeColor = color);
            }
        }

        private void buttonColorButton_Click(object sender, EventArgs e)
        {
            DialogResult buttonColorResult = buttonColorDiag.ShowDialog();
            if (buttonColorResult == DialogResult.OK)
            {
                Color color = buttonColorDiag.Color;
                CS410Project.Properties.Settings.Default.ButtonColor = color;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllButtonControls(this);
                allWindows.ForEach(x => x.BackColor = color);
            }
        }

        private void backgroundColorButton_Click(object sender, EventArgs e)
        {
            DialogResult backgroundColorResult = backgroundColorDiag.ShowDialog();
            if (backgroundColorResult == DialogResult.OK)
            {
                Color color = backgroundColorDiag.Color;
                CS410Project.Properties.Settings.Default.BackgroundColor = color;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllBackgroundControls(this);
                allWindows.ForEach(x => x.BackColor = color);
            }
        }

        private void ToolbarColorButton_Click(object sender, EventArgs e)
        {
            DialogResult toolbarColorResult = toolbarColorDiag.ShowDialog();
            if (toolbarColorResult == DialogResult.OK)
            {
                Color color = toolbarColorDiag.Color;
                CS410Project.Properties.Settings.Default.ToolbarColor = color;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllMenuStripControls(this);
                allWindows.ForEach(x => x.BackColor = color);
            }
        }

        private void textboxColorButton_Click(object sender, EventArgs e)
        {
            DialogResult toolbarColorResult = textboxColorDiag.ShowDialog();
            if (toolbarColorResult == DialogResult.OK)
            {
                Color color = textboxColorDiag.Color;
                CS410Project.Properties.Settings.Default.TextboxColor = color;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllTextboxControls(this);
                allWindows.ForEach(x => x.BackColor = color);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
