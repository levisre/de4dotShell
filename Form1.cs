using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using de4dotEngine;

namespace de4dotShell
{
    public partial class deobform : Form
    {
        public string filePath = "";
        de4dotHandle de4dot;
        public deobform(string fileName)
        {
            filePath = fileName;
            de4dot = new de4dotHandle(filePath);
            InitializeComponent();
            if (!de4dot.de4dotExist)
            {
                outputbox.Text +=de4dot.de4dotNotFoundStr;
                deobbtn.Enabled = false;
            }
            else
            {
                outputbox.Text = "Status: " +de4dot.Verbose();
            }

        }

        private void deobform_Load(object sender, EventArgs e)
        {
            outputbox.Text += "\nFile loaded: " + filePath;
        }

        private void deobbtn_Click(object sender, EventArgs e)
        {
            de4dot.DeObfuscate(outputbox,argsBox.Text,args2Box.Text);
        }
    }

}

