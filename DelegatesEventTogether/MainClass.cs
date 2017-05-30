using DelegatesEventTogether.VideoEncoderSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventTogether
{
    class MainClass
    {
        static void Main(string[] args)
        {
            #region EventDelegateSample implementation

            //EventDelegateSample eventDeletgateSample = new EventDelegateSample();
            //eventDeletgateSample.SampleEvent += EventDeletgateSample_SampleEvent;
            //eventDeletgateSample.EventPropInt = 25;
            //eventDeletgateSample.EventPropString = "Tdada";
            //eventDeletgateSample.OnEventSubscribed();
            //Console.WriteLine(eventDeletgateSample.SampleMethod(100,"babababa"));
            //eventDeletgateSample.SampleEvent -= EventDeletgateSample_SampleEvent;

            #endregion

            #region VideoEncoderExample

            Video video = new Video() { Title = "Shawshank Redemption" };
            VideoEncoder vidEncoder = new VideoEncoder();

            MailSerivice mailService = new MailSerivice();
            MessageService msgService = new MessageService();
            TextService txtService = new TextService();
            TelegramService tlgrmService = new TelegramService();

            //Subscribing to Encoded Events
            vidEncoder.VideoEncoded += mailService.OnVideoEncoded;
            vidEncoder.VideoEncoded += msgService.OnVideoEncoded;
            vidEncoder.VideoEncoded += txtService.OnVideoEncoded;
            vidEncoder.VideoEncoded += tlgrmService.OnVideoEncoded;

            vidEncoder.Encode(video);

            //UnSubscribing to Encoded Events
            vidEncoder.VideoEncoded -= mailService.OnVideoEncoded;
            vidEncoder.VideoEncoded -= msgService.OnVideoEncoded;
            vidEncoder.VideoEncoded -= txtService.OnVideoEncoded;
            vidEncoder.VideoEncoded -= tlgrmService.OnVideoEncoded;
            #endregion
        }

        #region Private Method(s)
        
        private static void EventDeletgateSample_SampleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event raised from Sample event of IEventDelegateSample Inerface");
        }
        #endregion
    }
}
