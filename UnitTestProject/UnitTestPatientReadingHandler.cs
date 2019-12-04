using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPatientReadingHandler
    {
        DbConnector dbC = new DbConnector();
        PatientReadingsHandler UnitTest2 = new PatientReadingsHandler();

        [TestMethod]
        public void TestAddPatientReading()
        {
            string resp = dbC.connect();
            Assert.AreEqual("Done", resp);

            PatientReadings pRead = new PatientReadings();
            pRead.PatientId = 2;
            pRead.PulseRate = 23;
            pRead.BreathingRate = 23;
            pRead.Systolic = 23;
            pRead.Diastolic = 23;
            pRead.Temperature = 23; 
            pRead.DateTime = "12/1/2019 6:10:21 PM";

            
            UnitTest2.addPatientReading(dbC.getConn(), pRead);
        }
        [TestMethod]
        public void TestDisplayModuleReadings()
        {
            string resp = dbC.connect();
            Assert.AreEqual("Done", resp);

            PatientReadings pRead = new PatientReadings();
            pRead.PatientId = 2;
            

            string resp2 = UnitTest2.displayModuleReadings(dbC.getConn(), pRead, "pulseRate");
            Assert.IsNotNull(resp2);

        }
    }
}
