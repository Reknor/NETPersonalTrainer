using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BartlomiejJagielloLab2ZadDom.Authorization
{
    /// <summary>
    /// Static class to validate user input
    /// </summary>
    public static class ClassValidateData
    {
        #region user profiel input constraints

        /// <summary>
        /// Minimum required length for new user nickname
        /// </summary>
        private const int NickNameMinLength = 1;
        /// <summary>
        /// Maximum allowed length for new user nickname
        /// </summary>
        private const int NickNameMaxLength = 50;

        /// <summary>
        /// Minimum required length for new user first name
        /// </summary>
        private const int FirstNameMinLength = 1;
        /// <summary>
        /// Maximum allowed length for new user first name
        /// </summary>
        private const int FirstNameMaxLength = 50;

        /// <summary>
        /// Minimum required length for new user last name
        /// </summary>
        private const int LastNameMinLength = 1;
        /// <summary>
        /// Maximum allowed length for new user last name
        /// </summary>
        private const int LastNameMaxLength = 50;

        /// <summary>
        /// Required for regex to check if birthday is in correct date format
        /// </summary>
        private const string BirthdayPattern = @"^\d{4}-\d{2}-\d{2}";

        #endregion

        #region sign in input constraints

        /// <summary>
        /// Minimum required length for new user login
        /// </summary>
        private const int LoginMinLength = 4;
        /// <summary>
        /// Maximum allowed length for new user login
        /// </summary>
        private const int LoginMaxLength = 50;

        /// <summary>
        /// Minimum required length for new user password
        /// </summary>
        private const int PasswordMinLength = 8;
        /// <summary>
        /// Maximum allowed length for new user password
        /// </summary>
        private const int PasswordMaxLength = 50;

        #endregion

        /// <summary>
        /// Check if given string is correct login
        /// Show message box if show is true and login is not correct and return false
        /// </summary>
        /// <param name="login">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if login is correct, else false</returns>
        public static bool ValidateLogin(string login, bool show = true)
        {
            // Check login minimum length
            if (login.Length < LoginMinLength)
            {
                if (show)
                    MessageBox.Show("Your login must be at least " + LoginMinLength + " characters long.",
                        "Incorrect login!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Check login maximum length
            if (login.Length > LoginMaxLength)
            {
                if (show)
                    MessageBox.Show("Your login cannot exceed " + LoginMaxLength + " characters.",
                        "Incorrect login!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if given string is correct password
        /// Show message box if show is true and password is not correct and return false
        /// </summary>
        /// <param name="password">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if password is correct, else false</returns>
        public static bool ValidatePassword(string password, bool show = true)
        {
            // Check password minimum length
            if (password.Length < PasswordMinLength)
            {
                if (show)
                    MessageBox.Show("Your password must be at least " + PasswordMinLength + " characters long.",
                        "Incorrect password!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Check password maximum length
            if (password.Length > PasswordMaxLength)
            {
                if (show)
                    MessageBox.Show("Your password cannot exceed " + PasswordMaxLength + " characters.",
                        "Incorrect password!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is correct nickname
        /// Show message box if show is true and nickname is not correct and return false
        /// </summary>
        /// <param name="nickname">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if nickname is correct, else false</returns>
        public static bool ValidateNickname(string nickname, bool show = true)
        {
            // Check nickname minimum length
            if (nickname.Length < NickNameMinLength)
            {
                if (show)
                    MessageBox.Show("Your nickname  must be at least " + NickNameMinLength + " characters long.",
                        "Incorrect nickname!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Check nickname maximum length
            if (nickname.Length > NickNameMaxLength)
            {
                if (show)
                    MessageBox.Show("Your nickname cannot exceed " + NickNameMaxLength + " characters.",
                        "Incorrect nickname!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if given string is correct first name
        /// Show message box in case of error and return false
        /// </summary>
        /// <param name="firstName">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if first name is correct, else false</returns>
        public static bool ValidateFirstName(string firstName, bool show = true)
        {
            // Check first name minimum length
            if (firstName.Length < FirstNameMinLength)
            {
                if (show)
                    MessageBox.Show("Your first name  must be at least " + FirstNameMinLength + " characters long.",
                        "Incorrect first name!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Check first name maximum length
            if (firstName.Length > FirstNameMaxLength)
            {
                if (show)
                    MessageBox.Show("Your first name cannot exceed " + FirstNameMaxLength + " characters.",
                        "Incorrect first name!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if given string is correct last name
        /// Show message box in case of error and return false
        /// </summary>
        /// <param name="lastName">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if last name is correct, else false</returns>
        public static bool ValidateLastName(string lastName, bool show = true)
        {
            // Check last name minimum length
            if (lastName.Length < LastNameMinLength)
            {
                if (show)
                    MessageBox.Show("Your last name  must be at least " + LastNameMinLength + " characters long.",
                        "Incorrect last name!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            // Check last name maximum length
            if (lastName.Length > FirstNameMaxLength)
            {
                if (show)
                    MessageBox.Show("Your last name cannot exceed " + LastNameMaxLength + " characters.",
                        "Incorrect last name!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if given string is correct birthday date
        /// Show message box in case of error and return false
        /// </summary>
        /// <param name="birthday">string to check</param>
        /// <param name="show">flag if method should pop messageBox</param>
        /// <returns>true if birthday is correct, else false</returns>
        public static bool ValidateBirthday(string birthday, bool show = true)
        {
            // Check birthday pattern
            if (!Regex.IsMatch(birthday, BirthdayPattern))
            {
                if(show)
                    MessageBox.Show("Your birthday must be in format YYYY-MM-DD",
                        "Incorrect birthday!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }
    }
}
