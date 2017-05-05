using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVMSample
{
    public class ContactModel : INotifyPropertyChanged
    {
          
        #region Properties
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("LastName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("FirstName");
                OnPropertyChanged("LastName");
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; ; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        #endregion

        #region Private Members

        private string firstName;
        private string lastName;
        private string fullName;
        private string phoneNumber;

        #endregion

        #region Public Methods
        public override bool Equals(object obj)
        {
            if((obj is ContactModel) && ((obj as ContactModel).FullName == FullName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return FullName.GetHashCode();
        }
        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion


    }
}
