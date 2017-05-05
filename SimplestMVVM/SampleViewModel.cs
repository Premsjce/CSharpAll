using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimplestMVVM
{
    public class SampleViewModel : BaseViewModel
    {
        private readonly TextConverter _textConverter = new TextConverter((s) => s.ToUpper());
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        
        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                OnPropertyChanged(SomeText);
            }
        }

        public IEnumerable<string> History
        {
            get
            {
                return _history;
            }
        }

        public ICommand ConvertTextCommand
        {
            get
            {
                return new DelegateCommand(ConvertText);
            }
        }

        private void ConvertText()
        {
            if (string.IsNullOrEmpty(SomeText))
            {
                return;
            }
            AddtoHistory(_textConverter.ConvertText(SomeText));
        }


        private void AddtoHistory(string item)
        {
            if(!_history.Contains(item))
            {
                _history.Add(item);
            }
        }
    }
}
