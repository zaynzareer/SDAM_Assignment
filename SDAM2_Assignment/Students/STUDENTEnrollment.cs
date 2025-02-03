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
    public partial class STUDENTEnrollment : Form
    {
        private StudentDatabaseHelper dbHelper;
        private List<Course> enrollmentList;

        public STUDENTEnrollment()
        {
            InitializeComponent();
            dbHelper = new StudentDatabaseHelper();
            LoadEnrollments();
        }

        public void LoadEnrollments()
        {
            string studentId = SessionManager.LoggedInStudent.Id;
            enrollmentList = dbHelper.LoadEnrolledCourses(studentId);
            dgvStudentEnrollment.DataSource = enrollmentList;
        }

        private void btnRefreshErollments_Click(object sender, EventArgs e)
        {
            LoadEnrollments();
        }

        private void btnDropEnrollment_Click(object sender, EventArgs e)
        {
            if (dgvStudentEnrollment.CurrentRow != null)
            {
                DataGridViewRow row = dgvStudentEnrollment.CurrentRow;
                string courseId = row.Cells["CourseID"].Value.ToString();
                string studentId = SessionManager.LoggedInStudent.Id;

                bool successful = dbHelper.DropEnrollment(studentId, courseId);
                if (successful)
                {
                    MessageBox.Show("Enrollment dropped successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEnrollments();
                }
                else
                {
                    MessageBox.Show("Failed to drop enrollment!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a course to drop.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void STUDENTEnrollment_Load(object sender, EventArgs e)
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
