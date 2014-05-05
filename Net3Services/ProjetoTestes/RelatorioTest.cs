using Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB.Driver;

namespace ProjetoTestes
{
    
    
    /// <summary>
    ///This is a test class for RelatorioTest and is intended
    ///to contain all RelatorioTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RelatorioTest
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
        ///A test for Relatorio Constructor
        ///</summary>
        [TestMethod()]
        public void RelatorioConstructorTest()
        {
            Relatorio target = new Relatorio();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for _id
        ///</summary>
        [TestMethod()]
        public void _idTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target._id = expected;
            actual = target._id;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataFim
        ///</summary>
        [TestMethod()]
        public void dataFimTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataFim = expected;
            actual = target.dataFim;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for dataIni
        ///</summary>
        [TestMethod()]
        public void dataIniTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.dataIni = expected;
            actual = target.dataIni;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantOcorr
        ///</summary>
        [TestMethod()]
        public void quantOcorrTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantOcorr = expected;
            actual = target.quantOcorr;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantServCanc
        ///</summary>
        [TestMethod()]
        public void quantServCancTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantServCanc = expected;
            actual = target.quantServCanc;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantServFech
        ///</summary>
        [TestMethod()]
        public void quantServFechTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantServFech = expected;
            actual = target.quantServFech;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantUsuCP
        ///</summary>
        [TestMethod()]
        public void quantUsuCPTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantUsuCP = expected;
            actual = target.quantUsuCP;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantUsuContart
        ///</summary>
        [TestMethod()]
        public void quantUsuContartTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantUsuContart = expected;
            actual = target.quantUsuContart;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantUsuPrest
        ///</summary>
        [TestMethod()]
        public void quantUsuPrestTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantUsuPrest = expected;
            actual = target.quantUsuPrest;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantUsuario
        ///</summary>
        [TestMethod()]
        public void quantUsuarioTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantUsuario = expected;
            actual = target.quantUsuario;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for quantUsuarioInativ
        ///</summary>
        [TestMethod()]
        public void quantUsuarioInativTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.quantUsuarioInativ = expected;
            actual = target.quantUsuarioInativ;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for serMaisPrest
        ///</summary>
        [TestMethod()]
        public void serMaisPrestTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.serMaisPrest = expected;
            actual = target.serMaisPrest;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for servMaisContrat
        ///</summary>
        [TestMethod()]
        public void servMaisContratTest()
        {
            Relatorio target = new Relatorio(); // TODO: Initialize to an appropriate value
            Oid expected = null; // TODO: Initialize to an appropriate value
            Oid actual;
            target.servMaisContrat = expected;
            actual = target.servMaisContrat;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
