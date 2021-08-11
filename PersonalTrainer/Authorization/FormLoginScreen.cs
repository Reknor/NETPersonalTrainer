using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.PreLogin
{
    public partial class FormLoginScreen : Form
    {
        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// Login screen constructor
        /// </summary>
        public FormLoginScreen()
        {
            InitializeComponent();

            // Setting window to show in the screen center
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Disposes this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            // Disposes this form and all it's resources
            this.Dispose(true);
        }

        /// <summary>
        /// Takes user login and password from textboxes and calls repository to authenticate
        /// if login and passwords are correct, informs program and disposes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            bool logged;
            try
            {
                // Tries to log in using login and password
                logged = _repository.Login(login, password);
                if (logged)
                {
                    // Save information about currently logged user
                    Program.Logged = logged;
                    Program.Login = login;

                    DialogResult = DialogResult.OK;
                    Dispose(true);
                }
                else
                {
                    MessageBox.Show("Incorrect login or password!", "Logging in failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (SqlException)
            {
                logged = false;
                MessageBox.Show("Internal error. Try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
