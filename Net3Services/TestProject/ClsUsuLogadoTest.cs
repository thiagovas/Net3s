using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsUsuLogadoTest and is intended
    ///to contain all ClsUsuLogadoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsUsuLogadoTest
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
        ///A test for ClsUsuLogado Constructor
        ///</summary>
        [TestMethod()]
        public void ClsUsuLogadoConstructorTest()
        {
            ClsUsuLogado target = new ClsUsuLogado();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for LimparPropriedades
        ///</summary>
        [TestMethod()]
        public void LimparPropriedadesTest()
        {
            ClsUsuLogado.LimparPropriedades();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Cidade
        ///</summary>
        [TestMethod()]
        public void CidadeTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.Cidade = expected;
            actual = ClsUsuLogado.Cidade;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CpfCnpj
        ///</summary>
        [TestMethod()]
        public void CpfCnpjTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.CpfCnpj = expected;
            actual = ClsUsuLogado.CpfCnpj;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IdUsuario
        ///</summary>
        [TestMethod()]
        public void IdUsuarioTest()
        {
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            ClsUsuLogado.IdUsuario = expected;
            actual = ClsUsuLogado.IdUsuario;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Login
        ///</summary>
        [TestMethod()]
        public void LoginTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.Login = expected;
            actual = ClsUsuLogado.Login;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pais
        ///</summary>
        [TestMethod()]
        public void PaisTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.Pais = expected;
            actual = ClsUsuLogado.Pais;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Rg
        ///</summary>
        [TestMethod()]
        public void RgTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.Rg = expected;
            actual = ClsUsuLogado.Rg;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Uf
        ///</summary>
        [TestMethod()]
        public void UfTest()
        {
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            ClsUsuLogado.Uf = expected;
            actual = ClsUsuLogado.Uf;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
