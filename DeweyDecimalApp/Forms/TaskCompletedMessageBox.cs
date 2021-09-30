using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class TaskCompletedMessageBox : Form
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor, takes in paramaters to change text
        /// </summary>
        public TaskCompletedMessageBox(string status, string message, string time)
        {
            InitializeComponent();
            StatusMessageLb.Text = status;
            MessageLb.Text = message;
            TimeTakenLb.Text = time;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Takes user back to the 'Replacing Books Form'
        /// </summary>
        private void RetryTaskBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReplacingBooksTask replaceBooks = new ReplacingBooksTask();
            replaceBooks.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Takes user back to the 'Task Selection Form'
        /// </summary>
        private void MainMenuBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Takes user back to the 'Awards Tracker Form'
        /// </summary>
        private void AwardsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AwardsTracker awardsTracker = new AwardsTracker();
            awardsTracker.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Takes user back to the 'Task Selection Form' on form close
        /// </summary>
        private void TaskCompletedMessageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            TaskSelection taskSelectionClose = new TaskSelection();
            taskSelectionClose.ShowDialog();
            this.Close();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//