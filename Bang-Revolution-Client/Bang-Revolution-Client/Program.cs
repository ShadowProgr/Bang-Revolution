﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bang_Revolution_Client
{
    public static class Program
    {
        public static bool loggedIn = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!loggedIn)
            {
                Application.Run(new frmLogin());
            }
            Console.WriteLine(loggedIn);
        }
    }
}
