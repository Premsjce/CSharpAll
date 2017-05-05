using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// This is the Adaptee Class(Adapter will be written for this)
    /// </summary>
    class ChemicalDataBank
    {
        //Data bank legacy API
        public float GetCriticalPoint(string compound, string point)
        {
            //Melting Point
            if(point == "M")
            {
                switch(compound.ToUpper())
                {
                    case "WATER":
                        return 0.0f;
                    case "BENZENE":
                        return 5.5f;
                    case "ETHANOL":
                        return -114.1f;
                    default:
                        return 0f;
                }

            }
            //Boiling Point
            else
            {
                switch (compound.ToUpper())
                {
                    case "WATER":
                        return 100f;
                    case "BENZENE":
                        return 80.1f;
                    case "ETHANOL":
                        return 78.3f;
                    default:
                        return 0f;
                }
            }
        }


        public string GetMolecularStructure(string compound)
        {
            switch (compound.ToUpper())
            {
                case "WATER":
                    return "H20";
                case "BENZENE":
                    return "C6H6";
                case "ETHANOL":
                    return "C2H50H";
                default:
                    return "";
            }
        }


        public double GetMolecularWeight(string compound)
        {
            switch (compound.ToUpper())
            {
                case "WATER":
                    return 18.015;
                case "BENZENE":
                    return 78.1134;
                case "ETHANOL":
                    return 46.0688;
                default:
                    return 0d;
            }
        }
    }
}
