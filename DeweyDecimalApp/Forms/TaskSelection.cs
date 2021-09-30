using System;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class TaskSelection : Form
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public TaskSelection()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Open the 'Replacing Books Form'
        /// </summary>
        private void ReplacingBooksBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReplacingBooksTask replacingBooksTask = new ReplacingBooksTask();
            replacingBooksTask.Show();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Open the 'Awards Tracker Form'
        /// </summary>
        private void BadgesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AwardsTracker awardsTracker = new AwardsTracker();
            awardsTracker.Show();
        }

        private void TaskSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//
