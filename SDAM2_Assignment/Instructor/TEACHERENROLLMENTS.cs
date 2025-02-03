using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDAM2_Assignment.Classes;

namespace SDAM2_Assignment.Instructor
{
    public partial class TEACHERENROLLMENTS : Form
    {
        private DatabaseHelper dbHelper;
        private List<Enrollment> enrollmentlist;
        private string selectedEnrollmentId;

        public TEACHERENROLLMENTS()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            Loadlist();
        }
        private void TEACHERENROLLMENTS_Load(object sender, EventArgs e)
        {
            dgvEnrollment.ClearSelection();
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        public void Loadlist()
        {
            enrollmentlist = dbHelper.LoadEnrollments();
            dgvEnrollment.DataSource = enrollmentlist;
            dgvEnrollment.ClearSelection();

            dgvEnrollment.Columns["Progress"].Visible = false;
            dgvEnrollment.Columns["CompletionStatus"].Visible = false;
            dgvEnrollment.Columns["CourseID"].Visible = false;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            bool successful = dbHelper.UpdateEnrollment(selectedEnrollmentId, "Approved");
            if (successful)
            {
                MessageBox.Show("Successfully approved the Student!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadlist();               
            }
            else
            {
                MessageBox.Show("Failed to approve Student!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            bool successful = dbHelper.UpdateEnrollment(selectedEnrollmentId, "Rejected");
            if (successful)
            {
                MessageBox.Show("Successfully rejectd the Student!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Loadlist();      
            }
            else
            {
                MessageBox.Show("Failed to reject Student!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void dgvEnrollment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvEnrollment.Rows[e.RowIndex];
                selectedEnrollmentId = row.Cells["EnrollmentID"].Value.ToString();
                btnApprove.Enabled = true;
                btnReject.Enabled = true;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginPageInstructor ALP = new LoginPageInstructor();
            ALP.Show();
            this.Hide();
        }
    }
}
