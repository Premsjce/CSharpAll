using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySample
{
    public class BaseClass
    {

        private void SamplePrivateInternalMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SamplePrivateInternalMethod()");
        }

        protected internal void SampleProtectedInternalMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleMethodSampleProtectedInternalMethod()");
        }

        internal void SampleInternalMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleInternalMethod()");
        }

        protected void SampleProtectedMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleProtectedMethod()");
        }

    }

    public class DerriveClass : BaseClass
    {
        public void SampleMethodFromDerrivedClass()
        {
            SampleProtectedMethod();
            SampleInternalMethod();
            SampleProtectedInternalMethod();

            BaseClass baseClass = new BaseClass();
            //baseClass.SampleProtectedMethod(); => cannot be accessed
            baseClass.SampleInternalMethod();
            baseClass.SampleProtectedInternalMethod();

            
        }
    }


    public class NotADerrivedClass
    {
        public void SampleMethodFromNotADerrivedClass()
        {
            BaseClass bc = new BaseClass();
            //bc.SampleProtectedMethod() => cannot be accessed
            bc.SampleInternalMethod();
            bc.SampleProtectedInternalMethod();
        }
    }

}
