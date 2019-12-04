using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    public class ModuleReadings
    {
        private int id;
        private int patientId;
        private int minPulse;
        private int maxPulse;
        private int pulseIntTime;

        private int minBreath;
        private int maxBreath;
        private int breathIntTime;

        private int minSystolic;
        private int maxSystolic;
        private int minDiastolic;
        private int maxDiastolic;
        private int pressureIntTime;

        private float minTemp;
        private float maxTemp;
        private int tempIntTime;

        private string selected;
        private int bothMin;
        private int bothMax;
        private int selectedNum;
        private string pRModifiedTime;
        private string bRModifiedTime;
        private string bPModifiedTime;
        private string tempModifiedTime;

        public int Id { get => id; set => id = value; }
        public int PatientId { get => patientId; set => patientId = value; }
        public int MinPulse { get => minPulse; set => minPulse = value; }
        public int MaxPulse { get => maxPulse; set => maxPulse = value; }
        public int PulseIntTime { get => pulseIntTime; set => pulseIntTime = value; }
        public int MinBreath { get => minBreath; set => minBreath = value; }
        public int MaxBreath { get => maxBreath; set => maxBreath = value; }
        public int BreathIntTime { get => breathIntTime; set => breathIntTime = value; }
        public int MinSystolic { get => minSystolic; set => minSystolic = value; }
        public int MaxSystolic { get => maxSystolic; set => maxSystolic = value; }
        public int MinDiastolic { get => minDiastolic; set => minDiastolic = value; }
        public int MaxDiastolic { get => maxDiastolic; set => maxDiastolic = value; }
        public int PressureIntTime { get => pressureIntTime; set => pressureIntTime = value; }
        public float MinTemp { get => minTemp; set => minTemp = value; }
        public float MaxTemp { get => maxTemp; set => maxTemp = value; }
        public int TempIntTime { get => tempIntTime; set => tempIntTime = value; }
        public string Selected { get => selected; set => selected = value; }
        public int BothMin { get => bothMin; set => bothMin = value; }
        public int BothMax { get => bothMax; set => bothMax = value; }
        public int SelectedNum { get => selectedNum; set => selectedNum = value; }
        public string PRModifiedTime { get => pRModifiedTime; set => pRModifiedTime = value; }
        public string BRModifiedTime { get => bRModifiedTime; set => bRModifiedTime = value; }
        public string BPModifiedTime { get => bPModifiedTime; set => bPModifiedTime = value; }
        public string TempModifiedTime { get => tempModifiedTime; set => tempModifiedTime = value; }
    }
}
