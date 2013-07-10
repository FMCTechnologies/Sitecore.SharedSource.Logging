using System.Linq;
using Sitecore.SharedSource.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Sitecore.SharedSource.Logging.Tests
{
    /// <summary>
    ///This is a test class for MemoryLogRepositoryTest and is intended
    ///to contain all MemoryLogRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemoryLogRepositoryTest
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
        ///A test for MemoryLogRepository Constructor
        ///</summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            var target = new MemoryLogRepository();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AuditTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            Type ownerType = null;
            var format = string.Empty;
            string[] parameters = null;
            target.Audit(ownerType, format, parameters);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AuditTest1()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var format = string.Empty;
            string[] parameters = null;
            target.Audit(null, format, null);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest2()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            target.Audit(message, null);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Audit
        ///</summary>
        [TestMethod()]
        public void AuditTest3()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Type ownerType = null;
            target.Audit(message, ownerType);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        [TestMethod]
        public void AuditMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Audit(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Audit };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void AuditMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Audit(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Audit };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void AuditMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Audit(message, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Audit };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void AuditMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Audit(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Audit };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void AuditMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Audit(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Audit };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        /// <summary>
        ///A test for Clear
        ///</summary>
        [TestMethod()]
        public void ClearTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            Log.Audit(TestContext.TestName, log: target);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
            MemoryLogRepository.Clear();
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 0);
        }

        /// <summary>
        ///A test for Debug
        ///</summary>
        [TestMethod()]
        public void DebugTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Debug(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }
        
        [TestMethod]
        public void DebugMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Debug(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Debug };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void DebugMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Debug(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Debug };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void DebugMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Debug(message, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Debug };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void DebugMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Debug(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Debug };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void DebugMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Debug(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Debug };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Error(message, exception, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest1()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Exception exception = null;
            Type ownerType = null;
            target.Error(message, exception, ownerType);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest2()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Type ownerType = null;
            target.Error(message, ownerType);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Error
        ///</summary>
        [TestMethod()]
        public void ErrorTest3()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Error(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        [TestMethod]
        public void ErrorMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Error(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Error };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Error(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Error };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Error(message, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Error };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Error(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Error };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Error(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Error };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorExceptionOnly()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var exception = new Exception(message);
            Log.Error(null, exception, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, message), Caller = ToString(), Level = Log.Levels.Error, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void ErrorExceptionParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            var exception = new Exception(message);
            Log.Error(message, exception, null, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1} - ", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Error, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Fatal(message, exception, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest1()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Exception exception = null;
            Type ownerType = null;
            target.Fatal(message, exception, ownerType);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest2()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Fatal(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Fatal
        ///</summary>
        [TestMethod()]
        public void FatalTest3()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Type ownerType = null;
            target.Fatal(message, ownerType);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        [TestMethod]
        public void FatalMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Fatal(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Fatal };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Fatal(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Fatal };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Fatal(message, null, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Fatal };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Fatal(message, null, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Fatal };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Fatal(message, null, null, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Fatal };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalExceptionOnly()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var exception = new Exception(message);
            Log.Fatal(null, exception, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, message), Caller = ToString(), Level = Log.Levels.Fatal, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void FatalExceptionParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            var exception = new Exception(message);
            Log.Fatal(message, exception, null, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1} - ", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Fatal, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        /// <summary>
        ///A test for Info
        ///</summary>
        [TestMethod()]
        public void InfoTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Info(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }


        [TestMethod]
        public void InfoMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Info(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Info };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void InfoMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Info(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Info };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void InfoMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Info(message, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Info };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void InfoMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Info(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Info };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void InfoMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Info(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Info };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        /// <summary>
        ///A test for Trace
        ///</summary>
        [TestMethod()]
        public void TraceTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Trace(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }


        [TestMethod]
        public void TraceMessageNullTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            Log.Trace(log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Trace };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TraceMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Trace(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Trace };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TraceMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Trace(message, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Trace };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TraceMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Trace(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Trace };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void TraceMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Trace(message, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Trace };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        
        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            Exception exception = null;
            object owner = null;
            target.Warn(message, exception, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }

        /// <summary>
        ///A test for Warn
        ///</summary>
        [TestMethod()]
        public void WarnTest1()
        {
            MemoryLogRepository.Clear();
            var target = new MemoryLogRepository();
            var message = string.Empty;
            object owner = null;
            target.Warn(message, owner);
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1);
        }
        
        //[TestMethod]
        //public void WarnMessageNullTest()
        //{
        //    var memoryLog = new MemoryLogRepository();
        //    MemoryLogRepository.Clear();
        //    Log.Warn(log: memoryLog);
        //    var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, TestContext.TestName), Caller = ToString(), Level = Log.Levels.Warning };

        //    Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

        //    var actual = MemoryLogRepository.Entries.FirstOrDefault();

        //    Assert.IsNotNull(actual);
        //    Assert.AreEqual(expected.Caller, actual.Caller);
        //    Assert.AreEqual(expected.Exception, actual.Exception);
        //    Assert.AreEqual(expected.Level, actual.Level);
        //    Assert.AreEqual(expected.Message, actual.Message);
        //}

        [TestMethod]
        public void WarnMessageOnlyTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Warn(message, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Warning };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void WarnMessageAndOwnerTest()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            Log.Warn(message, null, this, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:\n{1}", this, message), Caller = ToString(), Level = Log.Levels.Warning };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void WarnMessageOwnerParametersNull()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var parameters = new ParameterDictionary(new { });
            Log.Warn(message, null, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Warning };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void WarnMessageOwnerParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            Log.Warn(message, null, null, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1}", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Warning };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void WarnExceptionOnly()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var exception = new Exception(message);
            Log.Warn(null, exception, log: memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}:", this, message), Caller = ToString(), Level = Log.Levels.Warning, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod]
        public void WarnExceptionParameters()
        {
            var memoryLog = new MemoryLogRepository();
            MemoryLogRepository.Clear();
            var message = TestContext.TestName;
            var param1 = message;
            var parameters = new ParameterDictionary(new { param1 });
            var exception = new Exception(message);
            Log.Warn(message, exception, this, parameters, memoryLog);
            var expected = new MemoryLogRepositoryEntry() { Message = String.Format("{0}.{1}{2}:\n{1} - ", this, message, parameters.GetString()), Caller = ToString(), Level = Log.Levels.Warning, Exception = exception };

            Assert.IsTrue(MemoryLogRepository.Entries.Count == 1, "Unexpected Log Count");

            var actual = MemoryLogRepository.Entries.FirstOrDefault();

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Caller, actual.Caller);
            Assert.AreEqual(expected.Exception, actual.Exception);
            Assert.AreEqual(expected.Level, actual.Level);
            Assert.AreEqual(expected.Message, actual.Message);
        }


        /// <summary>
        ///A test for Entries
        ///</summary>
        [TestMethod()]
        public void EntriesTest()
        {
            MemoryLogRepository.Clear();
            BlockingCollection<MemoryLogRepositoryEntry> actual;
            actual = MemoryLogRepository.Entries;
            Assert.IsTrue(MemoryLogRepository.Entries.Count == 0);
        }
    }
}
