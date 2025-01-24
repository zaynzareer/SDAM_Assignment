using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseHandout { get; set; }
        public DateTime CourseDeadline { get; set; }
        public List<Course> Courses { get; set; }

        public Course(string courseID, string courseName, DateTime courseHandout, DateTime courseDeadline)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseHandout = courseHandout;
            CourseDeadline = courseDeadline;
        }
    }
}
