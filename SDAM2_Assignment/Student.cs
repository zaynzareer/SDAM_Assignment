
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Student : User
    {
        public Student(int id, string name, int age, string gender, int telephone) :base(id, name, age, gender, telephone)
        {

        }
    }
}
