using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace de4dotShell
{
    //Initalize Class
    public class de4dotHandle
    {
        public string de4dotExecPath = Application.StartupPath + "\\de4dot.exe";
        public bool de4dotExist = false;
        public const string de4dotNotFoundStr = "De4dot Engine could not be found!";
        public static string de4dotVer = "";
        //public static ArrayList fpath = new ArrayList();
        public string deobOption = "";
        public string fileOption = "";
        Thread DeobThread;
        public string target = "";
        //Some constant for Contextual Function
        public const int CONTEXT_EXIST = 1;
        public const int CONTEXT_REMOVED = 0;
        public const int ERROR_OCCURED = -1;
        //Get the file to be deobfuscated, and check De4dot is Exist
        public de4dotHandle(string filepath)
        {
            if (File.Exists(de4dotExecPath))
            {
                de4dotExist = true;
                target = filepath;
            }
        }

        // Call de4dot.exe to perform deobfuscation, and then return output
        public string de4dotProcess(string args)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.FileName = de4dotExecPath;
                p.StartInfo.Arguments = args;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string result = p.StandardOutput.ReadToEnd();
                p.StandardInput.Write("\x3");
                if (p.HasExited)
                {
                    return result + "\nExecution Time: " + p.TotalProcessorTime.ToString() + " s"; ;
                }
                else
                {
                    throw new Exception("de4dot could not be exited...");
                }
            }
            catch (System.Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        //Unused code, just comment it out
/*        public string Detect(string file)
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
*/      //Create Deobfuscating thread and pass param to it
        public void DeObfuscate(RichTextBox rtxtBox, string param1, string param2)
        {
            ThreadStart StartDObfuscate = delegate{DeobAndShow(rtxtBox);};
            deobOption = param1;
            fileOption = param2;
            rtxtBox.Text = "Executing command with deob Option: " + deobOption + " file Option: " + fileOption;
            DeobThread = new Thread(StartDObfuscate);
            DeobThread.Start();
        }

        //Main job of the Thread, Call de4dot to Deobfuscate and print output to Rich TextBox
        private void DeobAndShow(RichTextBox txt)
        {
               string result = "";
               result += de4dotProcess(" " + deobOption + " " + target + " " + fileOption);
               SetControlPropertyThreadSafe(txt, "Text", result);
        }


        //I don't remember how i wrote these ugly code. Just wanna parse output from a thread to rich Textbox in the main from
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
       
        //Get de4dot Version
        public string Verbose()
        {
            try {
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
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
 
        //Check whether de4dotShell is in Context Menu, or add/remove it as user want
        //Requires Administrator Privilege to Add value to Registry.
        public int Contextual(bool status, bool? opt = null)
        {
            bool isAdminRole;
            WindowsIdentity indentify = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(indentify);
            isAdminRole = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if(isAdminRole)
            {
                string appname = Process.GetCurrentProcess().MainModule.FileName;
                var dllkey = Registry.ClassesRoot.OpenSubKey("dllfile\\shell\\de4dotShell\\command");
                var exekey = Registry.ClassesRoot.OpenSubKey("exefile\\shell\\de4dotShell\\command");
                if (status == true)
                {
                    if (dllkey == null && exekey == null)
                    {
                        return CONTEXT_REMOVED;
                    }
                    else if (dllkey != null && exekey != null)
                    {
                        return CONTEXT_EXIST;
                    }
                    else
                    {
                        return ERROR_OCCURED;
                    }
                }
                else
                {
                    if (opt == false)
                    {
                        try
                        {
                            Registry.ClassesRoot.DeleteSubKeyTree("dllfile\\shell\\de4dotShell");
                            Registry.ClassesRoot.DeleteSubKeyTree("exefile\\shell\\de4dotShell");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(ERROR_OCCURED);
                        }
                    }
                    else if (opt == true)
                    {
                        try
                        {
                            var rdllkey = Registry.ClassesRoot.CreateSubKey("dllfile\\shell\\de4dotShell\\command");
                            var rexekey = Registry.ClassesRoot.CreateSubKey("exefile\\shell\\de4dotShell\\command");
                            rdllkey.SetValue("", appname + " %1", RegistryValueKind.String);
                            rexekey.SetValue("", appname + " %1", RegistryValueKind.String);
                            rdllkey.Close();
                            rexekey.Close();
                            return CONTEXT_EXIST;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Environment.Exit(ERROR_OCCURED);
                        }
                    }
                }
                return ERROR_OCCURED;
            }
            else
            {
                MessageBox.Show("To Register Context Menu, you must run me with Administrator Privilege!", "Hey...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ERROR_OCCURED;
            }
        }
    }
}
