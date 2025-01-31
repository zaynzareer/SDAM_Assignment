using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Enrollment
    {
        public string EnrollmentId { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public Enrollment(string enrollmentId, string studentId, string studentName, string course, DateTime enrollmentDate, string status)
        {
            EnrollmentId = enrollmentId;
            StudentId = studentId;
            StudentName = studentName;
            Course = course;
            EnrollmentDate = enrollmentDate;
            Status = status;
        }
    }
}
