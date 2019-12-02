using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Engineering
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();

            this.MinimumSize = new Size(982, 763);
            this.MaximumSize = new Size(982, 763);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;

            dateTimePicker1.Value = DateTime.Now;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Gray)
            {
                if (textBox13.Text == "" && button1.BackColor == Color.Gray)
                {
                    patientDBtable(2);
                }
                else
                {
                    patientDBtable(1);
                }
            }
            else if (button2.BackColor == Color.Gray)
            {
                if (textBox13.Text == "" && button2.BackColor == Color.Gray)
                {
                    medicalStaffDBtable(2);
                }
                else
                {
                    medicalStaffDBtable(1);
                }
            }
            else if (button3.BackColor == Color.Gray)
            {

            }
            else if (button4.BackColor == Color.Gray)
            {

            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////"Patient" Tab///////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.BackColor == Color.Gray)
            {
                button1.BackColor = Color.LightGray;
                button1.ForeColor = Color.Black;
                panel2.Visible = false;
                panel9.Visible = false;
                panel12.Visible = false;
                panel10.Visible = false;
                panel17.Visible = false;
            }
            else
            {
                button1.BackColor = Color.Gray;
                button1.ForeColor = Color.White;

                button2.BackColor = Color.LightGray;
                button2.ForeColor = Color.Black;
                button3.BackColor = Color.LightGray;
                button3.ForeColor = Color.Black;
                button4.BackColor = Color.LightGray;
                button4.ForeColor = Color.Black;

                panel2.Visible = true;
                panel10.Visible = false;
                panel12.Visible = false;
                panel17.Visible = false;
                patientDBtable(1);

                panel9.Visible = true;
                textBox13.Text = "";
            }
        }

        public void patientDBtable(int num)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();
            PatientHandler patientHnd = new PatientHandler();

            if (num == 1)
            {
                ptient.Name = textBox13.Text;
            }
            else if (num == 2)
            {
                ptient.Wing = "%";
                ptient.Floor = "%";
                ptient.Bay = "%";
                ptient.Bed = "%";
            }

            dataGridView1.DataSource = patientHnd.listPatient(dbConn.getConn(), ptient, num);

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "AGE";
            dataGridView1.Columns[3].HeaderText = "GENDER";
            dataGridView1.Columns[4].HeaderText = "BEDSIDE ID";
            dataGridView1.Columns[5].HeaderText = "WING";
            dataGridView1.Columns[6].HeaderText = "FLOOR";
            dataGridView1.Columns[7].HeaderText = "BAY";
            dataGridView1.Columns[8].HeaderText = "BED";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Add new patient button
        private void button5_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();
            ModuleReadings mConfig = new ModuleReadings();

            if (textBox1.Text != "" && textBox2.Text != "" && (comboBox1.SelectedItem).ToString() != "- SELECT -"
                 && (comboBox2.SelectedItem).ToString() != "- SELECT -" && (comboBox3.SelectedItem).ToString() != "- SELECT -"
                  && (comboBox4.SelectedItem).ToString() != "- SELECT -" && (comboBox5.SelectedItem).ToString() != "- SELECT -"
                  && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != ""
                  && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != ""
                  && textBox11.Text != "" && textBox12.Text != "")
            {
                if (int.TryParse(textBox2.Text, out int theAge) && Int32.Parse(textBox2.Text) < 150)
                {
                    ptient.Name = textBox1.Text;
                    ptient.Age = Int32.Parse(textBox2.Text);
                    ptient.Gender = (comboBox1.SelectedItem).ToString();
                    ptient.Wing = (comboBox2.SelectedItem).ToString();
                    ptient.Floor = (comboBox3.SelectedItem).ToString();
                    ptient.Bay = (comboBox4.SelectedItem).ToString();
                    ptient.Bed = (comboBox5.SelectedItem).ToString();

                    mConfig.MinPulse = Int32.Parse(textBox3.Text);
                    mConfig.MaxPulse = Int32.Parse(textBox4.Text);
                    mConfig.MinBreath = Int32.Parse(textBox6.Text);
                    mConfig.MaxBreath = Int32.Parse(textBox5.Text);
                    mConfig.MinSystolic = Int32.Parse(textBox8.Text);
                    mConfig.MaxSystolic = Int32.Parse(textBox7.Text);
                    mConfig.MinDiastolic = Int32.Parse(textBox9.Text);
                    mConfig.MaxDiastolic = Int32.Parse(textBox10.Text);
                    mConfig.MinTemp = float.Parse(textBox11.Text);
                    mConfig.MaxTemp = float.Parse(textBox12.Text);

                    mConfig.PulseIntTime = Int32.Parse(textBox23.Text);
                    mConfig.BreathIntTime = Int32.Parse(textBox24.Text);
                    mConfig.PressureIntTime = Int32.Parse(textBox25.Text);
                    mConfig.TempIntTime = Int32.Parse(textBox26.Text);

                    mConfig.PRModifiedTime = DateTime.Now.ToString();
                    mConfig.BRModifiedTime = DateTime.Now.ToString();
                    mConfig.BPModifiedTime = DateTime.Now.ToString();
                    mConfig.TempModifiedTime = DateTime.Now.ToString();

                    PatientHandler patHnd = new PatientHandler();
                    int recordCnt = patHnd.addNewPatient(dbConn.getConn(), ptient);
                    patHnd.updatePatientBedsideIdAndReadings(dbConn.getConn(), ptient, mConfig);

                    MessageBox.Show(recordCnt + " Patient Registered Successfully !");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "60";
                    textBox4.Text = "100";
                    textBox5.Text = "20";
                    textBox6.Text = "12";
                    textBox7.Text = "120";
                    textBox8.Text = "80";
                    textBox9.Text = "60";
                    textBox10.Text = "80";
                    textBox11.Text = "35.2";
                    textBox12.Text = "36.9";

                    textBox23.Text = "1";
                    textBox24.Text = "2";
                    textBox25.Text = "3";
                    textBox26.Text = "5";

                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                    comboBox3.SelectedIndex = 0;
                    comboBox4.SelectedIndex = 0;
                    comboBox5.SelectedIndex = 0;

                    patientDBtable(1);
                }
                else
                {
                    MessageBox.Show("Invalid format for Age !");
                }
            }
            else
            {
                MessageBox.Show("Please fill up all fields to register.");
            }
        }

        //Clear all input fields and reset module readings to default values
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all the fields above?\n\n" +
                                "Note that the fields under module readings will be reset to default values.", "Alert !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "60";
                textBox4.Text = "100";
                textBox5.Text = "20";
                textBox6.Text = "12";
                textBox7.Text = "120";
                textBox8.Text = "80";
                textBox9.Text = "60";
                textBox10.Text = "80";
                textBox11.Text = "35.2";
                textBox12.Text = "36.9";

                textBox23.Text = "1";
                textBox24.Text = "2";
                textBox25.Text = "3";
                textBox26.Text = "5";

                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox2.SelectedItem).ToString() != "- SELECT -")
            {
                comboBox3.Enabled = true;
            }
            else
            {
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;

                comboBox3.SelectedIndex = 0;
                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox3.SelectedItem).ToString() != "- SELECT -")
            {
                comboBox4.Enabled = true;
            }
            else
            {
                comboBox4.Enabled = false;
                comboBox5.Enabled = false;

                comboBox4.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox4.SelectedItem).ToString() != "- SELECT -")
            {
                comboBox5.Enabled = true;

                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                BedSide bed = new BedSide();

                bed.Wing = (comboBox2.SelectedItem).ToString();
                bed.Floor = (comboBox3.SelectedItem).ToString();
                bed.Bay = (comboBox4.SelectedItem).ToString();

                BedSideHandler bedHnd = new BedSideHandler();
                comboBox5.DataSource = bedHnd.showBed(dbConn.getConn(), bed);
            }
            else
            {
                comboBox5.Enabled = false;

                comboBox5.SelectedIndex = 0;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////"Medical Staff" Tab////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Gray)
            {
                button2.BackColor = Color.LightGray;
                button2.ForeColor = Color.Black;
                panel9.Visible = false;
                panel10.Visible = false;
                panel12.Visible = false;
                panel17.Visible = false;
            }
            else
            {
                button2.BackColor = Color.Gray;
                button2.ForeColor = Color.White;

                button1.BackColor = Color.LightGray;
                button1.ForeColor = Color.Black;
                button3.BackColor = Color.LightGray;
                button3.ForeColor = Color.Black;
                button4.BackColor = Color.LightGray;
                button4.ForeColor = Color.Black;

                panel2.Visible = false;
                panel10.Visible = true;
                panel12.Visible = false;
                panel17.Visible = false;
                panel10.Location = new Point(190, 11);

                medicalStaffDBtable(1);

                panel9.Visible = true;
                textBox13.Text = "";
            }
        }

        public void medicalStaffDBtable(int num)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            MedicalStaff mStaff = new MedicalStaff();
            MedicalStaffHandler mStaffHnd = new MedicalStaffHandler();

            if (num == 1)
            {
                mStaff.Name = textBox13.Text;
            }
            else if (num == 2)
            {
                mStaff.Career = "%";
            }

            dataGridView2.DataSource = mStaffHnd.listStaff(dbConn.getConn(), mStaff, num);

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "STAFF ID";
            dataGridView2.Columns[2].HeaderText = "NAME";
            dataGridView2.Columns[3].HeaderText = "PASSWORD";
            dataGridView2.Columns[4].HeaderText = "CAREER TYPE";
            dataGridView2.Columns[5].HeaderText = "EMAIL";
            dataGridView2.Columns[6].HeaderText = "CONTACT NUMBER";
            dataGridView2.Columns[7].HeaderText = "PAGER NUMBER";
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Add new medical staff button
        private void button7_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            MedicalStaff mStaff = new MedicalStaff();
            MedicalStaffHandler mStaffHnd = new MedicalStaffHandler();

            bool verifyCareer = false;

            if (textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" &&
                (comboBox6.SelectedItem).ToString() != "- SELECT CAREER -")
            {
                if ((comboBox6.SelectedItem).ToString() == "Consultant")
                {
                    if (textBox17.Text != "")
                    {
                        verifyCareer = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid format for Email !");
                    }
                }
                else if ((comboBox6.SelectedItem).ToString() == "Doctor" || (comboBox6.SelectedItem).ToString() == "Nurse")
                {
                    if (int.TryParse(textBox18.Text, out int theContact))
                    {
                        if (int.TryParse(textBox19.Text, out int thePager))
                        {
                            verifyCareer = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid format for Pager Number !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid format for Contact Number!");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a type of career.");
                }

                if (verifyCareer == true)
                {
                    mStaff.Staffid = textBox14.Text;
                    mStaff.Name = textBox15.Text;
                    mStaff.Password = textBox16.Text;
                    mStaff.Email = textBox17.Text;
                    mStaff.Contact = textBox18.Text;
                    mStaff.Pager = textBox19.Text;
                    mStaff.Career = (comboBox6.SelectedItem).ToString();

                    int recordCnt = mStaffHnd.addNewMedicalStaff(dbConn.getConn(), mStaff);
                    MessageBox.Show(recordCnt + " Medical Staff Registered Successfully !");

                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";

                    comboBox6.SelectedIndex = 0;

                    medicalStaffDBtable(1);
                }
            }
            else
            {
                MessageBox.Show("Please fill up all fields to register.");
            }
        }

        //Clear all input fields
        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear all the fields above?\n\n" +
                                "Note that the fields cleared cannot be restored.", "Alert !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";

                comboBox6.SelectedIndex = 0;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////"Call Shift" Tab/////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Gray)
            {
                button3.BackColor = Color.LightGray;
                button3.ForeColor = Color.Black;
                panel2.Visible = false;
                panel10.Visible = false;
                panel9.Visible = false;
                panel12.Visible = false;
                panel17.Visible = false;
            }
            else
            {
                button3.BackColor = Color.Gray;
                button3.ForeColor = Color.White;

                button2.BackColor = Color.LightGray;
                button2.ForeColor = Color.Black;
                button1.BackColor = Color.LightGray;
                button1.ForeColor = Color.Black;
                button4.BackColor = Color.LightGray;
                button4.ForeColor = Color.Black;

                panel2.Visible = false;
                panel10.Visible = false;
                panel12.Visible = true;
                panel17.Visible = false;
                panel12.Location = new Point(190, 11);
                panel9.Visible = false;
                textBox13.Text = "";
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            if(textBox20.Text == "")
            {
                label36.Text = "Validate Medical Staff ID";
                label36.ForeColor = Color.Black;
                label36.Visible = false;
            }
            else
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                MedicalStaffHandler mStaffHnd = new MedicalStaffHandler();
                bool goCheckStaffId = mStaffHnd.checkStaffId(dbConn.getConn(), textBox20.Text);

                if (goCheckStaffId == true)
                {
                    label36.Text = "Valid Staff ID";
                    label36.ForeColor = Color.Green;
                    label36.Visible = true;

                    dateTimePicker1_ValueChanged(null,e);
                }
                else if(goCheckStaffId == false)
                {
                    label36.Text = "Invalid Staff ID";
                    label36.ForeColor = Color.Red;
                    label36.Visible = true;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CheckBox[] checkedList = new CheckBox[24] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6,
                                                      checkBox12, checkBox11, checkBox10, checkBox9, checkBox8, checkBox7,
                                                      checkBox24, checkBox23, checkBox22, checkBox21, checkBox20, checkBox19,
                                                      checkBox18, checkBox17, checkBox16, checkBox15, checkBox14, checkBox13 };

            if (textBox20.Text != "" && label36.ForeColor == Color.Green)
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                OnShift oShift = new OnShift();
                OnShiftHandler oShiftHnd = new OnShiftHandler();

                for (int x = 0; x < checkedList.Count(); x++)
                {
                    oShift.StaffId = textBox20.Text;
                    oShift.DateOnShift = (dateTimePicker1.Value).ToString("dd/MM/yyyy");
                    oShift.TimeOnShift = checkedList[x].Text;

                    bool registered = oShiftHnd.checkShift(dbConn.getConn(), oShift);

                    if (registered == true)
                    {
                        checkedList[x].Checked = true;
                        checkedList[x].Enabled = false;
                    }
                    else
                    {
                        checkedList[x].Checked = false;
                        checkedList[x].Enabled = true;
                    }
                }
            }
            else
            {
                for(int x = 0; x < checkedList.Count(); x++)
                {
                    checkedList[x].Checked = false;
                    checkedList[x].Enabled = false;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            CheckBox[] checkedList = new CheckBox[24] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6,
                                                      checkBox12, checkBox11, checkBox10, checkBox9, checkBox8, checkBox7,
                                                      checkBox24, checkBox23, checkBox22, checkBox21, checkBox20, checkBox19,
                                                      checkBox18, checkBox17, checkBox16, checkBox15, checkBox14, checkBox13 };
            bool isChecked = false;

            for(int x = 0; x < checkedList.Count(); x++)
            {
                if(checkedList[x].Checked == true)
                {
                    isChecked = true;
                }
            }

            if(label36.ForeColor == Color.Green && isChecked == true)
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                OnShift oShift = new OnShift();
                OnShiftHandler oShiftHnd = new OnShiftHandler();
                
                for(int x = 0; x < checkedList.Count(); x++)
                {
                    if(checkedList[x].Checked == true && checkedList[x].Enabled == true)
                    {
                        oShift.StaffId = textBox20.Text;
                        oShift.DateOnShift = (dateTimePicker1.Value).ToString("dd/MM/yyyy");
                        oShift.TimeOnShift = checkedList[x].Text;
                        oShift.DateAndTimeRegistered = DateTime.Now.ToString();
                        oShift.DateAndTimeDeregistered = "-";

                        bool registered = oShiftHnd.registerShift(dbConn.getConn(), oShift);
                    }
                }

                MessageBox.Show("Shift date and time registered successfully !");

                for(int x = 0; x < checkedList.Count(); x++)
                {
                    checkedList[x].Checked = false;
                }

                textBox21_TextChanged(null, e);
                dateTimePicker1_ValueChanged(null, e);
            }
            else
            {
                if(isChecked != true)
                {
                    MessageBox.Show("Please select at least one time slot to continue.");
                }
                else
                {
                    MessageBox.Show("Please insert valid staff's ID.");
                }
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                label41.Text = "Validate Medical Staff ID";
                label41.ForeColor = Color.Black;
                label41.Visible = false;
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
            }
            else
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                MedicalStaffHandler mStaffHnd = new MedicalStaffHandler();
                bool goCheckStaffId = mStaffHnd.checkStaffId(dbConn.getConn(), textBox21.Text);

                if (goCheckStaffId == true)
                {
                    label41.Text = "Valid Staff ID";
                    label41.ForeColor = Color.Green;
                    label41.Visible = true;
                    comboBox7.Enabled = true;

                    OnShift oShift = new OnShift();
                    OnShiftHandler oShiftHnd = new OnShiftHandler();

                    oShift.StaffId = textBox21.Text;

                    comboBox7.DataSource = oShiftHnd.showDate(dbConn.getConn(), oShift);
                }
                else if (goCheckStaffId == false)
                {
                    label41.Text = "Invalid Staff ID";
                    label41.ForeColor = Color.Red;
                    label41.Visible = true;

                    comboBox7.Enabled = false;
                    comboBox8.Enabled = false;
                    comboBox7.SelectedIndex = 0;
                    comboBox8.SelectedIndex = 0;
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox7.SelectedItem).ToString() != "- SELECT -")
            {
                comboBox8.Enabled = true;

                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                OnShift oShift = new OnShift();
                OnShiftHandler oShiftHnd = new OnShiftHandler();

                oShift.StaffId = textBox21.Text;
                oShift.DateOnShift = (comboBox7.SelectedItem).ToString();

                comboBox8.DataSource = oShiftHnd.showTime(dbConn.getConn(), oShift);
            }
            else
            {
                comboBox8.Enabled = false;
                comboBox8.SelectedIndex = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label41.ForeColor == Color.Green && (comboBox7.SelectedItem).ToString() != "- SELECT -"
                 && (comboBox8.SelectedItem).ToString() != "- SELECT -")
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                OnShift oShift = new OnShift();
                OnShiftHandler oShiftHnd = new OnShiftHandler();

                oShift.StaffId = textBox21.Text;
                oShift.DateOnShift = (comboBox7.SelectedItem).ToString();
                oShift.TimeOnShift = (comboBox8.SelectedItem).ToString();
                oShift.DateAndTimeDeregistered = DateTime.Now.ToString();

                bool deregistered = oShiftHnd.deregisterShift(dbConn.getConn(), oShift);

                if (deregistered == true)
                {
                    MessageBox.Show("Shift date and time deregistered successfully !");
                    textBox21_TextChanged(null,e);
                    dateTimePicker1_ValueChanged(null, e);
                }
                else
                {
                    MessageBox.Show("Failed to register shift date and time...");
                }
            }
            else
            {
                MessageBox.Show("Please insert valid information.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////"Analysis" Tab///////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Gray)
            {
                button4.BackColor = Color.LightGray;
                button4.ForeColor = Color.Black;
                panel2.Visible = false;
                panel10.Visible = false;
                panel12.Visible = false;
                panel9.Visible = false;
                panel17.Visible = false;
            }
            else
            {
                button4.BackColor = Color.Gray;
                button4.ForeColor = Color.White;

                button2.BackColor = Color.LightGray;
                button2.ForeColor = Color.Black;
                button3.BackColor = Color.LightGray;
                button3.ForeColor = Color.Black;
                button1.BackColor = Color.LightGray;
                button1.ForeColor = Color.Black;

                panel2.Visible = false;
                panel10.Visible = false;
                panel12.Visible = false;
                panel17.Visible = true;
                panel17.Location = new Point(190, 11);
                panel9.Visible = false;
                textBox13.Text = "";
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            if(textBox22.Text != "")
            {
                if (Int32.TryParse(textBox22.Text, out int theId) && Int32.Parse(textBox22.Text) >= 0)
                {
                    DbConnector dbConn = new DbConnector();
                    dbConn.connect();
                    PatientHandler patHnd = new PatientHandler();

                    label51.Text = patHnd.getPatientDetailsById(dbConn.getConn(), Int32.Parse(textBox22.Text), "patientName");
                    label52.Text = patHnd.getPatientDetailsById(dbConn.getConn(), Int32.Parse(textBox22.Text), "patientAge");
                    label53.Text = patHnd.getPatientDetailsById(dbConn.getConn(), Int32.Parse(textBox22.Text), "patientGender");

                    if (label51.Text == "No record found")
                    {
                        label47.Text = "Invalid Patient ID";
                        label47.ForeColor = Color.Red;
                        label47.Visible = true;

                        button11.Enabled = false;
                        button12.Enabled = false;
                        button13.Enabled = false;
                        button14.Enabled = false;
                    }
                    else
                    {
                        label47.Text = "Valid Patient ID";
                        label47.ForeColor = Color.Green;
                        label47.Visible = true;

                        button11.Enabled = true;
                        button12.Enabled = true;
                        button13.Enabled = true;
                        button14.Enabled = true;
                    }
                }
                else
                {
                    label47.Text = "Invalid Patient ID";
                    label47.ForeColor = Color.Red;
                    label47.Visible = true;

                    button11.Enabled = false;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    button14.Enabled = false;
                }
            }
            else
            {
                label51.Text = "No record found";
                label52.Text = "No record found";
                label53.Text = "No record found";

                button11.Enabled = false;
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;

                label47.Text = "Validate Medical Staff ID";
                label47.ForeColor = Color.Black;
                label47.Visible = false;
            }
        }

        string[] allData = new string[] { };

        private void button11_Click(object sender, EventArgs e)
        {
            allData = new string[5] { textBox22.Text, label51.Text, label52.Text, label53.Text, "Pulse Rate" };

            HistoryChecker checkHistory = new HistoryChecker();
            checkHistory.Show();
            checkHistory.getData(allData);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            allData = new string[5] { textBox22.Text, label51.Text, label52.Text, label53.Text, "Breathing Rate" };

            HistoryChecker checkHistory = new HistoryChecker();
            checkHistory.Show();
            checkHistory.getData(allData);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            allData = new string[5] { textBox22.Text, label51.Text, label52.Text, label53.Text, "Blood Pressure" };

            HistoryChecker checkHistory = new HistoryChecker();
            checkHistory.Show();
            checkHistory.getData(allData);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            allData = new string[5] { textBox22.Text, label51.Text, label52.Text, label53.Text, "Temperature" };

            HistoryChecker checkHistory = new HistoryChecker();
            checkHistory.Show();
            checkHistory.getData(allData);
        }
    }
}