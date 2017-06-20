using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZZScratchConsoleApp
{
    /// <summary>
    /// LattitudeToDecimalDegrees
    /// </summary>
    public class LattitudeToDecimalDegrees
    {

        // Convert Degrees/Minutes/Seconds to Decimal coordinate value
        // DD = d + (min/60) + (sec/3600)'        
        /// <summary>
        /// Converts the DMS to decimal.
        /// </summary>
        /// <param name="DMS">The DMS.</param>
        /// <param name="SignificantDigits">The significant digits.</param>
        /// <returns></returns>
        public string ConvertDMSToDecimal(String DMS, int SignificantDigits)
        {
            string[] ParsedDMS;
            Double Degrees;
            Double Minutes;
            Double Seconds;
            Double DecimalCoord;

            ParsedDMS = DMS.Split(':');

            try
            {
                Degrees = Convert.ToDouble(ParsedDMS[0]);
                Minutes = Convert.ToDouble(ParsedDMS[1]);
                Seconds = Convert.ToDouble(ParsedDMS[2]);

                if (Degrees > 0)
                {
                    DecimalCoord = Degrees + (Minutes / 60) + (Seconds / 3600);
                    DecimalCoord = Math.Round(DecimalCoord, SignificantDigits);
                }
                else
                {
                    //Take modulus if its Negative
                    double tempDegrees = Math.Abs(Degrees);
                    DecimalCoord = tempDegrees + (Minutes / 60) + (Seconds / 3600);
                }

            }
            catch (Exception e)
            {
                return e.ToString();
            }

            if(Degrees > 0)
            {
                return DecimalCoord.ToString();
            }
            else
            {
                return "-" + DecimalCoord.ToString();
            }
        }
    }
}
