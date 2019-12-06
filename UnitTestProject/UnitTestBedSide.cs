using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering;
using System.IO;
using System.Media;
using System.Threading;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestBedSide
    {
        [TestMethod]
        public void TestGetSound()
        {
            //To ensure that we are able to get the file path else it will be error
            using (SoundPlayer player = new SoundPlayer())
            {
                player.SoundLocation = "Sounds/criticalBeep.wav";
                player.SoundLocation = "Sounds/riskyBeep.wav";
                player.SoundLocation = "Sounds/normalBeep.wav";
                player.Stop();
            }
        }
        [TestMethod]
        public void TestGetCSV()
        {
            //To ensure that we are able to get the file path else it will be error
            _ = new StreamReader("CSV/ModuleReadings.csv");
        }
    }
}
