using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsAtualizacaoDALTest and is intended
    ///to contain all ClsAtualizacaoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsAtualizacaoDALTest
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
        ///A test for ClsAtualizacaoDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsAtualizacaoDALConstructorTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarAtualizacoes
        ///</summary>
        [TestMethod()]
        public void BuscarAtualizacoesTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            bool atualizacaoTipo = false; // TODO: Initialize to an appropriate value
            List<Atualizacao> expected = null; // TODO: Initialize to an appropriate value
            List<Atualizacao> actual;
            actual = target.BuscarAtualizacoes(oidUsuario, atualizacaoTipo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InserirAtualizacao
        ///</summary>
        [TestMethod()]
        public void InserirAtualizacaoTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL(); // TODO: Initialize to an appropriate value
            Atualizacao atualizacao = null; // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            bool proprio = false; // TODO: Initialize to an appropriate value
            target.InserirAtualizacao(atualizacao, oidUsuario, proprio);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MontarDocumento
        ///</summary>
        [TestMethod()]
        public void MontarDocumentoTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL(); // TODO: Initialize to an appropriate value
            Atualizacao atualizacao = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontarDocumento(atualizacao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaDocumento
        ///</summary>
        [TestMethod()]
        public void MontarListaDocumentoTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL(); // TODO: Initialize to an appropriate value
            List<Atualizacao> lstAtualizacao = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.MontarListaDocumento(lstAtualizacao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaObjeto
        ///</summary>
        [TestMethod()]
        public void MontarListaObjetoTest()
        {
            ClsAtualizacaoDAL target = new ClsAtualizacaoDAL(); // TODO: Initialize to an appropriate value
            Document docAtualizacao = null; // TODO: Initialize to an appropriate value
            List<Atualizacao> expected = null; // TODO: Initialize to an appropriate value
            List<Atualizacao> actual;
            actual = target.MontarListaObjeto(docAtualizacao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarObjeto
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void MontarObjetoTest()
        {
            ClsAtualizacaoDAL_Accessor target = new ClsAtualizacaoDAL_Accessor(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Atualizacao expected = null; // TODO: Initialize to an appropriate value
            Atualizacao actual;
            actual = target.MontarObjeto(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
