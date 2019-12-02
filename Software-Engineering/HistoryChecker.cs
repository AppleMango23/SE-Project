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
    public partial class HistoryChecker : Form
    {
        public HistoryChecker()
        {
            InitializeComponent();

            this.MinimumSize = new Size(942, 795);
            this.MaximumSize = new Size(943, 795);
        }

        string[] passData = new string[] { };

        public void getData(string[] allData)
        {
            passData = allData;

            label5.Text = allData[0];
            label6.Text = allData[1];
            label7.Text = allData[2];
            label8.Text = allData[3];
            label9.Text = allData[4];

            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            ModuleReadingsHandler mReadingsHnd = new ModuleReadingsHandler();

            //Table Section
            if(allData[4] == "Pulse Rate" || allData[4] == "Breathing Rate")
            {
                dataGridView1.DataSource = mReadingsHnd.listModules(dbConn.getConn(), Int32.Parse(allData[0]), allData[4]);
                dataGridView1.Columns[0].HeaderText = "NO.";
                dataGridView1.Columns[17].HeaderText = "MINIMUM READING";
                dataGridView1.Columns[18].HeaderText = "MAXIMUM READING";
                dataGridView1.Columns[19].HeaderText = "TIME INTERVAL (SECOND(S))";
                dataGridView1.Columns[20].HeaderText = "LAST MODIFIED";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[17].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[18].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[19].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[20].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns.Remove("PatientId");
                dataGridView1.Columns.Remove("MinPulse");
                dataGridView1.Columns.Remove("MaxPulse");
                dataGridView1.Columns.Remove("PulseIntTime");
                dataGridView1.Columns.Remove("MinBreath");
                dataGridView1.Columns.Remove("MaxBreath");
                dataGridView1.Columns.Remove("BreathIntTime");
                dataGridView1.Columns.Remove("MinSystolic");
                dataGridView1.Columns.Remove("MaxSystolic");
                dataGridView1.Columns.Remove("MinDiastolic");
                dataGridView1.Columns.Remove("MaxDiastolic");
                dataGridView1.Columns.Remove("PressureIntTime");
                dataGridView1.Columns.Remove("MinTemp");
                dataGridView1.Columns.Remove("MaxTemp");
                dataGridView1.Columns.Remove("TempIntTime");
                dataGridView1.Columns.Remove("Selected");
                dataGridView1.Columns.Remove("BRModifiedTime");
                dataGridView1.Columns.Remove("BPModifiedTime");
                dataGridView1.Columns.Remove("TempModifiedTime");
            }

            if (allData[4] == "Blood Pressure")
            {
                dataGridView1.DataSource = mReadingsHnd.listModules(dbConn.getConn(), Int32.Parse(allData[0]), allData[4]);
                dataGridView1.Columns[0].HeaderText = "NO.";
                dataGridView1.Columns[8].HeaderText = "MINIMUM READING (SYSTOLIC)";
                dataGridView1.Columns[9].HeaderText = "MAXIMUM READING (SYSTOLIC)";
                dataGridView1.Columns[10].HeaderText = "MINIMUM READING (DIASTOLIC)";
                dataGridView1.Columns[11].HeaderText = "MAXIMUM READING (DIASTOLIC)";
                dataGridView1.Columns[12].HeaderText = "TIME INTERVAL (SECOND(S))";
                dataGridView1.Columns[22].HeaderText = "LAST MODIFIED";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[22].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns.Remove("PatientId");
                dataGridView1.Columns.Remove("MinPulse");
                dataGridView1.Columns.Remove("MaxPulse");
                dataGridView1.Columns.Remove("PulseIntTime");
                dataGridView1.Columns.Remove("MinBreath");
                dataGridView1.Columns.Remove("MaxBreath");
                dataGridView1.Columns.Remove("BreathIntTime");
                dataGridView1.Columns.Remove("MinTemp");
                dataGridView1.Columns.Remove("MaxTemp");
                dataGridView1.Columns.Remove("TempIntTime");
                dataGridView1.Columns.Remove("Selected");
                dataGridView1.Columns.Remove("BothMin");
                dataGridView1.Columns.Remove("BothMax");
                dataGridView1.Columns.Remove("SelectedNum");
                dataGridView1.Columns.Remove("BRModifiedTime");
                dataGridView1.Columns.Remove("PRModifiedTime");
                dataGridView1.Columns.Remove("TempModifiedTime");
            }

            if (allData[4] == "Temperature")
            {
                dataGridView1.DataSource = mReadingsHnd.listModules(dbConn.getConn(), Int32.Parse(allData[0]), allData[4]);
                dataGridView1.Columns[0].HeaderText = "NO.";
                dataGridView1.Columns[13].HeaderText = "MINIMUM READING";
                dataGridView1.Columns[14].HeaderText = "MAXIMUM READING";
                dataGridView1.Columns[15].HeaderText = "TIME INTERVAL (SECOND(S))";
                dataGridView1.Columns[23].HeaderText = "LAST MODIFIED";
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[23].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Columns.Remove("PatientId");
                dataGridView1.Columns.Remove("MinPulse");
                dataGridView1.Columns.Remove("MaxPulse");
                dataGridView1.Columns.Remove("PulseIntTime");
                dataGridView1.Columns.Remove("MinBreath");
                dataGridView1.Columns.Remove("MaxBreath");
                dataGridView1.Columns.Remove("BreathIntTime");
                dataGridView1.Columns.Remove("MinSystolic");
                dataGridView1.Columns.Remove("MaxSystolic");
                dataGridView1.Columns.Remove("MinDiastolic");
                dataGridView1.Columns.Remove("MaxDiastolic");
                dataGridView1.Columns.Remove("PressureIntTime");
                dataGridView1.Columns.Remove("BothMin");
                dataGridView1.Columns.Remove("BothMax");
                dataGridView1.Columns.Remove("SelectedNum");
                dataGridView1.Columns.Remove("Selected");
                dataGridView1.Columns.Remove("BRModifiedTime");
                dataGridView1.Columns.Remove("BPModifiedTime");
                dataGridView1.Columns.Remove("PRModifiedTime");
            }

            //Graph Section
            if (allData[4] != "Blood Pressure")
            {
                int xBlockSize = 8;
                int yBlockSize = 10;
                chart1.Visible = true;
                chart2.Visible = false;

                PatientReadingsHandler pReadingsHnd = new PatientReadingsHandler();
                ModuleReadingsHandler mRHand = new ModuleReadingsHandler();

                string what = "";
                int minReading = 0;
                int maxReading = 0;
                float minReadingT = 0;
                float maxReadingT = 0;
                int counter = 0;
                var chart = chart1.ChartAreas[0];
                int timeInterval = 1;
                int readingsInterval = 1;
                int startOffset = -2;
                int endOffset = 2;

                if (allData[4] == "Pulse Rate")
                {
                    what = "pulseRate";
                    minReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRMin", allData[0].ToString()));
                    maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "pulseRMax", allData[0].ToString()));
                }
                else if(allData[4] == "Breathing Rate")
                {
                    what = "breathingRate";
                    minReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMin", allData[0].ToString()));
                    maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMax", allData[0].ToString()));
                }
                else if(allData[4] == "Temperature")
                {
                    what = "temperature";
                    minReadingT = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMin", allData[0].ToString()));
                    maxReadingT = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMax", allData[0].ToString()));
                }

                foreach (var Txt in pReadingsHnd.getReadings(dbConn.getConn(), Int32.Parse(allData[0]), what))
                {
                    CustomLabel dateTimeLabel = new CustomLabel(startOffset, endOffset, (Txt.DateTime).ToString(), 0, LabelMarkStyle.None);

                    if(what == "temperature")
                    {
                        chart1.Series["Module Readings"].Points.AddXY(counter, float.Parse((Txt.FloatRate).ToString()));
                    }
                    else
                    {
                        chart1.Series["Module Readings"].Points.AddXY(counter, Int32.Parse((Txt.IntRate).ToString()));
                    }
                    chart.AxisX.CustomLabels.Add(dateTimeLabel);

                    startOffset = startOffset + 1;
                    endOffset = endOffset + 1;
                    counter++;
                }

                chart1.Series["Module Readings"].IsValueShownAsLabel = true;

                chart.AxisX.LabelStyle.Angle = -45;
                chart.AxisY.Title = label9.Text;
                chart.AxisX.Title = "Date and Time";

                if (allData[4] == "Temperature")
                {
                    //Minimum Value
                    chart1.Series["Minimum"].Points.AddXY(0, minReadingT);
                    chart1.Series["Minimum"].Points.AddXY(counter, minReadingT);

                    //Maximum Value
                    chart1.Series["Maximum"].Points.AddXY(0, maxReadingT);
                    chart1.Series["Maximum"].Points.AddXY(counter, maxReadingT);
                }
                else
                {
                    //Minimum Value
                    chart1.Series["Minimum"].Points.AddXY(0, minReading);
                    chart1.Series["Minimum"].Points.AddXY(counter, minReading);

                    //Maximum Value
                    chart1.Series["Maximum"].Points.AddXY(0, maxReading);
                    chart1.Series["Maximum"].Points.AddXY(counter, maxReading);
                }

                //Set view range
                chart.AxisX.Minimum = 0;
                //chart.AxisX.Maximum = double.NaN;
                chart.AxisY.Minimum = 0;
                //chart.AxisY.Maximum = double.NaN;
                chart.AxisX.Interval = timeInterval;
                chart.AxisY.Interval = readingsInterval;

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
            else
            {
                chart1.Visible = false;
                chart2.Visible = true;

                int xBlockSize = 8;
                int yBlockSize = 10;
                string what = "bloodPressure";
                
                PatientReadingsHandler pReadingsHnd = new PatientReadingsHandler();
                ModuleReadingsHandler mRHand = new ModuleReadingsHandler();

                int counter = 0;
                int startOffset = -2;
                int endOffset = 2;
                var chart = chart2.ChartAreas[0];
                int timeInterval = 1;
                int readingsInterval = 1;

                int minReadingS = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "systolicMin", allData[0].ToString()));
                int maxReadingS = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "systolicMax", allData[0].ToString()));
                int minReadingD = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "diastolicMin", allData[0].ToString()));
                int maxReadingD = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "diastolicMax", allData[0].ToString()));

                foreach (var Txt in pReadingsHnd.getReadings(dbConn.getConn(), Int32.Parse(allData[0]), what))
                {
                    CustomLabel dateTimeLabel = new CustomLabel(startOffset, endOffset, (Txt.DateTime).ToString(), 0, LabelMarkStyle.None);

                    chart2.Series["Systolic"].Points.AddXY(counter, Int32.Parse((Txt.IntRate).ToString()));
                    chart2.Series["Diastolic"].Points.AddXY(counter, Int32.Parse((Txt.IntRate2).ToString()));
                    chart.AxisX.CustomLabels.Add(dateTimeLabel);

                    startOffset = startOffset + 1;
                    endOffset = endOffset + 1;
                    counter++;
                }

                chart2.Series["Systolic"].IsValueShownAsLabel = true;
                chart2.Series["Diastolic"].IsValueShownAsLabel = true;

                chart.AxisX.LabelStyle.Angle = -45;
                chart.AxisY.Title = "Blood Pressure Readings";
                chart.AxisX.Title = "Date and Time";

                //Minimum Value
                chart2.Series["Minimum (Systolic)"].Points.AddXY(0, minReadingS);
                chart2.Series["Minimum (Systolic)"].Points.AddXY(counter, minReadingS);
                chart2.Series["Minimum (Diastolic)"].Points.AddXY(0, minReadingD);
                chart2.Series["Minimum (Diastolic)"].Points.AddXY(counter, minReadingD);

                //Maximum Value
                chart2.Series["Maximum (Systolic)"].Points.AddXY(0, maxReadingS);
                chart2.Series["Maximum (Systolic)"].Points.AddXY(counter, maxReadingS);
                chart2.Series["Maximum (Diastolic)"].Points.AddXY(0, maxReadingD);
                chart2.Series["Maximum (Diastolic)"].Points.AddXY(counter, maxReadingD);

                //Set view range
                chart.AxisX.Minimum = 0;
                //chart.AxisX.Maximum = double.NaN;
                chart.AxisY.Minimum = 0;
                //chart.AxisY.Maximum = double.NaN;
                chart.AxisX.Interval = timeInterval;
                chart.AxisY.Interval = readingsInterval;

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
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ZoomGraph zoomGraph = new ZoomGraph();
            zoomGraph.getData(passData);
            zoomGraph.Show();
        }
    }
}
