using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BartlomiejJagielloLab2ZadDom.Database;

namespace BartlomiejJagielloLab2ZadDom.Main
{
    public partial class FormViewWorkouts : Form
    {
        /// <summary>
        /// Used to access application data storage
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// View workouts constructor
        /// </summary>
        public FormViewWorkouts()
        {
            InitializeComponent();

            // Setting window to show in the screen center
            StartPosition = FormStartPosition.CenterParent;

            // Refresh workouts data
            RefreshDataGridViewWorkouts();
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
        /// Refreshes data in dataGridViewWorkouts
        /// </summary>
        private void RefreshDataGridViewWorkouts()
        {
            try
            {
                // Get data from database
                DataTable workouts = _repository.GetWorkouts();

                // Show data in grid
                dataGridViewWorkouts.DataSource = workouts;
            }
            catch (SqlException)
            {

            }
        }
    }
}
