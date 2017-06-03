using System;

namespace LibrarySample
{
    /// <summary>
    /// Base Class which has some methods
    /// </summary>
    public class BaseClass
    {
        private void SamplePrivateMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SamplePrivateMethod()");
        }

        internal void SampleInternalMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleInternalMethod()");
        }

        protected void SampleProtectedMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleProtectedMethod()");
        }

        protected internal void SampleProtectedInternalMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SampleMethodSampleProtectedInternalMethod()");
        }

        public void SamplePublicMethod()
        {
            Console.WriteLine("Printing from LibrarySample dll and BaseClass.SamplePublicMethod()");
        }

    }

    /// <summary>
    /// Derrived Class which Derrives from BaseClass
    /// </summary>
    /// <seealso cref="LibrarySample.BaseClass" />
    public class DerriveClass : BaseClass
    {
        public void SampleMethodFromDerrivedClass()
        {
            SampleProtectedMethod();
            SampleInternalMethod();
            SampleProtectedInternalMethod();
            SamplePublicMethod();

            BaseClass baseClass = new BaseClass();
            //baseClass.SampleProtectedMethod(); => cannot be accessed
            baseClass.SampleInternalMethod();
            baseClass.SampleProtectedInternalMethod();
            baseClass.SamplePublicMethod();

            
        }
    }


    /// <summary>
    /// not a derrives Class
    /// </summary>
    public class NotADerrivedClass
    {
        public void SampleMethodFromNotADerrivedClass()
        {

            //Not Accessible
            //SampleInternalMethod();
            //SamplePublicMethod();
            //SampleProtectedMetod();

            BaseClass bc = new BaseClass();
            //bc.SampleProtectedMethod() => cannot be accessed
            bc.SampleInternalMethod();
            bc.SampleProtectedInternalMethod();
            bc.SamplePublicMethod();

            BaseClass bc1 = new DerriveClass();
            bc1.SampleInternalMethod();
            bc1.SampleProtectedInternalMethod();
            bc1.SamplePublicMethod();

            DerriveClass dc = new DerriveClass();
            dc.SampleInternalMethod();
            dc.SampleMethodFromDerrivedClass();
            dc.SampleProtectedInternalMethod();
            dc.SamplePublicMethod();


            //Below line will throw Error
            //DerriveClass dc = new BaseClass();
        }
    }

}
