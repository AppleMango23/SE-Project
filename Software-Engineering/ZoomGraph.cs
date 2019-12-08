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
    public partial class ZoomGraph : Form
    {
        public ZoomGraph()
        {
            InitializeComponent();

            this.MinimumSize = new Size(1300, 750);
            this.MaximumSize = new Size(1300, 750);
        }

        public void getData(string[] allData)
        {
            this.Text = "Patient ID: " + allData[0] + " (" + allData[1] + ")";

            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            //Graph Section
            if (allData[4] != "Blood Pressure")
            {
                int xBlockSize = 10;
                int yBlockSize = 20;

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
                else if (allData[4] == "Breathing Rate")
                {
                    what = "breathingRate";
                    minReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMin", allData[0].ToString()));
                    maxReading = Int32.Parse(mRHand.getModuleReading(dbConn.getConn(), "breathRMax", allData[0].ToString()));
                }
                else if (allData[4] == "Temperature")
                {
                    what = "temperature";
                    minReadingT = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMin", allData[0].ToString()));
                    maxReadingT = float.Parse(mRHand.getModuleReading(dbConn.getConn(), "tempMax", allData[0].ToString()));
                }

                foreach (var Txt in pReadingsHnd.getReadings(dbConn.getConn(), Int32.Parse(allData[0]), what))
                {
                    CustomLabel dateTimeLabel = new CustomLabel(startOffset, endOffset, (Txt.DateTime).ToString(), 0, LabelMarkStyle.None);

                    if (what == "temperature")
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
                chart.AxisY.Title = allData[4];
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

                int xBlockSize = 10;
                int yBlockSize = 20;
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
    }
}
