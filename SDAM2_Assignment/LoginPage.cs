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
            connectionString = ConfigurationManager.ConnectionStrings["AzureSqlConnection"].ConnectionString;

            conn = new SqlConnection(connectionString);
        }

        /// Event handler for the Login button click.
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Retrieve input from text boxes
            string usernametxt = username.Text.Trim();
            string passwordtxt = password.Text.Trim();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(usernametxt) || string.IsNullOrWhiteSpace(passwordtxt))
            {
                MessageBox.Show("Please fill in both fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the database connection
                conn.Open();

                // Prepare SQL command with parameterized query to prevent SQL injection
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [LOGIN-page] WHERE username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", usernametxt);
                cmd.Parameters.AddWithValue("@password", passwordtxt);

                // Execute the query and retrieve the result
                int result = (int)cmd.ExecuteScalar();

                // Check login success or failure
                if (result > 0)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}