using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MongoDB;
using Models;
using System.Collections.Generic;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsServicoBLLTest and is intended
    ///to contain all ClsServicoBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsServicoBLLTest
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
        ///A test for ClsServicoBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsServicoBLLConstructorTest()
        {
            ClsServicoBLL target = new ClsServicoBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for BuscarImagemCategoria
        ///</summary>
        [TestMethod()]
        public void BuscarImagemCategoriaTest()
        {
            string categoria = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = ClsServicoBLL.BuscarImagemCategoria(categoria);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarServicoPorDescricao
        ///</summary>
        [TestMethod()]
        public void BuscarServicoPorDescricaoTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            string descricao = string.Empty; // TODO: Initialize to an appropriate value
            bool RetirarServUsuLogado = false; // TODO: Initialize to an appropriate value
            Oid oidUsuarioLogado = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarServicoPorDescricao(descricao, RetirarServUsuLogado, oidUsuarioLogado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarServicoPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarServicoPorNomeTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            bool RetirarServUsuLogado = false; // TODO: Initialize to an appropriate value
            Oid oidUsuarioLogado = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarServicoPorNome(nome, RetirarServUsuLogado, oidUsuarioLogado);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarServicosPorCategoria
        ///</summary>
        [TestMethod()]
        public void BuscarServicosPorCategoriaTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            string categoria = string.Empty; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarServicosPorCategoria(categoria);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodos
        ///</summary>
        [TestMethod()]
        public void BuscarTodosTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarTodos(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarUltimosServicosInseridos
        ///</summary>
        [TestMethod()]
        public void BuscarUltimosServicosInseridosTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            int numServicos = 0; // TODO: Initialize to an appropriate value
            List<Servico> expected = null; // TODO: Initialize to an appropriate value
            List<Servico> actual;
            actual = target.BuscarUltimosServicosInseridos(numServicos);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContarQuantServicos
        ///</summary>
        [TestMethod()]
        public void ContarQuantServicosTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.ContarQuantServicos(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ContarQuantServicosAtivos
        ///</summary>
        [TestMethod()]
        public void ContarQuantServicosAtivosTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.ContarQuantServicosAtivos(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DesativarServico
        ///</summary>
        [TestMethod()]
        public void DesativarServicoTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Oid idServico = null; // TODO: Initialize to an appropriate value
            target.DesativarServico(idServico);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarServico
        ///</summary>
        [TestMethod()]
        public void EditarServicoTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Servico serv = null; // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.EditarServico(serv, idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for EditarServicos
        ///</summary>
        [TestMethod()]
        public void EditarServicosTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            IEnumerable<Servico> ieServicos = null; // TODO: Initialize to an appropriate value
            target.EditarServicos(ieServicos);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirServico
        ///</summary>
        [TestMethod()]
        public void InserirServicoTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Servico serv = null; // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.InserirServico(serv, idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for RetirarServicosRegional
        ///</summary>
        [TestMethod()]
        public void RetirarServicosRegionalTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            List<Servico> lstServ = null; // TODO: Initialize to an appropriate value
            List<Servico> lstServExpected = null; // TODO: Initialize to an appropriate value
            target.RetirarServicosRegional(ref lstServ);
            Assert.AreEqual(lstServExpected, lstServ);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for RetirarServicosUsuLogado
        ///</summary>
        [TestMethod()]
        public void RetirarServicosUsuLogadoTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            List<Servico> lstServ = null; // TODO: Initialize to an appropriate value
            List<Servico> lstServExpected = null; // TODO: Initialize to an appropriate value
            Oid idUsuarioLogado = null; // TODO: Initialize to an appropriate value
            target.RetirarServicosUsuLogado(ref lstServ, idUsuarioLogado);
            Assert.AreEqual(lstServExpected, lstServ);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for buscarServicoPorId
        ///</summary>
        [TestMethod()]
        public void buscarServicoPorIdTest()
        {
            ClsServicoBLL target = new ClsServicoBLL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            Servico expected = null; // TODO: Initialize to an appropriate value
            Servico actual;
            actual = target.buscarServicoPorId(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
