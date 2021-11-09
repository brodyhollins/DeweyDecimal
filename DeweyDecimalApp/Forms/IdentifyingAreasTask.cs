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
    public partial class IdentifyingAreasTask : Form
    {
        public Random random = new Random();

        Dictionary<string, string> currentDescriptions = new Dictionary<string, string>();
        Dictionary<string, string> questions = new Dictionary<string, string>();

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifyingAreasTask()
        {
            InitializeComponent();

            Clear();

            GenerateQuestions();

            CallNumbersToDescriptions();
            /*//Alternate column matching type
            if (random.Next(0, 2) == 0)
            {
                CallNumbersToDescriptions();
            }
            else
            {
                DescriptionsToCallNumbers();
            }*/
         }

        private void DescriptionsToCallNumbers()
        {
            
        }

        private void CallNumbersToDescriptions()
        {
            for (int j = 0; j < questions.Count; j++)
            {
                if (j > 3)
                {
                    Console.WriteLine("" + questions.Values.ElementAt(j));
                    continue;
                }
                Console.WriteLine(questions.Keys.ElementAt(j) + " = " + questions.Values.ElementAt(j));
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate the Questions for matching the column
        /// </summary>
        private void GenerateQuestions()
        {
            //Clone original dictionary data 
            foreach (string key in CallNumbersDescriptions.descriptions.Keys)
            {
                currentDescriptions.Add(key, CallNumbersDescriptions.descriptions[key]);
            }

            //Randomly take 7 descriptions
            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(0, currentDescriptions.Count);
                questions.Add(currentDescriptions.Keys.ElementAt(index), currentDescriptions.Values.ElementAt(index));
                currentDescriptions.Remove(currentDescriptions.Keys.ElementAt(index));
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
        ///     Clear variables
        /// </summary>
        private void Clear()
        {
            currentDescriptions.Clear();
            questions.Clear();
        }
    }
}
