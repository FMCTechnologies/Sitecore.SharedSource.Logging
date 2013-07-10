using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sitecore.SharedSource.Logging.Tests
{
    /// <summary>
    ///This is a test class for ParameterDictionaryExtensionsTest and is intended
    ///to contain all ParameterDictionaryExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ParameterDictionaryExtensionsTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion
        
        /// <summary>
        ///A test for GetString
        ///</summary>
        [TestMethod()]
        public void GetStringTest()
        {
            ParameterDictionary parameterDictionary = null;
            string expected = string.Empty;
            string actual;
            actual = ParameterDictionaryExtensions.GetString(parameterDictionary);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetStringWithEmptyTest()
        {
            var parameters = new ParameterDictionary(new { });
            var results = parameters.GetString();
            Assert.AreEqual(results, string.Empty);
        }

        [TestMethod]
        public void GetStringWithOneStringTest()
        {
            const string param1 = "test";
            var parameters = new ParameterDictionary(new { param1 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ")"));
        }

        [TestMethod]
        public void GetStringWithOneIntegerTest()
        {
            const int param1 = 13;
            var parameters = new ParameterDictionary(new { param1 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ")"));
        }

        [TestMethod]
        public void ParameterDictionaryGetStringWithTwoStringsTest()
        {
            const string param1 = "test";
            const string param2 = "testing";
            var parameters = new ParameterDictionary(new { param1, param2 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ",param2=", param2, ")"));
        }

        [TestMethod]
        public void GetStringWithTwoIntegersTest()
        {
            const int param1 = 13;
            const int param2 = 20;
            var parameters = new ParameterDictionary(new { param1, param2 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ",param2=", param2, ")"));
        }

        [TestMethod]
        public void GetStringWithOneStringAndOneIntegerTest()
        {
            const string param1 = "test";
            const int param2 = 20;
            var parameters = new ParameterDictionary(new { param1, param2 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ",param2=", param2, ")"));
        }

        [TestMethod]
        public void GetStringWithOneStringAndOneIntegerAndOneDateTimeTest()
        {
            const string param1 = "test";
            const int param2 = 20;
            var param3 = DateTime.Now;
            var parameters = new ParameterDictionary(new { param1, param2, param3 });
            var results = parameters.GetString();
            Assert.AreEqual(results, String.Concat("(param1=", param1, ",param2=", param2, ",param3=", param3, ")"));
        }
    }
}
