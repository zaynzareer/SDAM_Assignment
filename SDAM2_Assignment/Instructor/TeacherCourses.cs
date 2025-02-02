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
    public partial class TeacherCourses : Form
    {
        private Course course;
        private DatabaseHelper dbHelper;
        private List<Course> courselist;
        public TeacherCourses()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            Loadlist();
        }

        public void Clear()
        {
            txtCourseId.Clear();
            txtCourseName.Clear();
            txtDuration.Clear();
            txtDescription.Clear();
        }

        public void Loadlist()
        {
            courselist = dbHelper.LoadCourses();
            dgvCourses.DataSource = courselist;
        }
        private void btnAddCourses_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseId.Text) || string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            course = new Course
            (
                txtCourseId.Text,
                txtCourseName.Text,
                txtDuration.Text,
                txtDescription.Text
            );
            bool successful = dbHelper.AddCourse(course);
            if (successful)
            {
                MessageBox.Show("A new Course is added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to add Course!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCourses_Click(object sender, EventArgs e)
        {
            course = new Course
            (
                txtCourseId.Text,
                txtCourseName.Text,
                txtDuration.Text,
                txtDescription.Text
            );
            bool successful = dbHelper.UpdateCourse(course);
            if (successful)
            {
                MessageBox.Show("Successfully updated Course details!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to update Course details!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveCourses_Click(object sender, EventArgs e)
        {
            string courseid = txtCourseId.Text;
            bool successful = dbHelper.RemoveCourse(courseid);
            if (successful)
            {
                MessageBox.Show("Successfully deleted the Course!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to delete Course!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                string name = row.Cells[1].Value.ToString();
                string duration = row.Cells[2].Value.ToString();
                string description = row.Cells[3].Value.ToString();

                txtCourseId.Text = id;
                txtCourseName.Text = name;
                txtDuration.Text = duration;
                txtDescription.Text = description;
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
