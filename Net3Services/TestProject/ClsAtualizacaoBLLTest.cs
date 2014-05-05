using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsAtualizacaoBLLTest and is intended
    ///to contain all ClsAtualizacaoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsAtualizacaoBLLTest
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
        ///A test for ClsAtualizacaoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsAtualizacaoBLLConstructorTest()
        {
            ClsAtualizacaoBLL target = new ClsAtualizacaoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarAtualizacoes
        ///</summary>
        [TestMethod()]
        public void BuscarAtualizacoesTest()
        {
            ClsAtualizacaoBLL target = new ClsAtualizacaoBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            bool atualizacaoTipo = false; // TODO: Initialize to an appropriate value
            List<Atualizacao> expected = null; // TODO: Initialize to an appropriate value
            List<Atualizacao> actual;
            actual = target.BuscarAtualizacoes(oidUsuario, atualizacaoTipo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InserirAtualizacoes
        ///</summary>
        [TestMethod()]
        public void InserirAtualizacoesTest()
        {
            ClsAtualizacaoBLL target = new ClsAtualizacaoBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            string mensagem = string.Empty; // TODO: Initialize to an appropriate value
            TipoAtualizacao tipo = new TipoAtualizacao(); // TODO: Initialize to an appropriate value
            target.InserirAtualizacoes(oidUsuario, mensagem, tipo);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
