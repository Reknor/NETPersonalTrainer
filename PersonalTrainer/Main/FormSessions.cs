using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.Main
{
    public partial class FormSessions : Form
    {
        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// Sessions constructor
        /// </summary>
        public FormSessions()
        {
            InitializeComponent();

            // Setting window to show in the screen center
            StartPosition = FormStartPosition.CenterParent;

            // Refresh sessions data
            RefreshDataGridViewSessions();
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

        /// <summary>
        /// Refreshes data in dataGridViewWorkouts
        /// </summary>
        private void RefreshDataGridViewSessions()
        {
            try
            {
                // Get data from database
                DataTable sessions = _repository.GetUserSessions(Program.Login);

                // Show data in grid
                dataGridViewSessions.DataSource = sessions;
            }
            catch (SqlException)
            {
                MessageBox.Show("Internal error. Try again later.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button used to delete selected in dataGridViewSession sessions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteSession_Click(object sender, EventArgs e)
        {
            // If none of the rows is selected or multiple rows are selected
            int rowsCount = dataGridViewSessions.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1)
                return;

            //Take first selected row
            DataGridViewRow row = dataGridViewSessions.SelectedRows[0];

            // Get session id from selected row
            int id = (int)row.Cells[0].Value;
            _repository.DeleteSession(id);

            RefreshDataGridViewSessions();
        }
    }
}
