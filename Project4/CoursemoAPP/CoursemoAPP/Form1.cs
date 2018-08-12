using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursemoAPP
{
    public partial class Coursemo : Form
    {
        private CoursemoDataContext db;

        public Coursemo()
        {
            InitializeComponent();

            using (db = new CoursemoDataContext())
            {

                var squery = from c in db.Students
                             orderby c.Netid
                             select c;

                this.Students.Items.Clear();
                this.Courses.Items.Clear();

                foreach (Student c in squery)
                    this.Students.Items.Add(c.Netid + ": " + c.LastName + ", " + c.FirstName);

                var cquery = from c in db.Courses
                             orderby c.Department, c.Number
                             select c;
                foreach (Course c in cquery)
                    this.Courses.Items.Add(c.Department + " " + c.Number + ": " + c.CRN.ToString());
            }
        }

        private void Enroll_Click(object sender, EventArgs e)
        {
            //using (db = new CoursemoDataContext())
            //{
            //    this.CourseDetails.Items.Clear();

            //    int id, crn;
            //    string info = this.Students.Text;
            //    string netid = info.Substring(0, info.IndexOf(":"));
            //    info = this.Courses.Text;
            //    crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

            //    Student a = db.GetStudentID(netid);


            //    if (courseFull.ElementAt(0).Size == courseFull.ElementAt(0).Available)
            //    {
            //        Waitlist i = new Waitlist();
            //        i.ID = ID;
            //        i.CRN = CRN;
            //        db.Waitlists.InsertOnSubmit(i);
            //        db.SubmitChanges();

            //        MessageBox.Show("Studen Put on Waitlist");
            //    }
            //    else
            //    {
            //        Enrolled i = new Enrolled();
            //        i.ELID = 
            //        i.ID = ID;
            //        i.CRN = CRN;
            //        db.Enrolleds.InsertOnSubmit(i);
            //        db.SubmitChanges();

            //        MessageBox.Show("Student Enrolled in Course");
            //    }
            //}

        }

        private void Drop_Click(object sender, EventArgs e)
        {

        }

        private void Swap_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //using (db = new CoursemoDataContext())
            //{
            //    db.ExecuteCommand("TRUNCATE TABLE Waitlist;");
            //    db.ExecuteCommand("TRUNCATE TABLE Enrolled;");

            //    db.SubmitChanges();
            //}

            //MessageBox.Show("Database reset...");
        }

        private void Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (db = new CoursemoDataContext())
            //{
            //    string info = this.Students.Text;
            //    int ID = Int32.Parse(info.Substring(0, info.IndexOf(":")));

            //    var getWaitlist = from w in db.Waitlists
            //                      join c in db.Courses
            //                      on w.CRN equals c.CRN
            //                      where w.ID == ID
            //                      select new
            //                      {
            //                          crn = c.CRN,
            //                          Dep = c.Department,
            //                          Num = c.Number
            //                      };

            //    foreach (var w in getWaitlist)
            //        this.Waitlist.Items.Add(w.Dep + " " + w.Num + ", " + w.crn);

            //    var getEnrolled = from w in db.Waitlists
            //                      join c in db.Courses
            //                      on w.CRN equals c.CRN
            //                      where w.ID == ID
            //                      select new
            //                      {
            //                          crn = c.CRN,
            //                          Dep = c.Department,
            //                          Num = c.Number
            //                      };

            //    foreach (var w in getEnrolled)
            //        this.Waitlist.Items.Add(w.Dep + " " + w.Num + ", " + w.crn);


            //}
        }

        private void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                this.CourseDetails.Items.Clear();
                string info = this.Courses.Text;
                int crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

                Course c = db.GetCourse(crn);

                if (c == null)
                    return;

                this.CourseDetails.Items.Add("Semester: " + c._Semester);
                this.CourseDetails.Items.Add("Year: " + c._Year);
                this.CourseDetails.Items.Add("Type: " + c._Type);
                this.CourseDetails.Items.Add("Day: " + c._Day);
                this.CourseDetails.Items.Add("Time: " + c._Time);
                this.CourseDetails.Items.Add("Size: " + c.Size.ToString());
                this.CourseDetails.Items.Add("Current Enrollment: " + (c.Size - c.Available).ToString());
            }
        }
    }
}
