using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for ClsDenunciaDALTest and is intended
    ///to contain all ClsDenunciaDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsDenunciaDALTest
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
        ///A test for ClsDenunciaDAL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsDenunciaDALConstructorTest()
        {
            ClsDenunciaDAL target = new ClsDenunciaDAL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for MontaObjDenuncia
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void MontaObjDenunciaTest()
        {
            ClsDenunciaDAL_Accessor target = new ClsDenunciaDAL_Accessor(); // TODO: Initialize to an appropriate value
            Denuncia den = null; // TODO: Initialize to an appropriate value
            Document expected = null; // TODO: Initialize to an appropriate value
            Document actual;
            actual = target.MontaObjDenuncia(den);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MontaObjDoc
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void MontaObjDocTest()
        {
            ClsDenunciaDAL_Accessor target = new ClsDenunciaDAL_Accessor(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Denuncia expected = null; // TODO: Initialize to an appropriate value
            Denuncia actual;
            actual = target.MontaObjDoc(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RetornaListaDenuncias
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void RetornaListaDenunciasTest()
        {
            ClsDenunciaDAL_Accessor target = new ClsDenunciaDAL_Accessor(); // TODO: Initialize to an appropriate value
            List<Document> LstDoc = null; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.RetornaListaDenuncias(LstDoc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibDAL.dll")]
        public void _idTest()
        {
            ClsDenunciaDAL_Accessor target = new ClsDenunciaDAL_Accessor(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            actual = target._id(doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for buscaTodosIdAtend
        ///</summary>
        [TestMethod()]
        public void buscaTodosIdAtendTest()
        {
            ClsDenunciaDAL target = new ClsDenunciaDAL(); // TODO: Initialize to an appropriate value
            Denuncia den = null; // TODO: Initialize to an appropriate value
            List<Denuncia> expected = null; // TODO: Initialize to an appropriate value
            List<Denuncia> actual;
            actual = target.buscaTodosIdAtend(den);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for inserir
        ///</summary>
        [TestMethod()]
        public void inserirTest()
        {
            ClsDenunciaDAL target = new ClsDenunciaDAL(); // TODO: Initialize to an appropriate value
            Denuncia den = null; // TODO: Initialize to an appropriate value
            target.inserir(den);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for update
        ///</summary>
        [TestMethod()]
        public void updateTest()
        {
            ClsDenunciaDAL target = new ClsDenunciaDAL(); // TODO: Initialize to an appropriate value
            Denuncia den = null; // TODO: Initialize to an appropriate value
            target.update(den);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
