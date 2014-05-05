using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for DenunciaTest and is intended
    ///to contain all DenunciaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DenunciaTest
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
        ///A test for Denuncia Constructor
        ///</summary>
        [TestMethod()]
        public void DenunciaConstructorTest()
        {
            Denuncia target = new Denuncia();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for acusado
        ///</summary>
        [TestMethod()]
        public void acusadoTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.acusado = expected;
            actual = target.acusado;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for atendente
        ///</summary>
        [TestMethod()]
        public void atendenteTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.atendente = expected;
            actual = target.atendente;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataAtendimento
        ///</summary>
        [TestMethod()]
        public void dataAtendimentoTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataAtendimento = expected;
            actual = target.dataAtendimento;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataDenuncia
        ///</summary>
        [TestMethod()]
        public void dataDenunciaTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataDenuncia = expected;
            actual = target.dataDenuncia;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for denunciante
        ///</summary>
        [TestMethod()]
        public void denuncianteTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.denunciante = expected;
            actual = target.denunciante;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for descricao
        ///</summary>
        [TestMethod()]
        public void descricaoTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.descricao = expected;
            actual = target.descricao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for punicao
        ///</summary>
        [TestMethod()]
        public void punicaoTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.punicao = expected;
            actual = target.punicao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for resposta
        ///</summary>
        [TestMethod()]
        public void respostaTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.resposta = expected;
            actual = target.resposta;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for status
        ///</summary>
        [TestMethod()]
        public void statusTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            Nullable<bool> expected = new Nullable<bool>(); // TODO: Initialize to an appropriate value
            Nullable<bool> actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tipoDenuncia
        ///</summary>
        [TestMethod()]
        public void tipoDenunciaTest()
        {
            Denuncia target = new Denuncia(); // TODO: Initialize to an appropriate value
            TipoDenuncia expected = new TipoDenuncia(); // TODO: Initialize to an appropriate value
            TipoDenuncia actual;
            target.tipoDenuncia = expected;
            actual = target.tipoDenuncia;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
