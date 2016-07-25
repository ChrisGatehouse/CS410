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
    public partial class Login : Form
    {
        private Loginout loginManager = new Loginout();
        private Client client;


        private string savedName   = "";
        private string destination = "";
        private string password    = "";
        private string username    = "";

        public Login()
        {
            InitializeComponent();
            loginManager.readSessions();
            updateConnectionBox();
            SettingsController.initializeSettings(this);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (savedName != "")
            {
                loginManager.saveSessions(savedName, destination, username, password);
                updateConnectionBox();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            client = new FTPClient();
            if (loginManager.Login(client, username, password, destination))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.loginManager = loginManager;
                mainWindow.client = client;
                mainWindow.ShowDialog(this);
            }
            else
            {
                //Can't log on, error!
                MessageBox.Show("Destination is not a valid FTP", "You goofed up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void savedConnectionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (savedConnectionsBox.SelectedItem != null)
            {
                List<string> savedSession = new List<string>();
                savedSession = loginManager.loadSessions(savedConnectionsBox.SelectedItem.ToString());
                destination = savedSession[1];
                serverTextbox.Text = destination;
                username = savedSession[2];
                usernameTextbox.Text = username;
                password = savedSession[3];
                passwordTextbox.Text = password;
            }
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {
            username = usernameTextbox.Text;
        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            password = passwordTextbox.Text;
        }

        private void serverTextbox_TextChanged(object sender, EventArgs e)
        {
            destination = serverTextbox.Text;
        }

        private void savedConnectionsBox_TextChanged(object sender, EventArgs e)
        {
            savedName = savedConnectionsBox.Text;
        }

        private void updateConnectionBox()
        {
            savedConnectionsBox.Items.Clear();
            List<string> connectionList = new List<string>();
            connectionList = loginManager.getSessionDomains();
            for (int i = 0; i < connectionList.Count; i++)
            {
                savedConnectionsBox.Items.Add(connectionList[i]);
            }
            loginManager.writeSessions();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (savedConnectionsBox.SelectedItem != null)
            {
                loginManager.deleteSession(savedConnectionsBox.SelectedItem.ToString());
                updateConnectionBox();
                loginManager.writeSessions();
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult fontdialog = fontWindow.ShowDialog();
            if (fontdialog == DialogResult.OK)
            {
                Font font = fontWindow.Font;
                CS410Project.Properties.Settings.Default.SysFont = font;
                CS410Project.Properties.Settings.Default.Save();
                List<Control> allWindows = SettingsController.getAllControls(this);
                allWindows.ForEach(x => x.Font = font);
            }
        }

        private void changeColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }
    }
}
