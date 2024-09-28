using App_BanLaptop.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_BanLaptop
{
    internal static class Program
    {
        public static Main mainForm = null;
        public static Login loginForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new Login();
            Application.Run(loginForm);
        }
    }
}
