using System;
using System.Windows.Forms;

namespace BartlomiejJagielloLab2ZadDom.Main
{
    public partial class FormMainMenu : Form
    {
        /// <summary>
        /// Main menu constructor
        /// </summary>
        public FormMainMenu()
        {
            InitializeComponent();

            // Setting window to show in the screen center
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Closes application immediately
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Moves to options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOptions_Click(object sender, EventArgs e)
        {
            FormOptions formOptions = new FormOptions
            {
                Text = this.Text
            };
            formOptions.ShowDialog(this);
        }

        /// <summary>
        /// Open workouts view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWorkouts_Click(object sender, EventArgs e)
        {
            FormViewWorkouts formViewWorkouts = new FormViewWorkouts
            {
                Text = this.Text
            };
            formViewWorkouts.ShowDialog(this);
        }

        /// <summary>
        /// Open sessions view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSessions_Click(object sender, EventArgs e)
        {
            FormSessions formSessions = new FormSessions()
            {
                Text = this.Text
            };
            formSessions.ShowDialog(this);
        }
    }
}
