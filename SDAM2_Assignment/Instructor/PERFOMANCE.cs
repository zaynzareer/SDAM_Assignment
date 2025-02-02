using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDAM2_Assignment.Classes;

namespace SDAM2_Assignment.Instructor
{
    public partial class PERFOMANCE : Form
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();
        private List<Performance> performancelist;
        public PERFOMANCE()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadPerformance();
        }

        public void LoadPerformance()
        {
            performancelist = dbHelper.GetStudentPerformance();
            dgvPerformance.DataSource = performancelist;
            dgvPerformance.Columns["Progress"].DefaultCellStyle.Format = "0'%'";
        }

        private void btnGeneratePerformance_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvPerformance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvPerformance.Rows[e.RowIndex];

                string studentId = row.Cells["StudentID"].Value.ToString();
                string studentName = row.Cells["StudentName"].Value.ToString(); 

                txtId.Text = studentId;
                txtName.Text = studentName;
            }
        }

        //navigation buttons
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ui ui = new ui();
            ui.Show();
            this.Hide();
        }

        private void btnCoursePage_Click(object sender, EventArgs e)
        {
            TeacherCourses courses = new TeacherCourses();
            courses.Show();
            this.Hide();
        }

        private void btnStudentsPage_Click(object sender, EventArgs e)
        {
            TEACHERstudents students = new TEACHERstudents();
            students.Show();
            this.Hide();
        }

        private void btnEnrollmentPage_Click(object sender, EventArgs e)
        {
            TEACHERENROLLMENTS enrollments = new TEACHERENROLLMENTS();
            enrollments.Show();
            this.Hide();
        }

        private void btnAssignmentPage_Click(object sender, EventArgs e)
        {
            TEACHERASSIGNMENT assignments = new TEACHERASSIGNMENT();
            assignments.Show();
            this.Hide();
        }

        private void btnPerformanceReportPage_Click(object sender, EventArgs e)
        {
            PERFOMANCE performance = new PERFOMANCE();
            performance.Show();
            this.Hide();
        }

    }
}
