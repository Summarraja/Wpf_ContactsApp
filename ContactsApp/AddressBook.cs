using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class AddressBook
    {
        private List<Contact> contacts;
        public List<Contact> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
            }
        }
        //Indexer which takes a string and Filter out the list of contacts w.r.t that string value
        public List<Contact> this[string substring]
        {
            get
            {
                return this.contacts.FindAll(x => x.getFullname.ToLower().Contains(substring.ToLower()));

            }
        }
    }
}
