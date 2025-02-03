using SDAM2_Assignment.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment.Students
{
    public partial class STUDENTCourses : Form
    {
        private StudentDatabaseHelper dbHelper;
        private List<Course> courseList;
        public STUDENTCourses()
        {
            InitializeComponent();
            dbHelper = new StudentDatabaseHelper();
            LoadCourses();
        }
        // Load courses into the DataGridView
        private void LoadCourses()
        {
            courseList = dbHelper.LoadAvailableCourses();
            dgvAvailableCourses.DataSource = courseList;
        }

        private void btnRefreshCourse_Click(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvAvailableCourses.CurrentRow;
            // Check if a row is selected
            if (row != null) 
            {
                string courseId = row.Cells["CourseID"].Value.ToString();
                string courseName = row.Cells["CourseName"].Value.ToString();
                string studentId = SessionManager.LoggedInStudent.Id;

                Enrollment enrollment = new Enrollment
                (
                    dbHelper.GetNextEnrollmentId(), 
                    studentId,
                    SessionManager.LoggedInStudent.Name,
                    courseName,
                    DateTime.Now,
                    "Pending",
                    0,
                    "In Progress",
                    courseId
                );

                bool successful = dbHelper.EnrollStudent(enrollment);
                if (successful)
                {
                    MessageBox.Show("Enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCourses();
                }
                else
                {
                    MessageBox.Show("Enrollment failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a course to enroll.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDashboard1_Click(object sender, EventArgs e)
        {
            STUDENTSUI studentsui = new STUDENTSUI();
            studentsui.Show();
            this.Hide();
        }

        private void btnCoursePage1_Click(object sender, EventArgs e)
        {
            STUDENTCourses Cui = new STUDENTCourses();
            Cui.Show();
            this.Hide();
        }

        private void btnStudentsPage1_Click(object sender, EventArgs e)
        {
            STUDENTSStudent SSui = new STUDENTSStudent();
            SSui.Show();
            this.Hide();
        }


        private void btnEnrollmentPage1_Click(object sender, EventArgs e)
        {
            STUDENTEnrollment SEui = new STUDENTEnrollment();
            SEui.Show();
            this.Hide();
        }

        private void btnAssignmentPage1_Click(object sender, EventArgs e)
        {
            STUDENTAssignment SAui = new STUDENTAssignment();
            SAui.Show();
            this.Hide();
        }

        private void btnPerformanceReportPage1_Click(object sender, EventArgs e)
        {
            STUDENTPerformance SPui = new STUDENTPerformance();
            SPui.Show();
            this.Hide();
        }

        private void STUDENTCourses_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginPageStudent SLP = new LoginPageStudent();
            SLP.Show();
            this.Hide();
        }
    }
}
