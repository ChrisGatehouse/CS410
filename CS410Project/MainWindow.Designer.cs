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
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(57, 351);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(101, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Time to Bounce";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(70, 93);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(75, 23);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(57, 15);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(100, 20);
            this.UsernameTextbox.TabIndex = 2;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(58, 41);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextbox.TabIndex = 3;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // DestinationTextbox
            // 
            this.DestinationTextbox.Location = new System.Drawing.Point(57, 67);
            this.DestinationTextbox.Name = "DestinationTextbox";
            this.DestinationTextbox.Size = new System.Drawing.Size(100, 20);
            this.DestinationTextbox.TabIndex = 4;
            this.DestinationTextbox.Text = "Destination";
            this.DestinationTextbox.TextChanged += new System.EventHandler(this.Destination_TextChanged);
            // 
            // WorkingDirectory
            // 
            this.WorkingDirectory.FormattingEnabled = true;
            this.WorkingDirectory.Location = new System.Drawing.Point(279, 36);
            this.WorkingDirectory.Name = "WorkingDirectory";
            this.WorkingDirectory.Size = new System.Drawing.Size(284, 134);
            this.WorkingDirectory.TabIndex = 5;
            this.WorkingDirectory.DoubleClick += new System.EventHandler(this.WorkingDirectory_DoubleClick);
            // 
            // ParentButton
            // 
            this.ParentButton.Location = new System.Drawing.Point(279, 12);
            this.ParentButton.Name = "ParentButton";
            this.ParentButton.Size = new System.Drawing.Size(92, 23);
            this.ParentButton.TabIndex = 6;
            this.ParentButton.Text = "Parent Directory";
            this.ParentButton.UseVisualStyleBackColor = true;
            this.ParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(70, 122);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(75, 23);
            this.GetFile.TabIndex = 7;
            this.GetFile.Text = "Get File";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.getFile_Click);
            // 
            // AutoFill
            // 
            this.AutoFill.Location = new System.Drawing.Point(70, 151);
            this.AutoFill.Name = "AutoFill";
            this.AutoFill.Size = new System.Drawing.Size(75, 23);
            this.AutoFill.TabIndex = 8;
            this.AutoFill.Text = "Autofill Form";
            this.AutoFill.UseVisualStyleBackColor = true;
            this.AutoFill.Click += new System.EventHandler(this.populateLoginFields);
            // 
            // SavedConnections
            // 
            this.SavedConnections.FormattingEnabled = true;
            this.SavedConnections.Location = new System.Drawing.Point(25, 180);
            this.SavedConnections.Name = "SavedConnections";
            this.SavedConnections.Size = new System.Drawing.Size(167, 95);
            this.SavedConnections.TabIndex = 9;
            this.SavedConnections.DoubleClick += new System.EventHandler(this.SavedConnections_DoubleClick);
            // 
            // SaveConnectionsButton
            // 
            this.SaveConnectionsButton.Location = new System.Drawing.Point(25, 281);
            this.SaveConnectionsButton.Name = "SaveConnectionsButton";
            this.SaveConnectionsButton.Size = new System.Drawing.Size(69, 23);
            this.SaveConnectionsButton.TabIndex = 10;
            this.SaveConnectionsButton.Text = "Save";
            this.SaveConnectionsButton.UseVisualStyleBackColor = true;
            this.SaveConnectionsButton.Click += new System.EventHandler(this.SaveConnectionsButton_Click);
            // 
            // NewConnectionTextbox
            // 
            this.NewConnectionTextbox.Location = new System.Drawing.Point(100, 284);
            this.NewConnectionTextbox.Name = "NewConnectionTextbox";
            this.NewConnectionTextbox.Size = new System.Drawing.Size(92, 20);
            this.NewConnectionTextbox.TabIndex = 11;
            this.NewConnectionTextbox.Text = "New Connection";
            this.NewConnectionTextbox.TextChanged += new System.EventHandler(this.NewConnectionTextbox_TextChanged);
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(25, 310);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(69, 23);
            this.Remove.TabIndex = 12;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // PutFile
            // 
            this.PutFile.Location = new System.Drawing.Point(151, 122);
            this.PutFile.Name = "PutFile";
            this.PutFile.Size = new System.Drawing.Size(75, 23);
            this.PutFile.TabIndex = 13;
            this.PutFile.Text = "Put File";
            this.PutFile.UseVisualStyleBackColor = true;
            this.PutFile.Click += new System.EventHandler(this.PutFile_Click);
            // 
            // CreateRemoteDir
            // 
            this.CreateRemoteDir.Location = new System.Drawing.Point(279, 209);
            this.CreateRemoteDir.Name = "CreateRemoteDir";
            this.CreateRemoteDir.Size = new System.Drawing.Size(106, 23);
            this.CreateRemoteDir.TabIndex = 15;
            this.CreateRemoteDir.Text = "Create Remote Dir";
            this.CreateRemoteDir.UseVisualStyleBackColor = true;
            this.CreateRemoteDir.Click += new System.EventHandler(this.CreateRemoteDir_Click);
            // 
            // remoteDirText
            // 
            this.remoteDirText.Location = new System.Drawing.Point(391, 211);
            this.remoteDirText.Name = "remoteDirText";
            this.remoteDirText.Size = new System.Drawing.Size(172, 20);
            this.remoteDirText.TabIndex = 16;
            // 
            // DeleteFile
            // 
            this.DeleteFile.Location = new System.Drawing.Point(377, 12);
            this.DeleteFile.Name = "DeleteFile";
            this.DeleteFile.Size = new System.Drawing.Size(75, 23);
            this.DeleteFile.TabIndex = 17;
            this.DeleteFile.Text = "Delete File";
            this.DeleteFile.UseVisualStyleBackColor = true;
            this.DeleteFile.Click += new System.EventHandler(this.DeleteFile_Click);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 386);
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
    }
}

