using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether
{
    public interface IEventDelegateSample
    {
        int EventPropInt { get; set; }

        string EventPropString { get; set; }

        event EventHandler SampleEvent;

        string SampleMethod(int intInput, string stringInput);

    }
}
