using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sql;
using SDAM2_Assignment.Students;

namespace SDAM2_Assignment.Classes
{
    internal class DatabaseHelper
    {
        private string connectionString { get; }
        
        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AzureSqlConnection"].ConnectionString;
        }

        //Add Students
        public bool AddStudent(Student student, string username, string password)
        {
            bool successful = false;
            //establish new sql connection
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                // Start a transaction
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                // Insert into Students table
                string sqlStudent = "INSERT INTO Students(Id, Name, Age, Gender, Telephone, City) VALUES(@Id, @Name, @Age, @Gender, @Telephone, @City)";
                SqlCommand cmdStudent = new SqlCommand(sqlStudent, conn, transaction);
                cmdStudent.Parameters.AddWithValue("@Id", student.Id);
                cmdStudent.Parameters.AddWithValue("@Name", student.Name);
                cmdStudent.Parameters.AddWithValue("@Age", student.Age);
                cmdStudent.Parameters.AddWithValue("@Gender", student.Gender);
                cmdStudent.Parameters.AddWithValue("@Telephone", student.Telephone);
                cmdStudent.Parameters.AddWithValue("@City", student.City);

                int studentRows = cmdStudent.ExecuteNonQuery();

                if (studentRows > 0)
                {
                    // Insert into Credentials table
                    string sqlCredentials = "INSERT INTO Credentials(StudentId, Usernames, Passwords) VALUES(@StudentId, @Usernames, @Passwords)";
                    SqlCommand cmdCredentials = new SqlCommand(sqlCredentials, conn, transaction);
                    cmdCredentials.Parameters.AddWithValue("@StudentId", student.Id);
                    cmdCredentials.Parameters.AddWithValue("@Usernames", username);
                    cmdCredentials.Parameters.AddWithValue("@Passwords", password);

                    int credentialRows = cmdCredentials.ExecuteNonQuery();

                    if (credentialRows > 0)
                    {
                        successful = true;
                    }
                }
                // Commit the transaction
                transaction.Commit();
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
                // Start a transaction
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                // Delete from Credentials table
                string sqlCredentials = "DELETE FROM Credentials WHERE StudentId = @StudentId";
                SqlCommand cmdCredentials = new SqlCommand(sqlCredentials, conn, transaction);
                cmdCredentials.Parameters.AddWithValue("@StudentId", studentId);

                int credentialRows = cmdCredentials.ExecuteNonQuery();

                // Delete from Students table
                string sqlStudents = "DELETE FROM Students WHERE Id = @Id";
                SqlCommand cmdStudents = new SqlCommand(sqlStudents, conn, transaction);
                cmdStudents.Parameters.AddWithValue("@Id", studentId);

                int studentRows = cmdStudents.ExecuteNonQuery();

                // Check if both deletions were successful
                if (credentialRows > 0 && studentRows > 0)
                {
                    successful = true;
                    transaction.Commit(); // Commit the transaction if both deletions were successful
                }
                else
                {
                    transaction.Rollback(); // Rollback the transaction if any deletion failed
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
        public bool UpdateStudent(Student student, string username)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                // Start a transaction
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                // Update Students table
                string sqlStudent = "UPDATE Students SET Name = @Name, Age = @Age, Gender = @Gender, Telephone = @Telephone, City = @City WHERE Id = @Id";
                SqlCommand cmdStudent = new SqlCommand(sqlStudent, conn, transaction);

                cmdStudent.Parameters.AddWithValue("@Id", student.Id);
                cmdStudent.Parameters.AddWithValue("@Name", student.Name);
                cmdStudent.Parameters.AddWithValue("@Age", student.Age);
                cmdStudent.Parameters.AddWithValue("@Gender", student.Gender);
                cmdStudent.Parameters.AddWithValue("@Telephone", student.Telephone);
                cmdStudent.Parameters.AddWithValue("@City", student.City);

                int studentRows = cmdStudent.ExecuteNonQuery();

                // Update Credentials table
                string sqlCredentials = "UPDATE Credentials SET Usernames = @Username WHERE StudentId = @StudentId";
                SqlCommand cmdCredentials = new SqlCommand(sqlCredentials, conn, transaction);
                cmdCredentials.Parameters.AddWithValue("@Username", username);
                cmdCredentials.Parameters.AddWithValue("@StudentId", student.Id);

                int credentialRows = cmdCredentials.ExecuteNonQuery();

                // Check if both updates were successful
                if (studentRows > 0 && credentialRows > 0)
                {
                    successful = true;
                }

                // Commit the transaction
                transaction.Commit();
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
                        reader["Status"].ToString(),
                        0,
                        "",
                        ""
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
                string sql = "INSERT INTO Assignments (AssignmentID, AssignmentName, AssignmentHandout, AssignmentDeadline, CourseID) " +
                                "VALUES (@AssignmentID, @AssignmentName, @AssignmentHandout, @AssignmentDeadline, @CourseID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@AssignmentHandout", assignment.AssignmentHandout);
                cmd.Parameters.AddWithValue("@AssignmentDeadline", assignment.AssignmentDeadline);
                cmd.Parameters.AddWithValue("@CourseID", assignment.CourseID);

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
                                "AssignmentDeadline = @AssignmentDeadline, CourseID = @CourseID WHERE AssignmentID = @AssignmentID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Add parameters
                cmd.Parameters.AddWithValue("@AssignmentID", assignment.AssignmentID);
                cmd.Parameters.AddWithValue("@AssignmentName", assignment.AssignmentName);
                cmd.Parameters.AddWithValue("@AssignmentHandout", assignment.AssignmentHandout);
                cmd.Parameters.AddWithValue("@AssignmentDeadline", assignment.AssignmentDeadline);
                cmd.Parameters.AddWithValue("@CourseID", assignment.CourseID);

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
                        Convert.ToDateTime(reader["AssignmentDeadline"]),
                        reader["CourseID"].ToString()
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

        //---------------------------------------------------------------------------------------------
        //Code for Performance

        //Get student performance info
        public List<Performance> GetStudentPerformance()
        {
            List<Performance> performanceList = new List<Performance>();
            SqlConnection conn = new SqlConnection(connectionString);
   
            try
            {
                string sql = @"
                SELECT e.StudentID, 
                        s.Name, 
                        e.Course, 
                        e.Progress, 
                        e.CompletionStatus 
                FROM Enrollments e 
                JOIN Students s ON e.StudentID = s.Id";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Performance performance = new Performance
                    {
                        StudentID = reader["StudentID"].ToString(),
                        StudentName = reader["Name"].ToString(),
                        Course = reader["Course"].ToString(),
                        Progress = Convert.ToInt32(reader["Progress"]),
                        CompletionStatus = reader["CompletionStatus"].ToString()
                    };
                    performanceList.Add(performance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return performanceList;
        }
        public List<Performance> GetStudentPerformance(string studentId)
        {
            List<Performance> performanceList = new List<Performance>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = @"
                SELECT e.StudentID, 
                        s.Name, 
                        e.Course, 
                        e.Progress, 
                        e.CompletionStatus 
                FROM Enrollments e 
                JOIN Students s ON e.StudentID = s.Id 
                WHERE e.StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Performance performance = new Performance
                    {
                        StudentID = reader["StudentID"].ToString(),
                        StudentName = reader["Name"].ToString(),
                        Course = reader["Course"].ToString(),
                        Progress = Convert.ToInt32(reader["Progress"]),
                        CompletionStatus = reader["CompletionStatus"].ToString()
                    };
                    performanceList.Add(performance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return performanceList;
        }
    }
}
