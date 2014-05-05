using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ServicoTest and is intended
    ///to contain all ServicoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ServicoTest
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
        ///A test for Servico Constructor
        ///</summary>
        [TestMethod()]
        public void ServicoConstructorTest()
        {
            Servico target = new Servico();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for categoriaServico
        ///</summary>
        [TestMethod()]
        public void categoriaServicoTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.categoriaServico = expected;
            actual = target.categoriaServico;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for descricao
        ///</summary>
        [TestMethod()]
        public void descricaoTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.descricao = expected;
            actual = target.descricao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for idUsuario
        ///</summary>
        [TestMethod()]
        public void idUsuarioTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.idUsuario = expected;
            actual = target.idUsuario;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nivelRegionalidade
        ///</summary>
        [TestMethod()]
        public void nivelRegionalidadeTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nivelRegionalidade = expected;
            actual = target.nivelRegionalidade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nome
        ///</summary>
        [TestMethod()]
        public void nomeTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nome = expected;
            actual = target.nome;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for notaMedia
        ///</summary>
        [TestMethod()]
        public void notaMediaTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.notaMedia = expected;
            actual = target.notaMedia;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for preco
        ///</summary>
        [TestMethod()]
        public void precoTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.preco = expected;
            actual = target.preco;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for regiao
        ///</summary>
        [TestMethod()]
        public void regiaoTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.regiao = expected;
            actual = target.regiao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for regional
        ///</summary>
        [TestMethod()]
        public void regionalTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.regional = expected;
            actual = target.regional;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tempoMedioGasto
        ///</summary>
        [TestMethod()]
        public void tempoMedioGastoTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            target.tempoMedioGasto = expected;
            actual = target.tempoMedioGasto;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for unidadeMedida
        ///</summary>
        [TestMethod()]
        public void unidadeMedidaTest()
        {
            Servico target = new Servico(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.unidadeMedida = expected;
            actual = target.unidadeMedida;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
