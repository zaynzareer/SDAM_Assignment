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
        public string Duration { get; set; }
        public string Description { get; set; }
        public List<Course> Courses { get; set; }

        public Course(string courseID, string courseName, string duration, string description)
        {
            CourseID = courseID;
            CourseName = courseName;
            Duration = duration;
            Description = description;
        }
    }
}
