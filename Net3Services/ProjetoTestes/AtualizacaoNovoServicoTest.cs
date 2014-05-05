using Models.AtualizacaoEmDesuso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for AtualizacaoNovoServicoTest and is intended
    ///to contain all AtualizacaoNovoServicoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AtualizacaoNovoServicoTest
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
        ///A test for AtualizacaoNovoServico Constructor
        ///</summary>
        [TestMethod()]
        public void AtualizacaoNovoServicoConstructorTest()
        {
            AtualizacaoNovoServico target = new AtualizacaoNovoServico();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for NomeServico
        ///</summary>
        [TestMethod()]
        public void NomeServicoTest()
        {
            AtualizacaoNovoServico target = new AtualizacaoNovoServico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.NomeServico = expected;
            actual = target.NomeServico;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
