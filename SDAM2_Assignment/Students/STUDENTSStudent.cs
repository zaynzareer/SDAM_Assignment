using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDAM2_Assignment.Students
{
    public partial class STUDENTSStudent : Form
    {
        public STUDENTSStudent()
        {
            InitializeComponent();
        }

        private void btnDashboard1_Click(object sender, EventArgs e)
        {
            STUDENTSUI studentsui = new STUDENTSUI();
            studentsui.Show();
            this.Hide();
        }

        private void btnCoursePage1_Click(object sender, EventArgs e)
        {
            STUDENTCourses Cui = new STUDENTCourses();
            Cui.Show();
            this.Hide();
        }

        private void btnStudentsPage1_Click(object sender, EventArgs e)
        {
            STUDENTSStudent SSui = new STUDENTSStudent();
            SSui.Show();
            this.Hide();
        }


        private void btnEnrollmentPage1_Click(object sender, EventArgs e)
        {
            STUDENTEnrollment SEui = new STUDENTEnrollment();
            SEui.Show();
            this.Hide();
        }

        private void btnAssignmentPage1_Click(object sender, EventArgs e)
        {
            STUDENTAssignment SAui = new STUDENTAssignment();
            SAui.Show();
            this.Hide();
        }

        private void btnPerformanceReportPage1_Click(object sender, EventArgs e)
        {
            STUDENTPerformance SPui = new STUDENTPerformance();
            SPui.Show();
            this.Hide();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {

        }
    }
}