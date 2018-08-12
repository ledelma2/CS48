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
            this.SuspendLayout();
            // 
            // Enroll
            // 
            this.Enroll.Location = new System.Drawing.Point(435, 612);
            this.Enroll.Name = "Enroll";
            this.Enroll.Size = new System.Drawing.Size(100, 40);
            this.Enroll.TabIndex = 0;
            this.Enroll.Text = "Enroll";
            this.Enroll.UseVisualStyleBackColor = true;
            this.Enroll.Click += new System.EventHandler(this.Enroll_Click);
            // 
            // Drop
            // 
            this.Drop.Location = new System.Drawing.Point(541, 612);
            this.Drop.Name = "Drop";
            this.Drop.Size = new System.Drawing.Size(100, 40);
            this.Drop.TabIndex = 1;
            this.Drop.Text = "Drop";
            this.Drop.UseVisualStyleBackColor = true;
            this.Drop.Click += new System.EventHandler(this.Drop_Click);
            // 
            // Swap
            // 
            this.Swap.Location = new System.Drawing.Point(647, 612);
            this.Swap.Name = "Swap";
            this.Swap.Size = new System.Drawing.Size(100, 40);
            this.Swap.TabIndex = 2;
            this.Swap.Text = "Swap";
            this.Swap.UseVisualStyleBackColor = true;
            this.Swap.Click += new System.EventHandler(this.Swap_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(753, 612);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(100, 40);
            this.Reset.TabIndex = 3;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Courses
            // 
            this.Courses.FormattingEnabled = true;
            this.Courses.ItemHeight = 25;
            this.Courses.Location = new System.Drawing.Point(15, 15);
            this.Courses.Name = "Courses";
            this.Courses.Size = new System.Drawing.Size(400, 379);
            this.Courses.TabIndex = 4;
            this.Courses.SelectedIndexChanged += new System.EventHandler(this.Courses_SelectedIndexChanged);
            // 
            // Students
            // 
            this.Students.FormattingEnabled = true;
            this.Students.ItemHeight = 25;
            this.Students.Location = new System.Drawing.Point(887, 15);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(400, 379);
            this.Students.TabIndex = 5;
            this.Students.SelectedIndexChanged += new System.EventHandler(this.Students_SelectedIndexChanged);
            // 
            // Enrolled
            // 
            this.Enrolled.FormattingEnabled = true;
            this.Enrolled.ItemHeight = 25;
            this.Enrolled.Location = new System.Drawing.Point(451, 15);
            this.Enrolled.Name = "Enrolled";
            this.Enrolled.Size = new System.Drawing.Size(400, 179);
            this.Enrolled.TabIndex = 6;
            // 
            // Waitlist
            // 
            this.Waitlist.FormattingEnabled = true;
            this.Waitlist.ItemHeight = 25;
            this.Waitlist.Location = new System.Drawing.Point(451, 245);
            this.Waitlist.Name = "Waitlist";
            this.Waitlist.Size = new System.Drawing.Size(400, 179);
            this.Waitlist.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Waitlist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Enrolled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1042, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Students";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 399);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Courses";
            // 
            // CourseDetails
            // 
            this.CourseDetails.FormattingEnabled = true;
            this.CourseDetails.ItemHeight = 25;
            this.CourseDetails.Location = new System.Drawing.Point(15, 462);
            this.CourseDetails.Name = "CourseDetails";
            this.CourseDetails.Size = new System.Drawing.Size(400, 129);
            this.CourseDetails.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 594);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Course Details";
            // 
            // Coursemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOrange;
            this.ClientSize = new System.Drawing.Size(1299, 680);
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
    }
}

