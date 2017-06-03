using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    public class Developer : Employee
    {
        public Developer()
        {
            OnLeaveApliedEvent += Developer_OnLeaveApliedEvent;
        }

        private void Developer_OnLeaveApliedEvent(Employee emp, Leave leave)
        {
            //Developer has applied for leave
            TeamLeader tl = new TeamLeader();
            tl.ApproveLeave(new Leave(Guid.NewGuid(), 5));
        }

        public override void ApproveLeave(Leave leave)
        {
            //Develper WIll not approve leave, but only apply :)
        }
    }
}
