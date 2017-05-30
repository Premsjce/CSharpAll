using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether.VideoEncoderSample
{
    /// <summary>
    /// Video Encoded Event args
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class VideoEncodedEventArgs : EventArgs
    {
        public Video MyVideo { get; set; }
    }
}
