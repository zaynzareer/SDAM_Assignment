namespace SDAM2_Assignment.Instructor
{
    partial class TeacherCourses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherCourses));
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnUpdateCourses = new System.Windows.Forms.Button();
            this.btnRemoveCourses = new System.Windows.Forms.Button();
            this.btnAddCourses = new System.Windows.Forms.Button();
            this.btnEnrollmentPage = new System.Windows.Forms.Button();
            this.btnStudentsPage = new System.Windows.Forms.Button();
            this.btnAssignmentPage = new System.Windows.Forms.Button();
            this.btnCoursePage = new System.Windows.Forms.Button();
            this.btnPerformanceReportPage = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnUpdateStudent1 = new System.Windows.Forms.Button();
            this.btnRemoveStudent1 = new System.Windows.Forms.Button();
            this.btnRegisterStudent1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCourseId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(309, 14);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(655, 36);
            this.button7.TabIndex = 100;
            this.button7.Text = "TEACHERS";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(0, -4);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(255, 69);
            this.dataGridView3.TabIndex = 98;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(289, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(915, 69);
            this.dataGridView2.TabIndex = 97;
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(289, 97);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.ReadOnly = true;
            this.dgvCourses.Size = new System.Drawing.Size(682, 193);
            this.dgvCourses.TabIndex = 101;
            this.dgvCourses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.btnclear);
            this.panel1.Controls.Add(this.btnUpdateCourses);
            this.panel1.Controls.Add(this.btnRemoveCourses);
            this.panel1.Controls.Add(this.btnAddCourses);
            this.panel1.Location = new System.Drawing.Point(287, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 80);
            this.panel1.TabIndex = 89;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(524, 25);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(137, 36);
            this.btnclear.TabIndex = 80;
            this.btnclear.Text = "CLEAR";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnUpdateCourses
            // 
            this.btnUpdateCourses.Location = new System.Drawing.Point(195, 25);
            this.btnUpdateCourses.Name = "btnUpdateCourses";
            this.btnUpdateCourses.Size = new System.Drawing.Size(137, 36);
            this.btnUpdateCourses.TabIndex = 34;
            this.btnUpdateCourses.Text = "UPDATE COURSES";
            this.btnUpdateCourses.UseVisualStyleBackColor = true;
            this.btnUpdateCourses.Click += new System.EventHandler(this.btnUpdateCourses_Click);
            // 
            // btnRemoveCourses
            // 
            this.btnRemoveCourses.Location = new System.Drawing.Point(360, 25);
            this.btnRemoveCourses.Name = "btnRemoveCourses";
            this.btnRemoveCourses.Size = new System.Drawing.Size(137, 36);
            this.btnRemoveCourses.TabIndex = 23;
            this.btnRemoveCourses.Text = "REMOVE COURSES";
            this.btnRemoveCourses.UseVisualStyleBackColor = true;
            this.btnRemoveCourses.Click += new System.EventHandler(this.btnRemoveCourses_Click);
            // 
            // btnAddCourses
            // 
            this.btnAddCourses.Location = new System.Drawing.Point(30, 25);
            this.btnAddCourses.Name = "btnAddCourses";
            this.btnAddCourses.Size = new System.Drawing.Size(137, 36);
            this.btnAddCourses.TabIndex = 79;
            this.btnAddCourses.Text = "ADD COURSES";
            this.btnAddCourses.UseVisualStyleBackColor = true;
            this.btnAddCourses.Click += new System.EventHandler(this.btnAddCourses_Click);
            // 
            // btnEnrollmentPage
            // 
            this.btnEnrollmentPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnEnrollmentPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnEnrollmentPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnrollmentPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnEnrollmentPage.Location = new System.Drawing.Point(1, 331);
            this.btnEnrollmentPage.Name = "btnEnrollmentPage";
            this.btnEnrollmentPage.Size = new System.Drawing.Size(230, 36);
            this.btnEnrollmentPage.TabIndex = 108;
            this.btnEnrollmentPage.Text = "ENROLLMENTS";
            this.btnEnrollmentPage.UseVisualStyleBackColor = false;
            this.btnEnrollmentPage.Click += new System.EventHandler(this.btnEnrollmentPage_Click);
            // 
            // btnStudentsPage
            // 
            this.btnStudentsPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnStudentsPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnStudentsPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentsPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnStudentsPage.Location = new System.Drawing.Point(0, 265);
            this.btnStudentsPage.Name = "btnStudentsPage";
            this.btnStudentsPage.Size = new System.Drawing.Size(230, 36);
            this.btnStudentsPage.TabIndex = 107;
            this.btnStudentsPage.Text = "STUDENTS";
            this.btnStudentsPage.UseVisualStyleBackColor = false;
            this.btnStudentsPage.Click += new System.EventHandler(this.btnStudentsPage_Click);
            // 
            // btnAssignmentPage
            // 
            this.btnAssignmentPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnAssignmentPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnAssignmentPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignmentPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnAssignmentPage.Location = new System.Drawing.Point(1, 401);
            this.btnAssignmentPage.Name = "btnAssignmentPage";
            this.btnAssignmentPage.Size = new System.Drawing.Size(230, 36);
            this.btnAssignmentPage.TabIndex = 106;
            this.btnAssignmentPage.Text = "ASSIGNMENTS";
            this.btnAssignmentPage.UseVisualStyleBackColor = false;
            this.btnAssignmentPage.Click += new System.EventHandler(this.btnAssignmentPage_Click);
            // 
            // btnCoursePage
            // 
            this.btnCoursePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnCoursePage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnCoursePage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCoursePage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnCoursePage.Location = new System.Drawing.Point(1, 196);
            this.btnCoursePage.Name = "btnCoursePage";
            this.btnCoursePage.Size = new System.Drawing.Size(230, 36);
            this.btnCoursePage.TabIndex = 105;
            this.btnCoursePage.Text = "COURSES";
            this.btnCoursePage.UseVisualStyleBackColor = false;
            this.btnCoursePage.Click += new System.EventHandler(this.btnCoursePage_Click);
            // 
            // btnPerformanceReportPage
            // 
            this.btnPerformanceReportPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnPerformanceReportPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnPerformanceReportPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerformanceReportPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnPerformanceReportPage.Location = new System.Drawing.Point(1, 468);
            this.btnPerformanceReportPage.Name = "btnPerformanceReportPage";
            this.btnPerformanceReportPage.Size = new System.Drawing.Size(230, 36);
            this.btnPerformanceReportPage.TabIndex = 104;
            this.btnPerformanceReportPage.Text = "PERFORMANCE REPORTS";
            this.btnPerformanceReportPage.UseVisualStyleBackColor = false;
            this.btnPerformanceReportPage.Click += new System.EventHandler(this.btnPerformanceReportPage_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnDashboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnDashboard.Location = new System.Drawing.Point(1, 131);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(230, 36);
            this.btnDashboard.TabIndex = 103;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(241, 526);
            this.dataGridView1.TabIndex = 102;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.panel4.Controls.Add(this.txtDuration);
            this.panel4.Controls.Add(this.txtDescription);
            this.panel4.Controls.Add(this.txtCourseName);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtCourseId);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Location = new System.Drawing.Point(289, 317);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(682, 159);
            this.panel4.TabIndex = 109;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(426, 49);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 91;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(426, 103);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(216, 41);
            this.txtDescription.TabIndex = 90;
            // 
            // txtCourseName
            // 
            this.txtCourseName.ForeColor = System.Drawing.Color.Black;
            this.txtCourseName.Location = new System.Drawing.Point(167, 99);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(100, 20);
            this.txtCourseName.TabIndex = 83;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.panel5.Controls.Add(this.btnUpdateStudent1);
            this.panel5.Controls.Add(this.btnRemoveStudent1);
            this.panel5.Controls.Add(this.btnRegisterStudent1);
            this.panel5.Location = new System.Drawing.Point(-2, 185);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(682, 80);
            this.panel5.TabIndex = 89;
            // 
            // btnUpdateStudent1
            // 
            this.btnUpdateStudent1.Location = new System.Drawing.Point(284, 25);
            this.btnUpdateStudent1.Name = "btnUpdateStudent1";
            this.btnUpdateStudent1.Size = new System.Drawing.Size(137, 36);
            this.btnUpdateStudent1.TabIndex = 34;
            this.btnUpdateStudent1.Text = "UPDATE COURSES";
            this.btnUpdateStudent1.UseVisualStyleBackColor = true;
            // 
            // btnRemoveStudent1
            // 
            this.btnRemoveStudent1.Location = new System.Drawing.Point(489, 25);
            this.btnRemoveStudent1.Name = "btnRemoveStudent1";
            this.btnRemoveStudent1.Size = new System.Drawing.Size(137, 36);
            this.btnRemoveStudent1.TabIndex = 23;
            this.btnRemoveStudent1.Text = "REMOVE COURSES";
            this.btnRemoveStudent1.UseVisualStyleBackColor = true;
            // 
            // btnRegisterStudent1
            // 
            this.btnRegisterStudent1.Location = new System.Drawing.Point(77, 25);
            this.btnRegisterStudent1.Name = "btnRegisterStudent1";
            this.btnRegisterStudent1.Size = new System.Drawing.Size(137, 36);
            this.btnRegisterStudent1.TabIndex = 79;
            this.btnRegisterStudent1.Text = "ADD COURSES";
            this.btnRegisterStudent1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(75, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Course ID";
            // 
            // txtCourseId
            // 
            this.txtCourseId.ForeColor = System.Drawing.Color.Black;
            this.txtCourseId.Location = new System.Drawing.Point(167, 49);
            this.txtCourseId.Name = "txtCourseId";
            this.txtCourseId.Size = new System.Drawing.Size(100, 20);
            this.txtCourseId.TabIndex = 81;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(75, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 82;
            this.label11.Text = "Course Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(342, 106);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 84;
            this.label12.Text = "Description";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(355, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 86;
            this.label14.Text = "Duration";
            // 
            // TeacherCourses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(989, 621);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnEnrollmentPage);
            this.Controls.Add(this.btnStudentsPage);
            this.Controls.Add(this.btnAssignmentPage);
            this.Controls.Add(this.btnCoursePage);
            this.Controls.Add(this.btnPerformanceReportPage);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "TeacherCourses";
            this.Text = "TeacherCourses";
            this.Load += new System.EventHandler(this.TeacherCourses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUpdateCourses;
        private System.Windows.Forms.Button btnRemoveCourses;
        private System.Windows.Forms.Button btnAddCourses;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnEnrollmentPage;
        private System.Windows.Forms.Button btnStudentsPage;
        private System.Windows.Forms.Button btnAssignmentPage;
        private System.Windows.Forms.Button btnCoursePage;
        private System.Windows.Forms.Button btnPerformanceReportPage;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnUpdateStudent1;
        private System.Windows.Forms.Button btnRemoveStudent1;
        private System.Windows.Forms.Button btnRegisterStudent1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCourseId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
    }
}