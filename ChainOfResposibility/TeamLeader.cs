using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    public class TeamLeader : Employee
    {
        const int MAX_LEAVE_TL_CAN_APPROVE = 10;

        public TeamLeader()
        {
            this.OnLeaveApliedEvent += TeamLeader_OnLeaveApliedEvent;
        }

        private void TeamLeader_OnLeaveApliedEvent(Employee emp, Leave leave)
        {
            if(leave.NoOfDays <= MAX_LEAVE_TL_CAN_APPROVE)
            {
                ApproveLeave(leave);
            }
            else
            {
                if (Successor != null)
                    Successor.OnLeaveApplied(this,leave);
            }
        }

        public override void ApproveLeave(Leave leave)
        {
            Console.WriteLine("Leave ID: {0}, Days: {1}, Approver: {2}",leave.LeaveID, leave.NoOfDays,"Team Leader");
        }
    }
}
