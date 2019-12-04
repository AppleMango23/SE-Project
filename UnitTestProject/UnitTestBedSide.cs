using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestBedSide
    {
        [TestMethod]
        public void TestMethod1()
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


            Bedside_System UnitTest1 = new Bedside_System();
            //UnitTest1.runMonitor();
        }
    }
}
