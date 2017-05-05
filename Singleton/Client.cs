using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Singleton
{
    class Client
    {
        static void Main(string[] args)
        {
            
            LoadBalancer lb1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer lb2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer lb3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer lb4 = LoadBalancer.GetLoadBalancer();
            LoadBalancer lb5 = LoadBalancer.GetLoadBalancer();

            if(lb1 == lb2 && lb2 == lb3 && lb3 == lb4 && lb4 == lb5)
            {
                Console.WriteLine("They are all of same instance");
            }

            //Load balance  N Request

            LoadBalancer balancer = LoadBalancer.GetLoadBalancer();

            if (lb1 == balancer)
            {
                Console.WriteLine("Again same instance");
            }

            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: {0}", server);
            }


            //trying out the XMLserializing and Deserializing
            SerializeDeserialize(balancer);
            

        }

        private static void SerializeDeserialize(LoadBalancer balancer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LoadBalancer));
            TextWriter writer = new StreamWriter(@"C:\Users\310225812\Desktop\TempWritingForSerializatio.xml");
            using (writer)
            {
                serializer.Serialize(writer, balancer);
            }

            TextReader reader = new StreamReader(@"C:\Users\310225812\Desktop\TempWritingForSerializatio.xml");
            object _loadBalancerObject = serializer.Deserialize(reader);
            LoadBalancer loadbalancer = _loadBalancerObject as LoadBalancer;

            Console.WriteLine("LoadBalancer after deserializing\n");
            Console.WriteLine(loadbalancer.Server.ToString());
        }
    }
}

