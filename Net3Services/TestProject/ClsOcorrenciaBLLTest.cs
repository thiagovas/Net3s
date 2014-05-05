using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Collections.Generic;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsOcorrenciaBLLTest and is intended
    ///to contain all ClsOcorrenciaBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsOcorrenciaBLLTest
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
        ///A test for ClsOcorrenciaBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsOcorrenciaBLLConstructorTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarOcorrenciaPorAcusado
        ///</summary>
        [TestMethod()]
        public void BuscarOcorrenciaPorAcusadoTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            string acusado = string.Empty; // TODO: Initialize to an appropriate value
            List<Ocorrencia> expected = null; // TODO: Initialize to an appropriate value
            List<Ocorrencia> actual;
            actual = target.BuscarOcorrenciaPorAcusado(acusado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOcorrenciaPorData
        ///</summary>
        [TestMethod()]
        public void BuscarOcorrenciaPorDataTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            DateTime data = new DateTime(); // TODO: Initialize to an appropriate value
            List<Ocorrencia> expected = null; // TODO: Initialize to an appropriate value
            List<Ocorrencia> actual;
            actual = target.BuscarOcorrenciaPorData(data);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOcorrenciaPorDenunciado
        ///</summary>
        [TestMethod()]
        public void BuscarOcorrenciaPorDenunciadoTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            string denunciado = string.Empty; // TODO: Initialize to an appropriate value
            List<Ocorrencia> expected = null; // TODO: Initialize to an appropriate value
            List<Ocorrencia> actual;
            actual = target.BuscarOcorrenciaPorDenunciado(denunciado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOcorrenciaPorID
        ///</summary>
        [TestMethod()]
        public void BuscarOcorrenciaPorIDTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            Oid idocorrencia = null; // TODO: Initialize to an appropriate value
            Ocorrencia expected = null; // TODO: Initialize to an appropriate value
            Ocorrencia actual;
            actual = target.BuscarOcorrenciaPorID(idocorrencia);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarOcorrenciaPorStatus
        ///</summary>
        [TestMethod()]
        public void BuscarOcorrenciaPorStatusTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            short status = 0; // TODO: Initialize to an appropriate value
            List<Ocorrencia> expected = null; // TODO: Initialize to an appropriate value
            List<Ocorrencia> actual;
            actual = target.BuscarOcorrenciaPorStatus(status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditarOcorrencia
        ///</summary>
        [TestMethod()]
        public void EditarOcorrenciaTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            Oid idOcorrencia = null; // TODO: Initialize to an appropriate value
            string descricao = string.Empty; // TODO: Initialize to an appropriate value
            short status = 0; // TODO: Initialize to an appropriate value
            Oid denunciado = null; // TODO: Initialize to an appropriate value
            Oid acusado = null; // TODO: Initialize to an appropriate value
            string resposta = string.Empty; // TODO: Initialize to an appropriate value
            target.EditarOcorrencia(idOcorrencia, descricao, status, denunciado, acusado, resposta);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirOcorrencia
        ///</summary>
        [TestMethod()]
        public void ExcluirOcorrenciaTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            Oid idOcorrencia = null; // TODO: Initialize to an appropriate value
            target.ExcluirOcorrencia(idOcorrencia);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirOcorrencia
        ///</summary>
        [TestMethod()]
        public void InserirOcorrenciaTest()
        {
            ClsOcorrenciaBLL target = new ClsOcorrenciaBLL(); // TODO: Initialize to an appropriate value
            string descricao = string.Empty; // TODO: Initialize to an appropriate value
            short status = 0; // TODO: Initialize to an appropriate value
            Oid denunciante = null; // TODO: Initialize to an appropriate value
            Oid acusado = null; // TODO: Initialize to an appropriate value
            string resposta = string.Empty; // TODO: Initialize to an appropriate value
            target.InserirOcorrencia(descricao, status, denunciante, acusado, resposta);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
