using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternDemo
{
    class ConcreteColleague<T> : IColleague<T>
    {
        string name;
        public ConcreteColleague(string _name)
        {
            this.name = _name;
        }

        public void RecieveMessage(T message)
        {
            Console.WriteLine(this.name + " received" + message.ToString());
        }

        public void SendMessage(IMediator<T> mediator, T message)
        {
            mediator.DistributeMessage(this, message);
        }
    }
}
