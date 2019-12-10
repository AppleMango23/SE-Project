using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    public class PatientReadingsHandler
    {
        //Add normal data
        public void addPatientReading(MySqlConnection conn, PatientReadings pRead)
        {
            string sql = "INSERT INTO patientreadings (patientId, pulseRate, breathingRate, systolic, diastolic, " +
                "temperature, dateAndTime) VALUES (" + pRead.PatientId + ", " + pRead.PulseRate + " , " + pRead.BreathingRate + ", " +
                pRead.Systolic + ", " + pRead.Diastolic + ", " + pRead.Temperature + ", '" + pRead.DateTime + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            sqlComm.ExecuteNonQuery();
        }

        //Show on the central station one
        public string displayModuleReadings(MySqlConnection conn, PatientReadings pRead, string readingNeeded)
        {
            string reading = "";
            string sql = "SELECT " + readingNeeded +" FROM patientreadings WHERE patientId=" + pRead.PatientId;

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            sqlComm.ExecuteNonQuery();

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    reading = (string)(sqlReader.GetValue(0)).ToString();
                }
            }

            return reading;
        }

        public List<PatientReadings> showReadings(MySqlConnection conn, string patientId)
        {
            List<PatientReadings> listOfTheReadings = new List<PatientReadings>();

            string sql = "SELECT pulseRate, breathingRate, systolic, diastolic, temperature FROM `patientreadings` WHERE patientId="+ patientId + " ORDER BY patientReadingId DESC LIMIT 1";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    PatientReadings mReadings = new PatientReadings();

                    mReadings.PulseRate = (int)sqlReader.GetValue(0);
                    mReadings.BreathingRate = (int)sqlReader.GetValue(1);
                    mReadings.Systolic = (int)sqlReader.GetValue(2);
                    mReadings.Diastolic = (int)sqlReader.GetValue(3);
                    mReadings.Temperature = (float)sqlReader.GetValue(4);

                    listOfTheReadings.Add(mReadings);
                }
            }

            return listOfTheReadings;
        }

        public List<PatientReadings> getReadings(MySqlConnection conn, int patientId, string readingNeeded)
        {
            List<PatientReadings> listOfReadings = new List<PatientReadings>();

            string sql = "";

            if (readingNeeded == "pulseRate" || readingNeeded == "breathingRate" || readingNeeded == "temperature")
            {
                sql = "SELECT " + readingNeeded + ", dateAndTime FROM patientreadings WHERE patientId=" + patientId;
            }
            else
            {
                sql = "SELECT systolic, diastolic, dateAndTime FROM patientreadings WHERE patientId=" + patientId;
            }

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    PatientReadings mReadings = new PatientReadings();

                    if(readingNeeded == "pulseRate" || readingNeeded == "breathingRate")
                    {
                        mReadings.IntRate = (int)sqlReader.GetValue(0);
                        mReadings.DateTime = (string)sqlReader.GetValue(1);
                    }
                    else if(readingNeeded == "temperature")
                    {
                        mReadings.FloatRate = (float)sqlReader.GetValue(0);
                        mReadings.DateTime = (string)sqlReader.GetValue(1);
                    }
                    else
                    {
                        mReadings.IntRate = (int)sqlReader.GetValue(0);
                        mReadings.IntRate2 = (int)sqlReader.GetValue(1);
                        mReadings.DateTime = (string)sqlReader.GetValue(2);
                    }

                    listOfReadings.Add(mReadings);
                }
            }

            return listOfReadings;
        }
    }
}
