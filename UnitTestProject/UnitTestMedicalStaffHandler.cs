using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Software_Engineering;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestMedicalStaffHandler
    {
        [TestMethod]
        public void TestAddNewMedicalStaff()
        {
            DbConnector dbC = new DbConnector();
            string resp = dbC.connect();
            Assert.AreEqual("Done", resp);

            MedicalStaff staff = new MedicalStaff();
            staff.Staffid = "D3";
            staff.Name = "UnitTestName";
            staff.Password = "password";
            staff.Career = "East Wing";
            staff.Email = "Floor 1";
            staff.Contact = "0102315555";
            staff.Pager = "4415";

            MedicalStaffHandler UnitTest1 = new MedicalStaffHandler();
            int resp2 = UnitTest1.addNewMedicalStaff(dbC.getConn(), staff);

            Assert.IsNotNull(resp2);


            
        }
    }
}
