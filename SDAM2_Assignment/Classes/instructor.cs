using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SDAM2_Assignment.Classes
{
    internal class Instructor : User
    {
        public string Module { get; set; }

        public Instructor(string id, string name, int age, string gender, string telephone, string city, string module) : base(id,name, age, gender, telephone, city)
        {
            Module = module;
        }
    }
}
