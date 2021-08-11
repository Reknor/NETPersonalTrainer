using System;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.PreLogin;

namespace BartlomiejJagielloLab2ZadDom
{
    public partial class FormStartScreen : Form
    {
        /// <summary>
        /// Starting screen constructor
        /// </summary>
        public FormStartScreen()
        {
            InitializeComponent();

            // Setting window to show in the screen center
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Opens new windows where user can log in to his account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormLoginScreen loginScreen = new FormLoginScreen
            { 
                Text = this.Text
            };
            loginScreen.ShowDialog(this);

            // If user is logged quit this form
            if (Program.Logged)
            {
                this.Dispose(true);
            }
        }

        /// <summary>
        /// Opens new window where user can create an account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            FormSignInScreen signInScreen = new FormSignInScreen
            {
                Text = this.Text
            };
            signInScreen.ShowDialog(this);

            // If user is logged quit this form
            if (Program.Logged)
            {
                this.Dispose(true);
            }
        }

        /// <summary>
        /// Closes application immediately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
