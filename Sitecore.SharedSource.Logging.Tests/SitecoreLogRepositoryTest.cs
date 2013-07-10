using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sitecore.SharedSource.Logging.Tests
{
    /// <summary>
    ///This is a test class for SitecoreLogRepositoryTest and is intended
    ///to contain all SitecoreLogRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SitecoreLogRepositoryTest
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
        ///A test for SitecoreLogRepository Constructor
        ///</summary>
        [TestMethod()]
        public void SitecoreLogRepositoryConstructorTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Type ownerType = null;
            target.Audit(message, ownerType);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest1()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            object owner = null;
            string format = string.Empty;
            string[] parameters = null;
            target.Audit(owner, format, parameters);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest2()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            Type ownerType = null;
            string format = string.Empty;
            string[] parameters = null;
            target.Audit(ownerType, format, parameters);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest3()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Audit(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Debug
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Debug(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Error(message, exception, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest1()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Exception exception = null;
            Type ownerType = null;
            target.Error(message, exception, ownerType);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest2()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Error(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest3()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Type ownerType = null;
            target.Error(message, ownerType);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Fatal(message, exception, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest1()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Exception exception = null;
            Type ownerType = null;
            target.Fatal(message, exception, ownerType);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest2()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Fatal(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest3()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Type ownerType = null;
            target.Fatal(message, ownerType);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Info
        ///</summary>
        [TestMethod()]
        public void InfoTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Info(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Trace
        ///</summary>
        [TestMethod()]
        public void TraceTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Trace(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Warn(message, exception, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest1()
        {
            SitecoreLogRepository target = new SitecoreLogRepository();
            string message = string.Empty;
            object owner = null;
            target.Warn(message, owner);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
