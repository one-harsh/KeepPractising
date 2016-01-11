using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace KeepPractising.UnitTests
{
    [TestClass]
    public class KeepPractisingUnitTest
    {
        Assembly keepPracticisingAssembly;
        Type testSuiteEnumType;

        [TestInitialize]
        public void Initialize()
        {
            StrongReferenceLoader.Load();
            keepPracticisingAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(r => r.FullName.StartsWith("KeepPractising") && !r.FullName.Contains("UnitTests")).FirstOrDefault();
            testSuiteEnumType = keepPracticisingAssembly.GetTypes().FirstOrDefault(r => r.Name == "TestSuite");
        }

        [TestMethod]
        public void TestAllSuccessfulTestSuiteMethodRunsExceptThreadingProblems()
        {
            var classNames = Enum.GetValues(testSuiteEnumType);

            for (int i = 0; i < classNames.Length; i++)
            {
                // Not testing Threading test suite as testing it this way won't be a good idea.
                if (classNames.GetValue(i).ToString() == "MyThreadingTestSuite")
                    continue;

                var classType = keepPracticisingAssembly.GetTypes().FirstOrDefault(r => r.Name == classNames.GetValue(i).ToString());

                var methods = Program.GetPublicStaticMethods(classType);

                for (int methodIndex = 0; methodIndex < methods.Length; methodIndex++)
                {
                    var method = methods[methodIndex];
                    method.Invoke(null, new object[] { }); 
                }
            }
        }
    }
}
