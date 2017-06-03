using System;

namespace ChainOfResposibility
{
    public class LeaveAppliedEventArgs : EventArgs
    {
        public Leave Leave { get; set; }
    }
}