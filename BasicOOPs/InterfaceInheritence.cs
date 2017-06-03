using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOPs
{
    /// <summary>
    /// Interface inherience client class
    /// </summary>
    class InterfaceInheritence : Platform
    {
        public string GetCompanyName()
        {
            return "Philips India Pvt Limited";
        }

        public string GetPICFullName()
        {
            return "Philips Innovation Campus";
        }

        public string GetPlatformName(PlatformType type)
        {
            if(type == PlatformType.CLINICAL)
            {
                return "Clinical Platform";
            }
            else if (type == PlatformType.SERVICABILITY)
            {
                return "Servicability Plarform";
            }
            else
            {
                return null;
            }
            
        }
    }

    public enum PlatformType
    {
        CLINICAL,
        SERVICABILITY
    }

    public interface Philips
    {
        string GetCompanyName();
    }

    public interface PIC : Philips
    {
        string GetPICFullName();
    }

    public interface Platform : PIC, Philips
    {
        string GetPlatformName(PlatformType type);
    }

}
