using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOPs
{
    public class PtivateConstructor
    {
        private PtivateConstructor()
        {

        }

        public static PtivateConstructor GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        return new PtivateConstructor();
                    }
                }
            }

            return _instance;
        }

        private static PtivateConstructor _instance;

        private static object syncLock = new object();

    }

   


}
