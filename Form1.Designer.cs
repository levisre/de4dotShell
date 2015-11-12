namespace de4dotShell
{
    partial class deobform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(deobform));
            this.deobbtn = new System.Windows.Forms.Button();
            this.outputbox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.argsBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.args2Box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // deobbtn
            // 
            this.deobbtn.Location = new System.Drawing.Point(3, 90);
            this.deobbtn.Name = "deobbtn";
            this.deobbtn.Size = new System.Drawing.Size(470, 32);
            this.deobbtn.TabIndex = 0;
            this.deobbtn.Text = "&Deobfuscate";
            this.deobbtn.UseVisualStyleBackColor = true;
            this.deobbtn.Click += new System.EventHandler(this.deobbtn_Click);
            // 
            // outputbox
            // 
            this.outputbox.BackColor = System.Drawing.Color.Black;
            this.outputbox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputbox.ForeColor = System.Drawing.Color.White;
            this.outputbox.Location = new System.Drawing.Point(3, 128);
            this.outputbox.Name = "outputbox";
            this.outputbox.ReadOnly = true;
            this.outputbox.Size = new System.Drawing.Size(470, 185);
            this.outputbox.TabIndex = 1;
            this.outputbox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Deobfuscation Option;";
            // 
            // argsBox
            // 
            this.argsBox.Location = new System.Drawing.Point(3, 25);
            this.argsBox.Name = "argsBox";
            this.argsBox.Size = new System.Drawing.Size(470, 20);
            this.argsBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Option:";
            // 
            // args2Box
            // 
            this.args2Box.Location = new System.Drawing.Point(3, 64);
            this.args2Box.Name = "args2Box";
            this.args2Box.Size = new System.Drawing.Size(470, 20);
            this.args2Box.TabIndex = 5;
            // 
            // deobform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 321);
            this.Controls.Add(this.args2Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.argsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputbox);
            this.Controls.Add(this.deobbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "deobform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "de4dotShell";
            this.Load += new System.EventHandler(this.deobform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deobbtn;
        private System.Windows.Forms.RichTextBox outputbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox argsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox args2Box;
    }
}

