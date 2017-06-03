using LibrarySample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchConsoleApp
{
    public class DerrivedClassFromDifferentAssembly : BaseClass
    {
        public void SamplePublicMethod()
        {
            //Belo Mehtods can be accessed directly because of the Access specifies mentioed
            SampleProtectedMethod();
            SampleProtectedInternalMethod();

            //Creating instance of the BaseClaas to see which all methods are accessible
            BaseClass bc = new BaseClass(); 
            bc.SamplePublicMethod();

            BaseClass bc1 = new DerriveClass();
            bc1.SamplePublicMethod();

            DerriveClass dc1 = new DerriveClass();
            dc1.SampleMethodFromDerrivedClass();
            dc1.SamplePublicMethod();

            NotADerrivedClass ndc = new NotADerrivedClass();
            ndc.SampleMethodFromNotADerrivedClass();


            DerrivedClassFromDifferentAssembly dc = new DerrivedClassFromDifferentAssembly();
            dc.SampleProtectedMethod();
            dc.SampleProtectedInternalMethod();
            dc.SamplePublicMethod();
        }
    }
}
