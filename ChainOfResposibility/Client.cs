using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResposibility
{
    class Client
    {
        static void Main(string[] args)
        {
            TeamLeader teamLead = new TeamLeader();
            ProjectLeader projectLead = new ProjectLeader();
            HR hr = new HR();

            //Creating object chain
            teamLead.Successor = projectLead;
            projectLead.Successor = hr;

            teamLead.ApplyLeave(new Leave(Guid.NewGuid(), 10));
            teamLead.ApplyLeave(new Leave(Guid.NewGuid(), 20));
            teamLead.ApplyLeave(new Leave(Guid.NewGuid(), 30));
            teamLead.ApplyLeave(new Leave(Guid.NewGuid(), 31));

            Console.ReadLine();
        }
    }
}
