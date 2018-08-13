namespace CoursemoAPP
{
    partial class Coursemo
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
            this.Enroll = new System.Windows.Forms.Button();
            this.Drop = new System.Windows.Forms.Button();
            this.Swap = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.Courses = new System.Windows.Forms.ListBox();
            this.Students = new System.Windows.Forms.ListBox();
            this.Enrolled = new System.Windows.Forms.ListBox();
            this.Waitlist = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CourseDetails = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SwapNetid = new System.Windows.Forms.TextBox();
            this.SwapCRN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Delay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Enroll
            // 
            this.Enroll.Location = new System.Drawing.Point(218, 318);
            this.Enroll.Margin = new System.Windows.Forms.Padding(2);
            this.Enroll.Name = "Enroll";
            this.Enroll.Size = new System.Drawing.Size(50, 21);
            this.Enroll.TabIndex = 0;
            this.Enroll.Text = "Enroll";
            this.Enroll.UseVisualStyleBackColor = true;
            this.Enroll.Click += new System.EventHandler(this.Enroll_Click);
            // 
            // Drop
            // 
            this.Drop.Location = new System.Drawing.Point(270, 318);
            this.Drop.Margin = new System.Windows.Forms.Padding(2);
            this.Drop.Name = "Drop";
            this.Drop.Size = new System.Drawing.Size(50, 21);
            this.Drop.TabIndex = 1;
            this.Drop.Text = "Drop";
            this.Drop.UseVisualStyleBackColor = true;
            this.Drop.Click += new System.EventHandler(this.Drop_Click);
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(324, 318);
            this.Swap.Margin = new System.Windows.Forms.Padding(2);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(50, 21);
            this.Swap.TabIndex = 2;
            this.Swap.Text = "Swap";
            this.Swap.UseVisualStyleBackColor = true;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(376, 318);
            this.Reset.Margin = new System.Windows.Forms.Padding(2);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(50, 21);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Courses
            // 
            this.Courses.FormattingEnabled = true;
            this.Courses.Location = new System.Drawing.Point(8, 8);
            this.Courses.Margin = new System.Windows.Forms.Padding(2);
            this.Courses.Name = "Courses";
            this.Courses.Size = new System.Drawing.Size(202, 199);
            this.Courses.TabIndex = 4;
            this.Courses.SelectedIndexChanged += new System.EventHandler(this.Courses_SelectedIndexChanged);
            // 
            // Students
            // 
            this.Students.FormattingEnabled = true;
            this.Students.Location = new System.Drawing.Point(444, 8);
            this.Students.Margin = new System.Windows.Forms.Padding(2);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(202, 199);
            this.Students.TabIndex = 5;
            this.Students.SelectedIndexChanged += new System.EventHandler(this.Students_SelectedIndexChanged);
            // 
            // Enrolled
            // 
            this.Enrolled.FormattingEnabled = true;
            this.Enrolled.Location = new System.Drawing.Point(226, 8);
            this.Enrolled.Margin = new System.Windows.Forms.Padding(2);
            this.Enrolled.Name = "Enrolled";
            this.Enrolled.Size = new System.Drawing.Size(202, 95);
            this.Enrolled.TabIndex = 6;
            // 
            // Waitlist
            // 
            this.Waitlist.FormattingEnabled = true;
            this.Waitlist.Location = new System.Drawing.Point(226, 127);
            this.Waitlist.Margin = new System.Windows.Forms.Padding(2);
            this.Waitlist.Name = "Waitlist";
            this.Waitlist.Size = new System.Drawing.Size(202, 95);
            this.Waitlist.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Waitlist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enrolled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 207);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Students";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Courses";
            // 
            // CourseDetails
            // 
            this.CourseDetails.FormattingEnabled = true;
            this.CourseDetails.Location = new System.Drawing.Point(8, 240);
            this.CourseDetails.Margin = new System.Windows.Forms.Padding(2);
            this.CourseDetails.Name = "CourseDetails";
            this.CourseDetails.Size = new System.Drawing.Size(202, 69);
            this.CourseDetails.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 309);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Course Details";
            // 
            // SwapNetid
            // 
            this.SwapNetid.Location = new System.Drawing.Point(545, 240);
            this.SwapNetid.Name = "SwapNetid";
            this.SwapNetid.Size = new System.Drawing.Size(100, 20);
            this.SwapNetid.TabIndex = 14;
            // 
            // SwapCRN
            // 
            this.SwapCRN.Location = new System.Drawing.Point(545, 266);
            this.SwapCRN.Name = "SwapCRN";
            this.SwapCRN.Size = new System.Drawing.Size(101, 20);
            this.SwapCRN.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Swap NETID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(476, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Swap CRN:";
            // 
            // Delay
            // 
            this.Delay.Location = new System.Drawing.Point(546, 318);
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(100, 20);
            this.Delay.TabIndex = 18;
            this.Delay.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Delay in Milliseconds:";
            // 
            // Coursemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(650, 354);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Delay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SwapCRN);
            this.Controls.Add(this.SwapNetid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CourseDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Waitlist);
            this.Controls.Add(this.Enrolled);
            this.Controls.Add(this.Students);
            this.Controls.Add(this.Courses);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Swap);
            this.Controls.Add(this.Drop);
            this.Controls.Add(this.Enroll);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Coursemo";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Enroll;
        private System.Windows.Forms.Button Drop;
        private System.Windows.Forms.Button Swap;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.ListBox Courses;
        private System.Windows.Forms.ListBox Students;
        private System.Windows.Forms.ListBox Enrolled;
        private System.Windows.Forms.ListBox Waitlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox CourseDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SwapNetid;
        private System.Windows.Forms.TextBox SwapCRN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Delay;
        private System.Windows.Forms.Label label8;
    }
}

