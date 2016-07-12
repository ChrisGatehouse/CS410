namespace CS410Project
{
    partial class Main_Window
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.DestinationTextbox = new System.Windows.Forms.TextBox();
            this.WorkingDirectory = new System.Windows.Forms.ListBox();
            this.ParentButton = new System.Windows.Forms.Button();
            this.GetFile = new System.Windows.Forms.Button();
            this.AutoFill = new System.Windows.Forms.Button();
            this.SavedConnections = new System.Windows.Forms.ListBox();
            this.SaveConnectionsButton = new System.Windows.Forms.Button();
            this.NewConnectionTextbox = new System.Windows.Forms.TextBox();
            this.Remove = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(86, 540);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(152, 35);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Time to Bounce";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(105, 143);
            this.LoginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(112, 35);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(86, 23);
            this.UsernameTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(148, 26);
            this.UsernameTextbox.TabIndex = 2;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(87, 63);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(148, 26);
            this.PasswordTextbox.TabIndex = 3;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // DestinationTextbox
            // 
            this.DestinationTextbox.Location = new System.Drawing.Point(86, 103);
            this.DestinationTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DestinationTextbox.Name = "DestinationTextbox";
            this.DestinationTextbox.Size = new System.Drawing.Size(148, 26);
            this.DestinationTextbox.TabIndex = 4;
            this.DestinationTextbox.Text = "Destination";
            this.DestinationTextbox.TextChanged += new System.EventHandler(this.Destination_TextChanged);
            // 
            // WorkingDirectory
            // 
            this.WorkingDirectory.FormattingEnabled = true;
            this.WorkingDirectory.ItemHeight = 20;
            this.WorkingDirectory.Location = new System.Drawing.Point(418, 55);
            this.WorkingDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorkingDirectory.Name = "WorkingDirectory";
            this.WorkingDirectory.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.WorkingDirectory.Size = new System.Drawing.Size(424, 204);
            this.WorkingDirectory.TabIndex = 5;
            this.WorkingDirectory.DoubleClick += new System.EventHandler(this.WorkingDirectory_DoubleClick);
            // 
            // ParentButton
            // 
            this.ParentButton.Location = new System.Drawing.Point(418, 18);
            this.ParentButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ParentButton.Name = "ParentButton";
            this.ParentButton.Size = new System.Drawing.Size(138, 35);
            this.ParentButton.TabIndex = 6;
            this.ParentButton.Text = "Parent Directory";
            this.ParentButton.UseVisualStyleBackColor = true;
            this.ParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(105, 188);
            this.GetFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(112, 35);
            this.GetFile.TabIndex = 7;
            this.GetFile.Text = "Get File";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.getFile_Click);
            // 
            // AutoFill
            // 
            this.AutoFill.Location = new System.Drawing.Point(105, 232);
            this.AutoFill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AutoFill.Name = "AutoFill";
            this.AutoFill.Size = new System.Drawing.Size(112, 35);
            this.AutoFill.TabIndex = 8;
            this.AutoFill.Text = "Autofill Form";
            this.AutoFill.UseVisualStyleBackColor = true;
            this.AutoFill.Click += new System.EventHandler(this.populateLoginFields);
            // 
            // SavedConnections
            // 
            this.SavedConnections.FormattingEnabled = true;
            this.SavedConnections.ItemHeight = 20;
            this.SavedConnections.Location = new System.Drawing.Point(38, 277);
            this.SavedConnections.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SavedConnections.Name = "SavedConnections";
            this.SavedConnections.Size = new System.Drawing.Size(248, 144);
            this.SavedConnections.TabIndex = 9;
            this.SavedConnections.DoubleClick += new System.EventHandler(this.SavedConnections_DoubleClick);
            // 
            // SaveConnectionsButton
            // 
            this.SaveConnectionsButton.Location = new System.Drawing.Point(38, 432);
            this.SaveConnectionsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveConnectionsButton.Name = "SaveConnectionsButton";
            this.SaveConnectionsButton.Size = new System.Drawing.Size(104, 35);
            this.SaveConnectionsButton.TabIndex = 10;
            this.SaveConnectionsButton.Text = "Save";
            this.SaveConnectionsButton.UseVisualStyleBackColor = true;
            this.SaveConnectionsButton.Click += new System.EventHandler(this.SaveConnectionsButton_Click);
            // 
            // NewConnectionTextbox
            // 
            this.NewConnectionTextbox.Location = new System.Drawing.Point(150, 437);
            this.NewConnectionTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewConnectionTextbox.Name = "NewConnectionTextbox";
            this.NewConnectionTextbox.Size = new System.Drawing.Size(136, 26);
            this.NewConnectionTextbox.TabIndex = 11;
            this.NewConnectionTextbox.Text = "New Connection";
            this.NewConnectionTextbox.TextChanged += new System.EventHandler(this.NewConnectionTextbox_TextChanged);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(38, 477);
            this.Remove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(104, 35);
            this.Remove.TabIndex = 12;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // PutFile
            // 
            this.PutFile.Location = new System.Drawing.Point(226, 188);
            this.PutFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PutFile.Name = "PutFile";
            this.PutFile.Size = new System.Drawing.Size(112, 35);
            this.PutFile.TabIndex = 13;
            this.PutFile.Text = "Put File";
            this.PutFile.UseVisualStyleBackColor = true;
            this.PutFile.Click += new System.EventHandler(this.PutFile_Click);
            // 
            // CreateRemoteDir
            // 
            this.CreateRemoteDir.Location = new System.Drawing.Point(418, 277);
            this.CreateRemoteDir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateRemoteDir.Name = "CreateRemoteDir";
            this.CreateRemoteDir.Size = new System.Drawing.Size(159, 35);
            this.CreateRemoteDir.TabIndex = 15;
            this.CreateRemoteDir.Text = "Create Remote Dir";
            this.CreateRemoteDir.UseVisualStyleBackColor = true;
            this.CreateRemoteDir.Click += new System.EventHandler(this.CreateRemoteDir_Click);
            // 
            // remoteDirText
            // 
            this.remoteDirText.Location = new System.Drawing.Point(586, 282);
            this.remoteDirText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.remoteDirText.Name = "remoteDirText";
            this.remoteDirText.Size = new System.Drawing.Size(256, 26);
            this.remoteDirText.TabIndex = 16;
            // 
            // DeleteFile
            // 
            this.DeleteFile.Location = new System.Drawing.Point(566, 18);
            this.DeleteFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DeleteFile.Name = "DeleteFile";
            this.DeleteFile.Size = new System.Drawing.Size(112, 35);
            this.DeleteFile.TabIndex = 17;
            this.DeleteFile.Text = "Delete File";
            this.DeleteFile.UseVisualStyleBackColor = true;
            this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // RenameFile
            // 
            this.RenameFile.Location = new System.Drawing.Point(687, 18);
            this.RenameFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RenameFile.Name = "RenameFile";
            this.RenameFile.Size = new System.Drawing.Size(112, 35);
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
            this.RenameFile2.Location = new System.Drawing.Point(418, 363);
            this.RenameFile2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RenameFile2.Name = "RenameFile2";
            this.RenameFile2.Size = new System.Drawing.Size(159, 35);
            this.RenameFile2.TabIndex = 19;
            this.RenameFile2.Text = "Rename File 2";
            this.RenameFile2.UseVisualStyleBackColor = true;
            this.RenameFile2.Click += new System.EventHandler(this.RenameFile2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(582, 343);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "File To Rename";
            // 
            // renameFileSelected
            // 
            this.renameFileSelected.Location = new System.Drawing.Point(586, 363);
            this.renameFileSelected.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renameFileSelected.Name = "renameFileSelected";
            this.renameFileSelected.Size = new System.Drawing.Size(256, 26);
            this.renameFileSelected.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(582, 403);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "New File Name";
            // 
            // renameFileNewName
            // 
            this.renameFileNewName.Location = new System.Drawing.Point(586, 428);
            this.renameFileNewName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.renameFileNewName.Name = "renameFileNewName";
            this.renameFileNewName.Size = new System.Drawing.Size(256, 26);
            this.renameFileNewName.TabIndex = 23;
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 594);
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
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.NewConnectionTextbox);
            this.Controls.Add(this.SaveConnectionsButton);
            this.Controls.Add(this.SavedConnections);
            this.Controls.Add(this.AutoFill);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.ParentButton);
            this.Controls.Add(this.WorkingDirectory);
            this.Controls.Add(this.DestinationTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.ExitButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main_Window";
            this.Text = "The best FTP client ever made";
            this.Load += new System.EventHandler(this.Main_Window_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox DestinationTextbox;
        private System.Windows.Forms.ListBox WorkingDirectory;
        private System.Windows.Forms.Button ParentButton;
        private System.Windows.Forms.Button GetFile;
        private System.Windows.Forms.Button AutoFill;
        private System.Windows.Forms.ListBox SavedConnections;
        private System.Windows.Forms.Button SaveConnectionsButton;
        private System.Windows.Forms.TextBox NewConnectionTextbox;
        private System.Windows.Forms.Button Remove;
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
    }
}

