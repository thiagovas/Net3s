using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Models;
using System.IO;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsCatalogoEnderecosBLLTest and is intended
    ///to contain all ClsCatalogoEnderecosBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsCatalogoEnderecosBLLTest
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
        ///A test for ClsCatalogoEnderecosBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsCatalogoEnderecosBLLConstructorTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarCidadesPorUf
        ///</summary>
        [TestMethod()]
        public void BuscarCidadesPorUfTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string uf = string.Empty; // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.BuscarCidadesPorUf(uf);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarEstadosPorPais
        ///</summary>
        [TestMethod()]
        public void BuscarEstadosPorPaisTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.BuscarEstadosPorPais(pais);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarPaises
        ///</summary>
        [TestMethod()]
        public void BuscarPaisesTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.BuscarPaises();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodosEnderecos
        ///</summary>
        [TestMethod()]
        public void BuscarTodosEnderecosTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            List<CatalogoEndereco> expected = null; // TODO: Initialize to an appropriate value
            List<CatalogoEndereco> actual;
            actual = target.BuscarTodosEnderecos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExcluirCidade
        ///</summary>
        [TestMethod()]
        public void ExcluirCidadeTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            string uf = string.Empty; // TODO: Initialize to an appropriate value
            string cidade = string.Empty; // TODO: Initialize to an appropriate value
            target.ExcluirCidade(pais, uf, cidade);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirPais
        ///</summary>
        [TestMethod()]
        public void ExcluirPaisTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            target.ExcluirPais(pais);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirUf
        ///</summary>
        [TestMethod()]
        public void ExcluirUfTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            string uf = string.Empty; // TODO: Initialize to an appropriate value
            target.ExcluirUf(pais, uf);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Inserir
        ///</summary>
        [TestMethod()]
        public void InserirTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            CatalogoEndereco catEnd = null; // TODO: Initialize to an appropriate value
            target.Inserir(catEnd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Inserir
        ///</summary>
        [TestMethod()]
        public void InserirTest1()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            List<CatalogoEndereco> lstCatEnd = null; // TODO: Initialize to an appropriate value
            target.Inserir(lstCatEnd);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirCidade
        ///</summary>
        [TestMethod()]
        public void InserirCidadeTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            string uf = string.Empty; // TODO: Initialize to an appropriate value
            string cidade = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirCidade(pais, uf, cidade);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirPais
        ///</summary>
        [TestMethod()]
        public void InserirPaisTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirPais(pais);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirUf
        ///</summary>
        [TestMethod()]
        public void InserirUfTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            string pais = string.Empty; // TODO: Initialize to an appropriate value
            string uf = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirUf(pais, uf);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for lerXmlCatalogoEndereco
        ///</summary>
        [TestMethod()]
        public void lerXmlCatalogoEnderecoTest()
        {
            ClsCatalogoEnderecosBLL target = new ClsCatalogoEnderecosBLL(); // TODO: Initialize to an appropriate value
            Stream xml = null; // TODO: Initialize to an appropriate value
            List<CatalogoEndereco> expected = null; // TODO: Initialize to an appropriate value
            List<CatalogoEndereco> actual;
            actual = target.lerXmlCatalogoEndereco(xml);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
