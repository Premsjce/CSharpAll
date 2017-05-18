using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplestMVVM2
{
    public class ViewModel : INotifyPropertyChanged
    {
        UpdateCommand updtCommand;
        Model model;
        public ViewModel()
        {
            model = new Model();
            updtCommand = new UpdateCommand(this);
            dummyDataBox = model.JunkData;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Update
        {
            get
            {
                return updtCommand;
            }

        }

        private string dummyDataBox;

        public string DummyDataBox
        {
            get { return dummyDataBox; }
            set
            {
                dummyDataBox = value;
                OnPropertyChanged("DummyDataBox");
            }
        }

        private string dummydataBlock;

        public string DummyDataBlock
        {
            get { return dummydataBlock; }
            set
            {
                dummydataBlock = value;
                OnPropertyChanged("DummyDataBlock");
            }
        }


        public void UpdateCmnd()
        {
            DummyDataBlock = dummyDataBox;
        }


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
