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
                string sql = "INSERT INTO Courses(CourseID, CourseName, CourseDuration, CourseDescription) VALUES(@CourseID, @CourseName, @CourseDuration, @CourseDescription)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Addding para m eters
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseDuration", course.Duration);
                cmd.Parameters.AddWithValue("@CourseDescription", course.Description);

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
                string sql = "UPDATE Courses SET CourseName = @CourseName, CourseDuration = @CourseDuration, CourseDescription = @CourseDescription WHERE CourseID = @CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@CourseID", course.CourseID);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseDuration", course.Duration);
                cmd.Parameters.AddWithValue("@CourseDescription", course.Description);

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
                        reader["CourseDuration"].ToString(),
                        reader["CourseDescription"].ToString()
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

        //---------------------------------------------------------------------------------------------
        // Code for Enrollment

        //Update Enrollment 
        public bool UpdateEnrollment(string enrollmentid, string status)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "Update Enrollments SET Status = @Status WHERE EnrollmentID = @EnrollmentID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Adding parameters
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@EnrollmentID", enrollmentid);

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

        //load enrollments
        public List<Enrollment> LoadEnrollments()
        {
            List<Enrollment> enrollmentlist = new List<Enrollment>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT * FROM Enrollments";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment(
                        reader["EnrollmentID"].ToString(),
                        reader["StudentID"].ToString(),
                        reader["StudentName"].ToString(),
                        reader["Course"].ToString(),
                        Convert.ToDateTime(reader["EnrollmentDate"]),
                        reader["Status"].ToString()
                    );
                    enrollmentlist.Add( enrollment );
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
            return enrollmentlist;
        }


        //---------------------------------------------------------------------------------------------
        // Code for ASSIGNMENTS

        // Create Assignment
        public bool CreateAssignment(Assignment assignment)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "INSERT INTO Assignments (AssignmentID, AssignmentName, AssignmentHandout, AssignmentDeadline) " +
                                "VALUES (@AssignmentID, @AssignmentName, @AssignmentHandout, @AssignmentDeadline)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@AssignmentHandout", assignment.AssignmentHandout);
                cmd.Parameters.AddWithValue("@AssignmentDeadline", assignment.AssignmentDeadline);

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

        // Update Assignment
        public bool UpdateAssignment(Assignment assignment)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);
            
            try
            {
                string sql = "UPDATE Assignments SET AssignmentName = @AssignmentName, AssignmentHandout = @AssignmentHandout, " +
                                "AssignmentDeadline = @AssignmentDeadline WHERE AssignmentID = @AssignmentID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@AssignmentHandout", assignment.AssignmentHandout);
                cmd.Parameters.AddWithValue("@AssignmentDeadline", assignment.AssignmentDeadline);

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

        // Remove Assignment
        public bool RemoveAssignment(string assignmentID)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);
            
            try
            {
                string sql = "DELETE FROM Assignments WHERE AssignmentID = @AssignmentID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameter
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentID);

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

        // Load Assignments into a list
        public List<Assignment> LoadAssignments()
        {
            List<Assignment> assignmentList = new List<Assignment>();
            SqlConnection conn = new SqlConnection(connectionString);
            
            try
            {
                string sql = "SELECT * FROM Assignments";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Assignment assignment = new Assignment(
                        reader["AssignmentID"].ToString(),
                        reader["AssignmentName"].ToString(),
                        Convert.ToDateTime(reader["AssignmentHandout"]),
                        Convert.ToDateTime(reader["AssignmentDeadline"])
                    );

                    assignmentList.Add(assignment);
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
            return assignmentList;
        }
    }
}
