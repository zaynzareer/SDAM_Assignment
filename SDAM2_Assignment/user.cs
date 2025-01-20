using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class User
    {
        int Id { get; set; }
        public string Name { get; set; } 
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Telephone { get; set; }

        //constructor
        public User(int id, string name, int age, string gender, int telephone)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Telephone = telephone;
        }
    }
}
