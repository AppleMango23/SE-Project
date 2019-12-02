using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    class MedicalStaffHandler
    {
        public bool checkMedicalStaffLoginDetail(MySqlConnection conn, MedicalStaff staff)
        {
            bool check = false;

            string sql = "SELECT id FROM medicalstaff WHERE staffId LIKE '" + staff.Staffid + "' AND password LIKE '" + staff.Password + "';";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    MedicalStaff aStaff = new MedicalStaff();

                    if ((sqlReader.GetValue(0)).ToString() != " ")
                    {
                        check = true;
                    }
                }
            }

            return check;
        }

        public int addNewMedicalStaff(MySqlConnection conn, MedicalStaff staff)
        {
            string sql = "INSERT INTO medicalstaff (staffId, staffName, password, careerType, email, contactNumber" +
                ", pagerNumber) VALUES ('" + staff.Staffid + "', '" + staff.Name + "' , '" + staff.Password + "', '" +
                staff.Career + "' , '" + staff.Email + "', '" + staff.Contact + "' , '" + staff.Pager + "')";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            return sqlComm.ExecuteNonQuery();
        }

        public List<MedicalStaff> listStaff(MySqlConnection conn, MedicalStaff staff, int num)
        {
            List<MedicalStaff> listOfStaff = new List<MedicalStaff>();

            string sql = "";

            if (num == 1)
            {
                sql = "SELECT * from `medicalstaff` WHERE staffId LIKE '" + staff.Name + "%' OR staffName LIKE '" + staff.Name + "%' OR " +
                    "password LIKE '" + staff.Name + "%' OR careerType LIKE '" + staff.Name + "%' OR email LIKE '" + staff.Name + "%' OR contactNumber LIKE '" +
                    staff.Name + "%' OR pagerNumber LIKE '" + staff.Name + "%'";
            }
            else if (num == 2)
            {
                sql = "SELECT * from `medicalstaff` WHERE careerType LIKE '" + staff.Career + "'";
            }

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    MedicalStaff aStaff = new MedicalStaff();

                    aStaff.Id = (int)sqlReader.GetValue(0);
                    aStaff.Staffid = (string)sqlReader.GetValue(1);
                    aStaff.Name = (string)sqlReader.GetValue(2);
                    aStaff.Password = (string)sqlReader.GetValue(7);
                    aStaff.Career = (string)sqlReader.GetValue(3);
                    aStaff.Email = (string)sqlReader.GetValue(4);
                    aStaff.Contact = (string)sqlReader.GetValue(5);
                    aStaff.Pager = (string)sqlReader.GetValue(6);

                    listOfStaff.Add(aStaff);
                }
            }

            return listOfStaff;
        }

        public bool checkStaffId(MySqlConnection conn, string checkStaffId)
        {
            bool checkId = false;
            string checkedId = "";

            Console.WriteLine(checkStaffId);

            string sql = "SELECT staffId FROM `medicalstaff` WHERE staffId='" + checkStaffId + "'";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    checkedId = (string)sqlReader.GetValue(0);
                }
            }

            if(checkedId == "")
            {
                checkId = false;
            }
            else if(checkedId != "")
            {
                checkId = true;
            }

            return checkId;
        }

        public List<MedicalStaff> listMessages(MySqlConnection conn, BedSide bedSide)
        {
            List<MedicalStaff> listOfMessages = new List<MedicalStaff>();

            string sql = "SELECT location, patient, status, dateAndTimeAlert FROM `messages` WHERE staffId='" + bedSide.Wing + "' AND floor='" +
                bedSide.Floor + "' AND bay='" + bedSide.Bay + "' AND status=0;";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    MedicalStaff mStaff = new MedicalStaff();

                    mStaff.Location = (string)sqlReader.GetValue(0);
                    mStaff.Patient = (string)sqlReader.GetValue(1);
                    mStaff.Status = (string)sqlReader.GetValue(2);
                    mStaff.DateAndTimeAlert = (string)sqlReader.GetValue(3);

                    listOfMessages.Add(mStaff);
                }
            }

            return listOfMessages;
        }
    }
}
