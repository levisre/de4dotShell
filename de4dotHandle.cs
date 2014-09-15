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
using System.Reflection;

namespace de4dotEngine
{
    public class de4dotHandle
    {
        public string de4dotExecPath = Application.StartupPath + "\\de4dot.exe";
        public bool de4dotExist = false;
        public string de4dotNotFoundStr = "De4dot Engine could not be found!";
        public static string de4dotVer = "";
        public static ArrayList fpath = new ArrayList();
        public string deobOption = "";
        public string fileOption = "";
        Thread DeobThread;
        public string target = "";
        public de4dotHandle(string filepath)
        {
            if (File.Exists(de4dotExecPath))
            {
                de4dotExist = true;
  
                target = filepath;
            }
        }

        public string de4dotProcess(string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = de4dotExecPath;
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                return p.StandardOutput.ReadToEnd() + "\nExecution Time: " + p.TotalProcessorTime.ToString() + " s";
            }
            catch (System.Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        public string Detect(string file)
        {
            if (!de4dotExist)
            {
                return de4dotNotFoundStr;
            }
            else
            {
                string output;
                string cfile = "\"" + file + "\"";
                int sign;
                output = de4dotProcess(" -d " + cfile);
                if (Path.GetExtension(file) == ".exe" || Path.GetExtension(file) == ".dll" || Path.GetExtension(file) == "null")
                {
                    if (output.IndexOf("a .NET PE file") > 0)
                    {
                        return "-1";
                    }
                    else
                    {
                        fpath.Add(cfile);
                        output = output.Remove(0, 146);
                        sign = output.IndexOf("(", 0);
                        output = output.Substring(0, sign);
                        output = output.Trim();
                        return output;
                    }
                }
                else
                {
                    return "-2";
                }
            }
        }

        public void DeObfuscate(RichTextBox rtxtBox, string param1, string param2)
        {
            ThreadStart StartDObfuscate = delegate{RunDObfuscate(rtxtBox);};
            deobOption = param1;
            fileOption = param2;
            rtxtBox.Text = "Executing command with deob Option: " + deobOption + " file Option: " + fileOption;
            DeobThread = new Thread(StartDObfuscate);
            DeobThread.Start();
        }

        private void RunDObfuscate(RichTextBox txt)
        {
               string result = "";
               result += de4dotProcess(" " + deobOption + " " + target + " " + fileOption);
               SetControlPropertyThreadSafe(txt, "Text", result);
        }
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
       
        public string Verbose()
        {
            if (!de4dotExist)
            {
                return de4dotNotFoundStr;
            }
            else
            {
                int sign;
                de4dotVer = de4dotProcess(" -v");
                sign = de4dotVer.IndexOf("Copyright", 0);
                de4dotVer = de4dotVer.Substring(0, sign);
                return de4dotVer.Trim();
            }
        }
        public int Contextual(bool status, bool? opt = null)
        {
            string appname = Process.GetCurrentProcess().MainModule.FileName;

            var dllkey = Registry.ClassesRoot.OpenSubKey("dllfile\\shell\\de4dotShell\\command");
            var exekey = Registry.ClassesRoot.OpenSubKey("exefile\\shell\\de4dotShell\\command");

            if (status == true)
            {
                if (dllkey == null && exekey == null)
                {
                    return 1;
                }
                else if (dllkey != null && exekey != null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (opt == false)
                {
                    Registry.ClassesRoot.DeleteSubKeyTree("dllfile\\shell\\de4dotShell");
                    Registry.ClassesRoot.DeleteSubKeyTree("exefile\\shell\\de4dotShell");
                }
                else if (opt == true)
                {
                    var rdllkey = Registry.ClassesRoot.CreateSubKey("dllfile\\shell\\de4dotShell\\command");
                    var rexekey = Registry.ClassesRoot.CreateSubKey("exefile\\shell\\de4dotShell\\command");
                    rdllkey.SetValue("", appname + " %1", RegistryValueKind.String);
                    rexekey.SetValue("", appname + " %1", RegistryValueKind.String);
                    rdllkey.Close();
                    rexekey.Close();
                }
            }
            return -2;
        }
    }
}
