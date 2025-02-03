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
    public partial class ui : Form
    {
        private DatabaseHelper dbHelper;
        private List<Assignment> assignmentList;
        private List<Course> courseList;
        private List<Enrollment> enrollmentList;
        private List<Performance> performanceList;

        public ui()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadAllData();
        }

        private void LoadAllData()
        {
            LoadAssignments();
            LoadCourses();
            LoadEnrollments();
            LoadPerformance();
        }

        private void LoadAssignments()
        {
            try
            {
                assignmentList = dbHelper.LoadAssignments();
                dgvAssignment.DataSource = assignmentList;
                
                // Hide unnecessary columns
                dgvAssignment.Columns["CourseID"].Visible = false;
                dgvAssignment.Columns["SubmissionDate"].Visible = false;
                dgvAssignment.Columns["SubmissionFilePath"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assignments: " + ex.Message);
            }
        }

        private void LoadCourses()
        {
            try
            {
                courseList = dbHelper.LoadCourses();
                dgvCourses.DataSource = courseList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void LoadEnrollments()
        {
            try
            {
                enrollmentList = dbHelper.LoadEnrollments();
                dgvEnrollment.DataSource = enrollmentList;

                // Hide unnecessary columns
                dgvEnrollment.Columns["Progress"].Visible = false;
                dgvEnrollment.Columns["CompletionStatus"].Visible = false;
                dgvEnrollment.Columns["CourseID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading enrollments: " + ex.Message);
            }
        }

        private void LoadPerformance()
        {
            try
            {
                performanceList = dbHelper.GetStudentPerformance();
                dgvPerformance.DataSource = performanceList;
                dgvPerformance.Columns["Progress"].DefaultCellStyle.Format = "0'%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading performance data: " + ex.Message);
            }
        }

        // Navigation Methods
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Already on dashboard
            LoadAllData(); // Refresh data
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

        private void ui_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // Refresh button click handler
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginPageInstructor ALP = new LoginPageInstructor();
            ALP.Show();
            this.Hide();
        }
    }
}