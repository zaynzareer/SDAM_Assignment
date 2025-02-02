using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment.Classes
{
    internal class Assignment
    {
        // Properties for Assignment
        public string AssignmentID { get; set; }
        public string AssignmentName { get; set; }
        public DateTime? AssignmentHandout { get; set; }
        public DateTime? AssignmentDeadline { get; set; }
        public string CourseID { get; set; }

        public DateTime? SubmissionDate { get; set; }
        public string SubmissionFilePath { get; set; }

        public Assignment(string assignmentID, string assignmentName, DateTime? assignmentHandout, DateTime? assignmentDeadline, string courseID)
        {
            AssignmentID = assignmentID;
            AssignmentName = assignmentName;
            AssignmentHandout = assignmentHandout;
            AssignmentDeadline = assignmentDeadline;
            CourseID = courseID;
        }

        public Assignment(string assignmentID, string assignmentName, DateTime? assignmentHandout, DateTime? assignmentDeadline)
        {
            AssignmentID = assignmentID;
            AssignmentName = assignmentName;
            AssignmentHandout = assignmentHandout;
            AssignmentDeadline = assignmentDeadline;
        }
        // Constructor for submission details
        public Assignment(string assignmentID, string assignmentName, DateTime? assignmentHandout, DateTime? assignmentDeadline, DateTime? submissionDate, string submissionFilePath)
        {
            AssignmentID = assignmentID;
            AssignmentName = assignmentName;
            AssignmentHandout = assignmentHandout;
            AssignmentDeadline = assignmentDeadline;
            SubmissionDate = submissionDate;
            SubmissionFilePath = submissionFilePath;
        }
    }
}
