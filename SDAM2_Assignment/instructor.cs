using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment
{
    internal class Instructor : User
    {
        public string Module { get; set; }

        public Instructor(int id, string name, int age, string gender, int telephone, string city, string module) : base(id,name, age, gender, telephone, city)
        {
            Module = module;
        }
    }
}
