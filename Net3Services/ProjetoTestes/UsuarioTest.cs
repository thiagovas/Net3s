using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for UsuarioTest and is intended
    ///to contain all UsuarioTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UsuarioTest
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
        ///A test for Usuario Constructor
        ///</summary>
        [TestMethod()]
        public void UsuarioConstructorTest()
        {
            Usuario target = new Usuario();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for celular1
        ///</summary>
        [TestMethod()]
        public void celular1Test()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.celular1 = expected;
            actual = target.celular1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for celular2
        ///</summary>
        [TestMethod()]
        public void celular2Test()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.celular2 = expected;
            actual = target.celular2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for codigoConfirma
        ///</summary>
        [TestMethod()]
        public void codigoConfirmaTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.codigoConfirma = expected;
            actual = target.codigoConfirma;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for cpf_cnpj
        ///</summary>
        [TestMethod()]
        public void cpf_cnpjTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.cpf_cnpj = expected;
            actual = target.cpf_cnpj;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataCadastro
        ///</summary>
        [TestMethod()]
        public void dataCadastroTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataCadastro = expected;
            actual = target.dataCadastro;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataNasc
        ///</summary>
        [TestMethod()]
        public void dataNascTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataNasc = expected;
            actual = target.dataNasc;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for email
        ///</summary>
        [TestMethod()]
        public void emailTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.email = expected;
            actual = target.email;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for localImagem
        ///</summary>
        [TestMethod()]
        public void localImagemTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.localImagem = expected;
            actual = target.localImagem;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for login
        ///</summary>
        [TestMethod()]
        public void loginTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.login = expected;
            actual = target.login;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for natureza
        ///</summary>
        [TestMethod()]
        public void naturezaTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.natureza = expected;
            actual = target.natureza;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for nome
        ///</summary>
        [TestMethod()]
        public void nomeTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.nome = expected;
            actual = target.nome;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for rg
        ///</summary>
        [TestMethod()]
        public void rgTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.rg = expected;
            actual = target.rg;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for senha
        ///</summary>
        [TestMethod()]
        public void senhaTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.senha = expected;
            actual = target.senha;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for sexo
        ///</summary>
        [TestMethod()]
        public void sexoTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.sexo = expected;
            actual = target.sexo;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for site
        ///</summary>
        [TestMethod()]
        public void siteTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.site = expected;
            actual = target.site;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for status
        ///</summary>
        [TestMethod()]
        public void statusTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.status = expected;
            actual = target.status;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for telefone1
        ///</summary>
        [TestMethod()]
        public void telefone1Test()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.telefone1 = expected;
            actual = target.telefone1;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for telefone2
        ///</summary>
        [TestMethod()]
        public void telefone2Test()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.telefone2 = expected;
            actual = target.telefone2;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for tipoUsuario
        ///</summary>
        [TestMethod()]
        public void tipoUsuarioTest()
        {
            Usuario target = new Usuario(); // TODO: Initialize to an appropriate value
            Nullable<int> expected = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> actual;
            target.tipoUsuario = expected;
            actual = target.tipoUsuario;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
