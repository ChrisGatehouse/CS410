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
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(87, 540);
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
            this.LoginButton.Location = new System.Drawing.Point(105, 175);
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
            this.UsernameTextbox.Location = new System.Drawing.Point(87, 55);
            this.UsernameTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(148, 26);
            this.UsernameTextbox.TabIndex = 2;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(88, 95);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(148, 26);
            this.PasswordTextbox.TabIndex = 3;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // DestinationTextbox
            // 
            this.DestinationTextbox.Location = new System.Drawing.Point(87, 135);
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
            this.GetFile.Location = new System.Drawing.Point(105, 225);
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
            this.AutoFill.Location = new System.Drawing.Point(105, 269);
            this.AutoFill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AutoFill.Name = "AutoFill";
            this.AutoFill.Size = new System.Drawing.Size(112, 35);
            this.AutoFill.TabIndex = 8;
            this.AutoFill.Text = "Autofill Form";
            this.AutoFill.UseVisualStyleBackColor = true;
            this.AutoFill.Click += new System.EventHandler(this.populateLoginFields);
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 594);
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
    }
}

