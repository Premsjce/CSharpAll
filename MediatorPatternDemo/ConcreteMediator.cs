using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternDemo
{
    class ConcreteMediator<T> : IMediator<T>
    {
        private List<IColleague<T>> colleagueList = new List<IColleague<T>>();
        public List<IColleague<T>> ColleagueList
        {
            get
            {
                return colleagueList;
            }
        }

        public void DistributeMessage(IColleague<T> sender, T message)
        {
            foreach(IColleague<T> colleague in colleagueList)
            {
                //Excpet for sender, Distribute the message to all the Registered collagues
                if (colleague != sender)
                    colleague.RecieveMessage(message);
            }
        }

        public void Register(IColleague<T> colleague)
        {
            colleagueList.Add(colleague);
        }
    }
}
