using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Coursera
{
    public partial class frmEditCourses : Form
    {
        string constr = "User Id=hr;Password=hr;Data Source=orcl";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet set;

        string user_id = "";
        string fullName = "";

        public frmEditCourses()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(constr);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q1 = @"SELECT user_id, Full_Name FROM coursera_users 
                         WHERE email = :email AND Pass = :pass";

            OracleCommand cmd = new OracleCommand(q1, conn);
            cmd.Parameters.Add("email", txtEmail.Text);
            cmd.Parameters.Add("pass", txtPassword.Text);

            OracleDataReader reader = cmd.ExecuteReader();

            user_id = "";
            fullName = "";

            while (reader.Read())
            {
                user_id = reader[0].ToString();
                fullName = reader[1].ToString();
            }

            reader.Close();

            if (user_id == "")
            {
                MessageBox.Show("Incorrect Email Or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.DataSource = null;
                txtInstructor.Text = "";
                return;
            }

            string q2 = @"SELECT * FROM coursera_courses
                             WHERE instructor_id = :instructorId";



            adapter = new OracleDataAdapter(q2, conn);
            adapter.SelectCommand.Parameters.Add("instructorId", user_id);

            set = new DataSet();
            adapter.Fill(set);


            txtInstructor.Text = fullName;
            dataGridView1.DataSource = set.Tables[0];

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                builder = new OracleCommandBuilder(adapter);
                adapter.Update(set.Tables[0]);
                MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.Dispose();
            }

        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[5].Value = user_id;
        }

        private void frmEditCourses_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exist_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
