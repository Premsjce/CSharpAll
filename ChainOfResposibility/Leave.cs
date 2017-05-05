using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    public class Leave
    {
        public Leave(Guid guid, int days)
        {
            leaveID = guid;
            noOfDays = days;
        }


        private Guid leaveID;

        public Guid LeaveID
        {
            get { return leaveID; }
            set { Guid leaveID = value; }
        }


        private int noOfDays;

        public int NoOfDays
        {
            get { return noOfDays; }
            set { noOfDays = value; }
        }

    }
}
