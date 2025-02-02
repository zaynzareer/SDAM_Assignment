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
    public partial class STUDENTAssignment : Form
    {
        private StudentDatabaseHelper dbHelper;
        private List<Assignment> assignments;
        public STUDENTAssignment()
        {
            InitializeComponent();
            dbHelper = new StudentDatabaseHelper();
            LoadAssignments();
        }
        
        // Load assignments for the logged-in student
        private void LoadAssignments()
        {
            string studentId = SessionManager.LoggedInStudent.Id;
            assignments = dbHelper.LoadAssignments(studentId);
            dgvDisplayAssignment.DataSource = assignments;

            dgvDisplayAssignment.Columns["SubmissionDate"].Visible = false;
            dgvDisplayAssignment.Columns["SubmissionFilePath"].Visible = false;
        }


        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            {
                txtSubmissionFilePath.Text = openFileDialog.FileName;
            }
        }

        // Submit an assignment
        private void btnSubmitAssignment_Click_1(object sender, EventArgs e)
        {
            if (dgvDisplayAssignment.CurrentRow != null)
            {
                DataGridViewRow row = dgvDisplayAssignment.CurrentRow;
                string courseId = row.Cells["CourseID"].Value.ToString();
                string assignmentid = row.Cells["AssignmentID"].Value.ToString(); 
                string submissionFilePath = txtSubmissionFilePath.Text; 

                // Validate the submission file path
                if (string.IsNullOrEmpty(submissionFilePath))
                {
                    MessageBox.Show("Please provide a submission file path.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new submission
                bool successful = dbHelper.SubmitAssignment(SessionManager.LoggedInStudent.Id, courseId, assignmentid, submissionFilePath);
                if (successful)
                {
                    MessageBox.Show("Assignment submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubmissionFilePath.Clear();
                    LoadAssignments();
                    dbHelper.UpdateProgress(SessionManager.LoggedInStudent.Id);
                }
                else
                {
                    MessageBox.Show("Assignment submission Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
    }
}