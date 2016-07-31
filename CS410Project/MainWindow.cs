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

        public MainWindow()
        {
            InitializeComponent();
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
                        getFile temp = new getFile(RemoteDirectory.SelectedItem.ToString(), "");
                        temp.saveFiles(client, backWorkProgBar);
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
                    getFile temp = new getFile(Selected, "");
                    temp.saveFiles(client, backWorkProgBar);
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
                        MessageBox.Show("BackgroundWorker is busy");
                    }
                    remoteDirectory.refreshDirectory(client);
                    populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
                }
            }
            /*
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
            */
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
                    /*
                    string path = Path.GetDirectoryName(client.currDirectory);
                    string targetFile = path + "\\" + current;
                    string renamedPathFile = path + "\\" + value;
                    */
                    try
                    {
                        /*
                        File.Move(targetFile, renamedPathFile);
                        */
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

        //Local Rename
        private void RenameFile2_Click(object sender, EventArgs e)
        {/*
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
                    catch (Exception d)
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
            } //check result*/
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

        private void RemoteDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LocalDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void RemoteDirectory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void remoteDirText_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LocalNewFile_Click(object sender, EventArgs e)
        {

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
                /*
                using (FileStream fs = File.Create("poo.jpeg"))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);

                }
                */
                /*
                string[] poo = { "poo.jpeg" };

                if (File.Exists("ftp://abyss.mynetgear.com/files/" + "poo.jpeg"))
                {
                    MessageBox.Show("File 'testFile' Exist ");
                }
                else
                {
                    /* using (FileStream fs = File.Create("poo.jpeg"))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                            fs.Write(info, 0, info.Length);

                        }
                        

                    FileStream fs = File.Create("poo.jpeg");
                    fs.Close();
                    MessageBox.Show("File 'testFile' created ");
                }
                client.putMultiple(poo);
                */
                remoteDirectory.refreshDirectory(client);
                populateRemoteDirectoryBox(remoteDirectory.getDirectoryStructure());
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void CreateLocalDir_Click(object sender, EventArgs e)
        {

        }

        private void fontWindow_Apply(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (string filePath in files)
            {
                client.putFile(filePath, backWorkProgBar);
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = "{e.ProgressPercentage} %";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Complete";
            backWorkProgBar.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
