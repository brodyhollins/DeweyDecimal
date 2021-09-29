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
        List<Form> openForms = new List<Form>();
        public TaskCompletedMessageBox(string status, string message, string time)
        {
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            InitializeComponent();
            StatusMessageLb.Text = status;
            MessageLb.Text = message;
            TimeTakenLb.Text = time;
        }

        private void RetryTaskBtn_Click(object sender, EventArgs e)
        {
            HideForms();
            ReplacingBooksTask replaceBooks = new ReplacingBooksTask();
            replaceBooks.ShowDialog();
            CloseForms();
        }

        private void MainMenuBtn_Click(object sender, EventArgs e)
        {
            HideForms();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            CloseForms();
        }

        private void AwardsBtn_Click(object sender, EventArgs e)
        {

            HideForms();
            AwardsTracker awardsTracker = new AwardsTracker();
            awardsTracker.ShowDialog();
            CloseForms();
        }

        private void HideForms()
        {
            this.Hide();
            foreach (Form f in openForms)
            {
                f.Hide();
            }

        }
        private void CloseForms()
        {
            foreach (Form f in openForms)
            {
                f.Close();
            }
            this.Close();
        }
    }
}
