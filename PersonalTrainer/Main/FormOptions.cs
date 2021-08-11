using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Authorization;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.Main
{
    public partial class FormOptions : Form
    {
        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// Options constructor
        /// </summary>
        public FormOptions()
        {
            InitializeComponent();

            // Setting window to show in the center of previous screen
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Update current user data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOptions_Load(object sender, EventArgs e)
        {
            SetDataInTextBoxes();
        }

        /// <summary>
        /// Get data from database and insert into textBoxes
        /// </summary>
        private void SetDataInTextBoxes()
        {
            // Get information about current user
            DataTable userData = _repository.GetUser(Program.Login);

            string firstName = userData.Rows[0].Field<string>("FirstName");
            string lastName = userData.Rows[0].Field<string>("LastName");
            string nickname = userData.Rows[0].Field<string>("Nickname");
            DateTime birthday = userData.Rows[0].Field<DateTime>("DateOfBirth");

            // Update text box
            textBoxNickname.Text = nickname;
            textBoxFirstName.Text = firstName;
            textBoxLastName.Text = lastName;
            textBoxBirthday.Text = birthday.ToString("yyyy/MM/dd").Replace(".", "-");
        }

        /// <summary>
        /// Save changes to database if they're correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string nickname = textBoxNickname.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string birthday = textBoxBirthday.Text;

            // Check user nickname
            if (!ClassValidateData.ValidateNickname(nickname))
                return;

            // Check user first name
            if (!ClassValidateData.ValidateFirstName(firstName))
                return;

            // Check user last name
            if (!ClassValidateData.ValidateLastName(lastName))
                return;

            // Check user birthday
            if (!ClassValidateData.ValidateBirthday(birthday))
                return;

            // Try to update user data
            try
            {
                _repository.UpdateUser(Program.Login, nickname, firstName, lastName, birthday);
                this.Dispose(true);
            }
            catch (SqlException)
            {
                MessageBox.Show("Internal error. Try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Disposes this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }
    }
}
