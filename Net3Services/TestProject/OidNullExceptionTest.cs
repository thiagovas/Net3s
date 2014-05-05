using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for OidNullExceptionTest and is intended
    ///to contain all OidNullExceptionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OidNullExceptionTest
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
        ///A test for OidNullException Constructor
        ///</summary>
        [TestMethod()]
        public void OidNullExceptionConstructorTest()
        {
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            OidNullException target = new OidNullException(msg);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for OidNullException Constructor
        ///</summary>
        [TestMethod()]
        public void OidNullExceptionConstructorTest1()
        {
            OidNullException target = new OidNullException();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            OidNullException target = new OidNullException(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Message;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
