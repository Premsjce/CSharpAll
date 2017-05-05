using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// this is the adater class
    /// </summary>
    /// <seealso cref="Adapter.Compound" />
    class RichCompound : Compound
    {
        ChemicalDataBank _bank;

        public RichCompound(string chemical) : base(chemical)
        {
        }

        public override void Display()
        {
            //Adaptee
            _bank = new ChemicalDataBank();

            _boilingPoint = _bank.GetCriticalPoint(_chemical, "B");
            _meltingPoint = _bank.GetCriticalPoint(_chemical, "M");
            _molecularWeight = _bank.GetMolecularWeight(_chemical);
            _molecularStructure = _bank.GetMolecularStructure(_chemical);

            base.Display();

            Console.WriteLine("Formulae : {0}",_molecularStructure);
            Console.WriteLine("Weight : {0}", _molecularWeight);
            Console.WriteLine("Boling Point : {0}", _boilingPoint);
            Console.WriteLine("Melting Point : {0}", _meltingPoint);
        }
    }
}
