using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class LoadBalancer
    {
        static LoadBalancer _instance;
        static readonly object syncObject = new object();

        public List<string> _servers = new List<string>();
        Random _random = new Random();

        /// <summary>
        /// Prevents a default instance of the <see cref="LoadBalancer"/> class from being created.
        /// </summary>
        private LoadBalancer()
        {
            //Just to make sure object of this class should not be created
            _servers.Add("ServerA");
            _servers.Add("ServerB");
            _servers.Add("ServerC");
            _servers.Add("ServerD");
            _servers.Add("ServerE");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if(_instance == null)
            {
                lock(syncObject)
                {
                    if(_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        public string Server
        {
            get
            {
                int _number = _random.Next(_servers.Count);
                return _servers[_number];  
            }
        }


    }
}
