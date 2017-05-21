using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternDemo
{
    public interface IColleague<T>
    {
        void SendMessage(IMediator<T> mediator, T message);

        void RecieveMessage(T message);
    }
}
