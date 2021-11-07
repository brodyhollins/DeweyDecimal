﻿using System;
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
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// Constructor
        /// </summary>
        public IdentifyingAreasTask()
        {
            InitializeComponent();
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
    }
}