using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.UI.WebControls;
using System.Drawing;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for clsUtilidadesTest and is intended
    ///to contain all clsUtilidadesTest Unit Tests
    ///</summary>
    [TestClass()]
    public class clsUtilidadesTest
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
        ///A test for CampoCorreto
        ///</summary>
        [TestMethod()]
        public void CampoCorretoTest()
        {
            TextBox txt = null; // TODO: Initialize to an appropriate value
            Color cor = new Color(); // TODO: Initialize to an appropriate value
            clsUtilidades.CampoCorreto(txt, cor);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CampoErrado
        ///</summary>
        [TestMethod()]
        public void CampoErradoTest()
        {
            TextBox txt = null; // TODO: Initialize to an appropriate value
            string menssagem = string.Empty; // TODO: Initialize to an appropriate value
            clsUtilidades.CampoErrado(txt, menssagem);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetArquiosAleatorios
        ///</summary>
        [TestMethod()]
        public void GetArquiosAleatoriosTest()
        {
            string caminhoPasta = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = clsUtilidades.GetArquivosAleatorios(caminhoPasta);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNomeMes
        ///</summary>
        [TestMethod()]
        public void GetNomeMesTest()
        {
            DateTime myData = new DateTime(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = clsUtilidades.GetNomeMes(myData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for OidToString
        ///</summary>
        [TestMethod()]
        public void OidToStringTest()
        {
            byte[] oid = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = clsUtilidades.OidToString(oid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidarOid
        ///</summary>
        [TestMethod()]
        public void ValidarOidTest()
        {
            Oid id = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = clsUtilidades.ValidarOid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidarOid
        ///</summary>
        [TestMethod()]
        public void ValidarOidTest1()
        {
            string id = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = clsUtilidades.ValidarOid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for enviarEmailConfirmacao
        ///</summary>
        [TestMethod()]
        public void enviarEmailConfirmacaoTest()
        {
            string emailRemetente = string.Empty; // TODO: Initialize to an appropriate value
            string emailDestinatario = string.Empty; // TODO: Initialize to an appropriate value
            string senhaDestinatario = string.Empty; // TODO: Initialize to an appropriate value
            string hostSmtp = string.Empty; // TODO: Initialize to an appropriate value
            int porta = 0; // TODO: Initialize to an appropriate value
            string chave = string.Empty; // TODO: Initialize to an appropriate value
            string link = string.Empty; // TODO: Initialize to an appropriate value
            string nomeSistema = string.Empty; // TODO: Initialize to an appropriate value
            clsUtilidades.enviarEmailConfirmacao(emailRemetente, emailDestinatario, senhaDestinatario, hostSmtp, porta, chave, link, nomeSistema);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for messageEmail
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ClsLibBLL.dll")]
        public void messageEmailTest()
        {
            string randomNumber = string.Empty; // TODO: Initialize to an appropriate value
            string link = string.Empty; // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = clsUtilidades_Accessor.messageEmail(randomNumber, link, nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
