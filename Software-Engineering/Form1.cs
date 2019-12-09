using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    public partial class Form1 : Form
    {
        //Initialize component in Form1
        public Form1()
        {
            InitializeComponent();

            this.MinimumSize = new Size(735, 420);
            this.MaximumSize = new Size(735, 420);
        }

        //Onclick "Login" button verify username & password and navigate to Bedside System Page
        private void button1_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            MedicalStaff mStaff = new MedicalStaff();
            MedicalStaffHandler mStaffHnd = new MedicalStaffHandler();

            mStaff.Staffid = textBox1.Text;
            mStaff.Password = textBox2.Text;

            if ((mStaffHnd.checkMedicalStaffLoginDetail(dbConn.getConn(), mStaff)) == true)
            {
                Central_Station central_station = new Central_Station();
                central_station.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }

        //Onclick "Clear" button to clear username & password textbox
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bedside_System bedside_System = new Bedside_System();
            bedside_System.Show();
        }
    }
}