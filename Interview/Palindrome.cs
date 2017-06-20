using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    /// <summary>
    /// Class which contains funcionalities about Palindromes
    /// </summary>
    public class Palindrome
    {
        #region Constructor(s)
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Palindrome"/> class.
        /// </summary>
        public Palindrome()
        {
            //Default Constructor
        }
        #endregion

        #region Public Method(s)

        /// <summary>
        /// Finds the palindrome in the given string.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        public void FindPalindrome(string inputString)
        {
            char[] inputCharArray = inputString.ToCharArray();

            for(int i = 0; i < inputCharArray.Length; i++)
            {
                for(int j = inputCharArray.Length-1; j > i; j--)
                {
                    if(inputCharArray[i] == inputCharArray[j])
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for(int k = i; k<= j;k++)
                        {
                            stringBuilder.Append(inputCharArray[k]);
                        }
                        PalindromeOrNot(stringBuilder.ToString());
                    }
                }
            }

            if (palindromeCount.Keys.Count > 0)
            {
                foreach (string subString in palindromeCount.Keys)
                {
                    Console.WriteLine(subString+ ": ==> " + palindromeCount[subString].ToString());
                }
            }
            else
            {
                Console.WriteLine("No Palindrome is given string");
            }

        }

        #endregion

        #region Helper Method(s
        private bool PalindromeOrNot(string subString)
        {
            char[] tempArray = subString.ToCharArray();
            int initialCounter = 0, finalCounter = tempArray.Length-1;

            while (initialCounter < finalCounter)
            {
                if (tempArray[initialCounter] == tempArray[finalCounter])
                {
                    initialCounter++;
                    finalCounter--;
                }
                else
                {
                    return false;
                }
            }

            //Add the palindrome to Dictionary to keep the count
            if(palindromeCount.ContainsKey(subString))
            {
                palindromeCount[subString] = palindromeCount[subString] + 1;
            }
            else
            {
                palindromeCount.Add(subString, 1);
            }

            return true;
        }
        #endregion

        #region Private Member(s)
        Dictionary<string, int> palindromeCount = new Dictionary<string, int>();
        #endregion
    }
}
