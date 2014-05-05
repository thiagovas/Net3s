using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsContatoBLLTest and is intended
    ///to contain all ClsContatoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsContatoBLLTest
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
        ///A test for ClsContatoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsContatoBLLConstructorTest()
        {
            ClsContatoBLL target = new ClsContatoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarContatoPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarContatoPorNomeTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.BuscarContatoPorNome(idUsu, nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarContatoPorNomeRegex
        ///</summary>
        [TestMethod()]
        public void BuscarContatoPorNomeRegexTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.BuscarContatoPorNomeRegex(idUsu, nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarQuantidadeContatos
        ///</summary>
        [TestMethod()]
        public void BuscarQuantidadeContatosTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.BuscarQuantidadeContatos(oidUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodosContatos
        ///</summary>
        [TestMethod()]
        public void BuscarTodosContatosTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.BuscarTodosContatos(idUsu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExcluirContatoNetwork
        ///</summary>
        [TestMethod()]
        public void ExcluirContatoNetworkTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idContato = null; // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            target.ExcluirContatoNetwork(idContato, idUsu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirTodosContatos
        ///</summary>
        [TestMethod()]
        public void ExcluirTodosContatosTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            target.ExcluirTodosContatos(idUsu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirAtualizacao
        ///</summary>
        [TestMethod()]
        public void InserirAtualizacaoTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idContato = null; // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirAtualizacao(idContato, idUsu, nome);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirContatoNetwork
        ///</summary>
        [TestMethod()]
        public void InserirContatoNetworkTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idContato = null; // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nomeUsuario = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirContatoNetwork(idContato, idUsu, nomeUsuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirNotificacao
        ///</summary>
        [TestMethod()]
        public void InserirNotificacaoTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idContato = null; // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirNotificacao(idContato, idUsu, nome);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for VerificarExistenciaContato
        ///</summary>
        [TestMethod()]
        public void VerificarExistenciaContatoTest()
        {
            ClsContatoBLL target = new ClsContatoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            Oid idContato = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VerificarExistenciaContato(idUsuario, idContato);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
