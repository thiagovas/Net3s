using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for NotificacaoTest and is intended
    ///to contain all NotificacaoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class NotificacaoTest
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
        ///A test for Notificacao Constructor
        ///</summary>
        [TestMethod()]
        public void NotificacaoConstructorTest()
        {
            Notificacao target = new Notificacao();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for assunto
        ///</summary>
        [TestMethod()]
        public void assuntoTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.assunto = expected;
            actual = target.assunto;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataNotificacao
        ///</summary>
        [TestMethod()]
        public void dataNotificacaoTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataNotificacao = expected;
            actual = target.dataNotificacao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for descricao
        ///</summary>
        [TestMethod()]
        public void descricaoTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.descricao = expected;
            actual = target.descricao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for idDestinatatio
        ///</summary>
        [TestMethod()]
        public void idDestinatatioTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.idDestinatatio = expected;
            actual = target.idDestinatatio;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for idRemetente
        ///</summary>
        [TestMethod()]
        public void idRemetenteTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.idRemetente = expected;
            actual = target.idRemetente;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for idServico
        ///</summary>
        [TestMethod()]
        public void idServicoTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.idServico = expected;
            actual = target.idServico;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for prioridade
        ///</summary>
        [TestMethod()]
        public void prioridadeTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Prioridade expected = new Prioridade(); // TODO: Initialize to an appropriate value
            Prioridade actual;
            target.prioridade = expected;
            actual = target.prioridade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for qtdContratada
        ///</summary>
        [TestMethod()]
        public void qtdContratadaTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            Nullable<double> expected = new Nullable<double>(); // TODO: Initialize to an appropriate value
            Nullable<double> actual;
            target.qtdContratada = expected;
            actual = target.qtdContratada;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for status
        ///</summary>
        [TestMethod()]
        public void statusTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            StatusNotif expected = new StatusNotif(); // TODO: Initialize to an appropriate value
            StatusNotif actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tipo
        ///</summary>
        [TestMethod()]
        public void tipoTest()
        {
            Notificacao target = new Notificacao(); // TODO: Initialize to an appropriate value
            TipoNotificacao expected = new TipoNotificacao(); // TODO: Initialize to an appropriate value
            TipoNotificacao actual;
            target.tipo = expected;
            actual = target.tipo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
