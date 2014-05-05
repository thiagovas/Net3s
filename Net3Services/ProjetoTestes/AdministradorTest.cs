using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for AdministradorTest and is intended
    ///to contain all AdministradorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AdministradorTest
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
        ///A test for Administrador Constructor
        ///</summary>
        [TestMethod()]
        public void AdministradorConstructorTest()
        {
            Administrador target = new Administrador();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for UF
        ///</summary>
        [TestMethod()]
        public void UFTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.UF = expected;
            actual = target.UF;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cSenha
        ///</summary>
        [TestMethod()]
        public void cSenhaTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.cSenha = expected;
            actual = target.cSenha;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cidade
        ///</summary>
        [TestMethod()]
        public void cidadeTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.cidade = expected;
            actual = target.cidade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataCadastro
        ///</summary>
        [TestMethod()]
        public void dataCadastroTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> expected = new Nullable<DateTime>(); // TODO: Initialize to an appropriate value
            Nullable<DateTime> actual;
            target.dataCadastro = expected;
            actual = target.dataCadastro;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for login
        ///</summary>
        [TestMethod()]
        public void loginTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.login = expected;
            actual = target.login;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nome
        ///</summary>
        [TestMethod()]
        public void nomeTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nome = expected;
            actual = target.nome;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for pais
        ///</summary>
        [TestMethod()]
        public void paisTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.pais = expected;
            actual = target.pais;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantDenum
        ///</summary>
        [TestMethod()]
        public void quantDenumTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.quantDenum = expected;
            actual = target.quantDenum;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for senha
        ///</summary>
        [TestMethod()]
        public void senhaTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.senha = expected;
            actual = target.senha;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for situacao
        ///</summary>
        [TestMethod()]
        public void situacaoTest()
        {
            Administrador target = new Administrador(); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.situacao = expected;
            actual = target.situacao;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
