using System;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class TaskCompletedMessageBox : Form
    {
        string taskCompleted;
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor, takes in paramaters to change text
        /// </summary>
        public TaskCompletedMessageBox(string status, string message, string time, string task)
        {
            InitializeComponent();
            if(time.Equals(""))
            {
                TimeTakenTextLb.Visible = false;
            }

            StatusMessageLb.Text = status;
            MessageLb.Text = message;
            TimeTakenLb.Text = time;
            taskCompleted = task;

            
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Takes user back to the 'Replacing Books Form'
        /// </summary>
        private void RetryTaskBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (taskCompleted.Equals("replacingBooks"))
            {
                ReplacingBooksTask taskForm = new ReplacingBooksTask();
                taskForm.ShowDialog();
            }
            else
            {
                IdentifyingAreasTask taskForm = new IdentifyingAreasTask();
                taskForm.ShowDialog();
            }
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