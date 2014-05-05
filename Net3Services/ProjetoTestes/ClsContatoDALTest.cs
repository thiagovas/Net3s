using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    /// <summary>
    ///This is a test class for ClsContatoDALTest and is intended
    ///to contain all ClsContatoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsContatoDALTest
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
        ///A test for ClsContatoDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsContatoDALConstructorTest()
        {
            ClsContatoDAL target = new ClsContatoDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarContatoPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarContatoPorNomeTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
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
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.BuscarContatoPorNomeRegex(idUsu, nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodosContatos
        ///</summary>
        [TestMethod()]
        public void BuscarTodosContatosTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
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
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
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
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            target.ExcluirTodosContatos(idUsu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirContatoNetwork
        ///</summary>
        [TestMethod()]
        public void InserirContatoNetworkTest()
        {
            ClsContatoDAL target = new ClsContatoDAL();
            Oid idContato = new Oid("4eb1cc1a6a88f91ca0000001");
            Oid idUsu = new Oid("4eb1c6826a88f91c50000001");
            target.InserirContatoNetwork(idContato, idUsu);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MontarDocumento
        ///</summary>
        [TestMethod()]
        public void MontarDocumentoTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            Contato cont = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontarDocumento(cont);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaDocumento
        ///</summary>
        [TestMethod()]
        public void MontarListaDocumentoTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            List<Contato> lstContato = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.MontarListaDocumento(lstContato);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaObjeto
        ///</summary>
        [TestMethod()]
        public void MontarListaObjetoTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            List<Document> lstDoc = null; // TODO: Initialize to an appropriate value
            List<Contato> expected = null; // TODO: Initialize to an appropriate value
            List<Contato> actual;
            actual = target.MontarListaObjeto(lstDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarObjeto
        ///</summary>
        [TestMethod()]
        public void MontarObjetoTest()
        {
            ClsContatoDAL target = new ClsContatoDAL(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Contato expected = null; // TODO: Initialize to an appropriate value
            Contato actual;
            actual = target.MontarObjeto(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerificarExistenciaContato
        ///</summary>
        [TestMethod()]
        public void VerificarExistenciaContatoTest()
        {
            ClsContatoDAL target = new ClsContatoDAL();
            OidGenerator oidGen = new OidGenerator();
            Oid idUsuario = new Oid("4eb1cc1a6a88f91ca0000001");
            Oid idContato = new Oid("4eb1c6826a88f91c50000001");
            bool expected = true;
            bool actual;
            actual = target.VerificarExistenciaContato(idUsuario, idContato);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
