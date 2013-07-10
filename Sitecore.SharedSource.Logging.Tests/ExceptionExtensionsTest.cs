using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sitecore.SharedSource.Logging.Tests
{
    /// <summary>
    ///This is a test class for ExceptionExtensionsTest and is intended
    ///to contain all ExceptionExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExceptionExtensionsTest
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
        ///A test for LogAudit
        ///</summary>
        [TestMethod()]
        public void LogAuditTest()
        {
            Exception ex = null;
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            ExceptionExtensions.LogAudit(ex, message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogDebug
        ///</summary>
        [TestMethod()]
        public void LogDebugTest()
        {
            Exception ex = null;
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            ExceptionExtensions.LogDebug(ex, message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogError
        ///</summary>
        [TestMethod()]
        public void LogErrorTest()
        {
            Exception ex = null;
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            ExceptionExtensions.LogError(ex, message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogFatal
        ///</summary>
        [TestMethod()]
        public void LogFatalTest()
        {
            Exception ex = null;
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            ExceptionExtensions.LogFatal(ex, message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogWarn
        ///</summary>
        [TestMethod()]
        public void LogWarnTest()
        {
            Exception ex = null;
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            ExceptionExtensions.LogWarn(ex, message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
