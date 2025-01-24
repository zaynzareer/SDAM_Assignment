
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
        public Student(string id, string name, int age, string gender, string telephone, string city) :base(id, name, age, gender, telephone, city)
        {   

        }
        
    }
}
