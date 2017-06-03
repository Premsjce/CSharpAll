using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndDeserializationDemo
{
    class MainClass
    {
        #region Main Method
        
        static void Main(string[] args)
        {

            #region XMLSerialization Code

            AddressDetails addressDetails1 = new AddressDetails()
            {
                Name = "Narendra Modi",
                HouseNo = 606,
                StreetName = "RCR",
                City = "Delhi",
                PoAddress = "India-000001"
            };

            string temp =  addressDetails1.SampleMethod("abracadabra");

            List<AddressDetails> addressList = new List<AddressDetails>();
            addressList.Add(addressDetails1);
            addressList.Add(new AddressDetails() { Name = "A", HouseNo = 1, StreetName = "ABC", City = "LALA", PoAddress = "BABA" });
            addressList.Add(new AddressDetails() { Name = "B", HouseNo = 2, StreetName = "BCD", City = "BALA", PoAddress = "RABA" });
            addressList.Add(new AddressDetails() { Name = "C", HouseNo = 3, StreetName = "DEF", City = "VALA", PoAddress = "DABA" });
            addressList.Add(new AddressDetails() { Name = "D", HouseNo = 4, StreetName = "EFG", City = "CALA", PoAddress = "LABA" });

            Serializer(addressList);
            #endregion

            #region XMLDeserialization Code
            //List<AddressDetails> listOfAddress = Deserializer();

            //foreach (AddressDetails address in listOfAddress)
            //{
            //    Console.WriteLine("Name     : {0}", address.Name);
            //    Console.WriteLine("House No : {0}", address.HouseNo);
            //    Console.WriteLine("Street   : {0}", address.StreetName);
            //    Console.WriteLine("City     : {0}", address.City);
            //    Console.WriteLine("Postal   : {0}", address.PoAddress);
            //}
            #endregion

            #region BinarySerialization Code

            //AddressDetails addressDetailsA = new AddressDetails()
            //{
            //    Name = "Narendra Modi",
            //    HouseNo = 606,
            //    StreetName = "RCR",
            //    City = "Delhi",
            //    PoAddress = "India-000001"
            //};


            //List<AddressDetails> addressList = new List<AddressDetails>();
            //addressList.Add(addressDetailsA);
            //addressList.Add(new AddressDetails() { Name = "A", HouseNo = 1, StreetName = "ABC", City = "LALA", PoAddress = "BABA" });
            //addressList.Add(new AddressDetails() { Name = "B", HouseNo = 2, StreetName = "BCD", City = "BALA", PoAddress = "RABA" });
            //addressList.Add(new AddressDetails() { Name = "C", HouseNo = 3, StreetName = "DEF", City = "VALA", PoAddress = "DABA" });
            //addressList.Add(new AddressDetails() { Name = "D", HouseNo = 4, StreetName = "EFG", City = "CALA", PoAddress = "LABA" });

            //using (Stream stream = new FileStream(@"C:\temp\BinarySerialiaation.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            //{
            //    IFormatter formater = new BinaryFormatter();
            //    formater.Serialize(stream, addressList);

            //}
            #endregion

            #region BinaryDeSerialization Code

            //List<AddressDetails> listOfAddress;
            //using (Stream stream = new FileStream(@"C:\temp\BinarySerialiaation.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    IFormatter formater = new BinaryFormatter();
            //    listOfAddress = formater.Deserialize(stream) as List<AddressDetails>;

            //}

            //foreach (AddressDetails address in listOfAddress)
            //{
            //    Console.WriteLine("Name     : {0}", address.Name);
            //    Console.WriteLine("House No : {0}", address.HouseNo);
            //    Console.WriteLine("Street   : {0}", address.StreetName);
            //    Console.WriteLine("City     : {0}", address.City);
            //    Console.WriteLine("Postal   : {0}", address.PoAddress);
            //}
            #endregion

        }
        #endregion

        #region Serializer

        static void Serializer(List<AddressDetails> addressList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<AddressDetails>));
            using (TextWriter writer = new StreamWriter(@"C:\temp\AddressDetails.xml"))
            {
                serializer.Serialize(writer, addressList);
            }
        }

        #endregion

        #region Desrializer
        static List<AddressDetails> Deserializer()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<AddressDetails>));

            using (TextReader reader = new StreamReader(@"C:\temp\AddressDetails.xml"))
            {
                object obj = deserializer.Deserialize(reader);
               return obj as List<AddressDetails>;
            }
        }
        #endregion
    }
}
