using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ownsmutex = false;
            using (Mutex mutex = new Mutex(true, "6K54EC1646B99718D82CEE5FA258", out ownsmutex))
            {
                if (ownsmutex)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new FrmMain());
                }
            }
        }
    }
}
