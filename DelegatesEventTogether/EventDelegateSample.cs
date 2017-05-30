using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether
{
    public class EventDelegateSample : IEventDelegateSample
    {
        private int eventPropInt;

        public int EventPropInt
        {
            get { return eventPropInt; }
            set { eventPropInt = value; }
        }


        private string eventPropString;

        public string EventPropString
        {
            get { return eventPropString; }
            set { eventPropString = value; }
        }

        public event EventHandler SampleEvent;

        public string SampleMethod(int intInput, string stringInput)
        {
            string temp = eventPropInt.ToString() + "\t"+ eventPropString;
            return "Added Flavo" + temp  + stringInput;
        }

        public virtual void OnEventSubscribed()
        {
            SampleEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
