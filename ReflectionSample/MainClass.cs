using ReflectionSample;
using System;
using System.Reflection;

namespace ReflectionSample
{
    /// <summary>
    /// Main class which has the entry point
    /// </summary>
    static class MainClass
    {
        #region  Main Method
        static void Main(string[] args)
        {

            #region Reflection Sample

            string filePath = @"D:\Prem\Personel\C#\Code\SoloLearn\LibrarySample\bin\Debug\LibrarySample.dll";
            Assembly assmebly = Assembly.LoadFrom(filePath);

            Type[] types = assmebly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine(type.FullName);
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine("\t" + method.Name);
                    ParameterInfo[] parameterinfos = method.GetParameters();
                    foreach (ParameterInfo paraminfor in parameterinfos)
                    {
                        Console.WriteLine("\t\t" + paraminfor.Name);
                    }

                }
                MemberInfo[] members = type.GetMembers();
            }



            #endregion

            #region ExtensionMethod calling
            //Int will have an extra method called PrintNumber, see the ExensionMethodSample class and he method
            //argument pass will have this as specified along with type
            //Then that type will have the Extension method Embedded to it
            int temp = 5;
            temp.PrintNumbers();
            temp.Factorial();
            
            CalculatorClassForExtension calculator = new CalculatorClassForExtension()
            {
                Number1 = 20,
                Number2 = 5
            };

            //Following are regular Public methods 
            int Addition = calculator.Add();
            int Subtraciton = calculator.Minus();

            //Following are Extension Methods from CalculatorClassForExtension class
            int Multiplication = calculator.MultiplyFromExtension();
            int Division = calculator.DivisionFromExtension();

            Console.WriteLine("Calulcator results are as follow for {0} and {1}", calculator.Number1, calculator.Number2);
            Console.WriteLine("Addition\t: {0}", Addition.ToString());
            Console.WriteLine("Subtraciton\t: {0}", Subtraciton.ToString());
            Console.WriteLine("Multiplication\t: {0}", Multiplication.ToString());
            Console.WriteLine("Division\t: {0}", Division.ToString());

            #endregion

        }
        #endregion

    }
}
