using System;
using System.Diagnostics;
using System.Text;

namespace Interview
{
    /// <summary>
    /// Brute Force algorithm Demonstration
    /// </summary>
    public class BruteForce
    {
        #region Constructor(s)

        public BruteForce()
        {
            Console.WriteLine("Enter 3 character password which needs to be found.\n");
            this.password = Console.ReadLine();
        }

        #endregion

        #region Public Method(s)
        public void DetectPassword(int length = 3)
        {
            timer.Reset();
            timer.Start();
          
            for(int i = 0; i< length; i++)
            {
                foreach (char chFirst in charArraySet)
                {
                    foreach (char chSecond in charArraySet)
                    {
                        foreach (char chThird in charArraySet)
                        {
                            StringBuilder builder = new StringBuilder(3);
                            builder.Append(chFirst);
                            builder.Append(chSecond);
                            builder.Append(chThird);
                            totalSearch++;
                            if (isPasswordValid(builder.ToString()))
                            {
                                timer.Stop();
                                Console.WriteLine("Your password is " + Password);
                                Console.WriteLine("Total number of searches is  : " + totalSearch);
                                Console.WriteLine("Total time taken is : " + timer.ElapsedMilliseconds.ToString() + " Milliseconds");
                                return;
                            }

                        }
                    }
                }

            }


        }

        #endregion

        #region Helper(s)

        private bool isPasswordValid(string pswrd)
        {
            if (this.password != pswrd)
            {
                
                return false;
            }
            else
            {
                IsPasswordValid = true;
                Password = pswrd;
                return true;
            }
        }
        #endregion

        #region Private Member(s)
        Stopwatch timer = new Stopwatch();
        private double totalSearch = 0;
        private string password;

        private static char[] charArraySet = {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z','A','B','C','D','E',
        'F','G','H','I','J','K','L','M','N','O','P','Q','R',
        'S','T','U','V','W','X','Y','Z','1','2','3','4','5',
        '6','7','8','9','0','!','$','#','@','-'
        };
        #endregion

        #region Propertie(s)

        public bool IsPasswordValid
        { get; set; }

        public string Password { get; set; }


        #endregion
    }
}
