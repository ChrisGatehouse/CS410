namespace CS410Project
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.fontColorButton = new System.Windows.Forms.Button();
            this.buttonColorButton = new System.Windows.Forms.Button();
            this.backgroundColorButton = new System.Windows.Forms.Button();
            this.ToolbarColorButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.fontColorDiag = new System.Windows.Forms.ColorDialog();
            this.buttonColorDiag = new System.Windows.Forms.ColorDialog();
            this.backgroundColorDiag = new System.Windows.Forms.ColorDialog();
            this.toolbarColorDiag = new System.Windows.Forms.ColorDialog();
            this.textboxColorButton = new System.Windows.Forms.Button();
            this.textboxColorDiag = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // fontColorButton
            // 
            this.fontColorButton.Location = new System.Drawing.Point(12, 93);
            this.fontColorButton.Name = "fontColorButton";
            this.fontColorButton.Size = new System.Drawing.Size(109, 40);
            this.fontColorButton.TabIndex = 0;
            this.fontColorButton.Text = "Font Color";
            this.fontColorButton.UseVisualStyleBackColor = true;
            this.fontColorButton.Click += new System.EventHandler(this.fontColorButton_Click);
            // 
            // buttonColorButton
            // 
            this.buttonColorButton.Location = new System.Drawing.Point(12, 185);
            this.buttonColorButton.Name = "buttonColorButton";
            this.buttonColorButton.Size = new System.Drawing.Size(109, 40);
            this.buttonColorButton.TabIndex = 1;
            this.buttonColorButton.Text = "Button Color";
            this.buttonColorButton.UseVisualStyleBackColor = true;
            this.buttonColorButton.Click += new System.EventHandler(this.buttonColorButton_Click);
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.Location = new System.Drawing.Point(12, 231);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.Size = new System.Drawing.Size(109, 40);
            this.backgroundColorButton.TabIndex = 2;
            this.backgroundColorButton.Text = "Background Color";
            this.backgroundColorButton.UseVisualStyleBackColor = true;
            this.backgroundColorButton.Click += new System.EventHandler(this.backgroundColorButton_Click);
            // 
            // ToolbarColorButton
            // 
            this.ToolbarColorButton.Location = new System.Drawing.Point(12, 277);
            this.ToolbarColorButton.Name = "ToolbarColorButton";
            this.ToolbarColorButton.Size = new System.Drawing.Size(109, 40);
            this.ToolbarColorButton.TabIndex = 3;
            this.ToolbarColorButton.Text = "Toolbar Color";
            this.ToolbarColorButton.UseVisualStyleBackColor = true;
            this.ToolbarColorButton.Click += new System.EventHandler(this.ToolbarColorButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(132, 366);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // textboxColorButton
            // 
            this.textboxColorButton.Location = new System.Drawing.Point(12, 139);
            this.textboxColorButton.Name = "textboxColorButton";
            this.textboxColorButton.Size = new System.Drawing.Size(109, 40);
            this.textboxColorButton.TabIndex = 5;
            this.textboxColorButton.Text = "Textbox Color";
            this.textboxColorButton.UseVisualStyleBackColor = true;
            this.textboxColorButton.Click += new System.EventHandler(this.textboxColorButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 401);
            this.Controls.Add(this.textboxColorButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.ToolbarColorButton);
            this.Controls.Add(this.backgroundColorButton);
            this.Controls.Add(this.buttonColorButton);
            this.Controls.Add(this.fontColorButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fontColorButton;
        private System.Windows.Forms.Button buttonColorButton;
        private System.Windows.Forms.Button backgroundColorButton;
        private System.Windows.Forms.Button ToolbarColorButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.ColorDialog fontColorDiag;
        private System.Windows.Forms.ColorDialog buttonColorDiag;
        private System.Windows.Forms.ColorDialog backgroundColorDiag;
        private System.Windows.Forms.ColorDialog toolbarColorDiag;
        private System.Windows.Forms.Button textboxColorButton;
        private System.Windows.Forms.ColorDialog textboxColorDiag;
    }
}