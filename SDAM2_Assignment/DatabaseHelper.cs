using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sql;

namespace SDAM2_Assignment
{
    internal class DatabaseHelper
    {
        private string connectionString { get; }
        
        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AzureSqlConnection"].ConnectionString;
        }

        //Add Students
        public bool AddStudent(Student student)
        {
            bool successful = false;
            //establish new sql connection
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "INSERT INTO Students(Id, Name, Age, Gender, Telephone, City) VALUES(@Id, @Name, @Age, @Gender, @Telephone, @City)";
                //creating sql command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Telephone", student.Telephone);
                cmd.Parameters.AddWithValue("@city", student.City);

                //opening a connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }   

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return successful;
        }

        //Delete Students
        public bool DeleteStudent(string studentId)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = "DELETE FROM Students WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //opening a connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return successful;
        }

        public bool UpdateStudent(Student student)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "UPDATE Students SET Name = @Name, Age = @Age, Gender = @Gender, Telephone = @Telephone, City = @City WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Telephone", student.Telephone);
                cmd.Parameters.AddWithValue("@city", student.City);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return successful;
        }

        //load Student details into datagridview
        public List<Student> loadStudents()
        {
            List<Student> studentlist = new List<Student>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = "SELECT * FROM Students";

                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return studentlist;
        }
    }
}
