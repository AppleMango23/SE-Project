using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Software_Engineering
{
    public class DbConnector
    {
        MySqlConnection conn;

        public string connect()
        {
            string connStr = "datasource=localhost;user=dbcli;database=hospitaldb;port=3306;password=dbcli123";
            conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "Done";
        }

        public MySqlConnection getConn()
        {
            return conn;
        }
    }
}
