using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Student
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AddressBook addressBook { get; set; }
        public void addContact(Contact c)
        {
            this.addressBook.Contacts.Add(c);
        }
    }
}
