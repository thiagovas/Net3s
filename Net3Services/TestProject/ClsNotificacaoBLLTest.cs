using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsNotificacaoBLLTest and is intended
    ///to contain all ClsNotificacaoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsNotificacaoBLLTest
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
        ///A test for ClsNotificacaoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsNotificacaoBLLConstructorTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscaTodasOrcamentarias
        ///</summary>
        [TestMethod()]
        public void BuscaTodasOrcamentariasTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsu = null; // TODO: Initialize to an appropriate value
            List<Notificacao> expected = null; // TODO: Initialize to an appropriate value
            List<Notificacao> actual;
            actual = target.BuscaTodasOrcamentarias(idUsu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarNotifPorOid
        ///</summary>
        [TestMethod()]
        public void BuscarNotifPorOidTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Oid idNoti = null; // TODO: Initialize to an appropriate value
            Notificacao expected = null; // TODO: Initialize to an appropriate value
            Notificacao actual;
            actual = target.BuscarNotifPorOid(idNoti);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodas
        ///</summary>
        [TestMethod()]
        public void BuscarTodasTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            List<Notificacao> expected = null; // TODO: Initialize to an appropriate value
            List<Notificacao> actual;
            actual = target.BuscarTodas(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContarNotificacoes
        ///</summary>
        [TestMethod()]
        public void ContarNotificacoesTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.ContarNotificacoes(oidUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InserirNotificacao
        ///</summary>
        [TestMethod()]
        public void InserirNotificacaoTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Notificacao objNotif = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.InserirNotificacao(objNotif);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for editarNotificacao
        ///</summary>
        [TestMethod()]
        public void editarNotificacaoTest()
        {
            ClsNotificacaoBLL target = new ClsNotificacaoBLL(); // TODO: Initialize to an appropriate value
            Notificacao notifi = null; // TODO: Initialize to an appropriate value
            target.editarNotificacao(notifi);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
