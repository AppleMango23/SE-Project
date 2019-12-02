using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Software_Engineering
{
    public partial class Central_Station : Form
    {
        public static Timer check_Monitor = new Timer();

        public Central_Station()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1380, 695);
            this.MaximumSize = new Size(1380, 695);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            displayTimetable();

            Timer timer = new Timer();
            timer.Tick += new EventHandler(checkMonitor);
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        public void displayTimetable()
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            string[] xLabels = new string[24] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", 
                                                "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
                                                "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
                                                "18:00", "19:00", "20:00", "21:00", "22:00", "23:00" };
            var chart = chart1.ChartAreas[0];
            int startOffset = -2;
            int endOffset = 2;
            int counter = 0;
            int nextCounter = 0;
            int realCounter = 0;
            bool exist = false;
            int xBlockSize = 30;
            int yBlockSize = 10;

            foreach (string labels in xLabels)
            {
                CustomLabel timeSlot = new CustomLabel(startOffset, endOffset, labels, 0, LabelMarkStyle.None);
                chart.AxisY.CustomLabels.Add(timeSlot);
                startOffset++;
                endOffset++;
            }

            OnShiftHandler oSHnd = new OnShiftHandler();

            foreach (var Txt in oSHnd.getOnCall(dbConn.getConn(), DateTime.Now.ToString("dd/MM/yyyy")))
            {
                while(nextCounter > 0)
                {
                    nextCounter--;

                    if (chart1.Series["On Call Registered"].Points[nextCounter].Label == Txt.StaffId)
                    {
                        exist = true;
                        counter = nextCounter;
                    }
                }

                if(exist == false)
                {
                    counter = realCounter;
                }

                switch (Txt.TimeOnShift)
                {
                    case "00:00 - 00:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 0, 1);
                        break;
                    case "01:00 - 01:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 1, 2);
                        break;
                    case "02:00 - 02:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 2, 3);
                        break;
                    case "03:00 - 03:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 3, 4);
                        break;
                    case "04:00 - 04:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 4, 5);
                        break;
                    case "05:00 - 05:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 5, 6);
                        break;
                    case "06:00 - 06:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 6, 7);
                        break;
                    case "07:00 - 07:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 7, 8);
                        break;
                    case "08:00 - 08:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 8, 9);
                        break;
                    case "09:00 - 09:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 9, 10);
                        break;
                    case "10:00 - 10:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 10, 11);
                        break;
                    case "11:00 - 11:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 11, 12);
                        break;
                    case "12:00 - 12:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 12, 13);
                        break;
                    case "13:00 - 13:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 13, 14);
                        break;
                    case "14:00 - 14:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 14, 15);
                        break;
                    case "15:00 - 15:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 15, 16);
                        break;
                    case "16:00 - 16:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 16, 17);
                        break;
                    case "17:00 - 17:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 17, 18);
                        break;
                    case "18:00 - 18:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 18, 19);
                        break;
                    case "19:00 - 19:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 19, 20);
                        break;
                    case "20:00 - 20:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 20, 21);
                        break;
                    case "21:00 - 21:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 21, 22);
                        break;
                    case "22:00 - 22:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 22, 23);
                        break;
                    case "23:00 - 23:59":
                        chart1.Series["On Call Registered"].Points.AddXY(counter, 23, 24);
                        break;
                }

                chart1.Series["On Call Registered"].Points[realCounter].Label = Txt.StaffId;

                if (Txt.DateAndTimeDeregistered == "True")
                {
                    chart1.Series["On Call Registered"].Points[realCounter].Color = System.Drawing.Color.FromArgb(255, 8, 74);
                }
                else
                {
                    chart1.Series["On Call Registered"].Points[realCounter].Color = System.Drawing.Color.FromArgb(8, 255, 82);
                }

                realCounter++;
                nextCounter = realCounter;
                exist = false;
            }

            chart.AxisY.LabelStyle.Angle = -45;
            chart.AxisX.Title = "Medical Staff";
            chart.AxisY.Title = "Time Slot";

            chart.AxisX.Minimum = -0.5;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 24;
            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 1;

            //Enable autoscroll
            chart.CursorX.AutoScroll = true;
            chart.CursorY.AutoScroll = true;

            //Zoom to [0, xBlockSize]
            chart.AxisX.ScaleView.Zoomable = true;
            chart.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chart.AxisY.ScaleView.Zoomable = true;
            chart.AxisY.ScaleView.SizeType = DateTimeIntervalType.Number;

            int position = 1;
            int size = xBlockSize;
            int ysize = yBlockSize;

            chart.AxisX.ScaleView.Zoom(position, size);
            chart.AxisY.ScaleView.Zoom(0, ysize);

            //Disable zoom-reset button (only scrollbar's arrows are available)
            chart.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chart.AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // set scrollbar small change to blockSize (e.g. 100)
            chart.AxisX.ScaleView.SmallScrollSize = xBlockSize;
            chart.AxisY.ScaleView.SmallScrollSize = yBlockSize;
        }

        private void checkMonitor(object sender, EventArgs e)
        {
            Label[] tagName = new Label[8] { label2, label4, label6, label8, label10, label12, label14, label16 };
            Label[] tagValue = new Label[8] { label1, label3, label5, label7, label9, label11, label13, label15 };
            string[] bedNum = new string[8] { "Bed 1", "Bed 2", "Bed 3", "Bed 4", "Bed 5", "Bed 6", "Bed 7", "Bed 8" };
            Button[] buttonNum = new Button[8] { button4, button5, button6, button7, button8, button9, button10, button11 };
            PictureBox[] pitureBoxNum = new PictureBox[8] { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            
            var critical = Color.FromArgb(255, 8, 8);
            var risky = Color.FromArgb(255, 214, 8);
            var normal = Color.FromArgb(8, 255, 86);
            var none = Color.FromArgb(224, 224, 224);

            for (int x = 0; x < tagName.Count(); x++)
            {
                tagName[x].Text = "Pulse Rate\n" +
                      "Breathing Rate\n" +
                      "Blood Pressure\n" +
                      "Temperature";
            }

            if ((comboBox1.SelectedItem).ToString() != "-SELECT WING -" && (comboBox2.SelectedItem).ToString() != "-SELECT Floor -")
            {
                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255) || button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    DbConnector dbConn = new DbConnector();
                    dbConn.connect();

                    Patient ptient = new Patient();
                    ptient.Wing = (comboBox1.SelectedItem).ToString();
                    ptient.Floor = (comboBox2.SelectedItem).ToString();

                    if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                    {
                        ptient.Bay = "Bay A";
                    }
                    else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                    {
                        ptient.Bay = "Bay B";
                    }

                    PatientHandler patHnd = new PatientHandler();

                    PatientReadings pRead = new PatientReadings();
                    PatientReadingsHandler pReadHnd = new PatientReadingsHandler();

                    for (int x = 0; x < tagName.Count(); x++)
                    {
                        ptient.Bed = bedNum[x];
                        string checkPatientId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");

                        if(checkPatientId != "No record found")
                        {
                            pRead.PatientId = Int32.Parse(checkPatientId);
                            string pulseRate = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "pulseRate");
                            string breathingRate = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "breathingRate");
                            string systolic = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "systolic");
                            string diastolic = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "diastolic");
                            string temperature = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "temperature");
                            string dateAndTime = pReadHnd.displayModuleReadings(dbConn.getConn(), pRead, "dateAndTime");

                            if (DateTime.Now.ToString() == dateAndTime)
                            {
                                if (Int32.Parse(pulseRate) == 0 || Int32.Parse(breathingRate) == 0 ||
                                    Int32.Parse(systolic) == 0 || Int32.Parse(diastolic) == 0 ||
                                    float.Parse(temperature) == 0)
                                {
                                    buttonNum[x].BackColor = critical;
                                    tagName[x].BackColor = critical;
                                    tagValue[x].BackColor = critical;
                                    pitureBoxNum[x].BackColor = critical;

                                    bayButtonColorChanges();
                                }
                                else if (Int32.Parse(pulseRate) < Int32.Parse(getM("pulseRMin", checkPatientId)) || 
                                         Int32.Parse(pulseRate) > Int32.Parse(getM("pulseRMax", checkPatientId)) ||
                                         Int32.Parse(breathingRate) < Int32.Parse(getM("breathRMin", checkPatientId)) ||
                                         Int32.Parse(breathingRate) > Int32.Parse(getM("breathRMax", checkPatientId)) ||
                                         Int32.Parse(systolic) < Int32.Parse(getM("systolicMin", checkPatientId)) ||
                                         Int32.Parse(systolic) > Int32.Parse(getM("systolicMax", checkPatientId)) ||
                                         Int32.Parse(diastolic) < Int32.Parse(getM("diastolicMin", checkPatientId)) ||
                                         Int32.Parse(diastolic) > Int32.Parse(getM("diastolicMax", checkPatientId)) ||
                                         float.Parse(temperature) < float.Parse(getM("tempMin", checkPatientId)) ||
                                         float.Parse(temperature) > float.Parse(getM("tempMax", checkPatientId)))
                                {
                                    buttonNum[x].BackColor = risky;
                                    tagName[x].BackColor = risky;
                                    tagValue[x].BackColor = risky;
                                    pitureBoxNum[x].BackColor = risky;

                                    bayButtonColorChanges();
                                }
                                else if (Int32.Parse(pulseRate) >= Int32.Parse(getM("pulseRMin", checkPatientId)) &&
                                         Int32.Parse(pulseRate) <= Int32.Parse(getM("pulseRMax", checkPatientId)) &&
                                         Int32.Parse(breathingRate) >= Int32.Parse(getM("breathRMin", checkPatientId)) &&
                                         Int32.Parse(breathingRate) <= Int32.Parse(getM("breathRMax", checkPatientId)) &&
                                         Int32.Parse(systolic) >= Int32.Parse(getM("systolicMin", checkPatientId)) &&
                                         Int32.Parse(systolic) <= Int32.Parse(getM("systolicMax", checkPatientId)) &&
                                         Int32.Parse(diastolic) >= Int32.Parse(getM("diastolicMin", checkPatientId)) &&
                                         Int32.Parse(diastolic) <= Int32.Parse(getM("diastolicMax", checkPatientId)) &&
                                         float.Parse(temperature) >= float.Parse(getM("tempMin", checkPatientId)) &&
                                         float.Parse(temperature) <= float.Parse(getM("tempMax", checkPatientId)))
                                {
                                    buttonNum[x].BackColor = normal;
                                    tagName[x].BackColor = normal;
                                    tagValue[x].BackColor = normal;
                                    pitureBoxNum[x].BackColor = normal;

                                    bayButtonColorChanges();
                                }

                                tagValue[x].Text =
                                  ": " + pulseRate + "\n" +
                                  ": " + breathingRate + "\n" +
                                  ": " + systolic + "/" + diastolic + "\n" +
                                  ": " + temperature + "°C";
                            }
                            else
                            {
                                tagValue[x].Text = ": -\n" +
                                  ": -\n" +
                                  ": -/-\n" +
                                  ": -°C";

                                buttonNum[x].BackColor = none;
                                tagName[x].BackColor = none;
                                tagValue[x].BackColor = none;
                                pitureBoxNum[x].BackColor = none;

                                bayButtonColorChanges();
                            }
                        }
                        else
                        {
                            tagValue[x].Text = ": -\n" +
                              ": -\n" +
                              ": -/-\n" +
                              ": -°C";

                            buttonNum[x].BackColor = none;
                            tagName[x].BackColor = none;
                            tagValue[x].BackColor = none;
                            pitureBoxNum[x].BackColor = none;

                            bayButtonColorChanges();
                        }
                    }
                }
                else
                {
                    for (int x = 0; x < tagName.Count(); x++)
                    {
                        tagValue[x].Text = ": -\n" +
                              ": -\n" +
                              ": -/-\n" +
                              ": -°C";

                        buttonNum[x].BackColor = none;
                        tagName[x].BackColor = none;
                        tagValue[x].BackColor = none;
                        pitureBoxNum[x].BackColor = none;

                        bayButtonColorChanges();
                    }
                }
            }
            else
            {
                for (int x = 0; x < tagName.Count(); x++)
                {
                    tagValue[x].Text = ": -\n" +
                          ": -\n" +
                          ": -/-\n" +
                          ": -°C";

                    buttonNum[x].BackColor = none;
                    tagName[x].BackColor = none;
                    tagValue[x].BackColor = none;
                    pitureBoxNum[x].BackColor = none;
                }
            }
        }

        public string getM(string what, string checkPatientId)
        {
            string result = "";

            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            ModuleReadingsHandler mRHand = new ModuleReadingsHandler();
            result = mRHand.getModuleReading(dbConn.getConn(), what, checkPatientId);

            return result;
        }

        public void bayButtonColorChanges()
        {
            var critical = Color.FromArgb(255, 8, 8);
            var risky = Color.FromArgb(255, 214, 8);
            var normal = Color.FromArgb(8, 255, 86);
            var none = Color.DarkGray;

            if (button4.BackColor == critical || button5.BackColor == critical ||
                button6.BackColor == critical || button7.BackColor == critical ||
                button8.BackColor == critical || button9.BackColor == critical ||
                button10.BackColor == critical || button11.BackColor == critical)
            {
                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = critical;
                }
                else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = critical;
                }
            }
            else if (button4.BackColor == risky || button5.BackColor == risky ||
                button6.BackColor == risky || button7.BackColor == risky ||
                button8.BackColor == risky || button9.BackColor == risky ||
                button10.BackColor == risky || button11.BackColor == risky)
            {
                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = risky;
                }
                else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = risky;
                }
            }
            else if (button4.BackColor == normal || button5.BackColor == normal ||
                button6.BackColor == normal || button7.BackColor == normal ||
                button8.BackColor == normal || button9.BackColor == normal ||
                button10.BackColor == normal || button11.BackColor == normal)
            {
                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = normal;
                }
                else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = normal;
                }
            }
            else if (button4.BackColor == none || button5.BackColor == none ||
                button6.BackColor == none || button7.BackColor == none ||
                button8.BackColor == none || button9.BackColor == none ||
                button10.BackColor == none || button11.BackColor == none)
            {
                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = none;
                }
                else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    button2.BackColor = none;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.DarkGray)
            {
                button2.BackColor = Color.FromArgb(8, 255, 82);
                button2.FlatAppearance.BorderColor = Color.FromArgb(8, 94, 255);

                button3.BackColor = Color.DarkGray;
                button3.FlatAppearance.BorderColor = Color.Silver;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.DarkGray)
            {
                button3.BackColor = Color.FromArgb(8, 255, 82);
                button3.FlatAppearance.BorderColor = Color.FromArgb(8, 94, 255);

                button2.BackColor = Color.DarkGray;
                button2.FlatAppearance.BorderColor = Color.Silver;
            }
        }

        public void displayBedStatus(string condition)
        {
            Label[] tagName = new Label[8] { label2, label4, label6, label8, label10, label12, label14, label16 };
            Label[] tagValue = new Label[8] { label1, label3, label5, label7, label9, label11, label13, label15 };

            for (int x = 0; x < tagName.Count(); x++)
            {
                tagName[x].Text = "Pulse Rate\n" +
                      "Breathing Rate\n" +
                      "Blood Pressure\n" +
                      "Temperature";
            }

            if (condition == "Init")
            {
                for (int x = 0; x < tagName.Count(); x++)
                {
                    tagValue[x].Text = ": -\n" +
                          ": -\n" +
                          ": -/-\n" +
                          ": -°C";
                }
            }
            else if(condition == "Display")
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                Patient ptient = new Patient();
                ptient.Wing = (comboBox1.SelectedItem).ToString();
                ptient.Floor = (comboBox2.SelectedItem).ToString();

                if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    ptient.Bay = "Bay A";
                }
                else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
                {
                    ptient.Bay = "Bay B";
                }

                ptient.Bed = "Bed 1";

                PatientHandler patHnd = new PatientHandler();

                string checkPatientId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");

                for (int x = 0; x < tagName.Count(); x++)
                {
                    tagValue[x].Text = 
                          ": " + "\n" +
                          ": " + "\n" +
                          ": " + "/" + "\n" +
                          ": " + "°C";
                }
            }
        }

        //Function to call out the method in patientHandler to get any patient details
        public void displayPatientDetails(string bedNumber)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();

            ptient.Wing = (comboBox1.SelectedItem).ToString();
            ptient.Floor = (comboBox2.SelectedItem).ToString();

            if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
            {
                ptient.Bay = "Bay A";
            }
            else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
            {
                ptient.Bay = "Bay B";
            }

            ptient.Bed = bedNumber;

            PatientHandler patHnd = new PatientHandler();

            string checkName = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientName");
            string checkAge = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientAge");
            string checkGender = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientGender");

            MessageBox.Show("Name: " + checkName + "\nAge: " + checkAge + "\nGender: " + checkGender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 2");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 3");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 4");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 5");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 6");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 7");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            displayPatientDetails("Bed 8");
        }

        public void displayModuleReadings(int pictureBoxSelected)
        {
            string wingSelected = (comboBox1.SelectedItem).ToString();
            string floorSelected = (comboBox2.SelectedItem).ToString();
            string baySelected = "- SELECT BAY -";
            string bedSelected = "";

            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();

            ptient.Wing = wingSelected;
            ptient.Floor = floorSelected;

            if (button2.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
            {
                ptient.Bay = "Bay A";
                baySelected = "Bay A";
            }
            else if (button3.FlatAppearance.BorderColor == Color.FromArgb(8, 94, 255))
            {
                ptient.Bay = "Bay B";
                baySelected = "Bay B";
            }

            switch(pictureBoxSelected)
            {
                case 1:
                    ptient.Bed = "Bed 1";
                    bedSelected = "Bed 1";
                    break;

                case 2:
                    ptient.Bed = "Bed 2";
                    bedSelected = "Bed 2";
                    break;

                case 3:
                    ptient.Bed = "Bed 3";
                    bedSelected = "Bed 3";
                    break;

                case 4:
                    ptient.Bed = "Bed 4";
                    bedSelected = "Bed 4";
                    break;

                case 5:
                    ptient.Bed = "Bed 5";
                    bedSelected = "Bed 5";
                    break;

                case 6:
                    ptient.Bed = "Bed 6";
                    bedSelected = "Bed 6";
                    break;

                case 7:
                    ptient.Bed = "Bed 7";
                    bedSelected = "Bed 7";
                    break;

                case 8:
                    ptient.Bed = "Bed 8";
                    bedSelected = "Bed 8";
                    break;
            }

            PatientHandler patHnd = new PatientHandler();

            string checkId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");

            if(checkId != "No record found")
            {
                string[] patientData = new string[4] { wingSelected, floorSelected, baySelected, bedSelected };

                PatientModuleReadingsConfiguration passPatientData = new PatientModuleReadingsConfiguration();
                passPatientData.Show();
                passPatientData.displayData(patientData);
            }
            else
            {
                MessageBox.Show("No patient found !");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            displayModuleReadings(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            displayModuleReadings(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            displayModuleReadings(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            displayModuleReadings(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            displayModuleReadings(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            displayModuleReadings(6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            displayModuleReadings(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            displayModuleReadings(8);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Management management = new Management();
            management.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm Logout ?", "Alert !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            chart1.Series["On Call Registered"].Points.Clear();
            displayTimetable();
            chart1.Update();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}
