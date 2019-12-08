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
using MySql.Data.MySqlClient;
using System.IO;
using System.Media;

namespace Software_Engineering
{
    public partial class Bedside_System : Form
    {
        public static StreamReader sr = new StreamReader("CSV/ModuleReadingsA.csv");
        public static SoundPlayer player = new SoundPlayer();
        public static bool playingSound = false;
        public static string line;
        List<int> readingsList = new List<int>();

        public static int realCounter = 0;
        public static int counter = 0;
        public static int pulseRateCounter = 0;
        public static int breathingRateCounter = 0;
        public static int bloodPressureCounter = 0;
        public static int temperatureCounter = 0;
        public static int alarm = 4;

        public static int zoomPosition = 1;

        public static Timer run_Monitor = new Timer();

        public Bedside_System()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1095, 685);
            this.MaximumSize = new Size(1095, 685);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            labelBorder(10, "Init");
            labelBorder(11, "Init");
            labelBorder(12, "Init");
            labelBorder(13, "Init");

            displayGraph("Pulse Rate", false, "Init");
            displayGraph("Breathing Rate", false, "Init");
            displayGraph("Blood Pressure", false, "Init");
            displayGraph("Temperature", false, "Init");

            Timer timer = new Timer();
            timer.Tick += new EventHandler(showDateTime);
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        //Set realtime date and time
        public void showDateTime(object sender, EventArgs e)
        {
            label39.Text = DateTime.Now.ToString();
        }

