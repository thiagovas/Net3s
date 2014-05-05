using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using MongoDB;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsCategoriaServicoBLLTest and is intended
    ///to contain all ClsCategoriaServicoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsCategoriaServicoBLLTest
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
        ///A test for ClsCategoriaServicoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsCategoriaServicoBLLConstructorTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarCategoriaPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarCategoriaPorNomeTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            CategoriaServico expected = null; // TODO: Initialize to an appropriate value
            CategoriaServico actual;
            actual = target.BuscarCategoriaPorNome(nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarCategoriaPorOid
        ///</summary>
        [TestMethod()]
        public void BuscarCategoriaPorOidTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            Oid id = null; // TODO: Initialize to an appropriate value
            CategoriaServico expected = null; // TODO: Initialize to an appropriate value
            CategoriaServico actual;
            actual = target.BuscarCategoriaPorOid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodasCategorias
        ///</summary>
        [TestMethod()]
        public void BuscarTodasCategoriasTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            List<CategoriaServico> expected = null; // TODO: Initialize to an appropriate value
            List<CategoriaServico> actual;
            actual = target.BuscarTodasCategorias();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Editar
        ///</summary>
        [TestMethod()]
        public void EditarTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idCategoria = null; // TODO: Initialize to an appropriate value
            string nomeCategoria = string.Empty; // TODO: Initialize to an appropriate value
            target.Editar(idCategoria, nomeCategoria);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Excluir
        ///</summary>
        [TestMethod()]
        public void ExcluirTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idCategoria = null; // TODO: Initialize to an appropriate value
            target.Excluir(idCategoria);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Excluir
        ///</summary>
        [TestMethod()]
        public void ExcluirTest1()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            string nomeCategoria = string.Empty; // TODO: Initialize to an appropriate value
            target.Excluir(nomeCategoria);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Inserir
        ///</summary>
        [TestMethod()]
        public void InserirTest()
        {
            ClsCategoriaServicoBLL target = new ClsCategoriaServicoBLL(); // TODO: Initialize to an appropriate value
            string nomeCategoria = string.Empty; // TODO: Initialize to an appropriate value
            target.Inserir(nomeCategoria);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
