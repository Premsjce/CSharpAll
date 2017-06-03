using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSample
{
    /// <summary>
    /// Dynamic Code Generation from Other Assembly
    /// </summary>
    internal class DynamicCodeGeneration
    {
        public void DynamicMethod(string filePath)
        {
            Assembly assembly = Assembly.LoadFrom(filePath);
            //IEnumerable<DynamicCodeGeneration> asa = null;
            //IEnumerator<DynamicCodeGeneration> asda = null;
        }
    }
}
