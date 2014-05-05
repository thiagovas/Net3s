using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsHistoricoServicoBLLTest and is intended
    ///to contain all ClsHistoricoServicoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsHistoricoServicoBLLTest
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
        ///A test for ClsHistoricoServicoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsHistoricoServicoBLLConstructorTest()
        {
            ClsHistoricoServicoBLL target = new ClsHistoricoServicoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarHistoricoServicos
        ///</summary>
        [TestMethod()]
        public void BuscarHistoricoServicosTest()
        {
            ClsHistoricoServicoBLL target = new ClsHistoricoServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            List<HistoricoServico> expected = null; // TODO: Initialize to an appropriate value
            List<HistoricoServico> actual;
            actual = target.BuscarHistoricoServicos(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Editar
        ///</summary>
        [TestMethod()]
        public void EditarTest()
        {
            ClsHistoricoServicoBLL target = new ClsHistoricoServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            HistoricoServico histServ = null; // TODO: Initialize to an appropriate value
            target.Editar(idUsuario, histServ);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Inserir
        ///</summary>
        [TestMethod()]
        public void InserirTest()
        {
            ClsHistoricoServicoBLL target = new ClsHistoricoServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            HistoricoServico histServ = null; // TODO: Initialize to an appropriate value
            target.Inserir(idUsuario, histServ);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
