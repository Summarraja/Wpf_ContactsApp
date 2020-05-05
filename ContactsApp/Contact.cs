using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public struct Contact
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Country_code { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Job_title { get; set; }
        public string Address { get; set; }
        public string Photo_source { get; set; }

        public string getFullname
        {
            get { return First_name + " " + Last_name; }
        }

    }
}
