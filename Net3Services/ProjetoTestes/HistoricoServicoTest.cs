using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for HistoricoServicoTest and is intended
    ///to contain all HistoricoServicoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HistoricoServicoTest
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
        ///A test for HistoricoServico Constructor
        ///</summary>
        [TestMethod()]
        public void HistoricoServicoConstructorTest()
        {
            HistoricoServico target = new HistoricoServico();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void idTest()
        {
            HistoricoServico target = new HistoricoServico(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.id = expected;
            actual = target.id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nome
        ///</summary>
        [TestMethod()]
        public void nomeTest()
        {
            HistoricoServico target = new HistoricoServico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nome = expected;
            actual = target.nome;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nota
        ///</summary>
        [TestMethod()]
        public void notaTest()
        {
            HistoricoServico target = new HistoricoServico(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.nota = expected;
            actual = target.nota;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for preco
        ///</summary>
        [TestMethod()]
        public void precoTest()
        {
            HistoricoServico target = new HistoricoServico(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.preco = expected;
            actual = target.preco;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tipoServico
        ///</summary>
        [TestMethod()]
        public void tipoServicoTest()
        {
            HistoricoServico target = new HistoricoServico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.tipoServico = expected;
            actual = target.tipoServico;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
