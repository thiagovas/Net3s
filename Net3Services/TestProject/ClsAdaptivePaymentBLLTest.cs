using ClsLibBLL.Paypal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PayPal.Platform.SDK;
using PayPal.Services.Private.AP;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsAdaptivePaymentBLLTest and is intended
    ///to contain all ClsAdaptivePaymentBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsAdaptivePaymentBLLTest
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
        ///A test for ClsAdaptivePaymentBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsAdaptivePaymentBLLConstructorTest()
        {
            ClsAdaptivePaymentBLL target = new ClsAdaptivePaymentBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for LerAPIProfile
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibBLL.dll")]
        public void LerAPIProfileTest()
        {
            ClsAdaptivePaymentBLL_Accessor target = new ClsAdaptivePaymentBLL_Accessor(); // TODO: Initialize to an appropriate value
            BaseAPIProfile expected = null; // TODO: Initialize to an appropriate value
            BaseAPIProfile actual;
            actual = target.LerAPIProfile();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Pagar
        ///</summary>
        [TestMethod()]
        public void PagarTest()
        {
            ClsAdaptivePaymentBLL target = new ClsAdaptivePaymentBLL(); // TODO: Initialize to an appropriate value
            string emailPagante = string.Empty; // TODO: Initialize to an appropriate value
            string emailRecebedor = string.Empty; // TODO: Initialize to an appropriate value
            Decimal valor = new Decimal(); // TODO: Initialize to an appropriate value
            PayResponse expected = null; // TODO: Initialize to an appropriate value
            PayResponse actual;
            actual = target.Pagar(emailPagante, emailRecebedor, valor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
