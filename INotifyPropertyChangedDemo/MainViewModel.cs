using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChangedDemo
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public MainViewModel()
        {
            Intialize();
        }

        private void Intialize()
        {
            this._checkboxstate = false;
            this.checkBoxEnabled = false;
        }

        private bool _checkboxstate ;

        public bool CheckBoxState
        {
            set
            {
                _checkboxstate = value;
                CheckBoxEnabled = value;
                RaisePropertyChanged("CheckBoxState");
            }
        }


        private bool checkBoxEnabled;

        public bool CheckBoxEnabled
        {
            get
            {
                return checkBoxEnabled;
            }
            set
            {
                checkBoxEnabled = value;
                RaisePropertyChanged("CheckBoxEnabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }

    }
}
