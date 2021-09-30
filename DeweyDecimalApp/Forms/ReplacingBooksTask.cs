using CallNumbers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DeweyDecimalApp.Forms
{
    public partial class ReplacingBooksTask : Form
    {
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Declaring variables to be used throughout form
        /// </summary>
        private List<string> randomDewey = new List<string>();
        private List<string> correctOrder = new List<string>();
        private int index = 0;
        private int ticker;


        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public ReplacingBooksTask()
        {
            InitializeComponent();

            //Disabled buttons until task begins
            SubmitBtn.Enabled = false;
            RestartTaskBtn.Enabled = false;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     UserSortedCallNumbers Drag and Drop Functionality
        /// </summary>

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     On left click mouse down enable Drag Drop Effect
        /// </summary>
        private void UserSortedCallNumbers_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            index = listBox.IndexFromPoint(e.X, e.Y);

            if (index >= 0 && e.Button == MouseButtons.Left)
            {
                listBox.DoDragDrop(listBox.Items[index].ToString(), DragDropEffects.Move);
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Checks if item is of data type to be draggable - only our string items in listbox can be dragged
        /// </summary>
        private void UserSortedCallNumbers_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(System.String)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Allows items within listbox to be moved back and forth to reorder the items - Will reflect user sorted List
        /// </summary>
        private void UserSortedCallNumbers_DragDrop(object sender, DragEventArgs e)
        {
            Point point = UserSortedCallNumbers.PointToClient(new Point(e.X, e.Y));
            int index = this.UserSortedCallNumbers.IndexFromPoint(point);
            if (index < 0) index = this.UserSortedCallNumbers.Items.Count - 1;
            object data = e.Data.GetData(typeof(String));
            this.UserSortedCallNumbers.Items.Remove(data);
            this.UserSortedCallNumbers.Items.Insert(index, data);
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Compare sorted List with the User sorted List
        /// </summary>
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Stop our timer
            ReplacingBooksTimer.Stop();

            // Handles when sorted List is the same as User sorted list
            if (correctOrder.SequenceEqual(UserSortedCallNumbers.Items.Cast<string>().ToList()))
            {
                // Setting the 'Complete your first task' award to true if false on first time completed
                if (!Awards.firstTaskCompletedAward)
                {
                    Awards.firstTaskCompletedAward = true;
                }

                // Increment win streak by 1 until it reaches the goal amount
                if (Awards.winStreakAward < 3)
                {
                    Awards.winStreakAward++;
                }

                // Increment task attempted by 1 until it reaches the goal amount
                if (Awards.determindedAward < 10)
                {
                    Awards.determindedAward++;
                }

                // Setting beat the clock award to true
                if (!Awards.beatClockAward && ticker <= 15)
                {
                    Awards.beatClockAward = true;
                }

                // Custom text for the Message Box Popup for being correct
                string status = "Well Done!";
                string message = "You sorted the books correctly.";
                string time = "Task Completed in: " + ticker + " seconds";

                // Open custom messagebox
                this.Hide();
                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time);
                taskCompletedMessageBox.ShowDialog();
                this.Close();
            }
            else
            {
                // Reset win streak when user has sorted the books incorrectly - only if value is before the goal amount
                if(Awards.winStreakAward < 3)
                {
                    Awards.winStreakAward = 0;
                }
                // Increment task attempted by 1 until it reaches the goal amount
                if (Awards.determindedAward < 10)
                {
                    Awards.determindedAward++;
                }

                // Custom text for the Message Box Popup for being incorrect
                string status = "Good Try!";
                string message = "You failed to sorted the books correctly. \nClick 'Retry Task' to keep on trying!";
                string time = ticker + " seconds";

                // Open custom messagebox
                this.Hide();
                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time);
                taskCompletedMessageBox.ShowDialog();
                this.Close();
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
        ///     Starts the task and enables the 'Restart' button
        /// </summary>
        private void StartTaskBtn_Click(object sender, EventArgs e)
        {
            InitTask();
            RestartTaskBtn.Enabled = true;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Restart the task
        /// </summary>
        private void RestartTaskBtn_Click(object sender, EventArgs e)
        {
            InitTask();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Increment the timer by 1 every second, update the label on the from to reflect the value in real time 
        /// </summary>
        private void ReplacingBooksTimer_Tick(object sender, EventArgs e)
        {
            ticker++;
            TimerValueLb.Text = ticker.ToString() + "s";
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     New and redrawn data that is displayed to the user
        /// </summary>
        private void InitTask()
        {
            ResetValues();

            GenerateCallNumbers randomCallNumbers = new GenerateCallNumbers();
            SortCallNumbers sortList = new SortCallNumbers();

            // Generate the 10 random call numbers and add them to the ListBox
            randomDewey = randomCallNumbers.RandomCallNumbersGenerator();
            UserSortedCallNumbers.Items.AddRange(randomDewey.ToArray());

            // Sort the array to be used later for comparision
            correctOrder = sortList.InsertionSort(randomDewey, randomDewey.Count());
            
            // Draw the custom UI to the Listbox
            UserSortedCallNumbers.DrawItem += new DrawItemEventHandler(UserSortedCallNumbers_DrawItem);
            UserSortedCallNumbers.Refresh();

            // Start the timer once all the data is visible to the user
            ReplacingBooksTimer.Start();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Set the values back to their default values
        /// </summary>
        private void ResetValues()
        {
            StartTaskBtn.Enabled = false;
            randomDewey.Clear();
            UserSortedCallNumbers.Items.Clear();
            ReplacingBooksTimer.Stop();
            ticker = 0;
            SubmitBtn.Enabled = true;
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Handle the DrawItem event for an item in the ListBox for custom UI
        /// </summary>
        private void UserSortedCallNumbers_DrawItem(object sender, DrawItemEventArgs e)
        {
            SolidBrush lightBrush = new SolidBrush(Color.FromArgb(43, 43, 53));
            Pen darkBrush = new Pen(Color.FromArgb(28, 28, 38), 5);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(lightBrush, e.Bounds);
            }

            // Draw a rectangle in dark blue around each item to give space between items
            e.Graphics.DrawRectangle(darkBrush, e.Bounds);

            // Draw white rectangle for the Text to be displayed
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.Bounds.X + 12, e.Bounds.Bottom - 75, 90, 65));

            // Draw digits for the text on the top line
            e.Graphics.DrawString(UserSortedCallNumbers.Items[e.Index].ToString().Split(' ')[0],
               new Font("Red Hat Display", 12, FontStyle.Bold), Brushes.Black, e.Bounds.X + 12, e.Bounds.Height - 65);

            // Draw authors letters for the text on the next line
            e.Graphics.DrawString(UserSortedCallNumbers.Items[e.Index].ToString().Split(' ')[1],
                new Font("Red Hat Display", 12, FontStyle.Bold), Brushes.Black, e.Bounds.X + 12, e.Bounds.Height - 40);

            // Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Go back to 'Task Selection Form' on Form close
        /// </summary>
        private void ReplacingBooksTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }
    }
}
//------------------------------------------...ooo000 END OF FILE 000ooo...-------------------------------------------------//