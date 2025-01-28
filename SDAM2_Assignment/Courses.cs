using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDAM2_Assignment
{
    public class Course
    {//methods for desinger in the teacher courses 
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseHandout { get; set; }
        public string CourseDeadline { get; set; }

        public Course(int courseID, string courseName, int courseHandout, string courseDeadline)
        {
            CourseID = courseID;
            CourseName = courseName;
            CourseHandout = courseHandout;
            CourseDeadline = courseDeadline;
        }
    }
}