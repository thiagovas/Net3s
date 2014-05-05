using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsUsuDALTest and is intended
    ///to contain all ClsUsuDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsUsuDALTest
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
        ///A test for ClsUsuDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsUsuDALConstructorTest()
        {
            ClsUsuDAL target = new ClsUsuDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarCodigoVerificacao
        ///</summary>
        [TestMethod()]
        public void BuscarCodigoVerificacaoTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuscarCodigoVerificacao(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarCodigoVerificacao
        ///</summary>
        [TestMethod()]
        public void BuscarCodigoVerificacaoTest1()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string codVerificacao = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.BuscarCodigoVerificacao(codVerificacao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarStatus
        ///</summary>
        [TestMethod()]
        public void BuscarStatusTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuscarStatus(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarStatus
        ///</summary>
        [TestMethod()]
        public void BuscarStatusTest1()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string _id = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuscarStatus(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InserirImagemPadrao
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void InserirImagemPadraoTest()
        {
            ClsUsuDAL_Accessor target = new ClsUsuDAL_Accessor(); // TODO: Initialize to an appropriate value
            target.InserirImagemPadrao();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MontarDocumentoSemId
        ///</summary>
        [TestMethod()]
        public void MontarDocumentoSemIdTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontarDocumentoSemId(usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaObjetos
        ///</summary>
        [TestMethod()]
        public void MontarListaObjetosTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            IEnumerable<Document> cur = null; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.MontarListaObjetos(cur);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaObjetos
        ///</summary>
        [TestMethod()]
        public void MontarListaObjetosTest1()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            List<Document> lstDoc = null; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.MontarListaObjetos(lstDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarTodos
        ///</summary>
        [TestMethod()]
        public void buscarTodosTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.buscarTodos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarUsuarioPorCpfCnpj
        ///</summary>
        [TestMethod()]
        public void buscarUsuarioPorCpfCnpjTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string cpfCnpj = string.Empty; // TODO: Initialize to an appropriate value
            Usuario expected = null; // TODO: Initialize to an appropriate value
            Usuario actual;
            actual = target.buscarUsuarioPorCpfCnpj(cpfCnpj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarUsuarioPorEmail
        ///</summary>
        [TestMethod()]
        public void buscarUsuarioPorEmailTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.buscarUsuarioPorEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarUsuarioPorId
        ///</summary>
        [TestMethod()]
        public void buscarUsuarioPorIdTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            Usuario expected = null; // TODO: Initialize to an appropriate value
            Usuario actual;
            actual = target.BuscarUsuarioPorId(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarUsuarioPorLogin
        ///</summary>
        [TestMethod()]
        public void buscarUsuarioPorLoginTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.buscarUsuarioPorLogin(login);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscarUsuarioPorNome
        ///</summary>
        [TestMethod()]
        public void buscarUsuarioPorNomeTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarUsuarioPorNome(nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for editarUsu
        ///</summary>
        [TestMethod()]
        public void editarUsuTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            target.editarUsu(usu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for excluirUsu
        ///</summary>
        [TestMethod()]
        public void excluirUsuTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            target.excluirUsu(_id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserirUsu
        ///</summary>
        [TestMethod()]
        public void inserirUsuTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            target.inserirUsu(usu);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for montarDocumento
        ///</summary>
        [TestMethod()]
        public void montarDocumentoTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.montarDocumento(usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for montarObjeto
        ///</summary>
        [TestMethod()]
        public void montarObjetoTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Usuario expected = null; // TODO: Initialize to an appropriate value
            Usuario actual;
            actual = target.montarObjeto(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for verificarDuplicidadeLogin
        ///</summary>
        [TestMethod()]
        public void verificarDuplicidadeLoginTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.verificarDuplicidadeLogin(login);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for verificarLogin
        ///</summary>
        [TestMethod()]
        public void verificarLoginTest()
        {
            ClsUsuDAL target = new ClsUsuDAL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            Usuario usuExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.verificarLogin(ref usu);
            Assert.AreEqual(usuExpected, usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
