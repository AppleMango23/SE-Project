using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestOnShiftHandler
    {
        [TestMethod]
        public void TestRegisterShift()
        {
            DbConnector dbC = new DbConnector();
            string resp = dbC.connect();
            Assert.AreEqual("Done", resp);

            OnShift oShift = new OnShift();
            oShift.StaffId = "D2";
            oShift.DateOnShift = "04/12/2019";
            oShift.TimeOnShift = "11:00 - 11:59";
            oShift.DateAndTimeRegistered = "13/4/2019 5:29:15 PM";
            oShift.DateAndTimeDeregistered = "";


            OnShiftHandler UnitTest1 = new OnShiftHandler();
            UnitTest1.registerShift(dbC.getConn(), oShift);

            

            
        }
    }
}
