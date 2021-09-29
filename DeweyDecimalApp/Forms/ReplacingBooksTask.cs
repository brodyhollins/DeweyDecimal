﻿using CallNumbers;
using System;
using System.Collections;
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
    public partial class ReplacingBooksTask : Form
    {
        List<string> randomDewey = new List<string>();
        List<string> correctOrder = new List<string>();
        int index = 0;
        private int ticker;

        string[] test = new string[] { "595 ABC", "596.6 BCA", "595.01 BBA", "595.2 ABC", "595.9287 ABC", "597 BCA", "595.5 ABC", "595.0001 CCB", "595.408 ABC", "595.8 ABC" };

        public ReplacingBooksTask()
        {
            InitializeComponent();
            SubmitBtn.Enabled = false;
        }

        // Handle the DrawItem event for an owner-drawn ListBox.
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
                // Otherwise, draw the rectangle filled in beige.
                e.Graphics.FillRectangle(lightBrush, e.Bounds);
            }

            // Draw a rectangle in blue around each item.
            e.Graphics.DrawRectangle(darkBrush, e.Bounds);

            e.Graphics.FillRectangle(Brushes.White, new Rectangle(e.Bounds.X + 12, e.Bounds.Bottom - 75, 90, 65));

            // Draw the text in the item.
            e.Graphics.DrawString( UserSortedCallNumbers.Items[e.Index].ToString().Split(' ')[0],
               new Font("Red Hat Display", 12, FontStyle.Bold), Brushes.Black, e.Bounds.X + 12, e.Bounds.Height - 65);

            /*e.Graphics.DrawString((UserSortedCallNumbers.Items[e.Index].ToString().Split(' ')[0].Split('.')[1].PadRight(5, '0')),
                new Font("Red Hat Display", 12, FontStyle.Bold), Brushes.Black, e.Bounds.X + 12, e.Bounds.Height - 20);*/

            e.Graphics.DrawString(UserSortedCallNumbers.Items[e.Index].ToString().Split(' ')[1],
                new Font("Red Hat Display", 12, FontStyle.Bold), Brushes.Black, e.Bounds.X + 12, e.Bounds.Height - 40);

            // Draw the focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        // Handle the MeasureItem event for an owner-drawn ListBox.
        private void UserSortedCallNumbers_MeasureItem(object sender,
            MeasureItemEventArgs e)
        {
            e.ItemHeight += 75;
        }


        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     UserSortedCallNumbers Drag and Drop Functionality
        /// </summary>

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     On left click mouse down check if item has an index and allow drag effect
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
        ///     Checks if item is of data type to be draggable
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
        ///     Allows items within listbox to be moved up or down a position on drag
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


        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            ReplacingBooksTimer.Stop();
            if (correctOrder.SequenceEqual(UserSortedCallNumbers.Items.Cast<string>().ToList()))
            {
                //Setting the 'Complete your first task' award to true if false on first time completed
                if (!Awards.firstTaskCompletedAward)
                {
                    Awards.firstTaskCompletedAward = true;
                }

                //Increment win streak by 1
                if (Awards.winStreakAward < 3)
                {
                    Awards.winStreakAward++;
                }

                //Increment task attempted by 1
                if (Awards.determindedAward < 10)
                {
                    Awards.determindedAward++;
                }

                //Setting beat the clock award to true
                if (!Awards.beatClockAward && ticker <= 15)
                {
                    Awards.beatClockAward = true;
                }

                string status = "Well Done!";
                string message = "You sorted the books correctly.";
                string time = "Task Completed in: " + ticker + " seconds";

                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time);
                taskCompletedMessageBox.Show();
            }
            else
            {
                //Reset win streak when user has lost before the 3rd attempt
                if(Awards.winStreakAward < 3)
                {
                    Awards.winStreakAward = 0;
                }
                //Increment task attempted by 1
                if (Awards.determindedAward < 10)
                {
                    Awards.determindedAward++;
                }

                string status = "Good Try!";
                string message = "You failed to sorted the books correctly. \nClick 'Retry Task' to keep on trying!";
                string time = ticker + " seconds";

                TaskCompletedMessageBox taskCompletedMessageBox = new TaskCompletedMessageBox(status, message, time);
                taskCompletedMessageBox.Show();
            }
        }

        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Back button, to go back to TaskSelection Form
        /// </summary>
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskSelection taskSelection = new TaskSelection();
            taskSelection.ShowDialog();
            this.Close();
        }

        private void ReplacingBooksTimer_Tick(object sender, EventArgs e)
        {
            ticker++;
            TimerValueLb.Text = ticker.ToString() + "s";
        }

        private void StartTaskBtn_Click(object sender, EventArgs e)
        {
            InitTask();
            StartTaskBtn.Enabled = false;
        }

        private void RestartTaskBtn_Click(object sender, EventArgs e)
        {
            InitTask();
        }
        private void InitTask()
        {
            //Reset values
            randomDewey.Clear();
            UserSortedCallNumbers.Items.Clear();
            ReplacingBooksTimer.Stop();
            ticker = 0;
            SubmitBtn.Enabled = true;

            GenerateCallNumbers randomCallNumbers = new GenerateCallNumbers();
            SortCallNumbers sortList = new SortCallNumbers();
            randomDewey = randomCallNumbers.RandomCallNumbersGenerator();
            UserSortedCallNumbers.Items.AddRange(randomDewey.ToArray());

            int len = randomDewey.Count();
            
            correctOrder = sortList.InsertionSort(randomDewey, len);
            
            UserSortedCallNumbers.MeasureItem +=
                new MeasureItemEventHandler(UserSortedCallNumbers_MeasureItem);
            UserSortedCallNumbers.DrawItem += new DrawItemEventHandler(UserSortedCallNumbers_DrawItem);

            UserSortedCallNumbers.Refresh();

            ReplacingBooksTimer.Start();
        }
    }
}
