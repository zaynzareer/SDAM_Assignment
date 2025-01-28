using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Assignment
    {
        // Properties for Assignment
        public string AssignmentID { get; set; }
        public string AssignmentName { get; set; }
        public DateTime AssignmentHandout { get; set; }
        public DateTime AssignmentDeadline { get; set; }

        // Constructor
        public Assignment(string assignmentID, string assignmentName, DateTime assignmentHandout, DateTime assignmentDeadline)
        {
            AssignmentID = assignmentID;
            AssignmentName = assignmentName;
            AssignmentHandout = assignmentHandout;
            AssignmentDeadline = assignmentDeadline;
        }
    }
}
