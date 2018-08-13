//
//Liam Edelman
//U. of Illinois, Chicago
//CS480, Summer 2018
//Project 4
//

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

                foreach (Course c in cquery)
                {
                    this.Courses.Items.Add(c.Department + " " + c.Number + ": " + c.CRN.ToString());
                }

                var squery = from s in db.Students
                             orderby s.Netid, s.LastName, s.FirstName
                             select s;

                foreach (Student s in squery)
                {
                    this.Students.Items.Add(s.Netid + ": " + s.LastName + ", " + s.FirstName);
                }
            }
        }

        private void DelayTransaction(int ms)
        {
            if (ms < 0)
                ms = 0;
            System.Threading.Thread.Sleep(ms);
        }

        private void Enroll_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                DelayTransaction(Int32.Parse(this.Delay.Text));

                int crn;
                string info = this.Students.Text;
                if (info.Length == 0)
                    return;
                string netid = info.Substring(0, info.IndexOf(":"));
                info = this.Courses.Text;
                if (info.Length == 0)
                    return;
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

                DelayTransaction(Int32.Parse(this.Delay.Text));

                if (c.Available == 0)
                {
                    string sql = string.Format(@"
                    INSERT INTO 
                        Waitlist(ID,CRN)
                        Values({0},{1});
                    ", s.ID, c.CRN);
                    db.ExecuteCommand(sql);

                    MessageBox.Show("Student Put on Waitlist");
                }
                else
                {
                    string sql = string.Format(@"
                    INSERT INTO 
                        Enrolled(ID,CRN)
                        Values({0},{1});
                    ", s.ID, c.CRN);
                    db.ExecuteCommand(sql);
                    c.Available = c.Available - 1;

                    MessageBox.Show("Student Enrolled in Course");
                }

                db.SubmitChanges();

                this.CourseDetails.Items.Clear();
                this.Courses_SelectedIndexChanged(this, null);
            }
        }

        private void Drop_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                DelayTransaction(Int32.Parse(this.Delay.Text));

                int crn;
                string info = this.Students.Text;
                if (info.Length == 0)
                    return;
                string netid = info.Substring(0, info.IndexOf(":"));
                info = this.Courses.Text;
                if (info.Length == 0)
                    return;
                crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

                Student s = db.GetStudent(netid);
                Course c = db.GetCourse(crn);

                if (s == null || c == null)
                {
                    MessageBox.Show("Student or Course doesn't exist!?!");
                    return;
                }

                var wait = from w in db.Waitlists
                           where w.CRN == c.CRN && w.ID == s.ID
                           select w;

                DelayTransaction(Int32.Parse(this.Delay.Text));

                if (wait.Count() == 0)
                {
                    //student not on waitlist
                    var enroll = from i in db.Enrolleds
                                 where i.CRN == c.CRN && i.ID == s.ID
                                 select i;

                    if (enroll.Count() == 0)
                    {
                        //student not on enrolled list either
                        MessageBox.Show("Student is not enrolled or waitlisted for this class...");
                        return;
                    }
                    else
                    {
                        //db.Enrolleds.Attach(enroll);
                        db.Enrolleds.DeleteOnSubmit(enroll.First());
                        var query = from w in db.Waitlists
                                    where w.CRN == c.CRN
                                    orderby w.WLID
                                    select w;
                        if (query.Count() > 0)
                        {
                            //person on waitlist available to take space
                            string sql = string.Format(@"
                            INSERT INTO 
                                Enrolled(ID,CRN)
                                Values({0},{1});
                            ", query.First().ID, query.First().CRN);
                            db.ExecuteCommand(sql);
                            MessageBox.Show("Student dropped from enrolled");
                            MessageBox.Show("First waitlisted student added to enrolled");
                            //db.Waitlists.Attach(query.First());
                            db.Waitlists.DeleteOnSubmit(query.First());
                            db.SubmitChanges();
                        }
                        else
                        {
                            c.Available = c.Available + 1;
                            MessageBox.Show("Student dropped from enrolled");
                        }
                    }
                }
                else
                {
                    //db.Waitlists.Attach(wait);
                    MessageBox.Show("Student dropped from waitlist");
                    db.Waitlists.DeleteOnSubmit(wait.First());
                }
                db.SubmitChanges();
                this.Courses_SelectedIndexChanged(this, null);
            }
        }

        private void Swap_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {
                DelayTransaction(Int32.Parse(this.Delay.Text));

                int crn;
                string info = this.Students.Text;
                if (info.Length == 0)
                    return;
                string netid = info.Substring(0, info.IndexOf(":"));
                info = this.Courses.Text;
                if (info.Length == 0)
                    return;
                crn = Int32.Parse(info.Substring(info.IndexOf(":") + 1));

                Student s1 = db.GetStudent(netid);
                Course c1 = db.GetCourse(crn);
                Student s2 = db.GetStudent(this.SwapNetid.Text);
                Course c2 = db.GetCourse(Int32.Parse(this.SwapCRN.Text));

                if (s1 == null || s2 == null || c1 == null || c2 == null)
                {
                    MessageBox.Show("Student(s) or Course(s) don't exist!?!");
                    return;
                }

                var enroll1 = from i in db.Enrolleds
                              where i.CRN == c1.CRN && i.ID == s1.ID
                              select i;

                var enroll2 = from i in db.Enrolleds
                              where i.CRN == c2.CRN && i.ID == s2.ID
                              select i;

                var enroll3 = from i in db.Enrolleds
                              where i.CRN == c2.CRN && i.ID == s1.ID
                              select i;

                var enroll4 = from i in db.Enrolleds
                              where i.CRN == c1.CRN && i.ID == s2.ID
                              select i;

                if (enroll1.Count() == 0 || enroll2.Count() == 0)
                {
                    //student not on enrolled list
                    MessageBox.Show("Student is not enrolled for this class...");
                    return;
                }

                if(enroll3.Count() > 0 || enroll4.Count() > 0)
                {
                    MessageBox.Show("Student is already enrolled for this class...");
                    return;
                }

                db.Enrolleds.DeleteOnSubmit(enroll1.First());

                string sql1 = string.Format(@"
                            INSERT INTO 
                                Enrolled(ID,CRN)
                                Values({0},{1});
                            ", enroll1.First().ID, enroll2.First().CRN);
                db.ExecuteCommand(sql1);

                db.Enrolleds.DeleteOnSubmit(enroll2.First());

                string sql2 = string.Format(@"
                            INSERT INTO 
                                Enrolled(ID,CRN)
                                Values({0},{1});
                            ", enroll2.First().ID, enroll1.First().CRN);
                db.ExecuteCommand(sql2);

                db.SubmitChanges();
                MessageBox.Show("Courses swapped...");
                this.Courses_SelectedIndexChanged(this, null);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            using (db = new CoursemoDataContext())
            {

                DelayTransaction(Int32.Parse(this.Delay.Text));


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

                DelayTransaction(Int32.Parse(this.Delay.Text));

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

                DelayTransaction(Int32.Parse(this.Delay.Text));

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
