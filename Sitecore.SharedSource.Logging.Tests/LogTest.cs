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
    public class LogTest
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
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest()
        {
            string message = string.Empty;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Audit(message, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Debug
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            string message = string.Empty;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Debug(message, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            string message = string.Empty;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Error(message, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest1()
        {
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Error(message, exception, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest()
        {
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Fatal(message, exception, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetExceptionMessage
        ///</summary>
        [TestMethod()]
        public void GetExceptionMessageTest()
        {
            Exception exception = null;
            string expected = string.Empty;
            string actual;
            actual = Log.GetExceptionMessage(exception);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMessage
        ///</summary>
        [TestMethod()]
        public void GetMessageTest()
        {
            string message = string.Empty;
            string suffix = string.Empty;
            string expected = string.Empty;
            string actual;
            actual = Log.GetMessage(message, suffix);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Info
        ///</summary>
        [TestMethod()]
        public void InfoTest()
        {
            string message = string.Empty;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Info(message, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogByLevel
        ///</summary>
        [TestMethod()]
        public void LogByLevelTest()
        {
            string message = string.Empty;
            object owner = null;
            Log.Levels level = new Log.Levels();
            Exception exception = null;
            ILogRepository log = null;
            Log.LogByLevel(message, owner, level, exception, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogMsg
        ///</summary>
        [TestMethod()]
        public void LogMsgTest()
        {
            string message = string.Empty;
            object owner = null;
            bool isError = false;
            Log.Levels minimumLevel = new Log.Levels();
            ILogRepository log = null;
            Log.LogMsg(message, owner, isError, minimumLevel, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for LogMsg
        ///</summary>
        [TestMethod()]
        public void LogMsgTest1()
        {
            string message = string.Empty;
            object owner = null;
            Log.Levels level = new Log.Levels();
            Log.Levels minimumLevel = new Log.Levels();
            ILogRepository log = null;
            Log.LogMsg(message, owner, level, minimumLevel, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest()
        {
            string message = string.Empty;
            ILogRepository log = null;
            Log.Warn(message, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest1()
        {
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Warn(parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest2()
        {
            string message = string.Empty;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Warn(message, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest3()
        {
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Warn(message, exception, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest4()
        {
            string message = string.Empty;
            object owner = null;
            ParameterDictionary parameters = null;
            ILogRepository log = null;
            Log.Warn(message, owner, parameters, log);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
