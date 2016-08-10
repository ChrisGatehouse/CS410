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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.RemoteDirectory = new System.Windows.Forms.ListBox();
            this.RemoteParentButton = new System.Windows.Forms.Button();
            this.PutFileButton = new System.Windows.Forms.Button();
            this.CreateRemoteDirButton = new System.Windows.Forms.Button();
            this.RemoteDeleteFileButton = new System.Windows.Forms.Button();
            this.RemoteRenameFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.LocalDirectory = new System.Windows.Forms.ListBox();
            this.GetFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubReadmeOpensWebBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontWindow = new System.Windows.Forms.FontDialog();
            this.RemoteLabel = new System.Windows.Forms.Label();
            this.RemoteTree = new System.Windows.Forms.ListBox();
            this.LocalTree = new System.Windows.Forms.ListBox();
            this.DiffButton = new System.Windows.Forms.Button();
            this.LocalLabel = new System.Windows.Forms.Label();
            this.RemoteNewFileButton = new System.Windows.Forms.Button();
            this.LocalParentDirectoryButton = new System.Windows.Forms.Button();
            this.LocalNewFileButton = new System.Windows.Forms.Button();
            this.LocalRenameFileButton = new System.Windows.Forms.Button();
            this.CreateLocalDirButton = new System.Windows.Forms.Button();
            this.backWorkProgBar = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.LocalSearchBox = new System.Windows.Forms.TextBox();
            this.LocalSearchButton = new System.Windows.Forms.Button();
            this.backWorkGetProg = new System.ComponentModel.BackgroundWorker();
            this.RemoteSearchBox = new System.Windows.Forms.TextBox();
            this.RemoteSearchButton = new System.Windows.Forms.Button();
            this.hideLogInWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            // PutFileButton
            // 
            this.PutFileButton.Location = new System.Drawing.Point(302, 207);
            this.PutFileButton.Name = "PutFileButton";
            this.PutFileButton.Size = new System.Drawing.Size(75, 23);
            this.PutFileButton.TabIndex = 13;
            this.PutFileButton.Text = "Put File ↑";
            this.PutFileButton.UseVisualStyleBackColor = true;
            this.PutFileButton.Click += new System.EventHandler(this.PutFile_Click);
            // 
            // CreateRemoteDirButton
            // 
            this.CreateRemoteDirButton.Location = new System.Drawing.Point(398, 41);
            this.CreateRemoteDirButton.Name = "CreateRemoteDirButton";
            this.CreateRemoteDirButton.Size = new System.Drawing.Size(106, 23);
            this.CreateRemoteDirButton.TabIndex = 15;
            this.CreateRemoteDirButton.Text = "Create Remote Dir";
            this.CreateRemoteDirButton.UseVisualStyleBackColor = true;
            this.CreateRemoteDirButton.Click += new System.EventHandler(this.CreateRemoteDir_Click);
            // 
            // RemoteDeleteFileButton
            // 
            this.RemoteDeleteFileButton.Location = new System.Drawing.Point(383, 207);
            this.RemoteDeleteFileButton.Name = "RemoteDeleteFileButton";
            this.RemoteDeleteFileButton.Size = new System.Drawing.Size(75, 23);
            this.RemoteDeleteFileButton.TabIndex = 17;
            this.RemoteDeleteFileButton.TabStop = false;
            this.RemoteDeleteFileButton.Text = "Delete File X";
            this.RemoteDeleteFileButton.UseVisualStyleBackColor = true;
            this.RemoteDeleteFileButton.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // RemoteRenameFileButton
            // 
            this.RemoteRenameFileButton.Location = new System.Drawing.Point(317, 41);
            this.RemoteRenameFileButton.Name = "RemoteRenameFileButton";
            this.RemoteRenameFileButton.Size = new System.Drawing.Size(75, 23);
            this.RemoteRenameFileButton.TabIndex = 18;
            this.RemoteRenameFileButton.Text = "Rename File";
            this.RemoteRenameFileButton.UseVisualStyleBackColor = true;
            this.RemoteRenameFileButton.Click += new System.EventHandler(this.RenameFile_Click);
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.changeColorToolStripMenuItem,
            this.hideLogInWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            this.changeColorToolStripMenuItem.Click += new System.EventHandler(this.changeColorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.githubReadmeOpensWebBrowserToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // githubReadmeOpensWebBrowserToolStripMenuItem
            // 
            this.githubReadmeOpensWebBrowserToolStripMenuItem.Name = "githubReadmeOpensWebBrowserToolStripMenuItem";
            this.githubReadmeOpensWebBrowserToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.githubReadmeOpensWebBrowserToolStripMenuItem.Text = "Github Readme (Opens Web Browser)";
            this.githubReadmeOpensWebBrowserToolStripMenuItem.Click += new System.EventHandler(this.githubReadmeOpensWebBrowserToolStripMenuItem_Click);
            // 
            // RemoteLabel
            // 
            this.RemoteLabel.AutoSize = true;
            this.RemoteLabel.Location = new System.Drawing.Point(12, 41);
            this.RemoteLabel.Name = "RemoteLabel";
            this.RemoteLabel.Size = new System.Drawing.Size(44, 13);
            this.RemoteLabel.TabIndex = 27;
            this.RemoteLabel.Text = "Remote";
            // 
            // RemoteTree
            // 
            this.RemoteTree.FormattingEnabled = true;
            this.RemoteTree.Location = new System.Drawing.Point(0, 70);
            this.RemoteTree.Name = "RemoteTree";
            this.RemoteTree.Size = new System.Drawing.Size(132, 134);
            this.RemoteTree.TabIndex = 28;
            // 
            // LocalTree
            // 
            this.LocalTree.FormattingEnabled = true;
            this.LocalTree.Location = new System.Drawing.Point(0, 236);
            this.LocalTree.Name = "LocalTree";
            this.LocalTree.Size = new System.Drawing.Size(132, 134);
            this.LocalTree.TabIndex = 29;
            // 
            // DiffButton
            // 
            this.DiffButton.Location = new System.Drawing.Point(138, 207);
            this.DiffButton.Name = "DiffButton";
            this.DiffButton.Size = new System.Drawing.Size(75, 23);
            this.DiffButton.TabIndex = 30;
            this.DiffButton.Text = "Diff";
            this.DiffButton.UseVisualStyleBackColor = true;
            // 
            // LocalLabel
            // 
            this.LocalLabel.AutoSize = true;
            this.LocalLabel.Location = new System.Drawing.Point(12, 212);
            this.LocalLabel.Name = "LocalLabel";
            this.LocalLabel.Size = new System.Drawing.Size(33, 13);
            this.LocalLabel.TabIndex = 31;
            this.LocalLabel.Text = "Local";
            // 
            // RemoteNewFileButton
            // 
            this.RemoteNewFileButton.Location = new System.Drawing.Point(236, 41);
            this.RemoteNewFileButton.Name = "RemoteNewFileButton";
            this.RemoteNewFileButton.Size = new System.Drawing.Size(75, 23);
            this.RemoteNewFileButton.TabIndex = 32;
            this.RemoteNewFileButton.Text = "New File";
            this.RemoteNewFileButton.UseVisualStyleBackColor = true;
            this.RemoteNewFileButton.Click += new System.EventHandler(this.RemoteNewFile_Click);
            // 
            // LocalParentDirectoryButton
            // 
            this.LocalParentDirectoryButton.Location = new System.Drawing.Point(138, 376);
            this.LocalParentDirectoryButton.Name = "LocalParentDirectoryButton";
            this.LocalParentDirectoryButton.Size = new System.Drawing.Size(92, 23);
            this.LocalParentDirectoryButton.TabIndex = 33;
            this.LocalParentDirectoryButton.Text = "Parent Directory";
            this.LocalParentDirectoryButton.UseVisualStyleBackColor = true;
            this.LocalParentDirectoryButton.Click += new System.EventHandler(this.LocalParentDirectory_Click);
            // 
            // LocalNewFileButton
            // 
            this.LocalNewFileButton.Location = new System.Drawing.Point(236, 376);
            this.LocalNewFileButton.Name = "LocalNewFileButton";
            this.LocalNewFileButton.Size = new System.Drawing.Size(75, 23);
            this.LocalNewFileButton.TabIndex = 34;
            this.LocalNewFileButton.Text = "New File";
            this.LocalNewFileButton.UseVisualStyleBackColor = true;
            // 
            // LocalRenameFileButton
            // 
            this.LocalRenameFileButton.Location = new System.Drawing.Point(317, 376);
            this.LocalRenameFileButton.Name = "LocalRenameFileButton";
            this.LocalRenameFileButton.Size = new System.Drawing.Size(75, 23);
            this.LocalRenameFileButton.TabIndex = 35;
            this.LocalRenameFileButton.Text = "Rename File";
            this.LocalRenameFileButton.UseVisualStyleBackColor = true;
            this.LocalRenameFileButton.Click += new System.EventHandler(this.LocalRenameFileButton_Click);
            // 
            // CreateLocalDirButton
            // 
            this.CreateLocalDirButton.Location = new System.Drawing.Point(398, 376);
            this.CreateLocalDirButton.Name = "CreateLocalDirButton";
            this.CreateLocalDirButton.Size = new System.Drawing.Size(106, 23);
            this.CreateLocalDirButton.TabIndex = 36;
            this.CreateLocalDirButton.Text = "Create Local Dir";
            this.CreateLocalDirButton.UseVisualStyleBackColor = true;
            this.CreateLocalDirButton.Click += new System.EventHandler(this.CreateLocalDir_Click);
            // 
            // backWorkProgBar
            // 
            this.backWorkProgBar.WorkerReportsProgress = true;
            this.backWorkProgBar.WorkerSupportsCancellation = true;
            this.backWorkProgBar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backWorkProgBar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backWorkProgBar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(464, 207);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(186, 23);
            this.progressBar.TabIndex = 37;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(655, 211);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(21, 13);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "0%";
            // 
            // LocalSearchBox
            // 
            this.LocalSearchBox.Location = new System.Drawing.Point(510, 379);
            this.LocalSearchBox.Name = "LocalSearchBox";
            this.LocalSearchBox.Size = new System.Drawing.Size(172, 20);
            this.LocalSearchBox.TabIndex = 39;
            // 
            // LocalSearchButton
            // 
            this.LocalSearchButton.Location = new System.Drawing.Point(688, 379);
            this.LocalSearchButton.Name = "LocalSearchButton";
            this.LocalSearchButton.Size = new System.Drawing.Size(75, 23);
            this.LocalSearchButton.TabIndex = 40;
            this.LocalSearchButton.Text = "Search";
            this.LocalSearchButton.UseVisualStyleBackColor = true;
            this.LocalSearchButton.Click += new System.EventHandler(this.LocalSearchButton_Click);
            // 
            // backWorkGetProg
            // 
            this.backWorkGetProg.WorkerReportsProgress = true;
            this.backWorkGetProg.WorkerSupportsCancellation = true;
            this.backWorkGetProg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backWorkGetProg_DoWork);
            this.backWorkGetProg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backWorkGetProg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // RemoteSearchBox
            // 
            this.RemoteSearchBox.Location = new System.Drawing.Point(511, 43);
            this.RemoteSearchBox.Name = "RemoteSearchBox";
            this.RemoteSearchBox.Size = new System.Drawing.Size(171, 20);
            this.RemoteSearchBox.TabIndex = 41;
            // 
            // RemoteSearchButton
            // 
            this.RemoteSearchButton.Location = new System.Drawing.Point(688, 43);
            this.RemoteSearchButton.Name = "RemoteSearchButton";
            this.RemoteSearchButton.Size = new System.Drawing.Size(75, 23);
            this.RemoteSearchButton.TabIndex = 42;
            this.RemoteSearchButton.Text = "Search";
            this.RemoteSearchButton.UseVisualStyleBackColor = true;
            this.RemoteSearchButton.Click += new System.EventHandler(this.RemoteSearchButton_Click);
            // 
            // hideLogInWindowToolStripMenuItem
            // 
            this.hideLogInWindowToolStripMenuItem.Name = "hideLogInWindowToolStripMenuItem";
            this.hideLogInWindowToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.hideLogInWindowToolStripMenuItem.Text = "Hide/Show Log In Window";
            this.hideLogInWindowToolStripMenuItem.Click += new System.EventHandler(this.hideLogInWindowToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 406);
            this.Controls.Add(this.RemoteSearchButton);
            this.Controls.Add(this.RemoteSearchBox);
            this.Controls.Add(this.LocalSearchButton);
            this.Controls.Add(this.LocalSearchBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.CreateLocalDirButton);
            this.Controls.Add(this.LocalRenameFileButton);
            this.Controls.Add(this.LocalNewFileButton);
            this.Controls.Add(this.LocalParentDirectoryButton);
            this.Controls.Add(this.RemoteNewFileButton);
            this.Controls.Add(this.LocalLabel);
            this.Controls.Add(this.DiffButton);
            this.Controls.Add(this.LocalTree);
            this.Controls.Add(this.RemoteTree);
            this.Controls.Add(this.RemoteLabel);
            this.Controls.Add(this.LocalDirectory);
            this.Controls.Add(this.RemoteRenameFileButton);
            this.Controls.Add(this.RemoteDeleteFileButton);
            this.Controls.Add(this.CreateRemoteDirButton);
            this.Controls.Add(this.PutFileButton);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.RemoteParentButton);
            this.Controls.Add(this.RemoteDirectory);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "The best FTP client ever made";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Exit);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RemoteDirectory;
        private System.Windows.Forms.Button RemoteParentButton;
        private System.Windows.Forms.Button PutFileButton;
        private System.Windows.Forms.Button CreateRemoteDirButton;
        private System.Windows.Forms.Button RemoteDeleteFileButton;
        private System.Windows.Forms.Button RemoteRenameFileButton;
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
        private System.Windows.Forms.Label RemoteLabel;
        private System.Windows.Forms.ListBox RemoteTree;
        private System.Windows.Forms.ListBox LocalTree;
        private System.Windows.Forms.Button DiffButton;
        private System.Windows.Forms.Label LocalLabel;
        private System.Windows.Forms.Button RemoteNewFileButton;
        private System.Windows.Forms.Button LocalParentDirectoryButton;
        private System.Windows.Forms.Button LocalNewFileButton;
        private System.Windows.Forms.Button LocalRenameFileButton;
        private System.Windows.Forms.Button CreateLocalDirButton;
        private System.ComponentModel.BackgroundWorker backWorkProgBar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox LocalSearchBox;
        private System.Windows.Forms.Button LocalSearchButton;
        private System.ComponentModel.BackgroundWorker backWorkGetProg;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubReadmeOpensWebBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox RemoteSearchBox;
        private System.Windows.Forms.Button RemoteSearchButton;
        private System.Windows.Forms.ToolStripMenuItem hideLogInWindowToolStripMenuItem;
    }
}

