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
    public partial class PatientModuleReadingsConfiguration : Form
    {
        public PatientModuleReadingsConfiguration()
        {
            InitializeComponent();

            this.MinimumSize = new Size(775, 515);
            this.MaximumSize = new Size(775, 515);
        }

        public void displayData(string[] patientData)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            Patient ptient = new Patient();

            ptient.Wing = patientData[0];
            ptient.Floor = patientData[1];
            ptient.Bay = patientData[2];
            ptient.Bed = patientData[3];

            label15.Text = patientData[0];
            label16.Text = patientData[1];
            label17.Text = patientData[2];
            label18.Text = patientData[3];

            PatientHandler patHnd = new PatientHandler();

            string checkId = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientId");
            string checkName = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientName");
            string checkAge = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientAge");
            string checkGender = patHnd.getPatientDetails(dbConn.getConn(), ptient, "patientGender");

            label11.Text = checkId;
            label12.Text = checkName;
            label13.Text = checkAge;
            label14.Text = checkGender;

            latestValues();
        }

        public void latestValues()
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            string checkId = label11.Text;

            ModuleReadingsHandler mRHand = new ModuleReadingsHandler();

            //Pulse Rate
            textBox3.Text = mRHand.getModuleReading(dbConn.getConn(), "pulseRMin", checkId);
            textBox4.Text = mRHand.getModuleReading(dbConn.getConn(), "pulseRMax", checkId);
            textBox23.Text = mRHand.getModuleReading(dbConn.getConn(), "pulseRIntTime", checkId);
            //Breathing Rate
            textBox6.Text = mRHand.getModuleReading(dbConn.getConn(), "breathRMin", checkId);
            textBox5.Text = mRHand.getModuleReading(dbConn.getConn(), "breathRMax", checkId);
            textBox24.Text = mRHand.getModuleReading(dbConn.getConn(), "breathRIntTime", checkId);
            //Blood Pressure
            textBox8.Text = mRHand.getModuleReading(dbConn.getConn(), "systolicMin", checkId);
            textBox7.Text = mRHand.getModuleReading(dbConn.getConn(), "systolicMax", checkId);
            textBox9.Text = mRHand.getModuleReading(dbConn.getConn(), "diastolicMin", checkId);
            textBox10.Text = mRHand.getModuleReading(dbConn.getConn(), "diastolicMax", checkId);
            textBox25.Text = mRHand.getModuleReading(dbConn.getConn(), "bloodPIntTime", checkId);
            //Temperature
            textBox11.Text = mRHand.getModuleReading(dbConn.getConn(), "tempMin", checkId);
            textBox12.Text = mRHand.getModuleReading(dbConn.getConn(), "tempMax", checkId);
            textBox26.Text = mRHand.getModuleReading(dbConn.getConn(), "tempIntTime", checkId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnector dbConn = new DbConnector();
            dbConn.connect();

            string checkId = label11.Text;

            ModuleReadingsHandler mRHand = new ModuleReadingsHandler();

            if (textBox3.Text == mRHand.getModuleReading(dbConn.getConn(), "pulseRMin", checkId) &&
                textBox4.Text == mRHand.getModuleReading(dbConn.getConn(), "pulseRMax", checkId) &&
                textBox23.Text == mRHand.getModuleReading(dbConn.getConn(), "pulseRIntTime", checkId) &&
                textBox6.Text == mRHand.getModuleReading(dbConn.getConn(), "breathRMin", checkId) &&
                textBox5.Text == mRHand.getModuleReading(dbConn.getConn(), "breathRMax", checkId) &&
                textBox24.Text == mRHand.getModuleReading(dbConn.getConn(), "breathRIntTime", checkId) && 
                textBox8.Text == mRHand.getModuleReading(dbConn.getConn(), "systolicMin", checkId) &&
                textBox7.Text == mRHand.getModuleReading(dbConn.getConn(), "systolicMax", checkId) &&
                textBox9.Text == mRHand.getModuleReading(dbConn.getConn(), "diastolicMin", checkId) &&
                textBox10.Text == mRHand.getModuleReading(dbConn.getConn(), "diastolicMax", checkId) &&
                textBox25.Text == mRHand.getModuleReading(dbConn.getConn(), "bloodPIntTime", checkId) &&
                textBox11.Text == mRHand.getModuleReading(dbConn.getConn(), "tempMin", checkId) &&
                textBox12.Text == mRHand.getModuleReading(dbConn.getConn(), "tempMax", checkId) &&
                textBox26.Text == mRHand.getModuleReading(dbConn.getConn(), "tempIntTime", checkId))
            {
                MessageBox.Show("No changes detected");
            }
            else
            {
                ModuleReadings mConfig = new ModuleReadings();

                string thePatientId = checkId;

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

                mRHand.updatePatientBedsideId(dbConn.getConn(), mConfig, Int32.Parse(thePatientId), "New");

                MessageBox.Show("Module Reading Changed Successfully !");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            latestValues();
        }
    }
}
