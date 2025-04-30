using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WindowsFormsApp
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var loginForm = new Login();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                var mainForm = new MainForm();
                mainForm.CurrentPlayerName = loginForm.PlayerName; // Передаём имя в MainForm
                Application.Run(mainForm);
            }

        }
    }
}
