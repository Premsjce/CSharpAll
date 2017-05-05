using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVVMSample
{
    public class ContactViewModel
    {
        Button btn = new Button();

        public ObservableCollection<ContactModel> Contacts
        {
            get;
            set;
        }

        public void LoadCotacts()
        {
            ObservableCollection<ContactModel> _contacts = new ObservableCollection<ContactModel>();

            _contacts.Add(new ContactModel() { FirstName = "Mark", LastName = "Green" });
            _contacts.Add(new ContactModel() { FirstName = "Linda", LastName = "Geller" });
            _contacts.Add(new ContactModel() { FirstName = "Allan", LastName = "Joey" });
            _contacts.Add(new ContactModel() { FirstName = "Zunck", LastName = "Mark" });

            Contacts = _contacts;
        }



    }
}
