using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Authorization;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.PreLogin
{
    public partial class FormSignInScreen : Form
    {
        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// SignIn screen constructor
        /// </summary>
        public FormSignInScreen()
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
        /// Verifies if login is correct
        /// If password is correct
        /// And if passwords are equal
        /// If all above are met, moves to create user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string repeatedPassword = textBoxRepeatPassword.Text;

            // Check user login
            if (!ClassValidateData.ValidateLogin(login))
                return;

            bool isLoginUnique = false;
            try
            {
                // Tries to check if user login is already taken
                isLoginUnique = !_repository.FindLogin(login);

            }
            catch (SqlException)
            {
                MessageBox.Show("Internal error. Try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (!isLoginUnique)
            {
                MessageBox.Show("This login is already taken!",
                    "Incorrect login!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check user password
            if (!ClassValidateData.ValidatePassword(password))
                return;

            // Check if passwords are equal
            if (!password.Equals(repeatedPassword))
            {
                MessageBox.Show("Your passwords are not equal!",
                    "Incorrect password!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Move to create user
            FormCreateUser formCreateUser = new FormCreateUser(login, password)
            {
                Text = this.Text,
            };
            this.Visible = false;
            formCreateUser.ShowDialog(this);
        }
    }
}
