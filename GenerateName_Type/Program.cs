using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateName_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly genAssembly = Assembly.LoadFrom(@"C:\Users\КимМ\Documents\Visual Studio 2015\GeneratorName.dll");

            #region
            //foreach (Type item in genAssembly.GetTypes())
            //{
            //    Console.WriteLine("name {0}",item.Name);
            //    if (item.IsClass && item.Name == "Generator")
            //    {
            //        foreach (var p in item.GetMethods())
            //        {
            //            Console.WriteLine("\tNameOfMethod: {0}",p.Name);
            //        }
            //        MethodInfo method1 = item.GetMethod("GenerateDefault");
            //        Console.WriteLine(method1.ReturnType);

            //        foreach (ParameterInfo p  in method1.GetParameters())
            //        {
            //            Console.WriteLine(p.Name+" "+p.ParameterType);
            //        }
            //    }
            //}
            #endregion

            Type item = genAssembly.GetTypes()[2];//инфо о 2 элементе
            Object Gen = Activator.CreateInstance(item);

            MethodInfo method = Gen.GetType().GetMethod("GenerateDefault");

            Object gender = null;
            var enumType = method.GetParameters()[0];

            if (method.GetParameters()[0].ParameterType.IsEnum)
            {
                gender = Enum.ToObject(method.GetParameters()[0].ParameterType, 0);
            }

            string result = method.Invoke(Gen, new object[] { gender }).ToString();
        }
    }
}
