using System;
using System.Drawing;
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
            ReplacingBooksTask replaceBooks = new ReplacingBooksTask();
            replaceBooks.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Open the 'Identifying Areas Form'
        /// </summary>
        private void IdentifyingAreasBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            IdentifyingAreasTask identifyingAreas = new IdentifyingAreasTask();
            identifyingAreas.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Open the 'Finding Call Numbers Form'
        /// </summary>
        private void FindingCallNumbersBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindingCallNumebersTask findingCallNumbers = new FindingCallNumebersTask();
            findingCallNumbers.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Open the 'Awards Tracker Form'
        /// </summary>
        private void BadgesBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AwardsTracker awardsTracker = new AwardsTracker();
            awardsTracker.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///    Clsoe the thread on application quit
        /// </summary>
        private void TaskSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//
