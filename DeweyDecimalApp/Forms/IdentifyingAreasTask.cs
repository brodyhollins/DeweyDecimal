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

        Dictionary<string, string> answers = new Dictionary<string, string>();
        string selectedCallNumber, selectedDescription;

        List<string> colours = new List<string>
        {
            "Red",
            "Green",
            "Blue",
            "Pink"
        };

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

            if(listBox1.SelectedIndex == -1)
            {
                listBox2.Enabled = false;
            }

            listBox1.DrawItem += new DrawItemEventHandler(listBox1_SetColor);
            listBox2.DrawItem += new DrawItemEventHandler(listBox2_SetColor);
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

        private void QuestionsListCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*foreach (var selected in QuestionsListCb.CheckedItems)
            {
                if (selectedCallNumbers.Contains(selected))
                {
                    QuestionsListCb.Enabled = true;
                }
                else
                {
                    QuestionsListCb.Enabled = false;
                }
                selectedCallNumbers.Add(selected.ToString());
                Console.WriteLine(selected.)
            }*/
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.ClearSelected();
            listBox2.Enabled = true;
            if(listBox1.SelectedIndex != -1)
            {
                selectedCallNumber = listBox1.SelectedItem.ToString();
            }
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox2.SelectedIndex != -1)
            {
                selectedDescription = listBox2.SelectedItem.ToString();

                if (!answers.ContainsKey(selectedCallNumber))
                {
                    answers.Add(selectedCallNumber, selectedDescription);
                }
                else
                {
                    answers[selectedCallNumber] = selectedDescription;
                }

                int a = listBox1.Items.IndexOf(selectedCallNumber);
            }
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            listBox2.ClearSelected();
            foreach (var item in answers)
            {
                Console.WriteLine(item.Key  + " with " + item.Value);
            }
        }

        void listBox1_SetColor(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Graphics g = e.Graphics;
                SolidBrush backgroundColorBrush = new SolidBrush(Color.FromArgb(43, 43, 53));
                SolidBrush itemTextColorBrush = new SolidBrush(Color.White);
                Pen border = new Pen(Color.FromArgb(28, 28, 38));
                border.Width = 5;

               

                string item = ((ListBox)sender).Items[e.Index].ToString();

                for (int a = 0; a < answers.Count; a++)
                {
                    if (item.Equals(answers.ElementAt(a).Key))
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
            catch
            {

            }

        }

        private void listBox1_Leave(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void listBox2_Leave(object sender, EventArgs e)
        {
            listBox2.ClearSelected();
        }

        void listBox2_SetColor(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Graphics g = e.Graphics;
                SolidBrush backgroundColorBrush = new SolidBrush(Color.FromArgb(43, 43, 53));
                SolidBrush itemTextColorBrush = new SolidBrush(Color.White);
                Pen border = new Pen(Color.FromArgb(28, 28, 38));
                border.Width = 5;



                string item = ((ListBox)sender).Items[e.Index].ToString();

                for (int a = 0; a < answers.Count; a++)
                {
                    if (item.Equals(answers.ElementAt(a).Value))
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
                    backgroundColorBrush = new SolidBrush(Color.White);
                    itemTextColorBrush = new SolidBrush(Color.Black);
                }

                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                g.FillRectangle(backgroundColorBrush, e.Bounds);
                e.Graphics.DrawRectangle(border, e.Bounds);
                g.DrawString(((ListBox)sender).Items[e.Index].ToString(), e.Font, itemTextColorBrush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));

                e.DrawFocusRectangle();
            }
            catch
            {

            }

        }
    }
}
