using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsOrcamentoBLLTest and is intended
    ///to contain all ClsOrcamentoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsOrcamentoBLLTest
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
        ///A test for ClsOrcamentoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsOrcamentoBLLConstructorTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscaOrcamentoNaoAprovadosPrest
        ///</summary>
        [TestMethod()]
        public void BuscaOrcamentoNaoAprovadosPrestTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Oid usu = null; // TODO: Initialize to an appropriate value
            List<Orcamento> expected = null; // TODO: Initialize to an appropriate value
            List<Orcamento> actual;
            actual = target.BuscaOrcamentoNaoAprovadosPrest(usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOrcamentoPorID
        ///</summary>
        [TestMethod()]
        public void BuscarOrcamentoPorIDTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Oid idOrcamento = null; // TODO: Initialize to an appropriate value
            Orcamento expected = null; // TODO: Initialize to an appropriate value
            Orcamento actual;
            actual = target.BuscarOrcamentoPorID(idOrcamento);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOrcamentoPorUsuario
        ///</summary>
        [TestMethod()]
        public void BuscarOrcamentoPorUsuarioTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Oid usu = null; // TODO: Initialize to an appropriate value
            Orcamento orc = null; // TODO: Initialize to an appropriate value
            List<Orcamento> expected = null; // TODO: Initialize to an appropriate value
            List<Orcamento> actual;
            actual = target.BuscarOrcamentoPorUsuario(usu, orc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarQuantOrcamentosNaoAprovadosContrat
        ///</summary>
        [TestMethod()]
        public void BuscarQuantOrcamentosNaoAprovadosContratTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Oid usu = null; // TODO: Initialize to an appropriate value
            List<Orcamento> expected = null; // TODO: Initialize to an appropriate value
            List<Orcamento> actual;
            actual = target.BuscarQuantOrcamentosNaoAprovadosContrat(usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CriarOrcamento
        ///</summary>
        [TestMethod()]
        public void CriarOrcamentoTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Orcamento orcamento = null; // TODO: Initialize to an appropriate value
            target.CriarOrcamento(orcamento);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarOrcamento
        ///</summary>
        [TestMethod()]
        public void EditarOrcamentoTest()
        {
            ClsOrcamentoBLL target = new ClsOrcamentoBLL(); // TODO: Initialize to an appropriate value
            Orcamento orcamento = null; // TODO: Initialize to an appropriate value
            target.EditarOrcamento(orcamento);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
