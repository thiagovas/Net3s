using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsEnderecoDALTest and is intended
    ///to contain all ClsEnderecoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsEnderecoDALTest
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
        ///A test for ClsEnderecoDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsEnderecoDALConstructorTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarEnderecoPorId
        ///</summary>
        [TestMethod()]
        public void BuscarEnderecoPorIdTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            List<Endereco> expected = null; // TODO: Initialize to an appropriate value
            List<Endereco> actual;
            actual = target.BuscarEnderecoPorId(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for excluirEndereco
        ///</summary>
        [TestMethod()]
        public void excluirEnderecoTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Oid _idEndereco = null; // TODO: Initialize to an appropriate value
            target.excluirEndereco(_idEndereco);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserirEndereco
        ///</summary>
        [TestMethod()]
        public void inserirEnderecoTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Endereco end = null; // TODO: Initialize to an appropriate value
            Oid _idUsuario = null; // TODO: Initialize to an appropriate value
            target.inserirEndereco(end, _idUsuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for montarDocumento
        ///</summary>
        [TestMethod()]
        public void montarDocumentoTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Endereco end = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.montarDocumento(end);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarDocumentoSemId
        ///</summary>
        [TestMethod()]
        public void montarDocumentoSemIdTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Endereco end = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.montarDocumentoSemId(end);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarListaDocumentos
        ///</summary>
        [TestMethod()]
        public void montarListaDocumentosTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            List<Endereco> lstEndereco = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.montarListaDocumentos(lstEndereco);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarListaObjetos
        ///</summary>
        [TestMethod()]
        public void montarListaObjetosTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            IEnumerable<Document> cur = null; // TODO: Initialize to an appropriate value
            List<Endereco> expected = null; // TODO: Initialize to an appropriate value
            List<Endereco> actual;
            actual = target.montarListaObjetos(cur);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarObjeto
        ///</summary>
        [TestMethod()]
        public void montarObjetoTest()
        {
            ClsEnderecoDAL target = new ClsEnderecoDAL(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Endereco expected = null; // TODO: Initialize to an appropriate value
            Endereco actual;
            actual = target.montarObjeto(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
