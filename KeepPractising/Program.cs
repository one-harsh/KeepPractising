using System;
using System.Linq;
using System.Reflection;

namespace KeepPractising
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the testing suite class!");
            PrintTestSuiteEnum();
            TestSuite className = (TestSuite)Enum.Parse(typeof(TestSuite), Console.ReadLine().Trim());

            Console.WriteLine("Enter the method that contains the testing code!");
            string methodName = Console.ReadLine();
            methodName = methodName.Trim();

            Console.WriteLine();

            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(r => r.FullName.StartsWith("KeepPractising"));
            var type = assembly.GetTypes().FirstOrDefault(r => r.Name == className.ToString());

            MethodInfo method = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public);
            method.Invoke(null, new object[] { });

            Console.Read();
        }

        static void PrintTestSuiteEnum()
        {
            var values = (TestSuite[])Enum.GetValues(typeof(TestSuite));

            for (int i = 0; i < values.Length; i++)
                Console.WriteLine((i + 1) + " for " + values[i]);
        }
    }

    enum TestSuite
    {
        MyLinkedListsTestSuite = 1,
        MyStacksTestSuite = 2,
        MyQueuesTestSuite = 3,
        MyThreadingTestSuite = 4
    }
}
