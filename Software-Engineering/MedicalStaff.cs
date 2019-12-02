using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    class MedicalStaff
    {
        private int id;
        private string staffid;
        private string name;
        private string career;
        private string email;
        private string contact;
        private string pager;
        private string password;

        private string location;
        private string patient;
        private string status;
        private string dateAndTimeAlert;

        public int Id { get => id; set => id = value; }
        public string Staffid { get => staffid; set => staffid = value; }
        public string Name { get => name; set => name = value; }
        public string Career { get => career; set => career = value; }
        public string Email { get => email; set => email = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Pager { get => pager; set => pager = value; }
        public string Password { get => password; set => password = value; }
        public string Location { get => location; set => location = value; }
        public string Patient { get => patient; set => patient = value; }
        public string Status { get => status; set => status = value; }
        public string DateAndTimeAlert { get => dateAndTimeAlert; set => dateAndTimeAlert = value; }
    }
}
