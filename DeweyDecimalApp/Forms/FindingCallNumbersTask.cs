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

        int level1, level2, level3;
        int currentLevel = 3;


        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Declaring variables to be used throughout form
        /// </summary>
        Tree<string> mainTree = new Tree<string>();
        Dictionary<string, string> question = new Dictionary<string, string>();
        Dictionary<int, string> answers = new Dictionary<int, string>();

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public FindingCallNumebersTask()
        {
            InitializeComponent();

            FileReader();


            Init();

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Create question and possible answers
        /// </summary>
        private void Init()
        {
            AnswersCLb.Items.Clear();

            GenerateQuestion(3);

            GenerateAnswers();


        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate a random question description from level 3 in the tree
        /// </summary>
        public void GenerateQuestion(int lvl)
        {
            List<string> values = new List<string>();
            level1 = random.Next(0, 10);
            level2 = random.Next(0, mainTree.Root.Children[level1].Children.Count());
            level3 = random.Next(0, mainTree.Root.Children[level1].Children[level2].Children.Count());

            //Take just the description and remove the key

            switch (lvl)
            {
                case 3:
                    values = mainTree.Root.Children[level1].Children[level2].Children[level3].Data.Split(' ').ToList();
                    break;
                case 2:
                    values = mainTree.Root.Children[level1].Children[level2].Data.Split(' ').ToList();
                    break;
            }
            
            string callNumber = values.First();
            values.RemoveAt(0);
            string description = string.Join(" ", values);

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
            //Create a temp dictionary as to not mutate original answers Dictionary
            Dictionary<int, string> tempAnswers = new Dictionary<int, string>();
            
            answers.Add(level1, mainTree.Root.Children[level1].Data);
            tempAnswers.Add(level1, mainTree.Root.Children[level1].Data);

            for (int x = 0; x < 3; x ++)
            {
                int index = random.Next(0, 10);
                if (!answers.ContainsKey(index))
                {
                    answers.Add(index, mainTree.Root.Children[index].Data);
                    tempAnswers.Add(index, mainTree.Root.Children[index].Data);
                }
                else
                {
                    x--;
                }
                
            }

            //Sort our values by call number
            var sortByCallNumbers = tempAnswers.ToList();
            sortByCallNumbers.Sort((set1, set2) => set1.Value.CompareTo(set2.Value));

            AnswersCLb.Items.Clear();
            //Populate our checklistbox with the values
            foreach(var answer in sortByCallNumbers)
            {
                AnswersCLb.Items.Add(answer.Value);
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
        ///     Back button, to go back to 'Task Selection Form'
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }

        private void AnswersCLb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < AnswersCLb.Items.Count; ++ix)
                if (ix != e.Index) AnswersCLb.SetItemChecked(ix, false);
        }

        public void ContinueToNextLevel()
        {
            if(currentLevel > 1)
            {
                DialogResult dialogResult = MessageBox.Show("You identified the call number correctly. \nContinue to next level?", "Correct Answer!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    GenerateQuestion(currentLevel);
                    GenerateAnswers();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Console.WriteLine("Go to Main Menu");
                }
            }
            else
            {
                TaskCompleted();
            }
            
        }

        public void RepeatLevel()
        {
            DialogResult dialogResult = MessageBox.Show("You identified the call number incorrectly. \nKeep trying?", "Incorrect Answer.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                GenerateQuestion(currentLevel);
                GenerateAnswers();
            }
            else if (dialogResult == DialogResult.No)
            {
                Console.WriteLine("Go to Main Menu");
            }

        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Get correct answers and compare with user quesses
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
            Console.WriteLine("Show the finsih screen and cal awards");
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//