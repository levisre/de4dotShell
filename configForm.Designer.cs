namespace de4dotShell
{
    partial class configForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configForm));
            this.regShell = new System.Windows.Forms.CheckBox();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // regShell
            // 
            this.regShell.AutoSize = true;
            this.regShell.Location = new System.Drawing.Point(12, 41);
            this.regShell.Name = "regShell";
            this.regShell.Size = new System.Drawing.Size(140, 17);
            this.regShell.TabIndex = 0;
            this.regShell.Text = "Register Shell Extension";
            this.regShell.UseVisualStyleBackColor = true;
            this.regShell.CheckedChanged += new System.EventHandler(this.regShell_CheckedChanged);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(12, 64);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(302, 23);
            this.aboutBtn.TabIndex = 1;
            this.aboutBtn.Text = "&About";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 9);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.Text = "Status:";
            // 
            // configForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 99);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.regShell);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "configForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configure de4dotShell";
            this.Load += new System.EventHandler(this.configForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox regShell;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Label statusLabel;
    }
}