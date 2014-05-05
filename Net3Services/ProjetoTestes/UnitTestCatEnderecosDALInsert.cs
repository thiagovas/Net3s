using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClsLibDAL;

namespace ProjetoTestes
{
    [TestClass]
    public class UnitTestCatEnderecosDALInsert
    {
        [TestMethod]
        public void TesteVerificarExistenciaContatoDAL()
        {
            ClsContatoDAL contatoDAL = new ClsContatoDAL();
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            bool resultado = contatoDAL.VerificarExistenciaContato(usuarioDAL.buscarTodos().First()._id, usuarioDAL.buscarTodos().Last()._id);
        }

        [TestMethod]
        public void TesteCatEnderecoDALInsert()
        {
            ClsCatalogoEnderecosDAL catEndDAL = new ClsCatalogoEnderecosDAL();
            catEndDAL.InserirPais("Brasil");
        }
    }
}
