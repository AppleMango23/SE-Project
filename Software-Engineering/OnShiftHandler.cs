using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    public class OnShiftHandler
    {
        public bool checkShift(MySqlConnection conn, OnShift oShift)
        {
            bool checkedTime = false;

            string sql = "SELECT staffId FROM onshift WHERE staffId='" + oShift.StaffId + "' AND dateOnShift='" + oShift.DateOnShift + "' AND " +
                         "timeOnShift='" + oShift.TimeOnShift + "' AND dateAndTimeDeregistered='-'";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    if ((string)sqlReader.GetValue(0) != "")
                    {
                        checkedTime = true;
                    }
                    else
                    {
                        checkedTime = false;
                    }
                }
            }

            return checkedTime;
        }

        public bool registerShift(MySqlConnection conn, OnShift oShift)
        {
            string sql = "INSERT INTO onshift (staffId, dateOnShift, timeOnShift, dateAndTimeRegistered, dateAndTimeDeregistered) " +
                "VALUES ('" + oShift.StaffId + "', '" + oShift.DateOnShift + "' ,'" + oShift.TimeOnShift + "' , '" + 
                oShift.DateAndTimeRegistered + "', '" +
                oShift.DateAndTimeDeregistered + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            sqlComm.ExecuteNonQuery();

            return true;
        }

        public bool deregisterShift(MySqlConnection conn, OnShift oShift)
        {
            Console.WriteLine(oShift.TimeOnShift);
            string sql = "UPDATE `onshift` SET `dateAndTimeDeregistered`='" + 
                oShift.DateAndTimeDeregistered + "' WHERE `staffId`='" + oShift.StaffId + "' AND `dateOnShift` = '" + 
                oShift.DateOnShift + "' AND" +
                "`timeOnShift` = '" + oShift.TimeOnShift + "'";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            sqlComm.ExecuteNonQuery();

            return true;
        }

        public List<String> showDate(MySqlConnection conn, OnShift oShift)
        {
            List<String> listOfDate = new List<String>();

            string sql = "SELECT dateOnShift FROM `onshift` WHERE staffId='" + oShift.StaffId + "' AND " +
                "dateAndTimeDeregistered='-';";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                listOfDate.Add("- SELECT -");

                while (sqlReader.Read())
                {
                    if(!listOfDate.Contains((string)sqlReader.GetValue(0)))
                    {
                        OnShift ooShift = new OnShift();

                        ooShift.DateOnShift = (string)sqlReader.GetValue(0);

                        listOfDate.Add(ooShift.DateOnShift);
                    }
                }
            }

            return listOfDate;
        }

        public List<String> showTime(MySqlConnection conn, OnShift oShift)
        {
            List<String> listOfTime = new List<String>();

            string sql = "SELECT timeOnShift FROM `onshift` WHERE staffId='" + oShift.StaffId + "' AND dateOnShift='" +
                oShift.DateOnShift + "' AND dateAndTimeDeregistered='-'";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                listOfTime.Add("- SELECT -");

                while (sqlReader.Read())
                {
                    OnShift ooShift = new OnShift();

                    ooShift.TimeOnShift = (string)sqlReader.GetValue(0);

                    listOfTime.Add(ooShift.TimeOnShift);
                }
            }

            return listOfTime;
        }

        public List<OnShift> getOnCall(MySqlConnection conn, string getDate)
        {
            List<OnShift> listOfTimeSlots = new List<OnShift>();

            string sql = "SELECT staffId, timeOnShift, dateAndTimeDeregistered FROM onshift WHERE dateOnShift='" + getDate + "'";
            
            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    OnShift mReadings = new OnShift();

                    mReadings.StaffId = (string)sqlReader.GetValue(0);
                    mReadings.TimeOnShift = (string)sqlReader.GetValue(1);

                    if((string)sqlReader.GetValue(2) == "-")
                    {
                        mReadings.DateAndTimeDeregistered = "false";
                    }
                    else
                    {
                        mReadings.DateAndTimeDeregistered = "True";
                    }

                    listOfTimeSlots.Add(mReadings);
                }
            }

            return listOfTimeSlots;
        }
    }
}