        //Start or Halt button for module readings monitor
        public void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Halt")
            {
                DialogResult result = MessageBox.Show("Are you sure to terminate the module readings ?", "Alert !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    haltMonitor();
                }
            }
            else if (button2.Text == "Start")
            {
                startMonitor();
            }
        }

        //Function to start the monitor and retrieve some bedside and patient data
        public void startMonitor()
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Please select 1 or more module(s) to be read.");
            }
            else
            {
                if (label1.Text == "No record found")
                {

                    DialogResult result = MessageBox.Show("Are you sure you want to continue without patient details?\n\n" +
                                    "Note that the module readings will not be saved to database.", "Alert !", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (result == DialogResult.Yes)
                    {
                        button2.Text = "Halt";
                        button2.BackColor = Color.FromArgb(255, 8, 74);

                        run_Monitor.Tick += new EventHandler(runMonitor);
                        run_Monitor.Interval = 1000;
                        run_Monitor.Enabled = true;

                        getSoundBeep();

                        comboBox1.Enabled = false;
                        comboBox2.Enabled = false;
                        comboBox3.Enabled = false;
                        comboBox4.Enabled = false;

                        checkBox1.Enabled = false;
                        checkBox2.Enabled = false;
                        checkBox3.Enabled = false;
                        checkBox4.Enabled = false;
                    }
                }
                else
                {
                    button2.Text = "Halt";
                    button2.BackColor = Color.FromArgb(255, 8, 74);

                    run_Monitor.Tick += new EventHandler(runMonitor);
                    run_Monitor.Interval = 1000;
                    run_Monitor.Enabled = true;

                    getSoundBeep();

                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    comboBox4.Enabled = false;

                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    checkBox3.Enabled = false;
                    checkBox4.Enabled = false;
                }
            }
        }

        public void haltMonitor()
        {
            Label[] minMaxLabels = new Label[10] { label14, label15, label16, label17, label18, label19, label20, label21, label22, label23 };

            labelBorder(10, "Init");
            labelBorder(11, "Init");
            labelBorder(12, "Init");
            labelBorder(13, "Init");

            displayGraph("Pulse Rate", false, "Init");
            displayGraph("Breathing Rate", false, "Init");
            displayGraph("Blood Pressure", false, "Init");
            displayGraph("Temperature", false, "Init");

            button2.Text = "Start";
            button2.BackColor = Color.FromArgb(8, 255, 82);

            run_Monitor.Stop();
            player.Stop();
            playingSound = false;

            counter = 0;
            pulseRateCounter = 0;
            breathingRateCounter = 0;
            bloodPressureCounter = 0;
            temperatureCounter = 0;
            alarm = 4;

            //Still got problem in resetting the file reader
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            sr.BaseStream.Position = 0;

            for(int x = 0; x < minMaxLabels.Count(); x++)
            {
                minMaxLabels[x].Text = "---";
                minMaxLabels[x].ForeColor = Color.Silver;
            }

            label38.Text = "-";
            label38.ForeColor = Color.Silver;
            pictureBox14.BackColor = Color.Transparent;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;

            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox4.Enabled = true;
        }

        public void labelBorder(int labelSelected, string condition)
        {
            var labelBorder = label10;
            var labelName = label6;
            var borderColor = Color.Silver;

            Panel pnlTop = new Panel();
            Panel pnlRight = new Panel();
            Panel pnlBottom = new Panel();
            Panel pnlLeft = new Panel();

            switch (labelSelected)
            {
                case 10:
                    labelBorder = label10;
                    labelName = label6;
                    label10.Controls.Clear();

                    displayGraph("Pulse Rate", true, condition);

                    break;

                case 11:
                    labelBorder = label11;
                    labelName = label7;
                    label11.Controls.Clear();

                    displayGraph("Breathing Rate", true, condition);

                    break;

                case 12:
                    labelBorder = label12;
                    labelName = label8;
                    label12.Controls.Clear();

                    displayGraph("Blood Pressure", true, condition);

                    break;

                case 13:
                    labelBorder = label13;
                    labelName = label9;
                    label13.Controls.Clear();

                    displayGraph("Temperature", true, condition);

                    break;
            }

            if (condition == "Init")
            {
                borderColor = Color.Silver;
                labelBorder.ForeColor = Color.Silver;
                labelName.ForeColor = Color.Silver;

                label10.Text = "---";
                label11.Text = "--";
                label12.Text = "---/---";
                label13.Text = "--°C";
            }
            else if (condition == "Normal")
            {
                borderColor = Color.FromArgb(8, 255, 86);
                labelBorder.ForeColor = Color.FromArgb(8, 255, 86);
                labelName.ForeColor = Color.FromArgb(8, 255, 86);
            }
            else if (condition == "Risky")
            {
                borderColor = Color.FromArgb(255, 214, 8);
                labelBorder.ForeColor = Color.FromArgb(255, 214, 8);
                labelName.ForeColor = Color.FromArgb(255, 214, 8);
            }
            else if (condition == "Critical")
            {
                borderColor = Color.FromArgb(255, 8, 8);
                labelBorder.ForeColor = Color.FromArgb(255, 8, 8);
                labelName.ForeColor = Color.FromArgb(255, 8, 8);
            }

            pnlTop = new Panel() { Height = 2, Dock = DockStyle.Top, BackColor = borderColor };
            pnlRight = new Panel() { Width = 2, Dock = DockStyle.Right, BackColor = borderColor };
            pnlBottom = new Panel() { Height = 2, Dock = DockStyle.Bottom, BackColor = borderColor };
            pnlLeft = new Panel() { Width = 2, Dock = DockStyle.Left, BackColor = borderColor };

            labelBorder.Controls.Add(pnlTop);
            labelBorder.Controls.Add(pnlBottom);
            labelBorder.Controls.Add(pnlLeft);
            labelBorder.Controls.Add(pnlRight);
        }

        //Display realtime data of different modules in line graph format
        public void displayGraph(string module, bool reset, string condition)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            PatientReadingsHandler pReadingsHnd = new PatientReadingsHandler();
            ModuleReadingsHandler mRHand = new ModuleReadingsHandler();

            int maxReading = 0;
            float maxReadingT = 0;
            int counter = 0;

            //Set default value to variables
            var chart = chart1.ChartAreas[0];
            var chartChosen = chart1;

            var chartColor = Color.Silver;
            double xMin = 0.0;
            double xMax = 10.0;
            double yMin = 0.0;
            double yMax = 20.0;
            double xInt = 5;
            double yInt = 5;

            switch (module)
            {
                case "Pulse Rate":
                    chart = chart1.ChartAreas[0];
                    chartChosen = chart1;

                    if((label1.Text).ToString() != "No record found")
                    {
                        maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRMax", (label1.Text).ToString()));
                    }
                    
                    break;

                case "Breathing Rate":
                    chart = chart2.ChartAreas[0];
                    chartChosen = chart2;
                    
                    if((label1.Text).ToString() != "No record found")
                    {
                        maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMax", (label1.Text).ToString()));
                    }
                        
                    break;

                case "Blood Pressure":
                    chart = chart3.ChartAreas[0];
                    chartChosen = chart3;

                    if ((label1.Text).ToString() != "No record found")
                    {
                        maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "systolicMax", (label1.Text).ToString()));
                    }

                    break;

                case "Temperature":
                    chart = chart4.ChartAreas[0];
                    chartChosen = chart4;

                    if((label1.Text).ToString() != "No record found")
                    {
                        maxReadingT = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMax", (label1.Text).ToString()));
                    }
                     
                    break;
            }

            if (condition == "Init")
            {
                chartColor = Color.Silver;
            }
            else if (condition == "Normal")
            {
                chartColor = Color.FromArgb(8, 255, 86);
            }
            else if (condition == "Risky")
            {
                chartColor = Color.FromArgb(255, 214, 8);
            }
            else if (condition == "Critical")
            {
                chartColor = Color.FromArgb(255, 8, 8);
            }

            if (reset == false)
            {
                chart.AxisX.IntervalType = DateTimeIntervalType.Number;
                chart.AxisX.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                chart.AxisX.Minimum = xMin;
                chart.AxisX.Maximum = xMax;
                chart.AxisY.Minimum = yMin;
                chart.AxisY.Maximum = yMax;
                chart.AxisX.Interval = xInt;
                chart.AxisY.Interval = yInt;

                chartChosen.Series.Add(module);
                chartChosen.Series[module].ChartType = SeriesChartType.Line;
                chartChosen.Series[module].BorderWidth = 3;
                chartChosen.Series[module].Color = chartColor;

                chartChosen.Series[module].Points.AddXY(1, 10);
                chartChosen.Series[module].Points.AddXY(10, 10);
            }
            else if (reset == true && condition == "Init")
            {
                while (chartChosen.Series.Count > 0)
                {
                    chartChosen.Series.RemoveAt(0);
                }
            }
            else if(reset == true && condition != "Init")
            {
                while (chartChosen.Series.Count > 0)
                {
                    chartChosen.Series.RemoveAt(0);
                }

                chart.AxisX.IntervalType = DateTimeIntervalType.Number;
                chart.AxisX.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.IsEndLabelVisible = true;

                if (module == "Temperature")
                {
                    //Minimum Value
                    chart.AxisX.Minimum = 0;
                    chart.AxisY.Minimum = 0;

                    //Maximum Value
                    chart.AxisX.Maximum = double.NaN;
                    chart.AxisY.Maximum = maxReadingT + 20;
                }
                else
                {
                    //Minimum Value
                    chart.AxisX.Minimum = 0;
                    chart.AxisY.Minimum = 0;

                    //Maximum Value
                    chart.AxisX.Maximum = double.NaN;
                    chart.AxisY.Maximum = maxReading + 20;
                }

                chart.AxisX.Interval = 1;
                chart.AxisY.Interval = 1;
                chart.AxisX.IsMarginVisible = false;

                chartChosen.Series.Add(module);
                chartChosen.Series[module].ChartType = SeriesChartType.Line;
                chartChosen.Series[module].BorderWidth = 3;
                chartChosen.Series[module].Color = chartColor;

                for (int x = 0; x < realCounter; x++)
                {
                    chartChosen.Series[module].Points.AddXY(x, readingsList[x]);
                    chartChosen.Series[module].Points.AddXY(x + 0.5, 0);
                    
                    if (x > 10)
                    {
                        zoomPosition = realCounter - 10;

                        chart.AxisX.ScaleView.Zoom(zoomPosition, realCounter);
                    }
                    else
                    {
                        chart.AxisX.ScaleView.Zoom(1, 11);
                    }
                }
            }
        }

        public void runMonitor(object sender, EventArgs e)
        {
            var pulseRate = checkBox1.Checked;
            var breathingRate = checkBox2.Checked;
            var bloodPressure = checkBox3.Checked;
            var temperature = checkBox4.Checked;

            var criticalColor = Color.FromArgb(255, 8, 8);
            var inRiskColor = Color.FromArgb(255, 214, 8);
            var normalColor = Color.FromArgb(8, 255, 86);

            line = sr.ReadLine();

            if (line == null)
            {
                sr = new StreamReader("CSV/ModuleReadingsA.csv");
                line = sr.ReadLine();
            }

            DbConnector dbConn = new DbConnector();
            dbConn.connect();
            
            Patient ptient = new Patient();
            PatientHandler patHnd = new PatientHandler();

            ptient.Wing = (comboBox1.SelectedItem).ToString();
            ptient.Floor = (comboBox2.SelectedItem).ToString();
            ptient.Bay = (comboBox3.SelectedItem).ToString();
            ptient.Bed = (comboBox4.SelectedItem).ToString();

            string getPatientId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");

            int minPulse = 60;
            int maxPulse = 100;
            int minBreath = 12;
            int maxBreath = 20;
            int minSystolic = 80;
            int maxSystolic = 120;
            int minDiastolic = 60;
            int maxDiastolic = 80;
            float minTemp = 35.2F;
            float maxTemp = 36.1F;

            int pulseIntervalTime = 1;
            int breathIntervalTime = 1;
            int bloodPressureIntervalTime = 1;
            int temperatureIntervalTime = 1;

            if (getPatientId != "No record found")
            {
                ModuleReadingsHandler mRHand = new ModuleReadingsHandler();
                minPulse = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRMin", getPatientId));
                maxPulse = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRMax", getPatientId));
                pulseIntervalTime = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRIntTime", getPatientId));

                minBreath = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMin", getPatientId));
                maxBreath = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMax", getPatientId));
                breathIntervalTime = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRIntTime", getPatientId));

                minSystolic = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "systolicMin", getPatientId));
                maxSystolic = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "systolicMax", getPatientId));
                minDiastolic = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "diastolicMin", getPatientId));
                maxDiastolic = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "diastolicMax", getPatientId));
                bloodPressureIntervalTime = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "bloodPIntTime", getPatientId));

                minTemp = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMin", getPatientId));
                maxTemp = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMax", getPatientId));
                temperatureIntervalTime = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempIntTime", getPatientId));
            }

            PatientReadings pRead = new PatientReadings();
            PatientReadingsHandler pReadHnd = new PatientReadingsHandler();

            try
            {
                string[] data = line.Split(',');

                readingsList.Add(Int32.Parse(data[0]));

                //Pulse Rate Readings
                if (counter == pulseRateCounter && pulseRate != false)
                {
                    label10.Text = data[0];
                    label14.Text = (maxPulse).ToString();
                    label15.Text = (minPulse).ToString();

                    if (Int32.Parse(data[0]) == 0)
                    {
                        labelBorder(10, "Critical");
                        label14.ForeColor = criticalColor;
                        label15.ForeColor = criticalColor;
                    }
                    else if (Int32.Parse(data[0]) > maxPulse || Int32.Parse(data[0]) < minPulse)
                    {
                        labelBorder(10, "Risky");

                        if (Int32.Parse(data[0]) > maxPulse)
                        {
                            label14.ForeColor = inRiskColor;
                            label15.ForeColor = normalColor;
                        }
                        else
                        {
                            label14.ForeColor = normalColor;
                            label15.ForeColor = inRiskColor;
                        }
                    }
                    else if (Int32.Parse(data[0]) >= minPulse && Int32.Parse(data[0]) <= maxPulse)
                    {
                        labelBorder(10, "Normal");
                        label14.ForeColor = normalColor;
                        label15.ForeColor = normalColor;
                    }

                    pulseRateCounter = pulseRateCounter + pulseIntervalTime;
                }

                //Breathing Rate Readings
                if (counter == breathingRateCounter && breathingRate != false)
                {
                    label11.Text = data[1];
                    label16.Text = (maxBreath).ToString();
                    label17.Text = (minBreath).ToString();

                    if (Int32.Parse(data[1]) == 0)
                    {
                        labelBorder(11, "Critical");
                        label16.ForeColor = criticalColor;
                        label17.ForeColor = criticalColor;
                    }
                    else if ((Int32.Parse(data[1]) > maxBreath || Int32.Parse(data[1]) < minBreath))
                    {
                        labelBorder(11, "Risky");

                        if (Int32.Parse(data[1]) > maxBreath)
                        {
                            label16.ForeColor = inRiskColor;
                            label17.ForeColor = normalColor;
                        }
                        else
                        {
                            label16.ForeColor = normalColor;
                            label17.ForeColor = inRiskColor;
                        }
                    }
                    else if (Int32.Parse(data[1]) >= minBreath && Int32.Parse(data[1]) <= maxBreath)
                    {
                        labelBorder(11, "Normal");
                        label16.ForeColor = normalColor;
                        label17.ForeColor = normalColor;
                    }

                    breathingRateCounter = breathingRateCounter + breathIntervalTime;
                }

                //Blood Pressure  Readings
                if (counter == bloodPressureCounter && bloodPressure != false)
                {
                    label12.Text = data[2] + "/" + data[3];
                    label18.Text = (maxSystolic).ToString();
                    label19.Text = (minSystolic).ToString();
                    label20.Text = (maxDiastolic).ToString();
                    label21.Text = (minDiastolic).ToString();

                    if (Int32.Parse(data[2]) == 0 || (Int32.Parse(data[3]) == 0))
                    {
                        labelBorder(12, "Critical");
                        label18.ForeColor = criticalColor;
                        label19.ForeColor = criticalColor;
                        label20.ForeColor = criticalColor;
                        label21.ForeColor = criticalColor;
                    }
                    else if ((Int32.Parse(data[2]) > maxSystolic || Int32.Parse(data[2]) < minSystolic) || (Int32.Parse(data[3]) > maxDiastolic || Int32.Parse(data[3]) < minDiastolic))
                    {
                        labelBorder(12, "Risky");

                        if(Int32.Parse(data[2]) > maxSystolic)
                        {
                            label18.ForeColor = inRiskColor;
                            label19.ForeColor = normalColor;
                        }
                        else if(Int32.Parse(data[2]) < minSystolic)
                        {
                            label18.ForeColor = normalColor;
                            label19.ForeColor = inRiskColor;
                        }

                        if (Int32.Parse(data[3]) > maxDiastolic)
                        {
                            label20.ForeColor = inRiskColor;
                            label21.ForeColor = normalColor;
                        }
                        else if (Int32.Parse(data[3]) < minDiastolic)
                        {
                            label20.ForeColor = normalColor;
                            label21.ForeColor = inRiskColor;
                        }
                    }
                    else if (Int32.Parse(data[2]) >= minSystolic && Int32.Parse(data[2]) <= maxSystolic && Int32.Parse(data[3]) >= minSystolic && Int32.Parse(data[3]) <= maxSystolic)
                    {
                        labelBorder(12, "Normal");
                        label18.ForeColor = normalColor;
                        label19.ForeColor = normalColor;
                        label20.ForeColor = normalColor;
                        label21.ForeColor = normalColor;
                    }

                    bloodPressureCounter = bloodPressureCounter + bloodPressureIntervalTime;
                }

                //Temperature Readings
                if (counter == temperatureCounter && temperature != false)
                {
                    label13.Text = data[4] + "°C";
                    label22.Text = (maxTemp).ToString();
                    label23.Text = (minTemp).ToString();

                    if (float.Parse(data[4]) == 0)
                    {
                        labelBorder(13, "Critical");
                        label22.ForeColor = criticalColor;
                        label23.ForeColor = criticalColor;
                    }
                    else if (float.Parse(data[4]) > maxTemp || float.Parse(data[4]) < minTemp)
                    {
                        labelBorder(13, "Risky");

                        if(float.Parse(data[4]) > maxTemp)
                        {
                            label22.ForeColor = inRiskColor;
                            label23.ForeColor = normalColor;
                        }
                        else
                        {
                            label22.ForeColor = normalColor;
                            label23.ForeColor = inRiskColor;
                        }
                    }
                    else if (float.Parse(data[4]) >= minTemp && float.Parse(data[4]) <= maxTemp)
                    {
                        labelBorder(13, "Normal");
                        label22.ForeColor = normalColor;
                        label23.ForeColor = normalColor;
                    }

                    temperatureCounter = temperatureCounter + temperatureIntervalTime;
                }

                if (getPatientId != "No record found")
                {
                    pRead.PatientId = Int32.Parse(getPatientId);
                    pRead.PulseRate = Int32.Parse(data[0]);
                    pRead.BreathingRate = Int32.Parse(data[1]);
                    pRead.Systolic = Int32.Parse(data[2]);
                    pRead.Diastolic = Int32.Parse(data[3]);
                    pRead.Temperature = float.Parse(data[4]);
                    pRead.DateTime = DateTime.Now.ToString();

                    pReadHnd.addPatientReading(dbConn.getConn(), pRead);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DID NOT RECEIVE ANY DETECTION OF THE READING : " + ex);
                run_Monitor.Stop();
            }

            if (counter == 5)
            {
                counter = 0;
                pulseRateCounter = 0;
                bloodPressureCounter = 0;
                breathingRateCounter = 0;
                temperatureCounter = 0;
            }
            else
            {
                counter++;
            }

            realCounter++;
        }

        public void getSoundBeep()
        {
            int checkAlarm = 0;

            Panel pnlTop = new Panel();
            Panel pnlRight = new Panel();
            Panel pnlBottom = new Panel();
            Panel pnlLeft = new Panel();

            var borderColor = Color.Silver;
            label38.Controls.Clear();

            if (label10.ForeColor == Color.FromArgb(255, 8, 8) ||
               label11.ForeColor == Color.FromArgb(255, 8, 8) ||
               label12.ForeColor == Color.FromArgb(255, 8, 8) ||
               label13.ForeColor == Color.FromArgb(255, 8, 8))
            {
                checkAlarm = 3;
                label38.ForeColor = Color.FromArgb(255, 8, 8);
                label38.Text = "Critical";
                borderColor = Color.FromArgb(255, 8, 8);
                pictureBox14.BackColor = Color.FromArgb(255, 8, 8);
            }
            else if (label10.ForeColor == Color.FromArgb(255, 214, 8) ||
               label11.ForeColor == Color.FromArgb(255, 214, 8) ||
               label12.ForeColor == Color.FromArgb(255, 214, 8) ||
               label13.ForeColor == Color.FromArgb(255, 214, 8))
            {
                checkAlarm = 2;
                label38.ForeColor = Color.FromArgb(255, 214, 8);
                label38.Text = "In Risk";
                borderColor = Color.FromArgb(255, 214, 8);
                pictureBox14.BackColor = Color.FromArgb(255, 214, 8);
            }
            else if (label10.ForeColor == Color.FromArgb(8, 255, 86) ||
               label11.ForeColor == Color.FromArgb(8, 255, 86) ||
               label12.ForeColor == Color.FromArgb(8, 255, 86) ||
               label13.ForeColor == Color.FromArgb(8, 255, 86))
            {
                checkAlarm = 1;
                label38.ForeColor = Color.FromArgb(8, 255, 86);
                label38.Text = "Normal";
                borderColor = Color.FromArgb(8, 255, 86);
                pictureBox14.BackColor = Color.FromArgb(8, 255, 86);
            }

            if (checkAlarm != alarm)
            {
                if (alarm > checkAlarm)
                {
                    alarm = checkAlarm;

                    if (alarm == 3)
                    {
                        player.SoundLocation = "Sounds/criticalBeep.wav";
                    }
                    else if (alarm == 2)
                    {
                        player.SoundLocation = "Sounds/riskyBeep.wav";
                    }
                    else if (alarm == 1)
                    {
                        player.SoundLocation = "Sounds/normalBeep.wav";
                    }

                    player.PlayLooping();
                }
                else if (checkAlarm > alarm)
                {
                    alarm = checkAlarm;

                    if (label10.ForeColor == Color.FromArgb(255, 8, 8) ||
                        label11.ForeColor == Color.FromArgb(255, 8, 8) ||
                        label12.ForeColor == Color.FromArgb(255, 8, 8) ||
                        label13.ForeColor == Color.FromArgb(255, 8, 8))
                    {
                        checkAlarm = 3;
                        label38.ForeColor = Color.FromArgb(255, 8, 8);
                        label38.Text = "Critical";
                        borderColor = Color.FromArgb(255, 8, 8);
                        pictureBox14.BackColor = Color.FromArgb(255, 8, 8);
                    }
                    else if (label10.ForeColor == Color.FromArgb(255, 214, 8) ||
                       label11.ForeColor == Color.FromArgb(255, 214, 8) ||
                       label12.ForeColor == Color.FromArgb(255, 214, 8) ||
                       label13.ForeColor == Color.FromArgb(255, 214, 8))
                    {
                        checkAlarm = 2;
                        label38.ForeColor = Color.FromArgb(255, 214, 8);
                        label38.Text = "In Risk";
                        borderColor = Color.FromArgb(255, 214, 8);
                        pictureBox14.BackColor = Color.FromArgb(255, 214, 8);
                    }
                    else if (label10.ForeColor == Color.FromArgb(8, 255, 86) ||
                       label11.ForeColor == Color.FromArgb(8, 255, 86) ||
                       label12.ForeColor == Color.FromArgb(8, 255, 86) ||
                       label13.ForeColor == Color.FromArgb(8, 255, 86))
                    {
                        checkAlarm = 1;
                        label38.ForeColor = Color.FromArgb(8, 255, 86);
                        label38.Text = "Normal";
                        borderColor = Color.FromArgb(8, 255, 86);
                        pictureBox14.BackColor = Color.FromArgb(8, 255, 86);
                    }

                    if (checkAlarm == 3)
                    {
                        player.SoundLocation = "Sounds/criticalBeep.wav";
                    }
                    else if (checkAlarm == 2)
                    {
                        player.SoundLocation = "Sounds/riskyBeep.wav";
                    }
                    else if (checkAlarm == 1)
                    {
                        player.SoundLocation = "Sounds/normalBeep.wav";
                    }

                    player.PlayLooping();
                }
            }

            pnlTop = new Panel() { Height = 2, Dock = DockStyle.Top, BackColor = borderColor };
            pnlRight = new Panel() { Width = 2, Dock = DockStyle.Right, BackColor = borderColor };
            pnlBottom = new Panel() { Height = 2, Dock = DockStyle.Bottom, BackColor = borderColor };
            pnlLeft = new Panel() { Width = 2, Dock = DockStyle.Left, BackColor = borderColor };

            label38.Controls.Add(pnlTop);
            label38.Controls.Add(pnlBottom);
            label38.Controls.Add(pnlLeft);
            label38.Controls.Add(pnlRight);

            playingSound = true;
        }

        // Detect changes in fore color at label10
        public void label10_ForeColorChanged(object sender, EventArgs e)
        {
            getSoundBeep();
        }

        // Detect changes in fore color at label11
        public void label11_ForeColorChanged(object sender, EventArgs e)
        {
            getSoundBeep();
        }

        // Detect changes in fore color at label12
        public void label12_ForeColorChanged(object sender, EventArgs e)
        {
            getSoundBeep();
        }

        // Detect changes in fore color at label13
        public void label13_ForeColorChanged(object sender, EventArgs e)
        {
            getSoundBeep();
        }

        //Stop beep sound and monitor while closing
        public void Bedside_System_FormClosed(object sender, FormClosedEventArgs e)
        {
            run_Monitor.Stop();
            player.Stop();
        }

        public void getBasicPatientDetails()
        {
            if ((comboBox1.SelectedItem).ToString() != " - SELECT WING - " &&
                   (comboBox2.SelectedItem).ToString() != " - SELECT FLOOR - " &&
                   (comboBox3.SelectedItem).ToString() != " - SELECT BAY - " &&
                   (comboBox4.SelectedItem).ToString() != " - SELECT BED - ")
            {
                DbConnector dbConn = new DbConnector();
                dbConn.connect();

                Patient ptient = new Patient();

                ptient.Wing = (comboBox1.SelectedItem).ToString();
                ptient.Floor = (comboBox2.SelectedItem).ToString();
                ptient.Bay = (comboBox3.SelectedItem).ToString();
                ptient.Bed = (comboBox4.SelectedItem).ToString();

                PatientHandler patHnd = new PatientHandler();

                string checkId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");
                string checkName = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientName");
                string checkAge = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientAge");
                string checkGender = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientGender");

                label1.Text = checkId;
                label2.Text = checkName;
                label3.Text = checkAge;
                label4.Text = checkGender;

                label34.Text = (comboBox1.SelectedItem).ToString() + " → " + (comboBox2.SelectedItem).ToString() + " → " +
                               (comboBox3.SelectedItem).ToString();
                label36.Text = (comboBox4.SelectedItem).ToString().Remove(0, 4);
            }
            else
            {
                label1.Text = "No record found";
                label2.Text = "No record found";
                label3.Text = "No record found";
                label4.Text = "No record found";

                label34.Text = "- Wing → Floor - → Bay - ";
                label36.Text = "-";
            }
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBasicPatientDetails();
        }

        public void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBasicPatientDetails();
        }

        public void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBasicPatientDetails();
        }

        public void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            getBasicPatientDetails();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            string wingSelected = (comboBox1.SelectedItem).ToString();
            string floorSelected = (comboBox2.SelectedItem).ToString();
            string baySelected = (comboBox3.SelectedItem).ToString();
            string bedSelected = (comboBox4.SelectedItem).ToString();

            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();

            ptient.Wing = wingSelected;
            ptient.Floor = floorSelected;
            ptient.Bay = baySelected;
            ptient.Bed = bedSelected;

            PatientHandler patHnd = new PatientHandler();

            string checkId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");

            if (checkId != "No record found")
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

        public void pictureBox14_Click(object sender, EventArgs e)
        {
            if(pictureBox14.BackColor == Color.FromArgb(255, 8, 8))
            {
                MessageBox.Show("Critical alarm cannot be stopped !");
            }
            else if(pictureBox14.BackColor == Color.FromArgb(255, 214, 8))
            {
                player.Stop(); 
            }
        }
    }
}
