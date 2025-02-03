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
using System.Xml.Linq;

namespace SDAM2_Assignment.Students
{
    public partial class STUDENTSStudent : Form
    {
        
        private Student student;
        private DatabaseHelper dbHelper;
        private List<Student> studentlist;



        public void Loadlist()
        {
            studentlist = dbHelper.loadStudents();
            dgvAssignment14.DataSource = studentlist;
        }

        public STUDENTSStudent()
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
            txtUsername.Clear();
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

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new Student object with the current form values
                student = new Student(
                    txtId.Text,
                    txtName.Text,
                    Convert.ToInt32(txtAge.Text),
                    cmbGender.SelectedItem.ToString(),
                    txtTelephone.Text,
                    txtCity.Text
                );

                // Get the username from the textbox
                string username = txtUsername.Text;

                // Attempt to update the student in the database
                bool successful = dbHelper.UpdateStudent(student, username);

                if (successful)
                {
                    MessageBox.Show("Profile updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the student list to show updated data
                    Loadlist();
                }
                else
                {
                    MessageBox.Show("Failed to update profile!", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid age!", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void STUDENTSStudent_Load(object sender, EventArgs e)
        {

        }

        private void dgvAssignment14_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvAssignment14.Rows[e.RowIndex];
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

        private void btnLoadProfile_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            student = new Student
            (
                txtId.Text,
                txtName.Text,
                Convert.ToInt32(txtAge.Text),
                cmbGender.SelectedItem.ToString(),
                txtTelephone.Text,
                txtCity.Text
            );
            bool successful = dbHelper.UpdateStudent(student, username);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginPageStudent SLP = new LoginPageStudent();
            SLP.Show();
            this.Hide();
        }
    }
    }

            
       
    