using Models.AtualizacaoEmDesuso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for AtualizacaoNovoContatoTest and is intended
    ///to contain all AtualizacaoNovoContatoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AtualizacaoNovoContatoTest
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
        ///A test for AtualizacaoNovoContato Constructor
        ///</summary>
        [TestMethod()]
        public void AtualizacaoNovoContatoConstructorTest()
        {
            AtualizacaoNovoContato target = new AtualizacaoNovoContato();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for NomeContato
        ///</summary>
        [TestMethod()]
        public void NomeContatoTest()
        {
            AtualizacaoNovoContato target = new AtualizacaoNovoContato(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.NomeContato = expected;
            actual = target.NomeContato;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OidContato
        ///</summary>
        [TestMethod()]
        public void OidContatoTest()
        {
            AtualizacaoNovoContato target = new AtualizacaoNovoContato(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.OidContato = expected;
            actual = target.OidContato;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
