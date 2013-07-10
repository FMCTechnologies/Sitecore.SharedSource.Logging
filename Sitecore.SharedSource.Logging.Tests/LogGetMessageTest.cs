using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sitecore.SharedSource.Logging.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogTest and is intended
    ///to contain all LogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogGetMessageTest
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
        ///A test for GetMessage
        ///</summary>
        [TestMethod()]
        public void GetMessageEmptyTest()
        {
            var message = string.Empty;
            var suffix = string.Empty;
            var expected = string.Empty;
            var actual = Log.GetMessage(message, suffix);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMessageNullTest()
        {
            string message = null;
            var suffix = string.Empty;
            var expected = string.Empty;
            var actual = Log.GetMessage(message, suffix);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMessageNoSuffixTest()
        {
            var message = TestContext.TestName;
            var suffix = string.Empty;
            var expected = String.Concat("\n", TestContext.TestName);
            var actual = Log.GetMessage(message, suffix);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMessageSuffixTest()
        {
            var message = TestContext.TestName;
            var suffix = " - ";
            var expected = String.Concat("\n", TestContext.TestName, suffix);
            var actual = Log.GetMessage(message, suffix);
            Assert.AreEqual(expected, actual);
        }
    }
}