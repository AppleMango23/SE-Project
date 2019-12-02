using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    class BedSideHandler
    {
        public List<String> showBed(MySqlConnection conn, BedSide bedSide)
        {
            List<String> listOfBed = new List<String>();

            string sql = "SELECT bed FROM `bedside` WHERE wing='" + bedSide.Wing + "' AND floor='" +
                bedSide.Floor + "' AND bay='" + bedSide.Bay + "' AND status=0;";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                listOfBed.Add("- SELECT -");

                while (sqlReader.Read())
                {
                    BedSide aBed = new BedSide();

                    aBed.Bed = (string)sqlReader.GetValue(0);

                    listOfBed.Add(aBed.Bed);
                }
            }

            return listOfBed;
        }

        public List<BedSide> listBed(MySqlConnection conn, BedSide bedSide)
        {
            List<BedSide> listOfBed = new List<BedSide>();

            string sql = "SELECT bed FROM `bedside` WHERE wing='" + bedSide.Wing + "' AND floor='" +
                bedSide.Floor + "' AND bay='" + bedSide.Bay + "' AND status=0;";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            using (MySqlDataReader sqlReader = sqlComm.ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    BedSide aBed = new BedSide();

                    aBed.Bed = (string)sqlReader.GetValue(0);

                    Console.WriteLine(aBed.Bed);

                    listOfBed.Add(aBed);
                }
            }

            return listOfBed;
        }
    }
}
