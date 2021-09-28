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
    public partial class TaskSelection : Form
    {
        public TaskSelection()
        {
            InitializeComponent();
        }

        private void ReplacingBooksBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReplacingBooksTask replacingBooksTask = new ReplacingBooksTask();
            replacingBooksTask.ShowDialog();
            this.Close();
        }

        private void BadgesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AwardsTracker awardsTracker = new AwardsTracker();
            awardsTracker.ShowDialog();
            this.Close();
        }
    }
}
