using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment
{
    public partial class TEACHERstudents : Form
    {
        private Student student;
        private DatabaseHelper dbHelper;
        private List<Student> studentlist;

        public TEACHERstudents()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            Loadlist();
        }

        public void Clear()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbGender.SelectedIndex = -1;
            txtTelephone.Clear();
            txtCity.Clear();
        }

        public void Loadlist()
        {
            studentlist = dbHelper.loadStudents();
            dgvStudents.DataSource = studentlist;
        }

        private void btnRegisterStudent_Click(object sender, EventArgs e)
        {
            student = new Student
            (
                txtId.Text,
                txtName.Text,
                Convert.ToInt32(txtAge.Text),
                cmbGender.SelectedItem.ToString(),
                txtTelephone.Text,
                txtCity.Text
            );
            bool successful = dbHelper.AddStudent(student);
            if (successful)
            {
                MessageBox.Show("A new Student is registered successfully!", "Success", MessageBoxButtons.OK , MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to register Student!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            student = new Student
            (
                txtId.Text,
                txtName.Text,
                Convert.ToInt32(txtAge.Text),
                cmbGender.SelectedItem.ToString(),
                txtTelephone.Text,
                txtCity.Text
            );
            bool successful = dbHelper.UpdateStudent(student);
            if (successful)
            {
                MessageBox.Show("Successfully updated Student details!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to update Student details!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            string studentid = txtId.Text;
            bool successfull = dbHelper.DeleteStudent(studentid);
            if (successfull)
            {
                MessageBox.Show("Successfully deleted the Student!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                Loadlist();
            }
            else
            {
                MessageBox.Show("Failed to delete Student!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                string id = row.Cells[0].Value.ToString();
                string name = row.Cells[1].Value.ToString();
                int age = Convert.ToInt32(row.Cells[2].Value);
                string gender = row.Cells[3].Value.ToString();
                string telephone = row.Cells[4].Value.ToString();
                string city = row.Cells[5].Value.ToString();

                txtId.Text = id;
                txtName.Text = name;
                txtAge.Text = age.ToString();
                cmbGender.SelectedItem = gender;
                txtTelephone.Text = telephone;
                txtCity.Text = city;
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
            TEACHERCOURSES courses = new TEACHERCOURSES();
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

        private void TEACHERstudents_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
