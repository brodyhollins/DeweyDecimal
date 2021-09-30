namespace DeweyDecimalApp.Forms
{
    partial class ReplacingBooksTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplacingBooksTask));
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.UserSortedCallNumbers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RestartTaskBtn = new System.Windows.Forms.Button();
            this.StartTaskBtn = new System.Windows.Forms.Button();
            this.TimerValueLb = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BackBtn = new System.Windows.Forms.Button();
            this.ReplacingBooksTimer = new System.Windows.Forms.Timer(this.components);
            this.HowToPlayTt = new System.Windows.Forms.ToolTip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sort the books";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.SubmitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SubmitBtn.FlatAppearance.BorderSize = 0;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.SubmitBtn.Location = new System.Drawing.Point(1043, 346);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(140, 38);
            this.SubmitBtn.TabIndex = 6;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // UserSortedCallNumbers
            // 
            this.UserSortedCallNumbers.AllowDrop = true;
            this.UserSortedCallNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.UserSortedCallNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserSortedCallNumbers.ColumnWidth = 117;
            this.UserSortedCallNumbers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.UserSortedCallNumbers.Font = new System.Drawing.Font("Red Hat Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserSortedCallNumbers.ForeColor = System.Drawing.Color.White;
            this.UserSortedCallNumbers.FormattingEnabled = true;
            this.UserSortedCallNumbers.HorizontalExtent = 50;
            this.UserSortedCallNumbers.IntegralHeight = false;
            this.UserSortedCallNumbers.ItemHeight = 250;
            this.UserSortedCallNumbers.Location = new System.Drawing.Point(13, 49);
            this.UserSortedCallNumbers.MinimumSize = new System.Drawing.Size(325, 225);
            this.UserSortedCallNumbers.MultiColumn = true;
            this.UserSortedCallNumbers.Name = "UserSortedCallNumbers";
            this.UserSortedCallNumbers.Size = new System.Drawing.Size(1170, 275);
            this.UserSortedCallNumbers.TabIndex = 0;
            this.UserSortedCallNumbers.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserSortedCallNumbers_DragDrop);
            this.UserSortedCallNumbers.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserSortedCallNumbers_DragEnter);
            this.UserSortedCallNumbers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserSortedCallNumbers_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.label3.Location = new System.Drawing.Point(139, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Ascending Order)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RestartTaskBtn);
            this.panel2.Controls.Add(this.StartTaskBtn);
            this.panel2.Controls.Add(this.TimerValueLb);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.UserSortedCallNumbers);
            this.panel2.Controls.Add(this.SubmitBtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(19, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1195, 401);
            this.panel2.TabIndex = 5;
            // 
            // RestartTaskBtn
            // 
            this.RestartTaskBtn.BackColor = System.Drawing.Color.White;
            this.RestartTaskBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestartTaskBtn.FlatAppearance.BorderSize = 0;
            this.RestartTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartTaskBtn.Font = new System.Drawing.Font("Red Hat Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartTaskBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.RestartTaskBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RestartTaskBtn.Location = new System.Drawing.Point(844, 11);
            this.RestartTaskBtn.Name = "RestartTaskBtn";
            this.RestartTaskBtn.Size = new System.Drawing.Size(110, 26);
            this.RestartTaskBtn.TabIndex = 15;
            this.RestartTaskBtn.Text = "Restart";
            this.RestartTaskBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RestartTaskBtn.UseVisualStyleBackColor = false;
            this.RestartTaskBtn.Click += new System.EventHandler(this.RestartTaskBtn_Click);
            // 
            // StartTaskBtn
            // 
            this.StartTaskBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.StartTaskBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartTaskBtn.FlatAppearance.BorderSize = 0;
            this.StartTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTaskBtn.Font = new System.Drawing.Font("Red Hat Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartTaskBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.StartTaskBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StartTaskBtn.Location = new System.Drawing.Point(960, 11);
            this.StartTaskBtn.Name = "StartTaskBtn";
            this.StartTaskBtn.Size = new System.Drawing.Size(110, 26);
            this.StartTaskBtn.TabIndex = 14;
            this.StartTaskBtn.Text = "Start";
            this.StartTaskBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StartTaskBtn.UseVisualStyleBackColor = false;
            this.StartTaskBtn.Click += new System.EventHandler(this.StartTaskBtn_Click);
            // 
            // TimerValueLb
            // 
            this.TimerValueLb.AutoSize = true;
            this.TimerValueLb.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold);
            this.TimerValueLb.ForeColor = System.Drawing.Color.White;
            this.TimerValueLb.Location = new System.Drawing.Point(1149, 11);
            this.TimerValueLb.Name = "TimerValueLb";
            this.TimerValueLb.Size = new System.Drawing.Size(30, 21);
            this.TimerValueLb.TabIndex = 13;
            this.TimerValueLb.Text = "0s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1086, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Timer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Red Hat Display", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Replacing Books Task";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 511);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1231, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 511);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 508);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1228, 3);
            this.panel5.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1228, 40);
            this.panel1.TabIndex = 11;
            // 
            // BackBtn
            // 
            this.BackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Red Hat Display Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.ForeColor = System.Drawing.Color.White;
            this.BackBtn.Image = ((System.Drawing.Image)(resources.GetObject("BackBtn.Image")));
            this.BackBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BackBtn.Location = new System.Drawing.Point(0, 0);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.BackBtn.Size = new System.Drawing.Size(105, 40);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // ReplacingBooksTimer
            // 
            this.ReplacingBooksTimer.Interval = 1000;
            this.ReplacingBooksTimer.Tick += new System.EventHandler(this.ReplacingBooksTimer_Tick);
            // 
            // HowToPlayTt
            // 
            this.HowToPlayTt.AutoPopDelay = 20000;
            this.HowToPlayTt.InitialDelay = 0;
            this.HowToPlayTt.ReshowDelay = 100;
            this.HowToPlayTt.ShowAlways = true;
            this.HowToPlayTt.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.HowToPlayTt.ToolTipTitle = "How to play";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Red Hat Display Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1081, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "How to play ?";
            this.HowToPlayTt.SetToolTip(this.label5, "Click the \'Start\' button to begin.\r\nClick and Drag the Boxes and align them from " +
        "\r\nleft(lowest) to right(highest).");
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(53)))));
            this.panel6.Location = new System.Drawing.Point(19, 92);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1195, 1);
            this.panel6.TabIndex = 18;
            // 
            // ReplacingBooksTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1234, 511);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1250, 550);
            this.MinimumSize = new System.Drawing.Size(1250, 550);
            this.Name = "ReplacingBooksTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReplacingBooksTask";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReplacingBooksTask_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.ListBox UserSortedCallNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Timer ReplacingBooksTimer;
        private System.Windows.Forms.Label TimerValueLb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RestartTaskBtn;
        private System.Windows.Forms.Button StartTaskBtn;
        private System.Windows.Forms.ToolTip HowToPlayTt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
    }
}