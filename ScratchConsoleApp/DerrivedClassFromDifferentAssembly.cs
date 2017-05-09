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
        public void SamplePublicMthod()
        {
            //BaseClass bc = new BaseClass(); => cannot access any member by creating instance of baseclass

            DerrivedClassFromDifferentAssembly dc = new DerrivedClassFromDifferentAssembly();
            dc.SampleProtectedMethod();
            //dc.SampleInternalMethod(); => cannot be accessed
            dc.SampleProtectedInternalMethod();


            SampleProtectedMethod();
            SampleProtectedInternalMethod();
        }
    }
}
