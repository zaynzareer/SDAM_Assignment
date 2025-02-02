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
    public partial class STUDENTPerformance : Form
    {
        private StudentDatabaseHelper dbHelper;
        public STUDENTPerformance()
        {
            InitializeComponent();
            dbHelper = new StudentDatabaseHelper();
            LoadStudentPerformance();
        }

        // Load the student's performance data into the DataGridView
        private void LoadStudentPerformance()
        {

            string studentId = SessionManager.LoggedInStudent.Id;
            List<Enrollment> enrollments = dbHelper.GetStudentProgress(studentId);

            if (enrollments != null && enrollments.Count > 0)
            {
                // Create a DataTable to hold the performance data
                DataTable performanceTable = new DataTable();
                performanceTable.Columns.Add("Course", typeof(string));
                performanceTable.Columns.Add("Progress", typeof(string));
                performanceTable.Columns.Add("Completion Status", typeof(string));

                // Loop through each enrollment and add to the DataTable
                foreach (var enrollment in enrollments)
                {
                    performanceTable.Rows.Add(enrollment.Course, enrollment.Progress.ToString() + "%", enrollment.CompletionStatus);
                }

                dgvStudentPerformance.DataSource = performanceTable;
            }
            else
            {
                MessageBox.Show("No performance data found for the student.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefreshPerformance_Click(object sender, EventArgs e)
        {
            LoadStudentPerformance();
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

        private void dataGridView15_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvStudentPerformance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void STUDENTPerformance_Load(object sender, EventArgs e)
        {

        }
    }
}
