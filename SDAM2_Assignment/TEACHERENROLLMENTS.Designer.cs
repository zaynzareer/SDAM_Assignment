namespace SDAM2_Assignment
{
    partial class TEACHERENROLLMENTS 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TEACHERENROLLMENTS));
            this.dgvEnrollment = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnEnrollmentPage = new System.Windows.Forms.Button();
            this.btnStudentsPage = new System.Windows.Forms.Button();
            this.btnAssignmentPage = new System.Windows.Forms.Button();
            this.btnCoursePage = new System.Windows.Forms.Button();
            this.btnPerformanceReportPage = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEnrollment
            // 
            this.dgvEnrollment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollment.Location = new System.Drawing.Point(271, 108);
            this.dgvEnrollment.Name = "dgvEnrollment";
            this.dgvEnrollment.ReadOnly = true;
            this.dgvEnrollment.Size = new System.Drawing.Size(682, 193);
            this.dgvEnrollment.TabIndex = 42;
            this.dgvEnrollment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnrollment_CellClick);
            // 
            // btnApprove
            // 
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApprove.Location = new System.Drawing.Point(310, 330);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(143, 36);
            this.btnApprove.TabIndex = 40;
            this.btnApprove.Text = "APPROVE STUDENT";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReject.Location = new System.Drawing.Point(757, 330);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(137, 36);
            this.btnReject.TabIndex = 39;
            this.btnReject.Text = "REJECT STUDENT";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(310, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(655, 36);
            this.button7.TabIndex = 38;
            this.button7.Text = "TEACHERS";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(1, -17);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(255, 69);
            this.dataGridView3.TabIndex = 31;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(289, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(915, 69);
            this.dataGridView2.TabIndex = 30;
            // 
            // btnEnrollmentPage
            // 
            this.btnEnrollmentPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.btnEnrollmentPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(58)))), ((int)(((byte)(141)))));
            this.btnEnrollmentPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnrollmentPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.btnEnrollmentPage.Location = new System.Drawing.Point(2, 312);
            this.btnEnrollmentPage.Name = "btnEnrollmentPage";
            this.btnEnrollmentPage.Size = new System.Drawing.Size(230, 36);
            this.btnEnrollmentPage.TabIndex = 49;
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
            this.btnStudentsPage.Location = new System.Drawing.Point(1, 246);
            this.btnStudentsPage.Name = "btnStudentsPage";
            this.btnStudentsPage.Size = new System.Drawing.Size(230, 36);
            this.btnStudentsPage.TabIndex = 48;
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
            this.btnAssignmentPage.Location = new System.Drawing.Point(2, 382);
            this.btnAssignmentPage.Name = "btnAssignmentPage";
            this.btnAssignmentPage.Size = new System.Drawing.Size(230, 36);
            this.btnAssignmentPage.TabIndex = 47;
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
            this.btnCoursePage.Location = new System.Drawing.Point(2, 177);
            this.btnCoursePage.Name = "btnCoursePage";
            this.btnCoursePage.Size = new System.Drawing.Size(230, 36);
            this.btnCoursePage.TabIndex = 46;
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
            this.btnPerformanceReportPage.Location = new System.Drawing.Point(2, 449);
            this.btnPerformanceReportPage.Name = "btnPerformanceReportPage";
            this.btnPerformanceReportPage.Size = new System.Drawing.Size(230, 36);
            this.btnPerformanceReportPage.TabIndex = 45;
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
            this.btnDashboard.Location = new System.Drawing.Point(2, 112);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(230, 36);
            this.btnDashboard.TabIndex = 44;
            this.btnDashboard.Text = "DASHBOARD";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(241, 526);
            this.dataGridView1.TabIndex = 43;
            // 
            // TEACHERENROLLMENTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(991, 600);
            this.Controls.Add(this.btnEnrollmentPage);
            this.Controls.Add(this.btnStudentsPage);
            this.Controls.Add(this.btnAssignmentPage);
            this.Controls.Add(this.btnCoursePage);
            this.Controls.Add(this.btnPerformanceReportPage);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvEnrollment);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "TEACHERENROLLMENTS";
            this.Text = "ENROLLMENTS";
            this.Load += new System.EventHandler(this.TEACHERENROLLMENTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEnrollment;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnEnrollmentPage;
        private System.Windows.Forms.Button btnStudentsPage;
        private System.Windows.Forms.Button btnAssignmentPage;
        private System.Windows.Forms.Button btnCoursePage;
        private System.Windows.Forms.Button btnPerformanceReportPage;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}