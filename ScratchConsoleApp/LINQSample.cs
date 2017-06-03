using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsoleApp
{
    /// <summary>
    /// Student Class
    /// </summary>
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// LINQ Sample Class
    /// </summary>
    class LINQSample
    {
        #region Sample Method1
        public static void SampleMthod()
        {
            //Creating the Data set
            List<Student> StudentList = new List<Student>()
            {
                new Student() {FirstName = "Abhay", LastName="Deol", Age=40},
                new Student() {FirstName = "Sunny", LastName="Deol", Age=52},
                new Student() {FirstName = "Bobby", LastName="Deol", Age=48},
                new Student() {FirstName = "Ajay", LastName="Devgn", Age=49},
                new Student() {FirstName = "Sharukh", LastName="Khan", Age=50},
                new Student() {FirstName = "Salman", LastName="Khan", Age=51},
                new Student() {FirstName = "Abhiskek", LastName="Bachan", Age=42},
                new Student() {FirstName = "Suniel", LastName="Shetty", Age=47},
                new Student() {FirstName = "Disha", LastName="Patani", Age=21},
                new Student() {FirstName = "Zeishan", LastName="Quadri", Age=21},
            };

            var result = from c in StudentList
                         orderby c.LastName ascending
                         group c by c.LastName;

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Count());
                foreach (var innerItem in item)
                {
                    Console.WriteLine("\t{0}, {1} ", innerItem.LastName, innerItem.FirstName);
                }
            }
        }
        #endregion

        #region SampleMethod2

        public static void SampleMethod2()
        {
            string[] stringArray = new string[] { "tata", "bata", "birla", "ambani" };

            var result = stringArray.Select((S) => S + "addeedbaba");

            foreach(var str in result)
            {
                Console.WriteLine(str);
            }
        }
        #endregion
    }
}
