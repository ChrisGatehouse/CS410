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
using Microsoft.VisualBasic;


namespace CS410Project
{
    public partial class MainWindow : Form
    {
        private static readonly log4net.ILog Log = LogHelper.GetLogger();
        public Loginout loginManager = new Loginout();
        public RemoteDirectory remoteDirectory = new RemoteDirectory();
        public LocalDirectory localDirectory = new LocalDirectory();
        public Client client;
        string[] files;
        getFile temp;
        bool hidden = false; //boolean value whether or not the owner window is hidden or not

        public MainWindow()
        {
            InitializeComponent();
            populateLocalDirectoryBox(localDirectory.getDirectoryStructure());
            SettingsController.initializeSettings(this);
        }



        private void MainWindow_Exit(object sender, FormClosingEventArgs e)
        {
            if (hidden)
            {
                Owner.Show();
                hidden = !hidden;
            }
            Close();
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

        private void LocalParentDirectory_Click(object sender, EventArgs e)
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
                        temp = new getFile(RemoteDirectory.SelectedItem.ToString(), "");
                        if (!backWorkGetProg.IsBusy)
                        {
                            backWorkGetProg.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("An upload or download is currently in progress");
                        }
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
            for (int i = 0; i < input.Count; i++)
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
                    String[] Selected = new String[RemoteDirectory.SelectedItems.Count];
                    RemoteDirectory.SelectedItems.CopyTo(Selected, 0);
                    temp = new getFile(Selected, "");
                    if (!backWorkGetProg.IsBusy)
                    {
                        backWorkGetProg.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("An upload or download is currently in progress");
                    }
                }
            }
        }

        private void PutFile_Click(object sender, EventArgs e)
        {
            if (loginManager.LoggedIn)
            {
                OpenFileDialog opFilDlg = new OpenFileDialog();
                opFilDlg.Multiselect = true;
                if (opFilDlg.ShowDialog() == DialogResult.OK)
                {
                    files = opFilDlg.FileNames;
                    if (!backWorkProgBar.IsBusy)
                    {
                        backWorkProgBar.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("An upload or download is currently in progress");
                    }
                    remoteDirectory.refreshDirectory(client);
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
                }
            }
        }

        private void CreateRemoteDir_Click(object sender, EventArgs e)
        {
            string value = "Enter directory name";
            if (InputBox("New directory", "New directory name:", ref value) == DialogResult.OK)
            {
                string remoteDirText = value;

                if (string.IsNullOrWhiteSpace(remoteDirText)) { return; }

                if (client.createRemoteDir(remoteDirText))
                {
                    remoteDirectory.refreshDirectory(client);//refresh remote directory
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());//refresh workingDirectory view
                }
                else
                    MessageBox.Show("Directory creation failed", "Error");
            }
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            if (RemoteDirectory.SelectedItem == null) { return; }

            if (client.deleteRemoteFile(RemoteDirectory.SelectedItem.ToString()))
            {
                remoteDirectory.refreshDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());//refresh workingDirectory view
            }
            else if (client.deleteRemoteDir(RemoteDirectory.SelectedItem.ToString()))
            {
                remoteDirectory.refreshDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
            }
            else
                MessageBox.Show("Delete failed", "Error");
        }

        //Remote Rename
        private void RenameFile_Click(object sender, EventArgs e)
        {
            if (RemoteDirectory.SelectedItem == null)
            {
                return;
            }
            else
            {
                string current = RemoteDirectory.SelectedItem.ToString();
                string value = "Enter new file name";

                if (InputBox("Rename File", "New file name:", ref value) == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(value)) { return; }           
                    try
                    {
                        client.renameRemoteFile(current, value);

                    }
                    catch (Exception d)
                    {
                        Console.WriteLine("The process failed: {0}", d.ToString());
                        MessageBox.Show("Rename error occured");
                        return;
                    }

                    MessageBox.Show("File renamed successfully");

                    remoteDirectory.refreshDirectory(client);//refresh remote directory
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());//refresh workingDirectory view
                }
            }

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

        public DialogResult InputBox(string title, string promptText, ref string value)

        {
            Form form = new Form();
            form.Font = CS410Project.Properties.Settings.Default.SysFont;
            form.BackColor = CS410Project.Properties.Settings.Default.BackgroundColor;
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            buttonOk.BackColor = CS410Project.Properties.Settings.Default.ButtonColor;
            Button buttonCancel = new Button();
            buttonCancel.BackColor = CS410Project.Properties.Settings.Default.ButtonColor;
            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;
            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void RemoteNewFile_Click(object sender, EventArgs e)
        {

            if (loginManager.LoggedIn)
            {

                string value = "Enter file name";
                if (InputBox("New file", "New file name:", ref value) == DialogResult.OK)
                {
                    using (File.Create(value)) { }
                    MessageBox.Show("File " + value + " created ");
                }
                client.putFile(value);
                remoteDirectory.refreshDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
            }
        }

        private void CreateLocalDir_Click(object sender, EventArgs e)
        {
            string value = "Enter directory name";
            if (InputBox("New directory", "New directory name:", ref value) == DialogResult.OK)
            {
                string localDirText = value;

                if (string.IsNullOrWhiteSpace(localDirText)) { return; }

                if (localDirectory.createLocalDirectory(localDirText))
                {
                    localDirectory.refreshDirectory();
                    populateLocalDirectoryBox(localDirectory.getDirectoryStructure());//refresh workingDirectory view with addition of new directory
                }
                else
                    MessageBox.Show("A directory with that name already exists.", "Error");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string filePath in files)
            {
                backWorkProgBar.ReportProgress(0);
                client.putFile(filePath, backWorkProgBar);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = e.ProgressPercentage + "%";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Complete";
            backWorkProgBar.Dispose();
        }

        private void LocalSearchButton_Click(object sender, EventArgs e)
        {
            string inputSearch = LocalSearchBox.Text;
            localDirectory.searchLocalDirectory(inputSearch);
        }

        private void LocalRenameFileButton_Click(object sender, EventArgs e)
        {
            if (LocalDirectory.SelectedItem == null)
            {
                return;
            }
            else
            {
                string current = LocalDirectory.SelectedItem.ToString();
                string value = "Enter new file name";

                if (InputBox("Rename File", "New file name:", ref value) == DialogResult.OK)
                {
                    if (string.IsNullOrWhiteSpace(value)) { return; }
                    Exception returnValue;
                    returnValue = localDirectory.renameLocalFile(current, value);
                    if(returnValue == null) //success case with no exceptions
                    {
                        MessageBox.Show("File renamed successfully");
                    }
                    else //failure case with some exception
                    {
                        MessageBox.Show("Error: " + returnValue.Message);
                    }
                    localDirectory.refreshDirectory();
                    populateLocalDirectoryBox(localDirectory.getDirectoryStructure());//refresh workingDirectory view with renamed file.
                }
            }

        }

        private void backWorkGetProg_DoWork(object sender, DoWorkEventArgs e)
        {
            temp.saveFiles(client, backWorkGetProg);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a project for Portland State University CS410 Agile Software development. \nThis project was developed by:\nBen Lawrence\nChris Gatehouse\nJonathan Hasbun\nMiles Sanguinetti\nMohammed Inoue", "About", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void githubReadmeOpensWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ChrisGatehouse/CS410");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hidden)
            {
                Owner.Show();
                hidden = !hidden;
            }
            loginManager.Logout(client);
            Close();
        }

        private void RemoteSearchButton_Click(object sender, EventArgs e)
        {
            string inputSearch = RemoteSearchBox.Text;
            remoteDirectory.searchRemoteDirectory(client, inputSearch);
        }

        private void hideLogInWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hidden)
            {
                Owner.Hide();
                hidden = !hidden;
            }
            else
            {
                Owner.Show();
                hidden = !hidden;
            }
        }
    }
}
