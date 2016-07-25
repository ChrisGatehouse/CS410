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
            this.remoteDirText = new System.Windows.Forms.TextBox();
            this.DeleteFile = new System.Windows.Forms.Button();
            this.RenameFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.RenameFile2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.renameFileSelected = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.renameFileNewName = new System.Windows.Forms.TextBox();
            this.LocalDirectory = new System.Windows.Forms.ListBox();
            this.LocalParentButton = new System.Windows.Forms.Button();
            this.GetFile = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.underConstruction = new System.Windows.Forms.PictureBox();
            this.fontWindow = new System.Windows.Forms.FontDialog();
            this.changeColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.underConstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // RemoteDirectory
            // 
            this.RemoteDirectory.FormattingEnabled = true;
            this.RemoteDirectory.Location = new System.Drawing.Point(279, 70);
            this.RemoteDirectory.Name = "RemoteDirectory";
            this.RemoteDirectory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.RemoteDirectory.Size = new System.Drawing.Size(284, 134);
            this.RemoteDirectory.TabIndex = 5;
            this.RemoteDirectory.DoubleClick += new System.EventHandler(this.RemoteDirectory_DoubleClick);
            // 
            // RemoteParentButton
            // 
            this.RemoteParentButton.Location = new System.Drawing.Point(279, 41);
            this.RemoteParentButton.Name = "RemoteParentButton";
            this.RemoteParentButton.Size = new System.Drawing.Size(92, 23);
            this.RemoteParentButton.TabIndex = 6;
            this.RemoteParentButton.Text = "Parent Directory";
            this.RemoteParentButton.UseVisualStyleBackColor = true;
            this.RemoteParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // PutFile
            // 
            this.PutFile.Location = new System.Drawing.Point(189, 41);
            this.PutFile.Name = "PutFile";
            this.PutFile.Size = new System.Drawing.Size(75, 23);
            this.PutFile.TabIndex = 13;
            this.PutFile.Text = "Put File";
            this.PutFile.UseVisualStyleBackColor = true;
            this.PutFile.Click += new System.EventHandler(this.PutFile_Click);
            // 
            // CreateRemoteDir
            // 
            this.CreateRemoteDir.Location = new System.Drawing.Point(569, 41);
            this.CreateRemoteDir.Name = "CreateRemoteDir";
            this.CreateRemoteDir.Size = new System.Drawing.Size(106, 23);
            this.CreateRemoteDir.TabIndex = 15;
            this.CreateRemoteDir.Text = "Create Remote Dir";
            this.CreateRemoteDir.UseVisualStyleBackColor = true;
            this.CreateRemoteDir.Click += new System.EventHandler(this.CreateRemoteDir_Click);
            // 
            // remoteDirText
            // 
            this.remoteDirText.Location = new System.Drawing.Point(569, 88);
            this.remoteDirText.Name = "remoteDirText";
            this.remoteDirText.Size = new System.Drawing.Size(172, 20);
            this.remoteDirText.TabIndex = 16;
            // 
            // DeleteFile
            // 
            this.DeleteFile.Location = new System.Drawing.Point(377, 41);
            this.DeleteFile.Name = "DeleteFile";
            this.DeleteFile.Size = new System.Drawing.Size(75, 23);
            this.DeleteFile.TabIndex = 17;
            this.DeleteFile.Text = "Delete File";
            this.DeleteFile.UseVisualStyleBackColor = true;
            this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // RenameFile
            // 
            this.RenameFile.Location = new System.Drawing.Point(458, 41);
            this.RenameFile.Name = "RenameFile";
            this.RenameFile.Size = new System.Drawing.Size(75, 23);
            this.RenameFile.TabIndex = 18;
            this.RenameFile.Text = "Rename File";
            this.RenameFile.UseVisualStyleBackColor = true;
            this.RenameFile.Click += new System.EventHandler(this.RenameFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RenameFile2
            // 
            this.RenameFile2.Location = new System.Drawing.Point(569, 194);
            this.RenameFile2.Name = "RenameFile2";
            this.RenameFile2.Size = new System.Drawing.Size(106, 23);
            this.RenameFile2.TabIndex = 19;
            this.RenameFile2.Text = "Rename File 2";
            this.RenameFile2.UseVisualStyleBackColor = true;
            this.RenameFile2.Click += new System.EventHandler(this.RenameFile2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(575, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "File To Rename";
            // 
            // renameFileSelected
            // 
            this.renameFileSelected.Location = new System.Drawing.Point(569, 236);
            this.renameFileSelected.Name = "renameFileSelected";
            this.renameFileSelected.Size = new System.Drawing.Size(172, 20);
            this.renameFileSelected.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(575, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "New File Name";
            // 
            // renameFileNewName
            // 
            this.renameFileNewName.Location = new System.Drawing.Point(569, 281);
            this.renameFileNewName.Name = "renameFileNewName";
            this.renameFileNewName.Size = new System.Drawing.Size(172, 20);
            this.renameFileNewName.TabIndex = 23;
            // 
            // LocalDirectory
            // 
            this.LocalDirectory.FormattingEnabled = true;
            this.LocalDirectory.Location = new System.Drawing.Point(279, 247);
            this.LocalDirectory.Name = "LocalDirectory";
            this.LocalDirectory.Size = new System.Drawing.Size(284, 147);
            this.LocalDirectory.TabIndex = 24;
            this.LocalDirectory.DoubleClick += new System.EventHandler(this.LocalDirectory_DoubleClick);
            // 
            // LocalParentButton
            // 
            this.LocalParentButton.Location = new System.Drawing.Point(279, 210);
            this.LocalParentButton.Name = "LocalParentButton";
            this.LocalParentButton.Size = new System.Drawing.Size(101, 23);
            this.LocalParentButton.TabIndex = 25;
            this.LocalParentButton.Text = "Parent Directory";
            this.LocalParentButton.UseVisualStyleBackColor = true;
            this.LocalParentButton.Click += new System.EventHandler(this.LocalParentButton_Click);
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(189, 70);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(75, 23);
            this.GetFile.TabIndex = 7;
            this.GetFile.Text = "Get File";
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
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // underConstruction
            // 
            this.underConstruction.Location = new System.Drawing.Point(12, 148);
            this.underConstruction.Name = "underConstruction";
            this.underConstruction.Size = new System.Drawing.Size(249, 246);
            this.underConstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.underConstruction.TabIndex = 27;
            this.underConstruction.TabStop = false;
            // 
            // changeColorToolStripMenuItem
            // 
            this.changeColorToolStripMenuItem.Name = "changeColorToolStripMenuItem";
            this.changeColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeColorToolStripMenuItem.Text = "Change Color";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 406);
            this.Controls.Add(this.underConstruction);
            this.Controls.Add(this.LocalParentButton);
            this.Controls.Add(this.LocalDirectory);
            this.Controls.Add(this.renameFileNewName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.renameFileSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RenameFile2);
            this.Controls.Add(this.RenameFile);
            this.Controls.Add(this.DeleteFile);
            this.Controls.Add(this.remoteDirText);
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
            ((System.ComponentModel.ISupportInitialize)(this.underConstruction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RemoteDirectory;
        private System.Windows.Forms.Button RemoteParentButton;
        private System.Windows.Forms.Button PutFile;
        private System.Windows.Forms.Button CreateRemoteDir;
        private System.Windows.Forms.TextBox remoteDirText;
        private System.Windows.Forms.Button DeleteFile;
        private System.Windows.Forms.Button RenameFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RenameFile2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox renameFileSelected;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox renameFileNewName;
        private System.Windows.Forms.ListBox LocalDirectory;
        private System.Windows.Forms.Button LocalParentButton;
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox underConstruction;
        private System.Windows.Forms.FontDialog fontWindow;
        private System.Windows.Forms.ToolStripMenuItem changeColorToolStripMenuItem;
    }
}

