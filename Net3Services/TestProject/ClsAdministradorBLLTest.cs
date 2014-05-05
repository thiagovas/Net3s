using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Collections.Generic;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsAdministradorBLLTest and is intended
    ///to contain all ClsAdministradorBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsAdministradorBLLTest
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
        ///A test for ClsAdministradorBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsAdministradorBLLConstructorTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL();
            Administrador admin = new Administrador();
            admin.nome = "Thiago Vieira";
            admin.login = "thiago";
            admin.senha = "thiago";
            admin.cSenha = "thiago";
            admin.situacao = 0;
            admin.dataCadastro = DateTime.Now;
            target.InserirAdministrador(admin);
        }

        /// <summary>
        ///A test for BuscaAdministradorPorEmail
        ///</summary>
        [TestMethod()]
        public void BuscaAdministradorPorEmailTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.BuscaAdministradorPorEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarAdministradorPorID
        ///</summary>
        [TestMethod()]
        public void BuscarAdministradorPorIDTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Oid idAdmin = null; // TODO: Initialize to an appropriate value
            Administrador expected = null; // TODO: Initialize to an appropriate value
            Administrador actual;
            actual = target.BuscarAdministradorPorID(idAdmin);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarAdministradorPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarAdministradorPorNomeTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.BuscarAdministradorPorNome(nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodosAdmnistradores
        ///</summary>
        [TestMethod()]
        public void BuscarTodosAdmnistradoresTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.BuscarTodosAdmnistradores();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditarAdministrador
        ///</summary>
        [TestMethod()]
        public void EditarAdministradorTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.EditarAdministrador(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarSituacao
        ///</summary>
        [TestMethod()]
        public void EditarSituacaoTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.EditarSituacao(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirAdministrador
        ///</summary>
        [TestMethod()]
        public void ExcluirAdministradorTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.ExcluirAdministrador(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InativaAdmin
        ///</summary>
        [TestMethod()]
        public void InativaAdminTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            target.InativaAdmin(adm);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirAdministrador
        ///</summary>
        [TestMethod()]
        public void InserirAdministradorTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Administrador adm = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.InserirAdministrador(adm);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LogarViaLogin
        ///</summary>
        [TestMethod()]
        public void LogarViaLoginTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            string senha = string.Empty; // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            List<Administrador> expected = null; // TODO: Initialize to an appropriate value
            List<Administrador> actual;
            actual = target.LogarViaLogin(senha, login);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerificaDisponibilidade
        ///</summary>
        [TestMethod()]
        public void VerificaDisponibilidadeTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.VerificaDisponibilidade(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for carregaEstados
        ///</summary>
        [TestMethod()]
        public void carregaEstadosTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            object expected = null; // TODO: Initialize to an appropriate value
            object actual;
            actual = target.carregaEstados();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for verificaMenorQuantDenuncia
        ///</summary>
        [TestMethod()]
        public void verificaMenorQuantDenunciaTest()
        {
            ClsAdministradorBLL target = new ClsAdministradorBLL(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            actual = target.verificaMenorQuantDenuncia();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
