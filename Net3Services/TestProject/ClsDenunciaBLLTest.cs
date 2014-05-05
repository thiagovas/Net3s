using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Collections.Generic;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsDenunciaBLLTest and is intended
    ///to contain all ClsDenunciaBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsDenunciaBLLTest
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
        ///A test for ClsDenunciaBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsDenunciaBLLConstructorTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarDenunciaAtendente
        ///</summary>
        [TestMethod()]
        public void BuscarDenunciaAtendenteTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            string idAtendente = string.Empty; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarDenunciaAtendente(idAtendente);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarDenunciaPorAcusado
        ///</summary>
        [TestMethod()]
        public void BuscarDenunciaPorAcusadoTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Oid idAcusado = null; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarDenunciaPorAcusado(idAcusado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarDenunciaPorData
        ///</summary>
        [TestMethod()]
        public void BuscarDenunciaPorDataTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            DateTime dataDenuncia = new DateTime(); // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarDenunciaPorData(dataDenuncia);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarDenunciaPorDenunciante
        ///</summary>
        [TestMethod()]
        public void BuscarDenunciaPorDenuncianteTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Oid idDenunciante = null; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarDenunciaPorDenunciante(idDenunciante);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarDenunciaPorID
        ///</summary>
        [TestMethod()]
        public void BuscarDenunciaPorIDTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Oid idDenuncia = null; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarDenunciaPorID(idDenuncia);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodasDenuncias
        ///</summary>
        [TestMethod()]
        public void BuscarTodasDenunciasTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.BuscarTodasDenuncias();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditarDenuncia
        ///</summary>
        [TestMethod()]
        public void EditarDenunciaTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Denuncia denuncia = null; // TODO: Initialize to an appropriate value
            target.EditarDenuncia(denuncia);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirDenuncia
        ///</summary>
        [TestMethod()]
        public void ExcluirDenunciaTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Denuncia idDenuncia = null; // TODO: Initialize to an appropriate value
            target.ExcluirDenuncia(idDenuncia);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirDenuncia
        ///</summary>
        [TestMethod()]
        public void InserirDenunciaTest()
        {
            ClsDenunciaBLL target = new ClsDenunciaBLL(); // TODO: Initialize to an appropriate value
            Denuncia denuncia = null; // TODO: Initialize to an appropriate value
            target.InserirDenuncia(denuncia);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
