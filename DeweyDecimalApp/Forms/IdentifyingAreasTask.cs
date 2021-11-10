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
        Dictionary<string, string> correctAnswers = new Dictionary<string, string>();

        Dictionary<string, string> userAnswers = new Dictionary<string, string>();
        string selectedCallNumber, selectedDescription;

        List<string> leftColumn = new List<string>();
        List<string> rightColumn = new List<string>();

        Boolean callNumberToDescription = false;

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifyingAreasTask()
        {
            InitializeComponent();

            Clear();

            GenerateQuestions();

            /*CallNumbersToDescriptions();*/
            DescriptionsToCallNumbers();

            /*//Alternate column matching type
            if (random.Next(0, 2) == 0)
            {
                CallNumbersToDescriptions();
            }
            else
            {
                callNumberToDescription = false;
                DescriptionsToCallNumbers();
            }*/

            leftColumnLb.DataSource = leftColumn.OrderBy(x => Guid.NewGuid()).ToList();
            rightColumnLb.DataSource = rightColumn.OrderBy(x => Guid.NewGuid()).ToList();

            leftColumnLb.SelectedIndex = -1;
            rightColumnLb.SelectedIndex = -1;
            userAnswers.Clear();

            if (leftColumnLb.SelectedIndex == -1)
            {
                rightColumnLb.Enabled = false;
            }

            leftColumnLb.DrawItem += new DrawItemEventHandler(listBox_SetColor);
            rightColumnLb.DrawItem += new DrawItemEventHandler(listBox_SetColor);
            
        }

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
            }
        }

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
            Refresh();
        }

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

        void listBox_SetColor(object sender, DrawItemEventArgs e)
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
            catch
            {

            }

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            correctAnswers.Clear();
            leftColumnLb.ClearSelected();
            rightColumnLb.ClearSelected();

            
            foreach(var question in leftColumn)
            {
                if (callNumberToDescription)
                {
                    foreach (string key in questions.Keys)
                    {
                        if (key == question)
                        {
                            correctAnswers.Add(key, questions[key]);
                        }
                    }
                }
                else
                {
                    foreach (string value in questions.Values)
                    {
                        if (value == question)
                        {
                            var key = questions.FirstOrDefault(x => x.Value.Equals(value)).Key;
                            correctAnswers.Add(key, value);
                        }
                    }
                }
            }

            if (userAnswers.OrderBy(pair => pair.Key).SequenceEqual(correctAnswers.OrderBy(pair => pair.Key)))
            {

                // Custom text for the Message Box Popup for being correct
                string status = "Well Done!";
                string message = "You identified the call numbers correctly.";
                string time = "0 seconds";

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
                string message = "You failed to identify the call numbers correctly. \nClick 'Retry Task' to keep on trying!";
                string time = "0 seconds";

                // Open custom messagebox
                this.Hide();
                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time, "identifyingAreas");
                taskCompletedMessageBox.ShowDialog();
                this.Close();
            }
        }
    }
}
