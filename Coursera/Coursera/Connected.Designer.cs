namespace Coursera
{
    partial class Connected
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
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.comboBoxCourses = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.EnrollBtn = new System.Windows.Forms.Button();
            this.ShowCoursesBtn = new System.Windows.Forms.Button();
            this.ShowStatusBtn = new System.Windows.Forms.Button();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(564, 42);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(189, 28);
            this.comboBoxUsers.TabIndex = 0;
            this.comboBoxUsers.Text = "Users";
            // 
            // comboBoxCourses
            // 
            this.comboBoxCourses.FormattingEnabled = true;
            this.comboBoxCourses.Location = new System.Drawing.Point(564, 104);
            this.comboBoxCourses.Name = "comboBoxCourses";
            this.comboBoxCourses.Size = new System.Drawing.Size(189, 28);
            this.comboBoxCourses.TabIndex = 1;
            this.comboBoxCourses.Text = "Courses";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(302, 396);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(181, 29);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "Student Status";
            // 
            // EnrollBtn
            // 
            this.EnrollBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.EnrollBtn.Location = new System.Drawing.Point(538, 241);
            this.EnrollBtn.Name = "EnrollBtn";
            this.EnrollBtn.Size = new System.Drawing.Size(227, 44);
            this.EnrollBtn.TabIndex = 3;
            this.EnrollBtn.Text = "Enroll";
            this.EnrollBtn.UseVisualStyleBackColor = false;
            this.EnrollBtn.Click += new System.EventHandler(this.EnrollBtn_Click);
            // 
            // ShowCoursesBtn
            // 
            this.ShowCoursesBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ShowCoursesBtn.Location = new System.Drawing.Point(538, 167);
            this.ShowCoursesBtn.Name = "ShowCoursesBtn";
            this.ShowCoursesBtn.Size = new System.Drawing.Size(227, 44);
            this.ShowCoursesBtn.TabIndex = 4;
            this.ShowCoursesBtn.Text = "Show Courses";
            this.ShowCoursesBtn.UseVisualStyleBackColor = false;
            this.ShowCoursesBtn.Click += new System.EventHandler(this.ShowCoursesBtn_Click);
            // 
            // ShowStatusBtn
            // 
            this.ShowStatusBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ShowStatusBtn.Location = new System.Drawing.Point(12, 391);
            this.ShowStatusBtn.Name = "ShowStatusBtn";
            this.ShowStatusBtn.Size = new System.Drawing.Size(227, 44);
            this.ShowStatusBtn.TabIndex = 5;
            this.ShowStatusBtn.Text = "Show Student Status";
            this.ShowStatusBtn.UseVisualStyleBackColor = false;
            this.ShowStatusBtn.Click += new System.EventHandler(this.ShowStatusBtn_Click);
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCourses.Location = new System.Drawing.Point(26, 42);
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.RowHeadersWidth = 62;
            this.dataGridViewCourses.RowTemplate.Height = 28;
            this.dataGridViewCourses.Size = new System.Drawing.Size(376, 260);
            this.dataGridViewCourses.TabIndex = 6;
            // 
            // Connected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewCourses);
            this.Controls.Add(this.ShowStatusBtn);
            this.Controls.Add(this.ShowCoursesBtn);
            this.Controls.Add(this.EnrollBtn);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.comboBoxCourses);
            this.Controls.Add(this.comboBoxUsers);
            this.Name = "Connected";
            this.Text = "Connected";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connected_FormClosing);
            this.Load += new System.EventHandler(this.Connected_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.ComboBox comboBoxCourses;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button EnrollBtn;
        private System.Windows.Forms.Button ShowCoursesBtn;
        private System.Windows.Forms.Button ShowStatusBtn;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
    }
}