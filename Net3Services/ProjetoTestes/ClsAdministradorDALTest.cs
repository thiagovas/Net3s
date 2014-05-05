using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsAdministradorDALTest and is intended
    ///to contain all ClsAdministradorDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsAdministradorDALTest
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
        ///A test for ClsAdministradorDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsAdministradorDALConstructorTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MontaDocumento
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void MontaDocumentoTest()
        {
            ClsAdministradorDAL_Accessor target = new ClsAdministradorDAL_Accessor(); // TODO: Initialize to an appropriate value
            Administrador obj = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontaDocumento(obj);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontaObjAdm
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void MontaObjAdmTest()
        {
            ClsAdministradorDAL_Accessor target = new ClsAdministradorDAL_Accessor(); // TODO: Initialize to an appropriate value
            List<Document> ListDoc = null; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.MontaObjAdm(ListDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for atualizar
        ///</summary>
        [TestMethod()]
        public void atualizarTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            Oid idAntigo = null; // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.atualizar(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for buscaPorEmail
        ///</summary>
        [TestMethod()]
        public void buscaPorEmailTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.buscaPorEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for inativar
        ///</summary>
        [TestMethod()]
        public void inativarTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.inativar(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserir
        ///</summary>
        [TestMethod()]
        public void inserirTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.inserir(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for logar
        ///</summary>
        [TestMethod()]
        public void logarTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            string senha = string.Empty; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.logar(login, senha);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for verificaDisponibilidade
        ///</summary>
        [TestMethod()]
        public void verificaDisponibilidadeTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.verificaDisponibilidade(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for verificaMenorQuantDenuncia
        ///</summary>
        [TestMethod()]
        public void verificaMenorQuantDenunciaTest()
        {
            ClsAdministradorDAL target = new ClsAdministradorDAL(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            actual = target.verificaMenorQuantDenuncia();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
