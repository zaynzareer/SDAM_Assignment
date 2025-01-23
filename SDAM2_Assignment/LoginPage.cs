using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment
{
    public partial class LoginPage : Form
    {
        string connectionString;
        SqlConnection conn;
        public LoginPage()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["LocalSqlConnection"].ConnectionString;

            conn = new SqlConnection(connectionString);
        }

              

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

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
                // Open the database 
                conn.Open();

                // Prepare SQL command with parameterized query to prevent SQL injection
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Credentials WHERE Username = @username AND Password = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                // Execute the query and retrieve the result
                int result = (int)cmd.ExecuteScalar();

                // Check login success or failure
                if (result > 0)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TEACHERTeacher teacher = new TEACHERTeacher();
                    teacher.Show(); 
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

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}