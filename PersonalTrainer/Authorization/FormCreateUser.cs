using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.Authorization
{
    public partial class FormCreateUser : Form
    {
        /// <summary>
        /// Birthday example to show user date pattern
        /// </summary>
        private const string BirthdayExample = "2000-05-30";

        /// <summary>
        /// New user _login
        /// Used to create account
        /// </summary>
        private readonly string _login;

        /// <summary>
        /// New user _password
        /// Used to create account
        /// </summary>
        private readonly string _password;

        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// Create user screen constructor
        /// This form should only be called during sign in process
        /// </summary>
        /// <param name="login">new user _login</param>
        /// <param name="password">new user _password</param>
        public FormCreateUser(string login, string password)
        {
            InitializeComponent();

            // Save user _login and _password for later
            this._login = login;
            this._password = password;
           
            // Sets default nickname to _login
            textBoxNickname.Text = login;

            // Sets default birthdate to show the pattern to user
            textBoxBirthday.Text = BirthdayExample;

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
            // Activates parent form
            Owner.Visible = true;
            // Disposes this form and all it's resources
            this.Dispose(true);
        }

        /// <summary>
        /// Verifies if labels in this form have correct values
        /// If they're correct tries to create new account and new user in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            string nickname = textBoxNickname.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthday = textBoxBirthday.Text;

            if (!ClassValidateData.ValidateNickname(nickname))
                return;

            if (!ClassValidateData.ValidateFirstName(firstName))
                return;

            if (!ClassValidateData.ValidateLastName(lastName))
                return;

            if (!ClassValidateData.ValidateBirthday(birthday))
                return;
            // Try to add new user and account to database
            try
            {
                _repository.CreateUserAccount(_login, _password, nickname, firstName, lastName, birthday);

                // Save information about currently logged user
                Program.Logged = true;
                Program.Login = _login;

                this.Dispose(true);
            }
            catch (SqlException)
            {
                MessageBox.Show("Internal error. Try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
