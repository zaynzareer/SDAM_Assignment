using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.Data.Sql;
using System.Data.SqlClient;

namespace SDAM2_Assignment.Classes
{
    internal class StudentDatabaseHelper
    {
        private string connectionString { get; }

        public StudentDatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AzureSqlConnection"].ConnectionString;
        }


        //---------------------------------------------------------------------------------------------
        // Code for Courses

        // Load Available Courses for Students
        public List<Course> LoadAvailableCourses()
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

        // Enroll Student in a Course
        public bool EnrollStudent(Enrollment enrollment)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = "INSERT INTO Enrollments (EnrollmentID, StudentID, StudentName, Course, EnrollmentDate, Status, Progress, CompletionStatus, CourseID) " +
                                "VALUES (@EnrollmentID, @StudentID, @StudentName, @Course, @EnrollmentDate, @Status, @Progress, @CompletionStatus, @CourseID)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@EnrollmentID", enrollment.EnrollmentId);
                cmd.Parameters.AddWithValue("@StudentID", enrollment.StudentId);
                cmd.Parameters.AddWithValue("@StudentName", enrollment.StudentName);
                cmd.Parameters.AddWithValue("@Course", enrollment.Course);
                cmd.Parameters.AddWithValue("@EnrollmentDate", enrollment.EnrollmentDate);
                cmd.Parameters.AddWithValue("@Status", enrollment.Status);
                cmd.Parameters.AddWithValue("@Progress", enrollment.Progress);
                cmd.Parameters.AddWithValue("@CompletionStatus", enrollment.CompletionStatus);
                cmd.Parameters.AddWithValue("@CourseID", enrollment.CourseID);

                conn.Open();
                success = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }


        //---------------------------------------------------------------------------------------------
        // Code for Enrollment


        // Drop a Course Enrollment
        public bool DropEnrollment(string studentID, string courseID)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "DELETE FROM Enrollments WHERE StudentID = @StudentID AND CourseID = @CourseID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@StudentID", studentID);
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

        // Load Enrolled Courses for a Student
        public List<Course> LoadEnrolledCourses(string studentID)
        {
            List<Course> enrolledCourses = new List<Course>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT c.CourseID, c.CourseName, c.CourseDuration, c.CourseDescription " +
                             "FROM Enrollments e JOIN Courses c ON e.CourseID = c.CourseID " +
                             "WHERE e.StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

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
                    enrolledCourses.Add(course);
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

            return enrolledCourses;
        }



        //---------------------------------------------------------------------------------------------
        // Code for Assignment

        // Submit an Assignment
        public bool SubmitAssignment(string studentID, string courseID, string assignmentid, string submissionFilePath)
        {
            bool successful = false;
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "INSERT INTO Submissions(SubmissionID, StudentID, CourseID, AssignmentID, SubmissionDate, SubmissionFilePath) " +
                             "VALUES(@SubmissionID, @StudentID, @CourseID, @AssignmentID, @SubmissionDate, @SubmissionFilePath)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@SubmissionID", GetNextSubmissionId());
                cmd.Parameters.AddWithValue("@StudentID", studentID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentid);
                cmd.Parameters.AddWithValue("@SubmissionDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@SubmissionFilePath", submissionFilePath);

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

        public void UpdateProgress(string studentId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = @"
                UPDATE Enrollments 
                SET Progress = 
                    CASE 
                        WHEN (SELECT COUNT(*) FROM Assignments) > 0 THEN 
                            (SELECT COUNT(*) * 100 / (SELECT COUNT(*) FROM Assignments) 
                             FROM Submissions 
                             WHERE StudentID = @StudentID)
                        ELSE 0
                    END,
                    CompletionStatus = CASE 
                        WHEN (SELECT COUNT(*) FROM Submissions WHERE StudentID = @StudentID) = 
                             (SELECT COUNT(*) FROM Assignments) THEN 'Completed' 
                        ELSE 'In Progress' 
                    END
                WHERE StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load Assignments for a Student
        public List<Assignment> LoadAssignments(string studentID)
        {
            List<Assignment> assignmentList = new List<Assignment>();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT a.AssignmentID, a.AssignmentName, a.AssignmentHandout, a.AssignmentDeadline, e.CourseID " +
                             "FROM Assignments a " +
                             "JOIN Enrollments e ON a.CourseID = e.CourseID " +
                             "WHERE e.StudentID = @StudentID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

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
        // Code for Performance

        public List<Enrollment> GetStudentProgress(string studentId)
        {
            List<Enrollment> enrollmentList = new List<Enrollment>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = @"
                SELECT e.Course, 
                       e.Progress, 
                       e.CompletionStatus 
                FROM Enrollments e 
                WHERE e.StudentID = @StudentID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Enrollment enrollment = new Enrollment(
                        "", // Enrollment ID (if needed)
                        studentId,
                        "", // Student Name (if needed)
                        reader["Course"].ToString(),
                        DateTime.MinValue, // Enrollment Date (if needed)
                        "", // Status (if needed)
                        Convert.ToInt32(reader["Progress"]),
                        reader["CompletionStatus"].ToString(),
                        ""
                    );
                    enrollmentList.Add(enrollment);
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
            return enrollmentList;
        }


        //---------------------------------------------------------------------------------------------
        //Codes for auto generating ID 

        //For Enrollment ID
        public string GetNextEnrollmentId()
        {
            string nextId = "E001"; // Default ID if no enrollments exist
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT TOP 1 EnrollmentID FROM Enrollments ORDER BY EnrollmentID DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int numericPart = int.Parse(lastId.Substring(1)); // Get the numeric part
                    nextId = "E" + (numericPart + 1).ToString("D3"); // Increment and format
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

            return nextId;
        }

        //For Submission ID
        public string GetNextSubmissionId()
        {
            string nextId = "Su001"; // Default ID if no submissions exist
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string sql = "SELECT TOP 1 SubmissionID FROM Submission ORDER BY SubmissionID DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastId = result.ToString();
                    int numericPart = int.Parse(lastId.Substring(1)); // Get the numeric part
                    nextId = "Su" + (numericPart + 1).ToString("D3"); // Increment and format
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

            return nextId;
        }

    }
}
