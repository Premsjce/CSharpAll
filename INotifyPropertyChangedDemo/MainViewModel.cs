#region (C) Premz 2017
//
// File: MainViewModel.cs
// Creation: June 6,2017
// Author : Prem Kumar
//
// (C) Premz 2017
//
// All rights are reserved. Reproduction or transmission in whole or in part,in 
// any form or by any means, electronic, mechanical or otherwise, is prohibited 
// without the prior written permission of the copyright owner.
#endregion

#region Custom Directives
using LibrarySample;
#endregion

#region MS Directives
using System.ComponentModel;
#endregion

namespace INotifyPropertyChangedDemo
{
    /// <summary>
    /// View Model for MainView.xaml
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public MainViewModel()
        {
            Intialize();
        }

        #endregion

        #region Private Methods

        private void Intialize()
        {
            this._checkboxstate = false;
            this.checkBoxEnabled = false;
        }

        #endregion

        #region Fields
        private bool _checkboxstate ;
        private bool checkBoxEnabled;
        private BaseClass baseclass = new BaseClass();
        #endregion

        #region Properties

        public bool CheckBoxState
        {
            set
            {
                _checkboxstate = value;
                CheckBoxEnabled = value;
                RaisePropertyChanged("CheckBoxState");
            }
        }
        

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

        #endregion

        #region Evnets
        
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Protected Methods
        
        protected virtual void RaisePropertyChanged(string propertyName)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
        #endregion
    }
}
