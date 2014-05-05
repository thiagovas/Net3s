using ClsLibDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for RepositoryTest and is intended
    ///to contain all RepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RepositoryTest
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
        ///A test for Repository Constructor
        ///</summary>
        [TestMethod()]
        public void RepositoryConstructorTest()
        {
            Repository target = new Repository();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Desconectar
        ///</summary>
        [TestMethod()]
        public void DesconectarTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            target.Desconectar();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            target.Insert(doc, collectionName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Insert
        ///</summary>
        [TestMethod()]
        public void InsertTest1()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            IEnumerable<Document> doc = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            target.Insert(doc, collectionName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ProcurarRegex
        ///</summary>
        [TestMethod()]
        public void ProcurarRegexTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            string nomeCampo = string.Empty; // TODO: Initialize to an appropriate value
            string valorCampo = string.Empty; // TODO: Initialize to an appropriate value
            string collec = string.Empty; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.ProcurarRegex(nomeCampo, valorCampo, collec);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            target.Save(doc, collectionName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document docAntigo = null; // TODO: Initialize to an appropriate value
            Document docNovo = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            target.Update(docAntigo, docNovo, collectionName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for atualizaArquivo
        ///</summary>
        [TestMethod()]
        public void atualizaArquivoTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document docNew = null; // TODO: Initialize to an appropriate value
            Document docOld = null; // TODO: Initialize to an appropriate value
            string collection = string.Empty; // TODO: Initialize to an appropriate value
            target.atualizaArquivo(docNew, docOld, collection);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for deletaArquivo
        ///</summary>
        [TestMethod()]
        public void deletaArquivoTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            string collection = string.Empty; // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            target.deletaArquivo(collection, doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for delete
        ///</summary>
        [TestMethod()]
        public void deleteTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            string collectionName = string.Empty; // TODO: Initialize to an appropriate value
            target.delete(doc, collectionName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for inserirArquivo
        ///</summary>
        [TestMethod()]
        public void inserirArquivoTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            string collection = string.Empty; // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            target.inserirArquivo(collection, doc);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for procurar
        ///</summary>
        [TestMethod()]
        public void procurarTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            string collec = string.Empty; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.procurar(doc, collec);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for procurarArquivo
        ///</summary>
        [TestMethod()]
        public void procurarArquivoTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            string collection = string.Empty; // TODO: Initialize to an appropriate value
            Document doc = null; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.procurarArquivo(collection, doc);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for procurarArray
        ///</summary>
        [TestMethod()]
        public void procurarArrayTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            string col = string.Empty; // TODO: Initialize to an appropriate value
            string where = string.Empty; // TODO: Initialize to an appropriate value
            List<Document> expected = null; // TODO: Initialize to an appropriate value
            List<Document> actual;
            actual = target.procurarArray(col, where);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DB
        ///</summary>
        [TestMethod()]
        public void DBTest()
        {
            Repository target = new Repository(); // TODO: Initialize to an appropriate value
            Database actual;
            actual = target.DB;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
