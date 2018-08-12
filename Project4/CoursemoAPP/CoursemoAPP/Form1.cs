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
                this.Students.Items.Clear();
                this.Courses.Items.Clear();

                var cquery = from c in db.Courses
                             orderby c.Department, c.Number, c.CRN
                             select c;

                foreach(Course c in cquery)
                {
                    this.Courses.Items.Add(c.Department + " " + c.Number + ": " + c.CRN.ToString());
                }

                var squery = from s in db.Students
                             orderby s.Netid, s.LastName, s.FirstName
                             select s;

                foreach(Student s in squery)
                {
                    this.Students.Items.Add(s.Netid + ": " + s.LastName + ", " + s.FirstName);
                }
            }
        }

        private void Enroll_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                int crn;
                string info = this.Students.Text;
                string netid = info.Substring(0, info.IndexOf(":"));
                info = this.Courses.Text;
                crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

                Student s = db.GetStudent(netid);
                Course c = db.GetCourse(crn);

                if (s == null || c == null)
                {
                    MessageBox.Show("Student or Course doesn't exist!?!");
                    return;
                }

                foreach (Waitlist w in db.Waitlists)
                {
                    if (w.ID == s.ID && w.CRN == c.CRN)
                    {
                        MessageBox.Show("Student already waitlisted...");
                        return;
                    }
                }

                foreach (Enrolled i in db.Enrolleds)
                {
                    if (i.ID == s.ID && i.CRN == c.CRN)
                    {
                        MessageBox.Show("Student already enrolled...");
                        return;
                    }
                }

                if (c.Available == 0)
                {
                    Waitlist i = new Waitlist();
                    i.ID = s.ID;
                    i.CRN = c.CRN;
                    db.Waitlists.InsertOnSubmit(i);
                    db.SubmitChanges();

                    MessageBox.Show("Student Put on Waitlist");
                }
                else
                {
                    Enrolled i = new Enrolled();
                    i.ELID =
                    i.ID = s.ID;
                    i.CRN = c.CRN;
                    db.Enrolleds.InsertOnSubmit(i);
                    c.Available = c.Available - 1;
                    db.SubmitChanges();

                    MessageBox.Show("Student Enrolled in Course");
                }

                this.CourseDetails.Items.Clear();
                this.Courses_SelectedIndexChanged(this, null);
            }

        }

        private void Drop_Click(object sender, EventArgs e)
        {

        }

        private void Swap_Click(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                db.ExecuteCommand("TRUNCATE TABLE Waitlist;");
                db.ExecuteCommand("TRUNCATE TABLE Enrolled;");
                foreach (Course c in db.Courses)
                {
                    c.Available = c.Size;
                }

                db.SubmitChanges();
            }

            MessageBox.Show("Database reset...");

            this.CourseDetails.Items.Clear();
            this.Waitlist.Items.Clear();
            this.Enrolled.Items.Clear();
        }

        private void Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                this.Enrolled.Items.Clear();
                this.Waitlist.Items.Clear();
                string info = this.Students.Text;
                string netid = info.Substring(0, info.IndexOf(":"));

                Student s = db.GetStudent(netid);

                var wquery = from w in db.Waitlists
                             where w.ID == s.ID
                             join c in db.Courses
                             on w.CRN equals c.CRN
                             select new
                             {
                                 crn = c.CRN,
                                 dep = c.Department,
                                 num = c.Number
                             };

                foreach (var c in wquery)
                {
                    this.Waitlist.Items.Add(c.dep + " " + c.num + ": " + c.crn);
                }

                var equery = from w in db.Enrolleds
                             where w.ID == s.ID
                             join c in db.Courses
                             on w.CRN equals c.CRN
                             select new
                             {
                                 crn = c.CRN,
                                 dep = c.Department,
                                 num = c.Number
                             };

                foreach (var c in equery)
                {
                    this.Enrolled.Items.Add(c.dep + " " + c.num + ": " + c.crn);
                }


            }
        }

        private void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                this.CourseDetails.Items.Clear();
                this.Enrolled.Items.Clear();
                this.Waitlist.Items.Clear();
                string info = this.Courses.Text;
                int crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

                Course c = db.GetCourse(crn);

                if (c == null)
                    return;

                int onWaitlist = 0;

                foreach (Waitlist w in db.Waitlists)
                {
                    if (c.CRN == w.CRN)
                        onWaitlist++;
                }

                var wquery = from w in db.Waitlists
                             where w.CRN == c.CRN
                             join s in db.Students
                             on w.ID equals s.ID
                             select new
                             {
                                 netid = s.Netid,
                                 last = s.LastName,
                                 first = s.FirstName
                             };

                foreach (var s in wquery)
                {
                    this.Waitlist.Items.Add(s.netid + ": " + s.last + ", " + s.first);
                }

                var equery = from w in db.Enrolleds
                             where w.CRN == c.CRN
                             join s in db.Students
                             on w.ID equals s.ID
                             select new
                             {
                                 netid = s.Netid,
                                 last = s.LastName,
                                 first = s.FirstName
                             };

                foreach (var s in equery)
                {
                    this.Enrolled.Items.Add(s.netid + ": " + s.last + ", " + s.first);
                }

                this.CourseDetails.Items.Add("Semester: " + c._Semester);
                this.CourseDetails.Items.Add("Year: " + c._Year);
                this.CourseDetails.Items.Add("Type: " + c._Type);
                this.CourseDetails.Items.Add("Day: " + c._Day);
                this.CourseDetails.Items.Add("Time: " + c._Time);
                this.CourseDetails.Items.Add("Size: " + c.Size.ToString());
                this.CourseDetails.Items.Add("Current Enrollment: " + (c.Size - c.Available).ToString());
                this.CourseDetails.Items.Add("Current Waitlisted: " + onWaitlist.ToString());
            }
        }
    }
}
