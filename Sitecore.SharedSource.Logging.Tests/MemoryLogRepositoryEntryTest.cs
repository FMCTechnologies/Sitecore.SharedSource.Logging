using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Sitecore.SharedSource.Logging.Tests
{
    /// <summary>
    ///This is a test class for MemoryLogRepositoryEntryTest and is intended
    ///to contain all MemoryLogRepositoryEntryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemoryLogRepositoryEntryTest
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
        ///A test for MemoryLogRepositoryEntry Constructor
        ///</summary>
        [TestMethod()]
        public void MemoryLogRepositoryEntryConstructorTest()
        {
            var target = new MemoryLogRepositoryEntry();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Caller
        ///</summary>
        [TestMethod()]
        public void CallerEmptyTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = string.Empty;
            target.Caller = expected;
            var actual = target.Caller;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CallerValueTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = TestContext.TestName;
            target.Caller = expected;
            var actual = target.Caller;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Exception
        ///</summary>
        [TestMethod()]
        public void ExceptionNullTest()
        {
            var target = new MemoryLogRepositoryEntry();
            Exception expected = null;
            target.Exception = expected;
            var actual = target.Exception;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ExceptionValueTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = new Exception(TestContext.TestName);
            target.Exception = expected;
            var actual = target.Exception;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Level
        ///</summary>
        [TestMethod()]
        public void LevelTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = Log.Levels.Audit;
            target.Level = expected;
            var actual = target.Level;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for LineNumber
        ///</summary>
        [TestMethod()]
        public void LineNumberTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = 0;
            target.LineNumber = expected;
            var actual = target.LineNumber;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageEmptyTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = string.Empty;
            target.Message = expected;
            var actual = target.Message;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageValueTest()
        {
            var target = new MemoryLogRepositoryEntry();
            var expected = TestContext.TestName;
            target.Message = expected;
            var actual = target.Message;
            Assert.AreEqual(expected, actual);
        }
    }
}
