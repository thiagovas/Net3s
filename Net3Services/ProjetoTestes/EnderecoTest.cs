using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for EnderecoTest and is intended
    ///to contain all EnderecoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnderecoTest
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
        ///A test for Endereco Constructor
        ///</summary>
        [TestMethod()]
        public void EnderecoConstructorTest()
        {
            Endereco target = new Endereco();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for bairro
        ///</summary>
        [TestMethod()]
        public void bairroTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.bairro = expected;
            actual = target.bairro;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cep
        ///</summary>
        [TestMethod()]
        public void cepTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.cep = expected;
            actual = target.cep;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cidade
        ///</summary>
        [TestMethod()]
        public void cidadeTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.cidade = expected;
            actual = target.cidade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for complemento
        ///</summary>
        [TestMethod()]
        public void complementoTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.complemento = expected;
            actual = target.complemento;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for id
        ///</summary>
        [TestMethod()]
        public void idTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.id = expected;
            actual = target.id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for logradouro
        ///</summary>
        [TestMethod()]
        public void logradouroTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.logradouro = expected;
            actual = target.logradouro;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for numero
        ///</summary>
        [TestMethod()]
        public void numeroTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            ushort expected = 0; // TODO: Initialize to an appropriate value
            ushort actual;
            target.numero = expected;
            actual = target.numero;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pais
        ///</summary>
        [TestMethod()]
        public void paisTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.pais = expected;
            actual = target.pais;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for uf
        ///</summary>
        [TestMethod()]
        public void ufTest()
        {
            Endereco target = new Endereco(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.uf = expected;
            actual = target.uf;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
