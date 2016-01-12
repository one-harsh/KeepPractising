using System;
using System.Linq;
using System.Reflection;

namespace KeepPractising
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the testing suite class!");
            PrintTestSuiteEnum();
            TestSuite className = (TestSuite)Enum.Parse(typeof(TestSuite), Console.ReadLine().Trim());

            Console.WriteLine("Choose the method in your chosen test suite!");

            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(r => r.FullName.StartsWith("KeepPractising") && !r.FullName.Contains("UnitTests"));
            var type = assembly.GetTypes().FirstOrDefault(r => r.Name == className.ToString());

            var methods = GetPublicStaticMethods(type);
            var methodIndex = Convert.ToInt16(Console.ReadLine().Trim()) - 1;
            var method = methods[methodIndex];
            method.Invoke(null, new object[] { });

            Console.Read();
        }

        public static MethodInfo[] GetPublicStaticMethods(Type type)
        {
            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
            for (int i = 0; i < methods.Length; i++)
                Console.WriteLine((i + 1) + " for " + methods[i].Name);
            return methods;
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
        MySortingTestSuite = 1,
        MyLinkedListsTestSuite = 2,
        MyStacksTestSuite = 3,
        MyQueuesTestSuite = 4,
        StringsTestSuite = 5,
        MyTreeTestSuite = 6,
        MyMatrixTestSuite = 7,
        MyThreadingTestSuite = 8,
        InterestingProblemsTestSuite = 9
    }
}
