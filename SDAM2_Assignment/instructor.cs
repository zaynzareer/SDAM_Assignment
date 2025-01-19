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

        public Instructor(string name, int age, string gender, int telephone, string module) : base(name, age, gender, telephone)
        {
            Module = module;
        }
    }
}
