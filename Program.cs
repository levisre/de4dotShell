using System;
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
            //CHeck if file is passed via argument
          if(args.Length>0)
            {
                //Shoe deob form if file detected
                Application.Run(new deobform(args[0]));
            }
            else
            {
                //Show ConfigForm
                Application.Run(new configForm());
            }
        }
    }
}
