using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Coursera
{
    public partial class theMainForm : Form
    {
        public theMainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connected connectedMode= new Connected();
            connectedMode.Show();
        }

        private void btnDisConnectedMod_Click(object sender, EventArgs e)
        {
            frmEditCourses instructors = new frmEditCourses();
            instructors.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            report report1 = new report();
            report1.Show();
        }

        private void exist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCrystalReport_Click(object sender, EventArgs e)
        {
            report2 report2 = new report2();
            report2.Show();
        }

        private void hover(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void theMainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
