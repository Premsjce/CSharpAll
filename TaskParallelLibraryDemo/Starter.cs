using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibraryDemo
{
    class Starter
    {
        public static void StarterMethod()
        {
            Stopwatch watch = new Stopwatch();

            //64 is upper limit for WaitHandle.WaitAll method.
            int maxWaiHandleWaitAllAllowed = 64;

            ManualResetEventSlim[] mres = new ManualResetEventSlim[maxWaiHandleWaitAllAllowed];

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i] = new ManualResetEventSlim(false);
            }

            long threadTime = 0;
            long taskTime = 0;
            watch.Start();


            //Start a Classic Thread and signal it with manualresetevent when Done, so 
            //that we can snapshot the time taken for exection of the Threads
            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;

                Thread thrd = new Thread((state) =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("Thread : {0}, outputting : {1}", state.ToString(), j.ToString()));
                    }
                    mres[idx].Set();
                });

                thrd.Start(string.Format("Thread {0}", i.ToString()));
            }

            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            
            threadTime = watch.ElapsedMilliseconds;
            watch.Reset();

            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }

            watch.Start();

            //Start a TPL task and signal it with manualresetevent when Done, so 
            //that we can snapshot the time taken for exection of the Threads

            for (int i = 0; i < mres.Length; i++)
            {
                int idx = i;

                Task task = Task.Factory.StartNew((state) =>

                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.WriteLine(string.Format("Task : {0}, outputting : {1}", state.ToString(), j.ToString()));
                    }
                    mres[idx].Set();
                }, string.Format("Task {0}", i.ToString()));
            }

            WaitHandle.WaitAll((from x in mres select x.WaitHandle).ToArray());
            taskTime = watch.ElapsedMilliseconds;
            watch.Reset();

            Console.WriteLine("Threading total time for Same task was  : {0}", threadTime);
            Console.WriteLine("TPL Task total time for Same task was  : {0}", taskTime);


            for (int i = 0; i < mres.Length; i++)
            {
                mres[i].Reset();
            }

            Console.WriteLine("Thats it buddy. You're up now");
            Console.ReadLine();
        }
    }
}
