﻿namespace CS410Project
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.UsernameTextbox = new System.Windows.Forms.TextBox();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.DestinationTextbox = new System.Windows.Forms.TextBox();
            this.WorkingDirectory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Time to Bounce";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Log in";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Login_Click);
            // 
            // UsernameTextbox
            // 
            this.UsernameTextbox.Location = new System.Drawing.Point(58, 36);
            this.UsernameTextbox.Name = "UsernameTextbox";
            this.UsernameTextbox.Size = new System.Drawing.Size(100, 20);
            this.UsernameTextbox.TabIndex = 2;
            this.UsernameTextbox.Text = "Username";
            this.UsernameTextbox.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(59, 62);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextbox.TabIndex = 3;
            this.PasswordTextbox.Text = "Password";
            this.PasswordTextbox.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // DestinationTextbox
            // 
            this.DestinationTextbox.Location = new System.Drawing.Point(58, 88);
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
            // 
            // Main_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 386);
            this.Controls.Add(this.WorkingDirectory);
            this.Controls.Add(this.DestinationTextbox);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.UsernameTextbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Main_Window";
            this.Text = "The best FTP client ever made";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox UsernameTextbox;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.TextBox DestinationTextbox;
        private System.Windows.Forms.ListBox WorkingDirectory;
    }
}
