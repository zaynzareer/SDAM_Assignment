
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Student : User
    {
        public List<Student> Students { get; set; }
        public Student(int id, string name, int age, string gender, int telephone, string city) :base(id, name, age, gender, telephone, city)
        {

        }
    }
}
