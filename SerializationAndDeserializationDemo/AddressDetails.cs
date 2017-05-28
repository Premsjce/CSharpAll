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
        public AddressDetails()
        {
            Console.WriteLine("Parameter less or Default Constructor");
        }

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
    }
}
