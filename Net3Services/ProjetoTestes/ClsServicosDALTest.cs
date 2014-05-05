using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Collections.Generic;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsServicosDALTest and is intended
    ///to contain all ClsServicosDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsServicosDALTest
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
        ///A test for ClsServicosDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsServicosDALConstructorTest()
        {
            ClsServicosDAL target = new ClsServicosDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarServicoPorDescricao
        ///</summary>
        [TestMethod()]
        public void BuscarServicoPorDescricaoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            string descricao = string.Empty; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarServicoPorDescricao(descricao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarServicoPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarServicoPorNomeTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarServicoPorNome(nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ExcluirServicoIdServico
        ///</summary>
        [TestMethod()]
        public void ExcluirServicoIdServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Oid idServ = null; // TODO: Initialize to an appropriate value
            target.ExcluirServicoIdServico(idServ);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirServicoIdUsuario
        ///</summary>
        [TestMethod()]
        public void ExcluirServicoIdUsuarioTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            target.ExcluirServicoIdUsuario(idUsu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for buscarServicoPorId
        ///</summary>
        [TestMethod()]
        public void buscarServicoPorIdTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            Servico expected = null; // TODO: Initialize to an appropriate value
            Servico actual;
            actual = target.buscarServicoPorId(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarTodosServicos
        ///</summary>
        [TestMethod()]
        public void buscarTodosServicosTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Oid _idUsu = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.buscarTodosServicos(_idUsu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for editarServico
        ///</summary>
        [TestMethod()]
        public void editarServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Servico serv = null; // TODO: Initialize to an appropriate value
            target.editarServico(serv);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserirServico
        ///</summary>
        [TestMethod()]
        public void inserirServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Servico serv = null; // TODO: Initialize to an appropriate value
            target.inserirServico(serv);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for montarDocumentoSemId
        ///</summary>
        [TestMethod()]
        public void montarDocumentoSemIdTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Servico servico = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.montarDocumentoSemId(servico);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarDocumentoServico
        ///</summary>
        [TestMethod()]
        public void montarDocumentoServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Servico servico = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.montarDocumentoServico(servico);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarListaDocumentoServico
        ///</summary>
        [TestMethod()]
        public void montarListaDocumentoServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            List<Servico> lstServico = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.montarListaDocumentoServico(lstServico);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarListaServicos
        ///</summary>
        [TestMethod()]
        public void montarListaServicosTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            IEnumerable<Document> lstDoc = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.montarListaServicos(lstDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarListaServicos
        ///</summary>
        [TestMethod()]
        public void montarListaServicosTest1()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            List<Document> lstDoc = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.montarListaServicos(lstDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarObjetoServico
        ///</summary>
        [TestMethod()]
        public void montarObjetoServicoTest()
        {
            ClsServicosDAL target = new ClsServicosDAL(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Servico expected = null; // TODO: Initialize to an appropriate value
            Servico actual;
            actual = target.montarObjetoServico(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
