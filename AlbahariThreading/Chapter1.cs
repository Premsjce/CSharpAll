using System;
using System.Threading;

namespace AlbahariThreading
{
    class Chapter1
    {
        static bool done;
        static readonly object syncLock = new object();
        static void Main1(string[] args)
        {

            Thread thrd = new Thread(Go);
            thrd.Name = "Worker Thread";
            //Kicking of New thread,runnig GO();
            try
            {
                thrd.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exceptioin");
            }


            //Simultaneously doing some other things on the Main thread as the new thread "Worker Thread" is running parallelly
            Go();
            //Console.WriteLine((ThreadState.WaitSleepJoin == Thread.CurrentThread.ThreadState) ? "TRUE" : "FALSE");

            Console.ReadLine();
        }

        static void Go()
        {
            try
            {
                lock (syncLock)
                {

                    try
                    {
                        //Thread.Sleep(1000);
                        if (!done)
                        {
                            Console.WriteLine("Done is FALSE");
                            done = true;
                            throw new NullReferenceException();
                        }
                    }
                    catch(Exception  ex)
                    {
                        Console.WriteLine("Follwing excpetion was handeled " + ex.StackTrace + "\n" + ex.Message);
                        Console.WriteLine("Caught from Inneer mot exception block");
                        Console.WriteLine("Rethrowing from inner exception block");
                        throw;
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Follwing excpetion was handeled " + ex.StackTrace + "\n" + ex.Message);
            }
        }
    }

}
