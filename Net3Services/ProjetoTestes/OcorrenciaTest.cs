using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for OcorrenciaTest and is intended
    ///to contain all OcorrenciaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OcorrenciaTest
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
        ///A test for Ocorrencia Constructor
        ///</summary>
        [TestMethod()]
        public void OcorrenciaConstructorTest()
        {
            Ocorrencia target = new Ocorrencia();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for acusado
        ///</summary>
        [TestMethod()]
        public void acusadoTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
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
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.atendente = expected;
            actual = target.atendente;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataDenuncia
        ///</summary>
        [TestMethod()]
        public void dataDenunciaTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataDenuncia = expected;
            actual = target.dataDenuncia;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataResposta
        ///</summary>
        [TestMethod()]
        public void dataRespostaTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataResposta = expected;
            actual = target.dataResposta;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for denunciante
        ///</summary>
        [TestMethod()]
        public void denuncianteTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
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
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.descricao = expected;
            actual = target.descricao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for idOcorrencia
        ///</summary>
        [TestMethod()]
        public void idOcorrenciaTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.idOcorrencia = expected;
            actual = target.idOcorrencia;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for resposta
        ///</summary>
        [TestMethod()]
        public void respostaTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
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
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tempoBanido
        ///</summary>
        [TestMethod()]
        public void tempoBanidoTest()
        {
            Ocorrencia target = new Ocorrencia(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.tempoBanido = expected;
            actual = target.tempoBanido;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
