using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            #region Find Duplicate in Given string
            string inputDuplicate = "TEMPasdTEMPTEMPasdTEMPTEMPasdTEMP";
            DuplicateAlphabets duplicateAlphabets = new DuplicateAlphabets(inputDuplicate);
            //string output = duplicateAlphabets.FindDuplicate(inputDuplicate);
            //Console.WriteLine(output);
            #endregion

            #region Find the Palindrome in given String

            string inputPalindrome = "1234xyzyx49654";
            Palindrome palindrome = new Palindrome();
            palindrome.FindPalindrome(inputPalindrome);
            #endregion
        }
    }
}
