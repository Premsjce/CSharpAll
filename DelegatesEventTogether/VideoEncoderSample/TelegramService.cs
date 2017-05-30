using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether.VideoEncoderSample
{
    public class TelegramService
    {
        public void OnVideoEncoded(object source, VideoEncodedEventArgs args)
        {
            Console.WriteLine("TelegramService : Sendign a EMail of the Encoded Video : {0}", args.MyVideo.Title);
        }
    }
}
