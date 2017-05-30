using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesEventTogether.VideoEncoderSample
{
    /// <summary>
    /// Video Encoder class that encodes the video
    /// </summary>
    public class VideoEncoder : IVideoEncoder
    {
        #region Delegate(s)        
        /// <summary>
        /// Delegate that holds the reference for the methods that excetures once the Video is encoded
        /// </summary>
        public delegate void VideoEncodedEventHandler(object source, VideoEncodedEventArgs vidArgs);
        #endregion

        #region Event(s)                   
        /// <summary>
        /// Occurs when [video encoded event].
        /// This Event is from Conventional Event and Delegate Declaration
        /// </summary>
        public event VideoEncodedEventHandler VideoEncodedEvent;

        /// <summary>
        /// Occurs once the video encoding is complete. 
        /// This is from Generic Event declaration in the interface
        /// </summary>
        public event EventHandler<VideoEncodedEventArgs> VideoEncoded;
        #endregion

        #region Public Method(s)
        
        public void Encode(Video _video)
        {
            Console.WriteLine("Encoding Video...");
            //Some Encoding Logic
            //Simulationg the Encoding Logic
            Thread.Sleep(2000);

            VideoEncodingCompleted(_video);
        }
        #endregion

        #region Protected Metod(s)        
        protected virtual void VideoEncodingCompleted(Video _video)
        {
            //wait till the implemenation is done
            VideoEncoded?.Invoke(this, new VideoEncodedEventArgs() { MyVideo = _video});
        }
        #endregion
    }
}
