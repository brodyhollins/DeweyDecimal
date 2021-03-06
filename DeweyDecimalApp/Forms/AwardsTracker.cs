using System;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class AwardsTracker : Form
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public AwardsTracker()
        {
            InitializeComponent();

            //----------------------------------------------------------------------------------------------------------------//
            /// <summary>
            /// Replace Books Task Awards
            /// </summary>
            // Setting values for 'Complete your first task' award
            if (Awards.firstTaskCompletedAward)
            {
                completeAwardPb.Value = 100;
                completeAwardLb.Text = "1/1";
            }

            // Setting values for 'Win streak' award
            if (Awards.winStreakAward > 0)
            {
                winStreakAwardPb.Value = (Awards.winStreakAward * 33) + 1;
                winStreakAwardLb.Text = String.Concat(Awards.winStreakAward.ToString(), "/3");
            }

            // Setting values for 'Beat the clock' award
            if (Awards.beatClockAward)
            {
                beatClockAwardPb.Value = 100;
                beatClockAwardLb.Text = "1/1";
            }

            // Setting values for 'Determined' award
            if (Awards.determindedAward <= 10)
            {
                determinedAwardPb.Value = Awards.determindedAward * 10;
                determinedAwardLb.Text = String.Concat(Awards.determindedAward.ToString(), "/10");
            }


            //----------------------------------------------------------------------------------------------------------------//
            /// <summary>
            /// Identify Areas Task Awards
            /// </summary>
            /// 
            // Setting values for 'Complete Call Number Questions' award
            if (Awards.completeCallNumberQuestionAward)
            {
                callNumbersAwardPb.Value = 100;
                callNumbersAwardLb.Text = "1/1";
            }

            // Setting values for 'Complete Description Questions' award
            if (Awards.completeDescriptionQuestionAward)
            {
                descriptionsAwardPb.Value = 100;
                descriptionsAwardLb.Text = "1/1";
            }

            // Setting values for 'Determined' award
            if (Awards.correctQuestionsAward <= 20)
            {
                questionsAwardPb.Value = Awards.correctQuestionsAward * 5;
                questionsAwardLb.Text = String.Concat(Awards.correctQuestionsAward.ToString(), "/20");
            }

            //----------------------------------------------------------------------------------------------------------------//
            /// <summary>
            /// Finding Call Numbers Awards
            /// </summary>
            /// 
            // Setting values for 'Reach for the stars' award
            if (Awards.reachedTopLevel)
            {
                starsAwardPb.Value = 100;
                starsAwardLb.Text = "1/1";
            }

            // Setting values for 'No room for errors' award
            if (Awards.reachedTopLevelInOneTry)
            {
                errorsAwardPb.Value = 100;
                errorsAwardLb.Text = "1/1";
            }

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Back button, to go back to 'Task Selection Form'
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskSelection taskSelectionBack = new TaskSelection();
            taskSelectionBack.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Go back to 'Task Selection Form' on Form close
        /// </summary>
        private void AwardsTracker_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//