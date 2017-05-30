using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether.VideoEncoderSample
{
    /// <summary>
    /// Interface for VideoEncoder
    /// </summary>
    public interface IVideoEncoder
    {
        /// <summary>
        /// Encodes the specified video.
        /// </summary>
        /// <param name="video">The video.</param>
        void Encode(Video video);


        /// <summary>
        /// Occurs once the video encoding is complete.
        /// </summary>
        event EventHandler<VideoEncodedEventArgs> VideoEncoded;
    }
}
