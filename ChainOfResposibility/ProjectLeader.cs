using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    public class ProjectLeader : Employee
    {
        const int MAX_LEAVE_TL_CAN_APPROVE = 20;

        public ProjectLeader()
        {
            this.OnLeaveApliedEvent += ProjectLeader_OnLeaveApliedEvent;
        }

        private void ProjectLeader_OnLeaveApliedEvent(Employee emp, Leave leave)
        {
            if (leave.NoOfDays <= MAX_LEAVE_TL_CAN_APPROVE)
            {
                ApproveLeave(leave);
            }
            else
            {
                if (Successor != null)
                    Successor.OnLeaveApplied(this, leave);
            }
        }

        public override void ApproveLeave(Leave leave)
        {
            Console.WriteLine("Leave ID: {0}, Days: {1}, Approver: {2}", leave.LeaveID, leave.NoOfDays, "Project Leader");
        }
    }
}
