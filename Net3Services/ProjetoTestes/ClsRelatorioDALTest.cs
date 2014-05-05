using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsRelatorioDALTest and is intended
    ///to contain all ClsRelatorioDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsRelatorioDALTest
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
        ///A test for ClsRelatorioDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsRelatorioDALConstructorTest()
        {
            ClsRelatorioDAL target = new ClsRelatorioDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for atualizar
        ///</summary>
        [TestMethod()]
        public void atualizarTest()
        {
            ClsRelatorioDAL target = new ClsRelatorioDAL(); // TODO: Initialize to an appropriate value
            Relatorio relat = null; // TODO: Initialize to an appropriate value
            target.atualizar(relat);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserir
        ///</summary>
        [TestMethod()]
        public void inserirTest()
        {
            ClsRelatorioDAL target = new ClsRelatorioDAL(); // TODO: Initialize to an appropriate value
            Relatorio relat = null; // TODO: Initialize to an appropriate value
            target.inserir(relat);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
