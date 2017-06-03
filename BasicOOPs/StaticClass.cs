using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOPs
{
    public static class StaticClass
    {
        public static void SampleStaticMethod()
        {
            Console.WriteLine("Inside the static method of the static class");
        }

        //cannot hanve a non-satic method inside Static Class
        //public void NonstaticSampleMethod()
        //{
        //    Console.WriteLine("Sample Nonn static method");
        //}

        private static int myVar;

        public static int MyProperty
        {
            //get { return myVar; }
            set { myVar = value; }
        }

        public static event EventHandler SampleEvent;
    }


    public class NormalClass
    {
        public void SampleMehtodFromNormalClass()
        {
            StaticClass.SampleEvent += StaticClass_SampleEvent;
            Console.WriteLine("Sample public mehtod from normal class");
        }

        private void StaticClass_SampleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Event fird from Normal class. Event is published from Satic Class");
        }
    }
}
