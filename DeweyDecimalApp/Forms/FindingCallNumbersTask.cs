using CallNumbers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class FindingCallNumebersTask : Form
    {
        public Random random = new Random();


        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Declaring variables to be used throughout form
        /// </summary>
        Tree<string> mainTree = new Tree<string>();
        Dictionary<string, string> questions = new Dictionary<string, string>();

        //Column lists
        List<string> leftColumn = new List<string>();
        List<string> rightColumn = new List<string>();

        //User and Answer variables
        string selectedCallNumber, selectedDescription;
        Dictionary<string, string> userAnswers = new Dictionary<string, string>();
        Dictionary<string, string> correctAnswers = new Dictionary<string, string>();
        int totalCorrect = 0;

        //Swap from call number to decription to description to call numbers 
        Boolean callNumberToDescription = true;

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public FindingCallNumebersTask()
        {
            InitializeComponent();

            FileReader();


            /*Init();

            leftColumnLb.DrawItem += new DrawItemEventHandler(listBox_SetColor);
            rightColumnLb.DrawItem += new DrawItemEventHandler(listBox_SetColor);*/

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Create questions and randomize order, swap between call numbers and decriptions for questions
        /// </summary>
        private void Init()
        {
            correctAnswers.Clear();
            GenerateCallNumberQuestions callNumberQuestions = new GenerateCallNumberQuestions();
            questions = callNumberQuestions.GenerateQuestions();

            //Alternate column matching type
            if (random.Next(0, 2) == 0)
            {
                callNumberToDescription = true;
                CallNumbersToDescriptions();
            }
            else
            {
                callNumberToDescription = false;
                DescriptionsToCallNumbers();
            }

            leftColumnLb.DataSource = leftColumn.OrderBy(x => Guid.NewGuid()).ToList();
            rightColumnLb.DataSource = rightColumn.OrderBy(x => Guid.NewGuid()).ToList();

            leftColumnLb.SelectedIndex = -1;
            rightColumnLb.SelectedIndex = -1;
            userAnswers.Clear();

            if (leftColumnLb.SelectedIndex == -1)
            {
                rightColumnLb.Enabled = false;
            }

        }

        public void FileReader()
        {
            string fileName = @"..\..\..\Test.txt";

            CallNumbersTree callNumbersTree = new CallNumbersTree();
            mainTree = callNumbersTree.PopulateCallNumbersTree(fileName);

            /*Console.WriteLine("Root");
            Console.WriteLine(mainTree.Root.Data);

            Console.WriteLine("Level 1");
            Console.WriteLine(mainTree.Root.Children[0].Data);
            Console.WriteLine("Level 2");
            Console.WriteLine(mainTree.Root.Children[0].Children[0].Data);
            Console.WriteLine("Level 3");
            Console.WriteLine(mainTree.Root.Children[0].Children[0].Children[0].Data);


            Console.WriteLine("Level 1");
            Console.WriteLine(mainTree.Root.Children[0].Data);
            Console.WriteLine("Level 2");
            Console.WriteLine(mainTree.Root.Children[0].Children[1].Data);
            Console.WriteLine("Level 3");
            Console.WriteLine(mainTree.Root.Children[0].Children[1].Children[0].Data);*/
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Populate left column to be descriptions as questions
        /// </summary>
        private void DescriptionsToCallNumbers()
        {
            for (int j = 0; j < questions.Count; j++)
            {
                if (j > 3)
                {
                    rightColumn.Add(questions.Keys.ElementAt(j));
                    continue;
                }
                leftColumn.Add(questions.Values.ElementAt(j));
                rightColumn.Add(questions.Keys.ElementAt(j));

                //Populate correct answers dictionary
                correctAnswers.Add(questions.Keys.ElementAt(j), questions.Values.ElementAt(j));
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Populate left column to be call numbers as questions
        /// </summary>
        private void CallNumbersToDescriptions()
        {
            for (int j = 0; j < questions.Count; j++)
            {
                if (j > 3)
                {
                    rightColumn.Add(questions.Values.ElementAt(j));
                    continue;
                }
                leftColumn.Add(questions.Keys.ElementAt(j));
                rightColumn.Add(questions.Values.ElementAt(j));

                //Populate correct answers dictionary
                correctAnswers.Add(questions.Keys.ElementAt(j), questions.Values.ElementAt(j));
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Back button, to go back to 'Task Selection Form'
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Temp hold value of left column question 
        /// </summary>
        private void LeftColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            rightColumnLb.ClearSelected();
            rightColumnLb.Enabled = true;
            if (leftColumnLb.SelectedIndex != -1)
            {
                if (callNumberToDescription)
                {
                    selectedCallNumber = leftColumnLb.SelectedItem.ToString();
                }
                else
                {
                    selectedDescription = leftColumnLb.SelectedItem.ToString();
                }
                
            }
            //Refresh to load styling changes
            Refresh();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Temp hold value of right column answer, then add to the user answers dictionary 
        /// </summary>
        private void RightColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rightColumnLb.SelectedIndex != -1)
            {
                if (callNumberToDescription)
                {
                    selectedDescription = rightColumnLb.SelectedItem.ToString();
                }
                else
                {
                    selectedCallNumber = rightColumnLb.SelectedItem.ToString();
                }
                

                if (!userAnswers.ContainsKey(selectedCallNumber))
                {
                    userAnswers.Add(selectedCallNumber, selectedDescription);
                }
                else
                {
                    userAnswers[selectedCallNumber] = selectedDescription;
                }
                Refresh();
            }

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Styling for listbox items to match items from left column to right column.
        ///     Selected to be easy to notice without changing the colour of item for easier UX
        /// </summary>
        void listBox_SetColor(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            SolidBrush backgroundColorBrush = new SolidBrush(Color.FromArgb(43, 43, 53));
            SolidBrush itemTextColorBrush = new SolidBrush(Color.White);
            Pen border = new Pen(Color.FromArgb(28, 28, 38));
            border.Width = 5;

            string item = ((ListBox)sender).Items[e.Index].ToString();

            for (int a = 0; a < userAnswers.Count; a++)
            {
                if (item.Equals(userAnswers.ElementAt(a).Key) || item.Equals(userAnswers.ElementAt(a).Value))
                {
                    switch (a)
                    {
                        case 0:
                            backgroundColorBrush = new SolidBrush(Color.FromArgb(155, 115, 205));
                            break;
                        case 1:
                            backgroundColorBrush = new SolidBrush(Color.FromArgb(106, 106, 255));
                            break;
                        case 2:
                            backgroundColorBrush = new SolidBrush(Color.FromArgb(255, 106, 142));
                            break;
                        case 3:
                            backgroundColorBrush = new SolidBrush(Color.FromArgb(255, 124, 106));
                            break;

                    }
                }
            }

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            if (isItemSelected)
            {
                border.Color = Color.White;
            }

            SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
            g.FillRectangle(backgroundColorBrush, e.Bounds);
            e.Graphics.DrawRectangle(border, e.Bounds);
            g.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, itemTextColorBrush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));

            e.DrawFocusRectangle();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Get correct answers and compare with user quesses
        /// </summary>
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            leftColumnLb.ClearSelected();
            rightColumnLb.ClearSelected();

            foreach (var question in userAnswers)
            {
                if (callNumberToDescription)
                {
                    if (userAnswers[question.Key].Equals(correctAnswers[question.Key]))
                    {
                        totalCorrect++;
                        if (Awards.correctQuestionsAward != 20)
                        {
                            Awards.correctQuestionsAward++;
                        }
                    }
                }
                else
                {
                    if (correctAnswers.ContainsKey(question.Key))
                    {
                        if (userAnswers[question.Key].Equals(correctAnswers[question.Key]))
                        {
                            totalCorrect++;
                            if (Awards.correctQuestionsAward != 20)
                            {
                                Awards.correctQuestionsAward++;
                            }
                        }
                    }
                }
            }            
            TaskCompleted();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Direct user to completed message form on submit
        /// </summary>
        private void TaskCompleted()
        {
            if (totalCorrect == 4)
            {
                if (callNumberToDescription && !Awards.completeCallNumberQuestionAward)
                {
                    Awards.completeCallNumberQuestionAward = true;
                }

                if (!callNumberToDescription && !Awards.completeDescriptionQuestionAward)
                {
                    Awards.completeDescriptionQuestionAward = true;
                }

                // Custom text for the Message Box Popup for being correct
                string status = "Well Done!";
                string message = "You identified the call numbers correctly.";
                string time = "";

                // Open custom messagebox
                this.Hide();
                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time, "identifyingAreas");
                taskCompletedMessageBox.ShowDialog();
                this.Close();
            }
            else
            {
                // Custom text for the Message Box Popup for being correct
                string status = "Good Try!";
                string message = "You failed to identify the call numbers correctly. \nYou got " + totalCorrect + " answers correct" + "\nClick 'Retry Task' to keep on trying!";
                string time = "";

                // Open custom messagebox
                this.Hide();
                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time, "identifyingAreas");
                taskCompletedMessageBox.ShowDialog();
                this.Close();
            }
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//