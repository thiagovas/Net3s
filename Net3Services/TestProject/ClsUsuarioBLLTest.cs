using ClsLibBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Models;
using System.Collections.Generic;
using MongoDB;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for ClsUsuarioBLLTest and is intended
    ///to contain all ClsUsuarioBLLTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ClsUsuarioBLLTest
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
        ///A test for ClsUsuarioBLL Constructor
        ///</summary>
        [TestMethod()]
        public void ClsUsuarioBLLConstructorTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for AdicionarImagem
        ///</summary>
        [TestMethod()]
        public void AdicionarImagemTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Stream myStream = null; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.AdicionarImagem(myStream, id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BuscarAleatorio
        ///</summary>
        [TestMethod()]
        public void BuscarAleatorioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarAleatorio();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarEmail
        ///</summary>
        [TestMethod()]
        public void BuscarEmailTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuscarEmail(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarEmail
        ///</summary>
        [TestMethod()]
        public void BuscarEmailTest1()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string _id = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.BuscarEmail(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarQtdContatos
        ///</summary>
        [TestMethod()]
        public void BuscarQtdContatosTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            long expected = 0; // TODO: Initialize to an appropriate value
            long actual;
            actual = target.BuscarQtdContatos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarStatus
        ///</summary>
        [TestMethod()]
        public void BuscarStatusTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Oid _id = null; // TODO: Initialize to an appropriate value
            Status expected = new Status(); // TODO: Initialize to an appropriate value
            Status actual;
            actual = target.BuscarStatus(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarStatus
        ///</summary>
        [TestMethod()]
        public void BuscarStatusTest1()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string _id = string.Empty; // TODO: Initialize to an appropriate value
            Status expected = new Status(); // TODO: Initialize to an appropriate value
            Status actual;
            actual = target.BuscarStatus(_id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarTodosContatos
        ///</summary>
        [TestMethod()]
        public void BuscarTodosContatosTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarTodosContatos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarUsuarioPorEmail
        ///</summary>
        [TestMethod()]
        public void BuscarUsuarioPorEmailTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarUsuarioPorEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarUsuarioPorID
        ///</summary>
        [TestMethod()]
        public void BuscarUsuarioPorIDTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            Usuario expected = null; // TODO: Initialize to an appropriate value
            Usuario actual;
            actual = target.BuscarUsuarioPorID(idUsuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarUsuarioPorLogin
        ///</summary>
        [TestMethod()]
        public void BuscarUsuarioPorLoginTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string login = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarUsuarioPorLogin(login);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BuscarUsuarioPorNome
        ///</summary>
        [TestMethod()]
        public void BuscarUsuarioPorNomeTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string nome = string.Empty; // TODO: Initialize to an appropriate value
            List<Usuario> expected = null; // TODO: Initialize to an appropriate value
            List<Usuario> actual;
            actual = target.BuscarUsuarioPorNome(nome);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConfirmarCadastro
        ///</summary>
        [TestMethod()]
        public void ConfirmarCadastroTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string codVerificacao = string.Empty; // TODO: Initialize to an appropriate value
            Usuario expected = null; // TODO: Initialize to an appropriate value
            Usuario actual;
            actual = target.ConfirmarCadastro(codVerificacao);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DesativarUsuario
        ///</summary>
        [TestMethod()]
        public void DesativarUsuarioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Oid idUsuario = null; // TODO: Initialize to an appropriate value
            target.DesativarUsuario(idUsuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarImagem
        ///</summary>
        [TestMethod()]
        public void EditarImagemTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Stream myStream = null; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.EditarImagem(myStream, id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarLoginUsuario
        ///</summary>
        [TestMethod()]
        public void EditarLoginUsuarioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.EditarLoginUsuario(usuario, id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarPessoaEndereco
        ///</summary>
        [TestMethod()]
        public void EditarPessoaEnderecoTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.EditarPessoaEndereco(usuario, id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EditarPessoalUsuario
        ///</summary>
        [TestMethod()]
        public void EditarPessoalUsuarioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.EditarPessoalUsuario(usuario, id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnviarEmailConfirmacao
        ///</summary>
        [TestMethod()]
        public void EnviarEmailConfirmacaoTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario mUsu = null; // TODO: Initialize to an appropriate value
            string senha = string.Empty; // TODO: Initialize to an appropriate value
            target.EnviarEmailConfirmacao(mUsu, senha);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for EnviarEmailRecuperarSenha
        ///</summary>
        [TestMethod()]
        public void EnviarEmailRecuperarSenhaTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string userName = string.Empty; // TODO: Initialize to an appropriate value
            target.EnviarEmailRecuperarSenha(userName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ExcluirImagem
        ///</summary>
        [TestMethod()]
        public void ExcluirImagemTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string id = string.Empty; // TODO: Initialize to an appropriate value
            target.ExcluirImagem(id);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InserirUsuario
        ///</summary>
        [TestMethod()]
        public void InserirUsuarioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            target.InserirUsuario(usuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Logar
        ///</summary>
        [TestMethod()]
        public void LogarTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            Usuario usuExpected = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Logar(ref usu);
            Assert.AreEqual(usuExpected, usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidarChaveRecuperacaoSenha
        ///</summary>
        [TestMethod()]
        public void ValidarChaveRecuperacaoSenhaTest()
        {
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidarConfiguracoesGerais
        ///</summary>
        [TestMethod()]
        public void ValidarConfiguracoesGeraisTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.ValidarConfiguracoesGerais(usuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidarConfiguracoesInfoPessoais
        ///</summary>
        [TestMethod()]
        public void ValidarConfiguracoesInfoPessoaisTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.ValidarConfiguracoesInfoPessoais(usuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerificarCompCadastro
        ///</summary>
        [TestMethod()]
        public void VerificarCompCadastroTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usu = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VerificarCompCadastro(usu);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VerificarImagem
        ///</summary>
        [TestMethod()]
        public void VerificarImagemTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.VerificarImagem(name);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for VlidarConfigEnrereco
        ///</summary>
        [TestMethod()]
        public void VlidarConfigEnrerecoTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            string[] expected = null; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.ValidarConfigEnrereco(usuario);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for editarUsuario
        ///</summary>
        [TestMethod()]
        public void editarUsuarioTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            target.EditarUsuario(usuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for validaCadastroLogin
        ///</summary>
        [TestMethod()]
        public void validaCadastroLoginTest()
        {
            ClsUsuarioBLL target = new ClsUsuarioBLL(); // TODO: Initialize to an appropriate value
            Usuario usuario = null; // TODO: Initialize to an appropriate value
            target.validaCadastroLogin(usuario);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
