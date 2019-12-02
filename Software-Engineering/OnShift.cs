using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    class OnShift
    {
        private int id;
        private string staffId;
        private string dateOnShift;
        private string timeOnShift;
        private string dateAndTimeRegistered;
        private string dateAndTimeDeregistered;

        public int Id { get => id; set => id = value; }
        public string StaffId { get => staffId; set => staffId = value; }
        public string DateOnShift { get => dateOnShift; set => dateOnShift = value; }
        public string TimeOnShift { get => timeOnShift; set => timeOnShift = value; }
        public string DateAndTimeRegistered { get => dateAndTimeRegistered; set => dateAndTimeRegistered = value; }
        public string DateAndTimeDeregistered { get => dateAndTimeDeregistered; set => dateAndTimeDeregistered = value; }
    }
}
