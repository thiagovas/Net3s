using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsRelatoriosBLLTest and is intended
    ///to contain all ClsRelatoriosBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsRelatoriosBLLTest
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
        ///A test for ClsRelatoriosBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsRelatoriosBLLConstructorTest()
        {
            ClsRelatoriosBLL target = new ClsRelatoriosBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for EditarRelatorio
        ///</summary>
        [TestMethod()]
        public void EditarRelatorioTest()
        {
            ClsRelatoriosBLL target = new ClsRelatoriosBLL(); // TODO: Initialize to an appropriate value
            Relatorio relatorio = null; // TODO: Initialize to an appropriate value
            target.EditarRelatorio(relatorio);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirRelatorio
        ///</summary>
        [TestMethod()]
        public void ExcluirRelatorioTest()
        {
            ClsRelatoriosBLL target = new ClsRelatoriosBLL(); // TODO: Initialize to an appropriate value
            Relatorio relatorio = null; // TODO: Initialize to an appropriate value
            target.ExcluirRelatorio(relatorio);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirRelatorio
        ///</summary>
        [TestMethod()]
        public void InserirRelatorioTest()
        {
            ClsRelatoriosBLL target = new ClsRelatoriosBLL(); // TODO: Initialize to an appropriate value
            Relatorio relatorio = null; // TODO: Initialize to an appropriate value
            target.InserirRelatorio(relatorio);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
