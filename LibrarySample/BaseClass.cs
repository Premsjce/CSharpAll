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
        /// <summary>
        /// Samples the method from derrived class.
        /// </summary>
        public void SampleMethodFromDerrivedClass()
        {
            //Wihout Creating intsance of base class we can access all methods except for Private methods
            //SamplePrivateMethod(); => cannot be accessed
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
        /// <summary>
        /// Samples the method from not a derrived class.
        /// </summary>
        public void SampleMethodFromNotADerrivedClass()
        {

            //Not Accessible
            //SamplePrivateMethod();
            //SampleInternalMethod();
            //SamplePublicMethod();
            //SampleProtectedInternalMethod();
            //SampleProtectedMetod();

            BaseClass bc = new BaseClass();
            //bc.SamplePrivateMethod(); => cannot be accessed
            //bc.SampleProtectedMethod(); => cannot be accessed
            bc.SampleInternalMethod();
            bc.SampleProtectedInternalMethod();
            bc.SamplePublicMethod();

            BaseClass bc1 = new DerriveClass();
            bc1.SampleInternalMethod();
            bc1.SampleProtectedInternalMethod();
            bc1.SamplePublicMethod();

            DerriveClass dc = new DerriveClass();
            dc.SampleInternalMethod();
            dc.SampleProtectedInternalMethod();
            dc.SamplePublicMethod();

            dc.SampleMethodFromDerrivedClass();  //=> THis method is from DerrivedClass and not baseclass


            //Below lines will throw Error
            //DerriveClass dc = new BaseClass();
            //NotADerrivedClass notDerrived = new BaseClass();
            //BaseClass baseClass = new NotADerrivedClass();
        }
    }

}
