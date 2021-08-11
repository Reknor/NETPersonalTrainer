using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Main;


namespace BartlomiejJagielloLab2ZadDom
{
    static class Program
    {
        /// <summary>
        /// Stores true if user is correctly logged
        /// </summary>
        public static bool Logged;

        /// <summary>
        /// Stores application name displayed in all forms
        /// </summary>
        public const string AppName = "Personal Trainer";

        /// <summary>
        /// Login of currently logged user
        /// </summary>
        public static string Login = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Run start screen
            FormStartScreen formStartScreen = new FormStartScreen
            {
                Text = AppName
            };
            Application.Run(formStartScreen);
           
            if (!Logged)
            {
                return;
            }
            // If user is logged run main menu
            FormMainMenu formMainMenu = new FormMainMenu
            {
                Text = AppName
            };
            Application.Run(formMainMenu);
        }
    }
}
