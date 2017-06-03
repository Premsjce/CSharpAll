using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndDeserializationDemo
{
    //For Binary Serialization
    [Serializable]
    [XmlRoot("Address")]
    public class AddressDetails
    {
        #region Constructor(s)
        
        public AddressDetails()
        {
            Console.WriteLine("Parameter less or Default Constructor");
        }
        #endregion

        #region Propertie(s)
        
        [XmlElement("PrimeMinisterName")]
        public string Name { get; set; }

        [XmlAttribute("HouseNumber")]
        public int HouseNo { get; set; }

        [XmlElement("Street")]
        public string StreetName { get; set; }

        [XmlElement("CityName")]
        public string City { get; set; }

        [XmlElement("PostalAddress")]
        public string PoAddress { get; set; }
        #endregion

        #region Public Method(s)
        /// <summary>
        /// Public Method cannot be Serialized
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string SampleMethod(string inputString)
        {
            Console.WriteLine("Just returning the entered strin " + inputString);
            return "Added Extra from input" + inputString;
        }
        #endregion
    }
}
