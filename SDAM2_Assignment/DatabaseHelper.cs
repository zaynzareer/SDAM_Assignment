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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.Parameters.AddWithValue("@Id", studentId);

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return successful;
        }

        //Update Students
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //creating new student list
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
                    Student student = new Student
                    (
                        reader["Id"].ToString(),
                        reader["Name"].ToString(),
                        Convert.ToInt32(reader["Age"]),
                        reader["Gender"].ToString(),
                        reader["Telephone"].ToString(),
                        reader["City"].ToString()
                    );
                    studentlist.Add(student);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            return studentlist;
        }

        //---------------------------------------------------------------------------------------------
        // Code for Couses

        // Add Courses
        public bool AddCourse(Course course)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "INSERT INTO Courses(CourseID, CourseName, CourseHandout, CourseDeadline) VALUES(@CourseID, @CourseName, @CourseHandout, @CourseDeadline)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Addding para m eters
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseHandout", course.CourseHandout);
                cmd.Parameters.AddWithValue("@CourseDeadline", course.CourseDeadline);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    successful = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return successful;
        }


        // Update Courses
        public bool UpdateCourse(Course course)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "UPDATE Courses SET CourseName = @CourseName, CourseHandout = @CourseHandout, CourseDeadline = @CourseDeadline WHERE CourseID = @CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseHandout", course.CourseHandout);
                cmd.Parameters.AddWithValue("@CourseDeadline", course.CourseDeadline);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    successful = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return successful;
        }


        // Remove Course
        public bool RemoveCourse(string courseID)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "DELETE FROM Courses WHERE CourseID = @CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameter
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    successful = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return successful;
        }


        // Load Courses into a list
        public List<Course> LoadCourses()
        {
            List<Course> courseList = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT * FROM Courses";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course(
                        reader["CourseID"].ToString(),
                        reader["CourseName"].ToString(),
                        Convert.ToDateTime(reader["CourseHandout"]),
                        Convert.ToDateTime(reader["CourseDeadline"])
                    );

                    courseList.Add(course);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return courseList;
        }
    }
}
