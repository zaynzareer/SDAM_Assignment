using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment
{
    public partial class TEACHERASSIGNMENT : Form
    {
        private Assignment assignment;
        private List<Assignment> assignmentlist;
        private DatabaseHelper dbHelper;

        public TEACHERASSIGNMENT()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            Loadlist();
        }

        public void Loadlist()
        {
            assignmentlist = dbHelper.LoadAssignments();
            dgvAssignment.DataSource = assignmentlist;
        }

        public void Clear()
        {
            txtAssignmentId.Clear();
            txtAssignmentName.Clear();
            dtpHandout.Value = DateTime.Today;
            dtpDeadline.Value = DateTime.Today;
        }

        private void btnCreateAssignment_Click(object sender, EventArgs e)
        {
            assignment = new Assignment(
                txtAssignmentId.Text,
                txtAssignmentName.Text,
                dtpHandout.Value,
                dtpDeadline.Value
            );
            bool successful = dbHelper.CreateAssignment( assignment );
            if (successful)
            {
                MessageBox.Show("A new Assignment is created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to create Assignment!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAssignment_Click(object sender, EventArgs e)
        {
            assignment = new Assignment(
                txtAssignmentId.Text,
                txtAssignmentName.Text,
                dtpHandout.Value,
                dtpDeadline.Value
            );
            bool successful = dbHelper.UpdateAssignment(assignment);
            if (successful)
            {
                MessageBox.Show("Successfully updated Assignment details!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to update Assignment details!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveAssignment_Click(object sender, EventArgs e)
        {
            string assignmentid = txtAssignmentId.Text;
            bool successful = dbHelper.RemoveAssignment(assignmentid);
            if (successful)
            {
                MessageBox.Show("Successfully deleted the Assignment!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to delete Assignment!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvAssignment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvAssignment.Rows[e.RowIndex];
                string assignmentid = row.Cells[0].Value.ToString();
                string assignmentname = row.Cells[1].Value.ToString();
                string handout = row.Cells[2].Value.ToString();
                string deadline = row.Cells[3].Value.ToString();

                txtAssignmentId.Text = assignmentid;
                txtAssignmentName.Text = assignmentname;
                dtpHandout.Text = handout;
                dtpDeadline.Text = deadline;
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
