using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    public class PatientHandler
    {
        public int addNewPatient(MySqlConnection conn, Patient ptient)
        {
            int theBedSideId = bedSideId(conn, ptient);

            //This is for unit testing
            if(theBedSideId == 0)
            {
               theBedSideId = ptient.Bedsideid;
            }

            string sql = "INSERT INTO patient (patientName, patientAge, patientGender, " +
                "bedsideId) VALUES ('" + ptient.Name + "', " + ptient.Age + " , '" +
                ptient.Gender + "', '" + theBedSideId + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            return sqlComm.ExecuteNonQuery();
        }

        public int bedSideId(MySqlConnection conn, Patient ptient)
        {
            int theBedSideId = 0;

            string sql = "SELECT bedsideId FROM `bedside` WHERE wing='" + ptient.Wing + "' AND floor='" +
                ptient.Floor + "' AND bay='" + ptient.Bay + "' AND bed='" + ptient.Bed + "';";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    theBedSideId = (int)sqlReader.GetValue(0);
                }
            }

            return theBedSideId;
        }

        public void updatePatientBedsideIdAndReadings(MySqlConnection conn, Patient ptient, ModuleReadings moduleRConf)
        {
            int theBedSideId = bedSideId(conn, ptient);

            //Update bedside table
            int patientId = 0;

            string selectPatientIdSql = "SELECT patientId FROM `patient` WHERE bedsideId=" + theBedSideId + ";";

            MySqlCommand sqlComm1 = new MySqlCommand(selectPatientIdSql, conn);

            using (MySqlDataReader sqlReader = sqlComm1.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    patientId = (int)sqlReader.GetValue(0);
                }
            }

            string updateBedSideSql = "UPDATE `bedside` SET `status`=1, `patientId`=" + patientId + " WHERE `bedsideId`=" + theBedSideId + ";";
            MySqlCommand sqlComm2 = new MySqlCommand(updateBedSideSql, conn);
            sqlComm2.ExecuteNonQuery();

            ModuleReadingsHandler mRHand = new ModuleReadingsHandler();
            mRHand.updatePatientBedsideId(conn, moduleRConf, patientId, "New");
        }

        public List<Patient> listPatient(MySqlConnection conn, Patient ptient, int num)
        {
            List<Patient> listOfPatient = new List<Patient>();

            string joinSql = "";

            if (num == 1)
            {
                joinSql = "SELECT patient.patientId, patient.patientName, patient.patientAge, patient.patientGender, patient.bedsideId, " +
                        "bedside.wing, bedside.floor, bedside.bay, bedside.bed " +
                        "FROM `patient`" +
                        "INNER JOIN `bedside` ON patient.bedsideId=bedside.bedsideId " +
                        "WHERE patient.patientId LIKE '" + ptient.Name + "%' OR patient.patientName LIKE '" + 
                        ptient.Name + "%' OR patient.patientAge LIKE '" + ptient.Name + "%' OR patient.patientGender LIKE '" + 
                        ptient.Name + "%' OR patient.bedsideId LIKE '" + ptient.Name + "%' OR " +
                        "bedside.wing LIKE '" + ptient.Name + "%' OR bedside.floor LIKE '" + ptient.Name + "%' OR " +
                        "bedside.bay LIKE '" + ptient.Name + "%' OR bedside.bed LIKE '" + ptient.Name + "%'";
            }
            else if (num == 2)
            {
                joinSql = "SELECT patient.patientId, patient.patientName, patient.patientAge, patient.patientGender, patient.bedsideId, " +
                        "bedside.wing, bedside.floor, bedside.bay, bedside.bed " +
                        "FROM `patient`" +
                        "INNER JOIN `bedside` ON patient.bedsideId=bedside.bedsideId " +
                        "WHERE bedside.wing LIKE '" + ptient.Wing + "' AND bedside.floor LIKE '" + ptient.Floor + "' AND bedside.bay LIKE '" + ptient.Bay + "' AND bedside.bed LIKE '" + ptient.Bed + "'";
            }

            MySqlCommand sqlComm = new MySqlCommand(joinSql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Patient aPatient = new Patient();

                    aPatient.Id = (int)sqlReader.GetValue(0);
                    aPatient.Name = (string)sqlReader.GetValue(1);
                    aPatient.Age = (int)sqlReader.GetValue(2);
                    aPatient.Gender = (string)sqlReader.GetValue(3);
                    aPatient.Bedsideid = (int)sqlReader.GetValue(4);
                    aPatient.Wing = (string)sqlReader.GetValue(5);
                    aPatient.Floor = (string)sqlReader.GetValue(6);
                    aPatient.Bay = (string)sqlReader.GetValue(7);
                    aPatient.Bed = (string)sqlReader.GetValue(8);

                    listOfPatient.Add(aPatient);
                }
            }

            return listOfPatient;
        }

        public string getPatientDetails(MySqlConnection conn, Patient ptient, string what)
        {
            int theBedSideId = 0;

            string sql = "SELECT bedsideId FROM `bedside` WHERE wing='" + ptient.Wing + "' AND floor='" +
                ptient.Floor + "' AND bay='" + ptient.Bay + "' AND bed='" + ptient.Bed + "';";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Patient aPatient = new Patient();

                    theBedSideId = (int)sqlReader.GetValue(0);
                }
            }

            string patientDetail = "";

            string selectPatientIdSql = "SELECT `" + what + "` FROM `patient` WHERE bedsideId=" + theBedSideId + ";";

            MySqlCommand sqlComm1 = new MySqlCommand(selectPatientIdSql, conn);

            using (MySqlDataReader sqlReader = sqlComm1.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Patient aPatient = new Patient();

                    if (what == "bedsideId" || what == "patientAge" || what == "patientId")
                    {
                        patientDetail = ((int)sqlReader.GetValue(0)).ToString();
                    }
                    else
                    {
                        patientDetail = (string)sqlReader.GetValue(0);
                    }
                }
            }

            if (patientDetail == "")
            {
                patientDetail = "No record found";
            }

            return patientDetail;
        }

        public string getPatientDetailsById(MySqlConnection conn, int thePatientId, string what)
        {
            string patientDetail = "";

            string selectPatientIdSql = "SELECT " + what + " FROM `patient` WHERE patientId=" + thePatientId + ";";

            MySqlCommand sqlComm1 = new MySqlCommand(selectPatientIdSql, conn);

            using (MySqlDataReader sqlReader = sqlComm1.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    Patient aPatient = new Patient();

                    if (what == "bedsideId" || what == "patientAge")
                    {
                        patientDetail = ((int)sqlReader.GetValue(0)).ToString();
                    }
                    else
                    {
                        patientDetail = (string)sqlReader.GetValue(0);
                    }
                }
            }

            if (patientDetail == "")
            {
                patientDetail = "No record found";
            }

            return patientDetail;
        }
    }
}
