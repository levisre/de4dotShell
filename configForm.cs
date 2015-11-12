using System;
using System.Windows.Forms;

namespace de4dotShell
{
    public partial class configForm : Form
    {
        private string de4dotDetect = "";
        de4dotHandle de4dot;
        public configForm()
        {
            de4dot = new de4dotHandle("");
            de4dotDetect = de4dot.Verbose();
            InitializeComponent();
            int contextstatus = de4dot.Contextual(true);
            switch (contextstatus)
            {
                case de4dotHandle.CONTEXT_EXIST:
                    {
                        regShell.Checked = true;
                        break;
                    }
                case de4dotHandle.CONTEXT_REMOVED:
                    {
                        regShell.Checked = false;
                        break;
                    }
                case de4dotHandle.ERROR_OCCURED:
                    {
                        Environment.Exit(-1);
                        break;
                    }

            }
            if (de4dotDetect == de4dotHandle.de4dotNotFoundStr)
            {
                regShell.Enabled = false;
            }
        }

        private void configForm_Load(object sender, EventArgs e) //Detect De4dot is exist in current directory
        {
            statusLabel.Text += " " + de4dotDetect;
        }

        private void regShell_CheckedChanged(object sender, EventArgs e) //Add to Context Menu
        {
            if (regShell.CheckState == CheckState.Checked)
            {
                de4dot.Contextual(false, true);
            }
            else
            {
                de4dot.Contextual(false, false);
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e) //About button click
        {
            MessageBox.Show("de4dotShell v0.1b\n\n Created by Levis Nickaster\n\n Based on de4dotUI by Yashar Mahmoudnia\n Email: levintaeyeon[at]live[dot]com",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
