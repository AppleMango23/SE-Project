using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering
{
    class Patient
    {
        private int id;
        private string name;
        private int age;
        private string gender;
        private int bedsideid;

        private string wing;
        private string floor;
        private string bay;
        private string bed;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Bedsideid { get => bedsideid; set => bedsideid = value; }
        public string Wing { get => wing; set => wing = value; }
        public string Floor { get => floor; set => floor = value; }
        public string Bay { get => bay; set => bay = value; }
        public string Bed { get => bed; set => bed = value; }
    }
}
