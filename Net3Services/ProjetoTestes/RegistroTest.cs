using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for RegistroTest and is intended
    ///to contain all RegistroTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegistroTest
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
        ///A test for Registro Constructor
        ///</summary>
        [TestMethod()]
        public void RegistroConstructorTest()
        {
            Registro target = new Registro();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for nomeChave
        ///</summary>
        [TestMethod()]
        public void nomeChaveTest()
        {
            Registro target = new Registro(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nomeChave = expected;
            actual = target.nomeChave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for valorChave
        ///</summary>
        [TestMethod()]
        public void valorChaveTest()
        {
            Registro target = new Registro(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.valorChave = expected;
            actual = target.valorChave;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
