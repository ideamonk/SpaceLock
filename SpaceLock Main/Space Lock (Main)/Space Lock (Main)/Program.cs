using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Space_Lock__Main_
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Home h = new Home();
            Application.Run(h);
        }
    }
}
