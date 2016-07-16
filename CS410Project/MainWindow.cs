using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;


namespace CS410Project
{
    public partial class Main_Window : Form
    {
        public Loginout loginManager = new Loginout();
        public RemoteDirectory directory = new RemoteDirectory();
        public Client client;
        public string username = "";
        public string password = "";
        public string destination = "";
        public string savedName = "";

        public Main_Window()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the username string is updated
            username = UsernameTextbox.Text;
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the password string is updated
            password = PasswordTextbox.Text;
        }

        private void Destination_TextChanged(object sender, EventArgs e)
        {
            //When the textbox changes, the destination string is updated
            destination = DestinationTextbox.Text;
        }

        private void Timeout_Event(object sender, EventArgs e)
        {
            loginManager.Timeout();
            MessageBox.Show("Automatic timeout has triggered", "Timed out", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            client = new FTPClient();
            if (loginManager.Login(client, username, password, destination))
            {
                loginManager.EnableTimeoutTimer(Timeout_Event,360);
                directory = new RemoteDirectory();
                directory.initializeDirectory(client);
                populateDirectoryBox(directory.getDirectoryStructure());
            } 
            else
            {
                //Can't log on, error!
                MessageBox.Show("Destination is not a valid FTP", "You goofed up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ParentButton_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                directory.changeToParentDirectory(client);
                populateDirectoryBox(directory.getDirectoryStructure());
            }
        }
        private void WorkingDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                if (WorkingDirectory.SelectedItem != null)
                {
                    string index = WorkingDirectory.SelectedItem.ToString();
                    if (!directory.changeToDirectory(client, index))
                    {
                        //It's a file, not a directory, so just download it
                        Console.WriteLine();
                        getFile temp = new getFile(WorkingDirectory.SelectedItem.ToString(), "");
                        temp.saveFiles(client);
                    }
                    populateDirectoryBox(directory.getDirectoryStructure());
                }
            }
        }
        //This method populates the listbox to contain the current working directory of the FTP server
        private void populateDirectoryBox(List<string> input)
        {
            //Wipe out the box before adding items
            WorkingDirectory.Items.Clear();
            //Add items one by one from the directory's structure
            for (int i = 0;i < input.Count;i++)
            {
                WorkingDirectory.Items.Add(input[i]);
            }
        }

        //This method populates the login fields with valid login information to the end of expediting testing.
        private void populateLoginFields(object sender, EventArgs e)
        {
            username = "anonymous";
            UsernameTextbox.Text = username;
            password = "";
            PasswordTextbox.Text = password;
            destination = "ftp://speedtest.tele2.net/";
            DestinationTextbox.Text = destination;
        }

        private void getFile_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                if (WorkingDirectory.SelectedItem != null)
                {
                    //this implementation assumes a single selected item; change to list later
                    //in the case of multiple selected items.
                    String [] Selected = new String[WorkingDirectory.SelectedItems.Count];
                    WorkingDirectory.SelectedItems.CopyTo(Selected, 0);
                    getFile temp = new getFile(Selected, "");
                    temp.saveFiles(client);                       
                }
            }
        }

        private void NewConnectionTextbox_TextChanged(object sender, EventArgs e)
        {
            savedName = NewConnectionTextbox.Text;
        }

        private void SaveConnectionsButton_Click(object sender, EventArgs e)
        {
            if (savedName != "")
            {
                loginManager.saveSessions(savedName, destination, username, password);
                updateConnectionBox();
            }
        }

        private void updateConnectionBox()
        {
            SavedConnections.Items.Clear();
            List<string> connectionList = new List<string>();
            connectionList = loginManager.getSessionDomains();
            for (int i = 0; i < connectionList.Count; i++)
            {
                SavedConnections.Items.Add(connectionList[i]);
            }
            loginManager.writeSessions();
        }

        private void SavedConnections_DoubleClick(object sender, EventArgs e)
        {
            if (SavedConnections.SelectedItem != null)
            {
                List<string> savedSession = new List<string>();
                savedSession = loginManager.loadSessions(SavedConnections.SelectedItem.ToString());
                destination = savedSession[1];
                DestinationTextbox.Text = destination;
                username = savedSession[2];
                UsernameTextbox.Text = username;
                password = savedSession[3];
                PasswordTextbox.Text = password;
            }
        }

        private void Main_Window_Load(object sender, EventArgs e)
        {
            loginManager.readSessions();
            updateConnectionBox();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (SavedConnections.SelectedItem != null)
            {
                loginManager.deleteSession(SavedConnections.SelectedItem.ToString());
                updateConnectionBox();
                loginManager.writeSessions();
            }
        }

        private void PutFile_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                //not working directoy, local directory item
                //if (WorkingDirectory.SelectedItem != null)
                //{}
                OpenFileDialog opFilDlg = new OpenFileDialog();
                if (opFilDlg.ShowDialog() == DialogResult.OK)
                {
                    client.putFile(opFilDlg.FileName);
                }
            }
        }

        private void CreateRemoteDir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(remoteDirText.Text)) { return; }

            if (client.createRemoteDir(remoteDirText.Text))
            {
                directory.refreshDirectory(client);//refresh remote directory
                populateDirectoryBox(directory.getDirectoryStructure());//refresh workingDirectory view
            }
            else
                MessageBox.Show("Directory creation failed", "Error");
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            if (WorkingDirectory.SelectedItem == null) { return; }

            if (client.deleteRemoteFile(WorkingDirectory.SelectedItem.ToString()))
            {
                directory.refreshDirectory(client);
                populateDirectoryBox(directory.getDirectoryStructure());//refresh workingDirectory view
            }
            else
                MessageBox.Show("Delete file failed", "Error");
        }

        //We can rename a file easily from within a file dialog
        private void RenameFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            //DialogResult result = folderBrowserDialog1.ShowDialog();
            //can save the selected file/path here, if we want to use it later
            string targetFile = openFileDialog1.FileName;
            if (result == DialogResult.OK) { } //check result
        }

        private void RenameFile2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            string targetFile = openFileDialog1.FileName;
            renameFileSelected.Text = targetFile;
            string path = Path.GetDirectoryName(openFileDialog1.FileName);
            string renamedPathFile = path + "\\" + renameFileNewName.Text;//.ToString();
            if (result == DialogResult.OK)
            {
         
                //Can clean this up, pop up an inputBox(deprecated) to get the name
                if (!String.IsNullOrEmpty(renameFileNewName.Text))
                {
                    File.Move(targetFile, renamedPathFile);
                    renameFileSelected.Clear();
                    renameFileNewName.Clear();
                    MessageBox.Show("File renamed successfully");
                    //TODO: when local directory is added, do a refresh here
                }
                else
                    MessageBox.Show("No name to rename file too, try again");
            } //check result
        }
    }
}
