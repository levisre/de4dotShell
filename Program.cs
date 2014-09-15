using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace de4dotShell
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          if(args.Length>0)
            {
                Application.Run(new deobform(args[0]));
            }
            else
            {
              
                Application.Run(new configForm());
            }
        }
    }
}
