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
    public partial class MainWindow : Form
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        public Loginout loginManager = new Loginout();
        public RemoteDirectory remoteDirectory = new RemoteDirectory();
        public LocalDirectory localDirectory = new LocalDirectory();
        public Client client;

        public MainWindow()
        {
            InitializeComponent();
            underConstruction.Load("http://i.imgur.com/A5dbxGN.png");
            populateLocalDirectoryBox(localDirectory.getDirectoryStructure());
            SettingsController.initializeSettings(this);
        }



        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timeout_Event(object sender, EventArgs e)
        {
            loginManager.Timeout();
            MessageBox.Show("Automatic timeout has triggered", "Timed out", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ParentButton_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                remoteDirectory.changeToParentDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
            }
        }

        private void LocalParentButton_Click(object sender, EventArgs e)
        {
            localDirectory.changeToParentDirectory();
            populateLocalDirectoryBox(localDirectory.getDirectoryStructure());
        }

        private void LocalDirectory_DoubleClick(object sender, EventArgs e)
        {
           if (LocalDirectory.SelectedItem != null)
           {
               string index = LocalDirectory.SelectedItem.ToString();
               if (!localDirectory.changeToDirectory(index))
               {
                 //maybe add uploading here I don't know
               }
               populateLocalDirectoryBox(localDirectory.getDirectoryStructure());
           }
        }
        private void RemoteDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                if (RemoteDirectory.SelectedItem != null)
                {
                    string index = RemoteDirectory.SelectedItem.ToString();
                    if (!remoteDirectory.changeToDirectory(client, index))
                    {
                        //It's a file, not a directory, so just download it
                        Console.WriteLine();
                        getFile temp = new getFile(RemoteDirectory.SelectedItem.ToString(), "");
                        temp.saveFiles(client);
                    }
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
                }
            }
        }
        //This method populates the listbox to contain the current working directory of the FTP server
        private void populateRemoteDirectoryBox(List<string> input)
        {
            //Wipe out the box before adding items
            RemoteDirectory.Items.Clear();
            //Add items one by one from the directory's structure
            for (int i = 0;i < input.Count;i++)
            {
                RemoteDirectory.Items.Add(input[i]);
            }
        }

        //This method populates the listbox to contain the current working directory of the FTP server
        private void populateLocalDirectoryBox(List<string> input)
        {
            //Wipe out the box before adding items
            LocalDirectory.Items.Clear();
            //Add items one by one from the directory's structure
            for (int i = 0; i < input.Count; i++)
            {
                LocalDirectory.Items.Add(input[i]);
            }
        }

        private void getFile_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                if (RemoteDirectory.SelectedItem != null)
                {
                    //this implementation assumes a single selected item; change to list later
                    //in the case of multiple selected items.
                    String [] Selected = new String[RemoteDirectory.SelectedItems.Count];
                    RemoteDirectory.SelectedItems.CopyTo(Selected, 0);
                    getFile temp = new getFile(Selected, "");
                    temp.saveFiles(client);                       
                }
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
                opFilDlg.Multiselect = true;

                if (opFilDlg.ShowDialog() == DialogResult.OK)
                {
                    string[] files = opFilDlg.FileNames;
                    client.putMultiple(files);
                    remoteDirectory.refreshDirectory(client);
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
                }
            }
        }

        private void CreateRemoteDir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(remoteDirText.Text)) { return; }

            if (client.createRemoteDir(remoteDirText.Text))
            {
                remoteDirectory.refreshDirectory(client);//refresh remote directory
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());//refresh workingDirectory view
            }
            else
                MessageBox.Show("Directory creation failed", "Error");
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            if (RemoteDirectory.SelectedItem == null) { return; }

            if (client.deleteRemoteFile(RemoteDirectory.SelectedItem.ToString()))
            {
                remoteDirectory.refreshDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());//refresh workingDirectory view
            }
			else if (client.deleteRemoteDir(WorkingDirectory.SelectedItem.ToString()))
			{
				directory.refreshDirectory(client);
				populateDirectoryBox(directory.getDirectoryStructure());
			}
			else
                MessageBox.Show("Delete failed", "Error");
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
                    try
                    {
                        File.Move(targetFile, renamedPathFile);
                    }
                    catch(Exception d)
{
                        Console.WriteLine("The process failed: {0}", d.ToString());
                        MessageBox.Show("Rename error occured");
                                            return;
                    }
                    renameFileSelected.Clear();
                    renameFileNewName.Clear();
                    MessageBox.Show("File renamed successfully");
                    //TODO: when local directory is added, do a refresh here
                }
                else
                    MessageBox.Show("No name to rename file too, try again");
            } //check result
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            loginManager.EnableTimeoutTimer(Timeout_Event, 360);
            remoteDirectory = new RemoteDirectory();
            remoteDirectory.initializeDirectory(client);
            populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
        }


        //Toolbar for change Font
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

        private void changeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }

    }
}
