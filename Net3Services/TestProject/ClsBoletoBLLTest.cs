using ClsLibBLL.Boleto;
using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using BoletoNet;

namespace TestProject
{
    /// <summary>
    ///This is a test class for ClsBoletoBLLTest and is intended
    ///to contain all ClsBoletoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsBoletoBLLTest
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
        ///A test for ClsBoletoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsBoletoBLLConstructorTest()
        {
            ClsBoletoBLL target = new ClsBoletoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GerarBoleto
        ///</summary>
        [TestMethod()]
        public void GerarBoletoTest()
        {
            ClsBoletoBLL target = new ClsBoletoBLL();
            ClsOrcamentoBLL orcamentoBLL = new ClsOrcamentoBLL();

            Oid idOrcamento = null; // TODO: Initialize to an appropriate value
            Oid idContaBancaria = null; // TODO: Initialize to an appropriate value
            DateTime Vencimento = new DateTime().AddDays(7);
            int CodigoCedente = 0; // TODO: Initialize to an appropriate value
            string carteira = string.Empty; // TODO: Initialize to an appropriate value
            string nossoNumero = string.Empty; // TODO: Initialize to an appropriate value
            string numeroDocumento = string.Empty; // TODO: Initialize to an appropriate value
            BoletoBancario expected = null; // TODO: Initialize to an appropriate value
            BoletoBancario actual;
            actual = target.GerarBoleto(idOrcamento, idContaBancaria, Vencimento, CodigoCedente, carteira, nossoNumero, numeroDocumento);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
