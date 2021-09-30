namespace DeweyDecimalApp.Forms
{
    partial class TaskCompletedMessageBox
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RetryTaskBtn = new System.Windows.Forms.Button();
            this.AwardsBtn = new System.Windows.Forms.Button();
            this.MainMenuBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimeTakenLb = new System.Windows.Forms.Label();
            this.TimeTakenTextLb = new System.Windows.Forms.Label();
            this.MessageLb = new System.Windows.Forms.Label();
            this.StatusMessageLb = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 261);
            this.panel3.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 258);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(531, 3);
            this.panel5.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(531, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 258);
            this.panel4.TabIndex = 26;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.RetryTaskBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AwardsBtn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.MainMenuBtn, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 168);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(25);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(528, 90);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // RetryTaskBtn
            // 
            this.RetryTaskBtn.BackColor = System.Drawing.Color.White;
            this.RetryTaskBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RetryTaskBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RetryTaskBtn.FlatAppearance.BorderSize = 0;
            this.RetryTaskBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RetryTaskBtn.Font = new System.Drawing.Font("Red Hat Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetryTaskBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.RetryTaskBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RetryTaskBtn.Location = new System.Drawing.Point(28, 28);
            this.RetryTaskBtn.Name = "RetryTaskBtn";
            this.RetryTaskBtn.Size = new System.Drawing.Size(153, 34);
            this.RetryTaskBtn.TabIndex = 15;
            this.RetryTaskBtn.Text = "Retry Task";
            this.RetryTaskBtn.UseVisualStyleBackColor = false;
            this.RetryTaskBtn.Click += new System.EventHandler(this.RetryTaskBtn_Click);
            // 
            // AwardsBtn
            // 
            this.AwardsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.AwardsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AwardsBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AwardsBtn.FlatAppearance.BorderSize = 0;
            this.AwardsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AwardsBtn.Font = new System.Drawing.Font("Red Hat Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AwardsBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.AwardsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AwardsBtn.Location = new System.Drawing.Point(346, 28);
            this.AwardsBtn.Name = "AwardsBtn";
            this.AwardsBtn.Size = new System.Drawing.Size(154, 34);
            this.AwardsBtn.TabIndex = 17;
            this.AwardsBtn.Text = "See Awards";
            this.AwardsBtn.UseVisualStyleBackColor = false;
            this.AwardsBtn.Click += new System.EventHandler(this.AwardsBtn_Click);
            // 
            // MainMenuBtn
            // 
            this.MainMenuBtn.BackColor = System.Drawing.Color.White;
            this.MainMenuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenuBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuBtn.FlatAppearance.BorderSize = 0;
            this.MainMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenuBtn.Font = new System.Drawing.Font("Red Hat Display", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(38)))));
            this.MainMenuBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MainMenuBtn.Location = new System.Drawing.Point(187, 28);
            this.MainMenuBtn.Name = "MainMenuBtn";
            this.MainMenuBtn.Size = new System.Drawing.Size(153, 34);
            this.MainMenuBtn.TabIndex = 16;
            this.MainMenuBtn.Text = "Go to Main Menu";
            this.MainMenuBtn.UseVisualStyleBackColor = false;
            this.MainMenuBtn.Click += new System.EventHandler(this.MainMenuBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TimeTakenLb);
            this.panel1.Controls.Add(this.TimeTakenTextLb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 80);
            this.panel1.TabIndex = 30;
            // 
            // TimeTakenLb
            // 
            this.TimeTakenLb.AutoSize = true;
            this.TimeTakenLb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(53)))));
            this.TimeTakenLb.Dock = System.Windows.Forms.DockStyle.Left;
            this.TimeTakenLb.Font = new System.Drawing.Font("Red Hat Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTakenLb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(186)))), ((int)(((byte)(1)))));
            this.TimeTakenLb.Location = new System.Drawing.Point(176, 0);
            this.TimeTakenLb.Name = "TimeTakenLb";
            this.TimeTakenLb.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.TimeTakenLb.Size = new System.Drawing.Size(29, 36);
            this.TimeTakenLb.TabIndex = 23;
            this.TimeTakenLb.Text = "0s";
            this.TimeTakenLb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TimeTakenTextLb
            // 
            this.TimeTakenTextLb.AutoSize = true;
            this.TimeTakenTextLb.Dock = System.Windows.Forms.DockStyle.Left;
            this.TimeTakenTextLb.Font = new System.Drawing.Font("Red Hat Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeTakenTextLb.ForeColor = System.Drawing.Color.White;
            this.TimeTakenTextLb.Location = new System.Drawing.Point(0, 0);
            this.TimeTakenTextLb.Name = "TimeTakenTextLb";
            this.TimeTakenTextLb.Padding = new System.Windows.Forms.Padding(30, 15, 0, 0);
            this.TimeTakenTextLb.Size = new System.Drawing.Size(176, 36);
            this.TimeTakenTextLb.TabIndex = 22;
            this.TimeTakenTextLb.Text = "Task Completed in: ";
            // 
            // MessageLb
            // 
            this.MessageLb.AutoSize = true;
            this.MessageLb.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLb.Font = new System.Drawing.Font("Red Hat Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLb.ForeColor = System.Drawing.Color.White;
            this.MessageLb.Location = new System.Drawing.Point(3, 52);
            this.MessageLb.Name = "MessageLb";
            this.MessageLb.Padding = new System.Windows.Forms.Padding(30, 15, 0, 0);
            this.MessageLb.Size = new System.Drawing.Size(103, 36);
            this.MessageLb.TabIndex = 29;
            this.MessageLb.Text = "Message";
            // 
            // StatusMessageLb
            // 
            this.StatusMessageLb.AutoSize = true;
            this.StatusMessageLb.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusMessageLb.Font = new System.Drawing.Font("Red Hat Display", 15.75F, System.Drawing.FontStyle.Bold);
            this.StatusMessageLb.ForeColor = System.Drawing.Color.White;
            this.StatusMessageLb.Location = new System.Drawing.Point(3, 0);
            this.StatusMessageLb.Name = "StatusMessageLb";
            this.StatusMessageLb.Padding = new System.Windows.Forms.Padding(30, 25, 0, 0);
            this.StatusMessageLb.Size = new System.Drawing.Size(183, 52);
            this.StatusMessageLb.TabIndex = 28;
            this.StatusMessageLb.Text = "Status of Task";
            // 
            // TaskCompletedMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(534, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MessageLb);
            this.Controls.Add(this.StatusMessageLb);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(550, 300);
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "TaskCompletedMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Completed!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TaskCompletedMessageBox_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RetryTaskBtn;
        private System.Windows.Forms.Button AwardsBtn;
        private System.Windows.Forms.Button MainMenuBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TimeTakenLb;
        private System.Windows.Forms.Label TimeTakenTextLb;
        private System.Windows.Forms.Label MessageLb;
        private System.Windows.Forms.Label StatusMessageLb;
    }
}