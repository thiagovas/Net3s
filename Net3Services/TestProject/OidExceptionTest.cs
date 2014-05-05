using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for OidExceptionTest and is intended
    ///to contain all OidExceptionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OidExceptionTest
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
        ///A test for OidException Constructor
        ///</summary>
        [TestMethod()]
        public void OidExceptionConstructorTest()
        {
            string msg = string.Empty; // TODO: Initialize to an appropriate value
            OidException target = new OidException(msg);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for OidException Constructor
        ///</summary>
        [TestMethod()]
        public void OidExceptionConstructorTest1()
        {
            OidException target = new OidException();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            OidException target = new OidException(); // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Message;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
