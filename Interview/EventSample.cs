using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interview
{
    public delegate void VideoEncodedEventHandler(Video video);
    public interface IVideoEncoder
    {
        event VideoEncodedEventHandler VideoEncoded;
         
        void EncodeVideo(Video video);
    }

    public class Video
    {
        public string Title { get; set; }

        public string  Artist { get; set; }
    }

    public class VideoEncoder : IVideoEncoder
    {
        public event VideoEncodedEventHandler VideoEncoded;

        public void EncodeVideo(Video video)
        {
            Video encryptedVideo = new Video();
            encryptedVideo.Artist = video.Title;
            encryptedVideo.Title = video.Artist;

            //Simulating the encoding Logic Video
            Thread.Sleep(3000);

            VideoEncoded?.Invoke(video);
        }
    }

    public interface IService
    {
        void SendMessage(Video video);
    }

    public class MailService : IService
    {


        public void SendMessage(Video video)
        {
            Console.WriteLine("IN " + this.GetType().Name);
            Console.WriteLine("Video is encoded and message is neing sent as Mail service for video with Title as " + video.Artist);
        }
    }

    public class TextService : IService
    {


        public void SendMessage(Video video)
        {
            Console.WriteLine("IN " + this.GetType().Name);
            Console.WriteLine("Video is encoded and message is neing sent as Text service for video with Title as " + video.Artist);
        }
    }


    public static class SampleExensionClass
    {
        public static VideoEncoder DecodeVideo(this VideoEncoder videoEncoder)
        {
            VideoEncoder decodeVideo = new VideoEncoder();
                          
            Console.WriteLine("Trying to decode the video");
            return decodeVideo;
        }

        public static int Factorial(this int temp)
        {
            if(temp == 0)
                return 1;

            return temp * Factorial(temp - 1);
            
        }
    }
}
