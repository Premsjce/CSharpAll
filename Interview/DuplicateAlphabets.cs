using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    /// <summary>
    /// Class to find the Duplicate alphabets in a given String
    /// </summary>
    public class DuplicateAlphabets
    {
        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateAlphabets"/> class.
        /// </summary>
        public DuplicateAlphabets(string _inputString)
        {
            this.inputString = _inputString;
        }
        #endregion

        #region Private Member(s)        
        /// <summary>
        /// The input string
        /// </summary>
        private string inputString;
        #endregion

        #region Public Method(s)
        public string FindDuplicate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input string cannot be empty");
                return null;
            }

            char[] tempInputArray = input.ToCharArray();
            List<char> output = new List<char>();
           
            Dictionary<char, int> duplicationCount = new Dictionary<char, int>();


            //Find the repeated characters
            foreach(char tempChar in tempInputArray)
            {
                
                if(duplicationCount.ContainsKey(tempChar))
                {

                    duplicationCount[tempChar] = duplicationCount[tempChar] + 1;
                }
                else
                {
                    duplicationCount.Add(tempChar, 1);
                }
            }

            
            
            //Print the repeated characters
            foreach (char charater in duplicationCount.Keys)
            {
                Console.WriteLine(charater.ToString() +": ==> " + duplicationCount[charater].ToString());
                output.Add(charater);
                
            }
            
            return new string(output.ToArray());
        }
        #endregion
    }
}
