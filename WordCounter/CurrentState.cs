using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    /// <summary>
    /// Class to hold the state of Words matched and lines counted
    /// </summary>
    public class CurrentState
    {
        public int WordsMatched { get; set; }
        public int LinesCounted { get; set; }
    }
}
