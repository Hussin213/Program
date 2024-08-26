using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyNameSpace
{

    public class MyClass
    {
        public int s = 0;
        public int Property1 { get; set; }

        public void Method1()
        {
            Console.WriteLine("\tMethod1 is Executed");
        }

        public void Method2(int value1, string value2)
        {
            Console.WriteLine($"\tMethod2 is Executed with parameters: {value1}, {value2}");
        }
    }

    class Program
    {

        static string GetParameterList(ParameterInfo[] parameters)
        {
            return string.Join(", ", parameters.Select(parameter => $"{parameter.ParameterType} {parameter.Name}"));
        }
        static void Main()
        {
          
            Type myClassType = typeof(MyClass);

            
            Console.WriteLine($"Type Name: {myClassType.Name}");
            
            Console.WriteLine($"Full Name: {myClassType.FullName}");

            List<string> Listproperty = new List<string>();
            
            // Get the properties of MyClass
           
            Console.WriteLine("\nProperties:");
           
            // get and set يخزن من نوع 

            PropertyInfo[] Myproperty =myClassType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            foreach (var property in Myproperty)
            {
                Console.WriteLine($"Property Name: {property.Name}, Type: {property.PropertyType}");
                
                    Listproperty.Add(property.Name);
               
            }

            //  يخزن من نوع المتغيرات طبيعيه 

            FieldInfo[] fields = myClassType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            List<string> ListField = new List<string>();
            
            foreach (var property in fields)
            {
                Console.WriteLine($"Property Name: {property.Name}");

                ListField.Add(property.Name);

            }

            // يخزن الميثود

            List<string> ListMethod = new List<string>();
           
            Console.WriteLine("\nMethods:\n");

            foreach (var method in myClassType.GetMethods())
            {
                Console.WriteLine($"\t{method.ReturnType} {method.Name}({GetParameterList(method.GetParameters())})");

                if (!(method.IsSpecialName && (method.Name.StartsWith("get_") || method.Name.StartsWith("set_"))))
                {
                    ListMethod.Add(method.Name);
                }

            }

                // Create an instance of MyClass
           //     object myClassInstance = Activator.CreateInstance(myClassType);
           //
           //
           // // Set the value of Property1 using reflection
           //  myClassType.GetProperty(Listproperty[0]).SetValue(myClassInstance, 42);
           //     Console.WriteLine("\nSet Property1 to 42 using reflection:");
           //
           //
           // object value = Myproperty.GetValue(myClassInstance);
           // Console.WriteLine($" {value}");
           //
           //
           //
           // //now how to execute methods using reflection:
           // Console.WriteLine("\nExecuting Methods using reflection:\n");
           //
           //     // Invoke the Method1 using reflection
           //     myClassType.GetMethod(ListMethod[0]).Invoke(myClassInstance, null);
           //
           //     // Invoke Method2 with parameters using reflection
           //     object[] parameters = { 100, "Mohammed Abu-Hadhoud" };
           //     myClassType.GetMethod(ListMethod[1]).Invoke(myClassInstance, parameters);
           //
                Console.ReadKey();

            }
        }

    }

