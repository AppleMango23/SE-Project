using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    class ModuleReadingsHandler
    {
        public void updatePatientBedsideId(MySqlConnection conn, ModuleReadings moduleRConf, int thePatientId, string type)
        {
            string sql = "INSERT INTO modulesreading (patientId, pulseRMin, pulseRMax, pulseRIntTime, PRmodifiedTime, " +
                    "breathRMin, breathRMax, breathRIntTime, BRmodifiedTime, " +
                    "systolicMin, systolicMax, diastolicMin, diastolicMax, bloodPIntTime, BPmodifiedTime, " +
                    "tempMin, tempMax, tempIntTime, TEMPmodifiedTime) VALUES (" +
                    thePatientId + ", " + moduleRConf.MinPulse + " , " + moduleRConf.MaxPulse + ", " + moduleRConf.PulseIntTime +
                    " , '" + moduleRConf.PRModifiedTime + "', " + moduleRConf.MinBreath + ", " + moduleRConf.MaxBreath + ", " +
                    moduleRConf.BreathIntTime + " , '" + moduleRConf.BRModifiedTime + "', " + moduleRConf.MinSystolic + ", " +
                    moduleRConf.MaxSystolic + ", " + moduleRConf.MinDiastolic + ", " + moduleRConf.MaxDiastolic + ", " +
                    moduleRConf.PressureIntTime + " , '" + moduleRConf.BPModifiedTime + "', " + moduleRConf.MinTemp + ", " +
                    moduleRConf.MaxTemp + ", " + moduleRConf.TempIntTime + " , '" + moduleRConf.TempModifiedTime + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            sqlComm.ExecuteNonQuery();
        }

        public string getModuleReading(MySqlConnection conn, string theChosen, string thePatientId)
        {
            string getWhat = "";

            string sql = "SELECT " + theChosen + " FROM modulesreading WHERE patientId=" + thePatientId +
                " ORDER BY modulesReadingId DESC LIMIT 1";
            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    getWhat = (sqlReader.GetValue(0)).ToString();
                }
            }

            sqlComm.ExecuteNonQuery();

            return getWhat;
        }

        public List<ModuleReadings> listModules(MySqlConnection conn, int patientId, string what)
        {
            List<ModuleReadings> listOfModules = new List<ModuleReadings>();

            string sql = "";

            switch(what)
            {
                case "Pulse Rate":
                    sql = "SELECT pulseRMin, pulseRMax, pulseRIntTime, PRmodifiedTime FROM modulesreading WHERE patientId=" + patientId;
                    break;
                case "Breathing Rate":
                    sql = "SELECT breathRMin, breathRMax, breathRIntTime, BRmodifiedTime FROM modulesreading WHERE patientId=" + patientId;
                    break;
                case "Blood Pressure":
                    sql = "SELECT systolicMin, systolicMax, diastolicMin, diastolicMax, bloodPIntTime, BPmodifiedTime FROM modulesreading WHERE patientId=" + patientId;
                    break;
                case "Temperature":
                    sql = "SELECT tempMin, tempMax, tempIntTime, TEMPmodifiedTime FROM modulesreading WHERE patientId=" + patientId;
                    break;
            }

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            int counter = 1;

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    ModuleReadings mReadings = new ModuleReadings();
                    string[] outputThree = new string[] { };

                    if(what != "Blood Pressure")
                    {
                        if(what != "Temperature")
                        {
                            mReadings.Id = counter;
                            mReadings.BothMin = (int)sqlReader.GetValue(0);
                            mReadings.BothMax = (int)sqlReader.GetValue(1);
                            mReadings.SelectedNum = (int)sqlReader.GetValue(2);
                            mReadings.PRModifiedTime = (string)sqlReader.GetValue(3);
                        }
                        else
                        {
                            mReadings.Id = counter;
                            mReadings.MinTemp = (float)sqlReader.GetValue(0);
                            mReadings.MaxTemp = (float)sqlReader.GetValue(1);
                            mReadings.TempIntTime = (int)sqlReader.GetValue(2);
                            mReadings.TempModifiedTime = (string)sqlReader.GetValue(3);
                        }
                    }
                    else
                    {
                        mReadings.Id = counter;
                        mReadings.MinSystolic = (int)sqlReader.GetValue(0);
                        mReadings.MaxSystolic = (int)sqlReader.GetValue(1);
                        mReadings.MinDiastolic = (int)sqlReader.GetValue(2);
                        mReadings.MaxSystolic = (int)sqlReader.GetValue(3);
                        mReadings.PressureIntTime = (int)sqlReader.GetValue(4);
                        mReadings.BPModifiedTime = (string)sqlReader.GetValue(5);
                    }

                    listOfModules.Add(mReadings);

                    counter++;
                }
            }
            return listOfModules;
        }
    }
}
