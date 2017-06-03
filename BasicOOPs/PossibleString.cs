using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOPs
{
    /// <summary>
    /// PossibleString Class
    /// </summary>
    public static class PossibleString
    {

        static string DisplayUpper(string input)
        {
            return input.ToPossiblyUpper();
        }

        public static string ToPossiblyUpper(this string inputString)
        {
            if (inputString != null)
            {
                return inputString.ToUpper();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
