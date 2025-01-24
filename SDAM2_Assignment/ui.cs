using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment
{
    public partial class ui : Form
    {
        public ui()
        {
            InitializeComponent();
        }

        private void ui_Load(object sender, EventArgs e)
        {

        }

        private void btnStudentsPage_Click(object sender, EventArgs e)
        {
            TEACHERstudents studentpage = new TEACHERstudents();
            studentpage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
