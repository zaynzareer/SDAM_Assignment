using SDAM2_Assignment.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment.Classes
{
    internal class SessionManager
    {
        public static Student LoggedInStudent { get; private set; }

        // Method to set the logged-in student
        public static void SetLoggedInStudent(Student student)
        {
            LoggedInStudent = student;
        }

        // Method to clear session
        public static void ClearSessionManager()
        {
            LoggedInStudent = null;
        }
    }
}
