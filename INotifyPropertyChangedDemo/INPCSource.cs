using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChangedDemo
{
    public class INPCSource : INotifyPropertyChanged
    {
        public INPCSource()
        {

        }


        public void SampleMethod(string input)
        {
            SampleString = input;
        }

        private string sampleString;

        public string SampleString
        {
            get
            {
                return sampleString;
            }
            set
            {
                sampleString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SampleString"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
