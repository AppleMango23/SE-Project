using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using Software_Engineering;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPatientHandler
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("Hello world");
        }

        [TestMethod]
        public void TestAddNewPatient()
        {
            DbConnector dbC = new DbConnector();
            string resp = dbC.connect();
            Assert.AreEqual("Done", resp);

            Patient ptient = new Patient();
            ptient.Name = "unitTestName";
            ptient.Age = 23;
            ptient.Gender = "Male";
            ptient.Wing = "East Wing";
            ptient.Floor = "Floor 1";
            ptient.Bedsideid = 3;

            PatientHandler UnitTest1 = new PatientHandler();
            int resp2 = UnitTest1.addNewPatient(dbC.getConn(), ptient);

            Assert.IsNotNull(resp2);

            
        }
    }
}
