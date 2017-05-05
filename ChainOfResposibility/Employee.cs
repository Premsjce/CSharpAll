using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    public abstract class Employee
    {
        public abstract void ApproveLeave(Leave leave);

        public delegate void OnLeaveAppliedEventHandler(Employee emp, Leave leave);

        public event OnLeaveAppliedEventHandler OnLeaveApliedEvent;


        public void OnLeaveApplied(Employee emp, Leave leave)
        {
            OnLeaveApliedEvent?.Invoke(this, leave);
        }

        protected Employee successor;

        public Employee Successor
        {
            get { return successor; }
            set { successor = value; }
        }

        public void ApplyLeave(Leave leave)
        {
            OnLeaveApplied(this, leave);
        }

    }
}
