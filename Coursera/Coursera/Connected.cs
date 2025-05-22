using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursera
{
    public partial class Connected : Form
    {

        OracleConnection conn;

        public Connected()
        {
            InitializeComponent();
        }

        private void Connected_Load(object sender, EventArgs e)
        {
            string connStr = "Data Source=ORCL;User ID=hr;Password=hr";
            conn = new OracleConnection(connStr);
            conn.Open();
            LoadUsers();
            LoadCourses();
        }


        void LoadUsers()
        {
            OracleCommand cmd = new OracleCommand("SELECT user_id,FULL_NAME FROM Coursera_Users", conn);
            OracleDataReader dr = cmd.ExecuteReader();
            comboBoxUsers.Items.Add(new
            {
                Id = "0",
                Name = "Select User"
            });
            while (dr.Read())
            {
                comboBoxUsers.Items.Add(new
                {
                    Id = dr["user_id"].ToString(),
                    Name = dr["full_name"].ToString()
                });
            }
            dr.Close();
            comboBoxUsers.SelectedIndex = 0;
            comboBoxUsers.DisplayMember = "Name";
            comboBoxUsers.ValueMember = "Id";
        }

        void LoadCourses()
        {
            OracleCommand cmd = new OracleCommand("SELECT course_id, title FROM Coursera_Courses", conn);
            OracleDataReader dr = cmd.ExecuteReader();
            comboBoxCourses.Items.Add(new
            {
                Id = "0",
                Title = "Select Course"
            });

            while (dr.Read())
            {
                comboBoxCourses.Items.Add(new {
                    Id = dr["course_id"].ToString(),
                    Title = dr["title"].ToString()
                });
            }
            dr.Close();
            comboBoxCourses.SelectedIndex = 0;
            comboBoxCourses.DisplayMember = "title";
            comboBoxCourses.ValueMember= "Id";
        }



      

        private void Connected_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void ShowCoursesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic selectedUser= comboBoxUsers.SelectedItem;

                int userId = Convert.ToInt32(selectedUser.Id);
                if (comboBoxUsers.SelectedIndex == 0)
                    {
                    MessageBox.Show("Please select a user first.");
                    return;
                }
                OracleCommand cmd = new OracleCommand("Get_Student_Courses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;

                OracleParameter outParam = new OracleParameter("p_result", OracleDbType.RefCursor);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                OracleDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewCourses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR !!.. " + ex.Message);
            }

        }

        private void ShowStatusBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic selectedUser = comboBoxUsers.SelectedItem;
                int userId = Convert.ToInt32(selectedUser.Id);
                dynamic selectedCourse = comboBoxCourses.SelectedItem;
                int courseId = Convert.ToInt32(selectedCourse.Id);

                if (comboBoxUsers.SelectedIndex==0|| comboBoxCourses.SelectedIndex ==0 )
                {
                    MessageBox.Show("Please select both a user and a course.");
                    return;
                }

                OracleCommand cmd = new OracleCommand("Get_Enrollment_Status", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("p_user_id", OracleDbType.Int32).Value = userId;
                cmd.Parameters.Add("p_course_id", OracleDbType.Int32).Value = courseId;


                OracleParameter outParam = new OracleParameter("p_status", OracleDbType.Varchar2, 50);
                outParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                labelStatus.Text = "Status: " + (outParam.Value != null ? outParam.Value.ToString() : "Not enrolled");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message);
            }

        }

        private void EnrollBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic selectedUser = comboBoxUsers.SelectedItem;
                int userId = Convert.ToInt32(selectedUser.Id);
                dynamic selectedCourse = comboBoxCourses.SelectedItem;
                int courseId = Convert.ToInt32(selectedCourse.Id);

                string q1 = "SELECT Count(*) FROM Coursera_Enrollments WHERE user_id = :u  AND course_id = :c";
                OracleCommand checkDuplicate = new OracleCommand(q1, conn);

                checkDuplicate.Parameters.Add("u", OracleDbType.Int32).Value = userId;
                checkDuplicate.Parameters.Add("c", OracleDbType.Int32).Value = courseId;
                
                int x = Convert.ToInt32(checkDuplicate.ExecuteScalar());
                if (x>=1)
                {
                    MessageBox.Show("this user is aleady enrolled in this course");
                    return;
                }


                string q2 = "INSERT INTO Coursera_Enrollments (user_id, course_id, enrollment_date) " +
                                     "VALUES (:userParam, :courseParam, SYSDATE)";
                OracleCommand cmd = new OracleCommand(q2, conn);
                {
                    cmd.Parameters.Add("userParam", OracleDbType.Int32).Value = userId;
                    cmd.Parameters.Add("courseParam", OracleDbType.Int32).Value = courseId;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Enrolled successfully!");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
