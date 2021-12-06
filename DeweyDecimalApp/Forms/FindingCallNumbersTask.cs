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
        Dictionary<string, string> question = new Dictionary<string, string>();
        Dictionary<int, string> answers = new Dictionary<int, string>();

        //Used for determining our levels within the tree
        int level1, level2, level3;
        int currentLevel = 3;

        //Awards tracking values
        bool noErrors = true;
        bool topReached = false;

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public FindingCallNumebersTask()
        {
            InitializeComponent();

            //Obtain data from our file of dewey decimal numbers
            FileReader();
            Init();

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///    Get the filename of the text file stored in the root folder and store data in tree
        /// </summary>
        public void FileReader()
        {
            string fileName = @"..\..\..\CallNumbers.txt";

            //Store tree data in memory from file data
            CallNumbersTree callNumbersTree = new CallNumbersTree();
            mainTree = callNumbersTree.PopulateCallNumbersTree(fileName);
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Create question from level 3 and possible answers from top level on intial load
        /// </summary>
        private void Init()
        {
            AnswersCLb.Items.Clear();
            GenerateQuestion();
            GenerateAnswers();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate a random question description from current level in the tree
        /// </summary>
        public void GenerateQuestion()
        {
            List<string> values = new List<string>();
            level1 = random.Next(0, 10);
            level2 = random.Next(0, mainTree.Root.Children[level1].Children.Count());
            level3 = random.Next(0, mainTree.Root.Children[level1].Children[level2].Children.Count());

            //Determine which level to generate a question from
            switch (currentLevel)
            {
                case 3:
                    values = mainTree.Root.Children[level1].Children[level2].Children[level3].Data.Split(' ').ToList();
                    break;
                case 2:
                    values = mainTree.Root.Children[level1].Children[level2].Data.Split(' ').ToList();
                    break;
            }

            //Take just the description and remove the key
            string callNumber = values.First();
            values.RemoveAt(0);
            string description = string.Join(" ", values);

            //Add key value pair to the dictionary to compare in the submission
            question.Add(callNumber, description);
            questionDescriptionLb.Text = description;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate the level 1 answers, 1 being the correct answer which can be referenced by the question generated
        /// </summary>
        public void GenerateAnswers()
        {
            answers.Clear();
            answers.Add(level1, mainTree.Root.Children[level1].Data);
            
            int possibleAnswers = 3;

            //Generate random possible answers
            for (int x = 0; x < possibleAnswers; x ++)
            {
                int index = random.Next(0, 10);
                //Ensure no duplicates are added to dictionary
                if (!answers.ContainsKey(index))
                {
                    answers.Add(index, mainTree.Root.Children[index].Data);
                }
                else
                {
                    //Restart loop
                    x--;
                }
            }

            AnswersCLb.Items.Clear();
            //Populate our checklistbox with the values
            foreach(var answer in answers)
            {
                AnswersCLb.Items.Add(answer.Value);
            }
            
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Allow only one item to be selected in checkbox
        /// </summary>
        private void AnswersCLb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < AnswersCLb.Items.Count; ++ix)
                if (ix != e.Index) AnswersCLb.SetItemChecked(ix, false);
            SubmitBtn.Enabled = true;
            if (AnswersCLb.SelectedIndex == -1)
            {
                SubmitBtn.Enabled = false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Go up a level on correct answer to question
        /// </summary>
        public void ContinueToNextLevel()
        {
            if(currentLevel > 1)
            {
                DialogResult dialogResult = MessageBox.Show("You identified the call number correctly. \nContinue to next level?", "Correct Answer!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GenerateQuestion();
                    GenerateAnswers();
                }
                else if (dialogResult == DialogResult.No)
                {
                    ReturnToMainMenu();
                }
            }
            else
            {
                topReached = true;
                TaskCompleted();
            }
            
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Stay in current level and regenerate questions and answers
        /// </summary>
        public void RepeatLevel()
        {
            DialogResult dialogResult = MessageBox.Show("You identified the call number incorrectly. \nKeep trying?", "Incorrect Answer.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                noErrors = false;
                GenerateQuestion();
                GenerateAnswers();
            }
            else if (dialogResult == DialogResult.No)
            {
                ReturnToMainMenu();
            }

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Get correct answers and compare with user choice
        /// </summary>
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            var selectedKey = answers.FirstOrDefault(x => x.Value == AnswersCLb.SelectedItem.ToString()).Key;
            if (selectedKey == level1)
            {
                currentLevel--;
                ContinueToNextLevel();
            }
            else
            {
                RepeatLevel();
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Direct user to completed message form on submit
        /// </summary>
        private void TaskCompleted()
        {
            if (noErrors)
            {
                Awards.reachedTopLevelInOneTry = true;
            }
            if (topReached)
            {
                Awards.reachedTopLevel = true;
            }
            // Custom text for the Message Box Popup for being correct
            string status = "Well Done!";
            string message = "You reached the top level of the call numbers.";
            string time = "";

            // Open custom messagebox
            this.Hide();
            TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time, "findingCallNumbers");
            taskCompletedMessageBox.ShowDialog();
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Back button, to go back to 'Task Selection Form'
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            ReturnToMainMenu();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Return the user to the 'Task Selection Form'
        /// </summary>
        public void ReturnToMainMenu()
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//