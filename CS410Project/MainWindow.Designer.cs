namespace CS410Project
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RemoteDirectory = new System.Windows.Forms.ListBox();
            this.RemoteParentButton = new System.Windows.Forms.Button();
            this.PutFile = new System.Windows.Forms.Button();
            this.CreateRemoteDir = new System.Windows.Forms.Button();
            this.RemoteDeleteFile = new System.Windows.Forms.Button();
            this.RemoteRenameFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LocalDirectory = new System.Windows.Forms.ListBox();
            this.GetFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontWindow = new System.Windows.Forms.FontDialog();
            this.Remote = new System.Windows.Forms.Label();
            this.RemoteTree = new System.Windows.Forms.ListBox();
            this.LocalTree = new System.Windows.Forms.ListBox();
            this.Diff = new System.Windows.Forms.Button();
            this.Local = new System.Windows.Forms.Label();
            this.RemoteNewFile = new System.Windows.Forms.Button();
            this.LocalParentDirectory = new System.Windows.Forms.Button();
            this.LocalNewFile = new System.Windows.Forms.Button();
            this.LocalRenameFile = new System.Windows.Forms.Button();
            this.CreateLocalDir = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RemoteDirectory
            // 
            this.RemoteDirectory.FormattingEnabled = true;
            this.RemoteDirectory.Location = new System.Drawing.Point(138, 70);
            this.RemoteDirectory.Name = "RemoteDirectory";
            this.RemoteDirectory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RemoteDirectory.Size = new System.Drawing.Size(544, 134);
            this.RemoteDirectory.TabIndex = 5;
            this.RemoteDirectory.SelectedIndexChanged += new System.EventHandler(this.RemoteDirectory_SelectedIndexChanged_1);
            this.RemoteDirectory.DoubleClick += new System.EventHandler(this.RemoteDirectory_DoubleClick);
            // 
            // RemoteParentButton
            // 
            this.RemoteParentButton.Location = new System.Drawing.Point(138, 41);
            this.RemoteParentButton.Name = "RemoteParentButton";
            this.RemoteParentButton.Size = new System.Drawing.Size(92, 23);
            this.RemoteParentButton.TabIndex = 6;
            this.RemoteParentButton.Text = "Parent Directory";
            this.RemoteParentButton.UseVisualStyleBackColor = true;
            this.RemoteParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // PutFile
            // 
            this.PutFile.Location = new System.Drawing.Point(302, 207);
            this.PutFile.Name = "PutFile";
            this.PutFile.Size = new System.Drawing.Size(75, 23);
            this.PutFile.TabIndex = 13;
            this.PutFile.Text = "Put File ↑";
            this.PutFile.UseVisualStyleBackColor = true;
            this.PutFile.Click += new System.EventHandler(this.PutFile_Click);
            // 
            // CreateRemoteDir
            // 
            this.CreateRemoteDir.Location = new System.Drawing.Point(398, 41);
            this.CreateRemoteDir.Name = "CreateRemoteDir";
            this.CreateRemoteDir.Size = new System.Drawing.Size(106, 23);
            this.CreateRemoteDir.TabIndex = 15;
            this.CreateRemoteDir.Text = "Create Remote Dir";
            this.CreateRemoteDir.UseVisualStyleBackColor = true;
            this.CreateRemoteDir.Click += new System.EventHandler(this.CreateRemoteDir_Click);
            // 
            // RemoteDeleteFile
            // 
            this.RemoteDeleteFile.Location = new System.Drawing.Point(383, 207);
            this.RemoteDeleteFile.Name = "RemoteDeleteFile";
            this.RemoteDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.RemoteDeleteFile.TabIndex = 17;
            this.RemoteDeleteFile.TabStop = false;
            this.RemoteDeleteFile.Text = "Delete File X";
            this.RemoteDeleteFile.UseVisualStyleBackColor = true;
            this.RemoteDeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // RemoteRenameFile
            // 
            this.RemoteRenameFile.Location = new System.Drawing.Point(317, 41);
            this.RemoteRenameFile.Name = "RemoteRenameFile";
            this.RemoteRenameFile.Size = new System.Drawing.Size(75, 23);
            this.RemoteRenameFile.TabIndex = 18;
            this.RemoteRenameFile.Text = "Rename File";
            this.RemoteRenameFile.UseVisualStyleBackColor = true;
            this.RemoteRenameFile.Click += new System.EventHandler(this.RenameFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LocalDirectory
            // 
            this.LocalDirectory.FormattingEnabled = true;
            this.LocalDirectory.Location = new System.Drawing.Point(138, 236);
            this.LocalDirectory.Name = "LocalDirectory";
            this.LocalDirectory.Size = new System.Drawing.Size(544, 134);
            this.LocalDirectory.TabIndex = 24;
            this.LocalDirectory.DoubleClick += new System.EventHandler(this.LocalDirectory_DoubleClick);
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(219, 207);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(77, 23);
            this.GetFile.TabIndex = 7;
            this.GetFile.Text = "Get File ↓ ";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.getFile_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFontToolStripMenuItem,
            this.changeColorToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fontWindow
            // 
            this.fontWindow.Apply += new System.EventHandler(this.fontWindow_Apply);
            // 
            // Remote
            // 
            this.Remote.AutoSize = true;
            this.Remote.Location = new System.Drawing.Point(12, 41);
            this.Remote.Name = "Remote";
            this.Remote.Size = new System.Drawing.Size(44, 13);
            this.Remote.TabIndex = 27;
            this.Remote.Text = "Remote";
            this.Remote.Click += new System.EventHandler(this.label3_Click);
            // 
            // RemoteTree
            // 
            this.RemoteTree.FormattingEnabled = true;
            this.RemoteTree.Location = new System.Drawing.Point(0, 70);
            this.RemoteTree.Name = "RemoteTree";
            this.RemoteTree.Size = new System.Drawing.Size(132, 134);
            this.RemoteTree.TabIndex = 28;
            this.RemoteTree.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // LocalTree
            // 
            this.LocalTree.FormattingEnabled = true;
            this.LocalTree.Location = new System.Drawing.Point(0, 236);
            this.LocalTree.Name = "LocalTree";
            this.LocalTree.Size = new System.Drawing.Size(132, 134);
            this.LocalTree.TabIndex = 29;
            this.LocalTree.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // Diff
            // 
            this.Diff.Location = new System.Drawing.Point(138, 207);
            this.Diff.Name = "Diff";
            this.Diff.Size = new System.Drawing.Size(75, 23);
            this.Diff.TabIndex = 30;
            this.Diff.Text = "Diff";
            this.Diff.UseVisualStyleBackColor = true;
            // 
            // Local
            // 
            this.Local.AutoSize = true;
            this.Local.Location = new System.Drawing.Point(12, 212);
            this.Local.Name = "Local";
            this.Local.Size = new System.Drawing.Size(33, 13);
            this.Local.TabIndex = 31;
            this.Local.Text = "Local";
            // 
            // RemoteNewFile
            // 
            this.RemoteNewFile.Location = new System.Drawing.Point(236, 41);
            this.RemoteNewFile.Name = "RemoteNewFile";
            this.RemoteNewFile.Size = new System.Drawing.Size(75, 23);
            this.RemoteNewFile.TabIndex = 32;
            this.RemoteNewFile.Text = "New File";
            this.RemoteNewFile.UseVisualStyleBackColor = true;
            this.RemoteNewFile.Click += new System.EventHandler(this.RemoteNewFile_Click);
            // 
            // LocalParentDirectory
            // 
            this.LocalParentDirectory.Location = new System.Drawing.Point(138, 376);
            this.LocalParentDirectory.Name = "LocalParentDirectory";
            this.LocalParentDirectory.Size = new System.Drawing.Size(92, 23);
            this.LocalParentDirectory.TabIndex = 33;
            this.LocalParentDirectory.Text = "Parent Directory";
            this.LocalParentDirectory.UseVisualStyleBackColor = true;
            this.LocalParentDirectory.Click += new System.EventHandler(this.LocalParentDirectory_Click);
            // 
            // LocalNewFile
            // 
            this.LocalNewFile.Location = new System.Drawing.Point(236, 376);
            this.LocalNewFile.Name = "LocalNewFile";
            this.LocalNewFile.Size = new System.Drawing.Size(75, 23);
            this.LocalNewFile.TabIndex = 34;
            this.LocalNewFile.Text = "New File";
            this.LocalNewFile.UseVisualStyleBackColor = true;
            this.LocalNewFile.Click += new System.EventHandler(this.LocalNewFile_Click);
            // 
            // LocalRenameFile
            // 
            this.LocalRenameFile.Location = new System.Drawing.Point(317, 376);
            this.LocalRenameFile.Name = "LocalRenameFile";
            this.LocalRenameFile.Size = new System.Drawing.Size(75, 23);
            this.LocalRenameFile.TabIndex = 35;
            this.LocalRenameFile.Text = "Rename File";
            this.LocalRenameFile.UseVisualStyleBackColor = true;
            // 
            // CreateLocalDir
            // 
            this.CreateLocalDir.Location = new System.Drawing.Point(398, 376);
            this.CreateLocalDir.Name = "CreateLocalDir";
            this.CreateLocalDir.Size = new System.Drawing.Size(106, 23);
            this.CreateLocalDir.TabIndex = 36;
            this.CreateLocalDir.Text = "Create Local Dir";
            this.CreateLocalDir.UseVisualStyleBackColor = true;
            this.CreateLocalDir.Click += new System.EventHandler(this.CreateLocalDir_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(464, 207);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(186, 23);
            this.progressBar1.TabIndex = 37;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(646, 211);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(21, 13);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "0%";
            this.lblStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 406);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.CreateLocalDir);
            this.Controls.Add(this.LocalRenameFile);
            this.Controls.Add(this.LocalNewFile);
            this.Controls.Add(this.LocalParentDirectory);
            this.Controls.Add(this.RemoteNewFile);
            this.Controls.Add(this.Local);
            this.Controls.Add(this.Diff);
            this.Controls.Add(this.LocalTree);
            this.Controls.Add(this.RemoteTree);
            this.Controls.Add(this.Remote);
            this.Controls.Add(this.LocalDirectory);
            this.Controls.Add(this.RemoteRenameFile);
            this.Controls.Add(this.RemoteDeleteFile);
            this.Controls.Add(this.CreateRemoteDir);
            this.Controls.Add(this.PutFile);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.RemoteParentButton);
            this.Controls.Add(this.RemoteDirectory);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "The best FTP client ever made";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RemoteDirectory;
        private System.Windows.Forms.Button RemoteParentButton;
        private System.Windows.Forms.Button PutFile;
        private System.Windows.Forms.Button CreateRemoteDir;
        private System.Windows.Forms.Button RemoteDeleteFile;
        private System.Windows.Forms.Button RemoteRenameFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox LocalDirectory;
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontWindow;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
        private System.Windows.Forms.Label Remote;
        private System.Windows.Forms.ListBox RemoteTree;
        private System.Windows.Forms.ListBox LocalTree;
        private System.Windows.Forms.Button Diff;
        private System.Windows.Forms.Label Local;
        private System.Windows.Forms.Button RemoteNewFile;
        private System.Windows.Forms.Button LocalParentDirectory;
        private System.Windows.Forms.Button LocalNewFile;
        private System.Windows.Forms.Button LocalRenameFile;
        private System.Windows.Forms.Button CreateLocalDir;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
    }
}

