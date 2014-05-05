using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using Models;
using System.Collections.Generic;

namespace ProjetoTestes
{
    /// <summary>
    ///This is a test class for ClsNotificacaoDALTest and is intended
    ///to contain all ClsNotificacaoDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsNotificacaoDALTest
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
        ///A test for ClsNotificacaoDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsNotificacaoDALConstructorTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarNotifPorIdRemetente
        ///</summary>
        [TestMethod()]
        public void BuscarNotifPorIdRemetenteTest()
        {
            InserirSolicitacaoTest();
            ClsNotificacaoDAL target = new ClsNotificacaoDAL();
            Oid idRemetente = new Oid("4e9643186a88f91dd0000001");
            Notificacao expected = new Notificacao();
            Notificacao actual;
            actual = target.BuscarNotifPorIdRemetente(idRemetente);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarNotifPorOid
        ///</summary>
        [TestMethod()]
        public void BuscarNotifPorOidTest()
        {
            InserirSolicitacaoTest();
            ClsNotificacaoDAL target = new ClsNotificacaoDAL();
            List<Notificacao> actual;
            actual = target.BuscarTodasNotificacoes(new Oid("4e9394b26a88f91ca4000001"));
            Oid idNoti = actual[0]._id;
            Notificacao expected = new Notificacao();
            Notificacao atual;
            atual = target.BuscarNotifPorOid(idNoti);
            Assert.AreEqual(expected, atual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodasNotificacoes
        ///</summary>
        [TestMethod()]
        public void BuscarTodasNotificacoesTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            List<Notificacao> expected = null; // TODO: Initialize to an appropriate value
            List<Notificacao> actual;
            actual = target.BuscarTodasNotificacoes(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InserirSolicitacao
        ///</summary>
        [TestMethod()]
        public void InserirSolicitacaoTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL();
            Notificacao noti = new Notificacao();
            noti.assunto = "AssuntoAbcd";
            noti.dataNotificacao = DateTime.Now;
            noti.descricao = "Descrição da notificação";
            noti.idDestinatatio = new Oid("4e9394b26a88f91ca4000001");
            noti.idRemetente = new Oid("4e9643186a88f91dd0000001");
            noti.prioridade = Prioridade.Media;
            noti.status = StatusNotif.Pendente;
            noti.tipo = TipoNotificacao.Network;
            target.InserirSolicitacao(noti);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MontarDocumento
        ///</summary>
        [TestMethod()]
        public void MontarDocumentoTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            Notificacao notif = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontarDocumento(notif);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarDocumentoSemId
        ///</summary>
        [TestMethod()]
        public void MontarDocumentoSemIdTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            Notificacao notif = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontarDocumentoSemId(notif);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaDocumento
        ///</summary>
        [TestMethod()]
        public void MontarListaDocumentoTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            List<Notificacao> lstNotif = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.MontarListaDocumento(lstNotif);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontarListaObjeto
        ///</summary>
        [TestMethod()]
        public void MontarListaObjetoTest()
        {
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            List<Document> lstDoc = null; // TODO: Initialize to an appropriate value
            List<Notificacao> expected = null; // TODO: Initialize to an appropriate value
            List<Notificacao> actual;
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
            ClsNotificacaoDAL target = new ClsNotificacaoDAL(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Notificacao expected = null; // TODO: Initialize to an appropriate value
            Notificacao actual;
            actual = target.MontarObjeto(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
