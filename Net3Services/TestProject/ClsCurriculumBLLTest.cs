using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsCurriculumBLLTest and is intended
    ///to contain all ClsCurriculumBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsCurriculumBLLTest
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
        ///A test for ClsCurriculumBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsCurriculumBLLConstructorTest()
        {
            ClsCurriculumBLL target = new ClsCurriculumBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarCurriculum
        ///</summary>
        [TestMethod()]
        public void BuscarCurriculumTest()
        {
            ClsCurriculumBLL target = new ClsCurriculumBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            Curriculum expected = null; // TODO: Initialize to an appropriate value
            Curriculum actual;
            actual = target.BuscarCurriculum(oidUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditarCurriculum
        ///</summary>
        [TestMethod()]
        public void EditarCurriculumTest()
        {
            ClsCurriculumBLL target = new ClsCurriculumBLL(); // TODO: Initialize to an appropriate value
            Oid oidUsuario = null; // TODO: Initialize to an appropriate value
            Curriculum objCur = null; // TODO: Initialize to an appropriate value
            target.EditarCurriculum(oidUsuario, objCur);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ValidarInfoCertificados
        ///</summary>
        [TestMethod()]
        public void ValidarInfoCertificadosTest()
        {
            ClsCurriculumBLL target = new ClsCurriculumBLL(); // TODO: Initialize to an appropriate value
            Certificacao cert = null; // TODO: Initialize to an appropriate value
            bool[] expected = null; // TODO: Initialize to an appropriate value
            bool[] actual;
            actual = target.ValidarInfoCertificados(cert);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
