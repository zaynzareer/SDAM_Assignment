using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;
using SDAM2_Assignment.Students;
using SDAM2_Assignment.Classes;

namespace SDAM2_Assignment
{
    public partial class LoginPageStudent : Form
    {
        string connectionString;
        SqlConnection conn;
        public LoginPageStudent()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["AzureSqlConnection"].ConnectionString;

            conn = new SqlConnection(connectionString);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Retrieve input from text boxes
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the database connection
                conn.Open();

                //query to fetch student details
                string query = "SELECT s.Id, s.Name, s.Age, s.Gender, s.Telephone, s.City, c.Usernames FROM Students s " +
                "JOIN Credentials c ON s.Id = c.StudentId " +
                "WHERE c.Usernames = @username AND c.Passwords = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If a record is found
                {
                    // Create a student object from the retrieved data
                    Student loggedInStudent = new Student
                    (
                        reader["Id"].ToString(),
                        reader["Name"].ToString(),
                        Convert.ToInt32(reader["Age"]),
                        reader["Gender"].ToString(),
                        reader["Telephone"].ToString(),
                        reader["City"].ToString()
                    );

                    // Store the logged-in student in SessionManager
                    SessionManager.SetLoggedInStudent(loggedInStudent);


                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open Student Dashboard
                    STUDENTSUI dashboard = new STUDENTSUI();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the database connection is closed
                conn.Close();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
        }

        /// Event handler for the Exit button click.
        /// Closes the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void btnAdminLoginPage_Click(object sender, EventArgs e)
        {
            LoginPageInstructor ALP = new LoginPageInstructor();
            ALP.Show();
            this.Hide();
        }
    }
}
