using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternDemo
{
    public interface IMediator<T>
    {
        List<IColleague<T>> ColleagueList
        {
            get;
        }

        void DistributeMessage(IColleague<T> sender, T message);

        void Register(IColleague<T> colleague);
    }
}
