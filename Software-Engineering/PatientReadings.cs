using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    class PatientReadings
    {
        private int id;
        private int patientId;
        private int pulseRate;
        private int breathingRate;
        private int systolic;
        private int diastolic;
        private float temperature;
        private string dateTime;
        private int intRate;
        private float floatRate;
        private int intRate2;

        public int Id { get => id; set => id = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public int PulseRate { get => pulseRate; set => pulseRate = value; }
        public int BreathingRate { get => breathingRate; set => breathingRate = value; }
        public int Systolic { get => systolic; set => systolic = value; }
        public int Diastolic { get => diastolic; set => diastolic = value; }
        public float Temperature { get => temperature; set => temperature = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
        public int IntRate { get => intRate; set => intRate = value; }
        public float FloatRate { get => floatRate; set => floatRate = value; }
        public int IntRate2 { get => intRate2; set => intRate2 = value; }
    }
}
