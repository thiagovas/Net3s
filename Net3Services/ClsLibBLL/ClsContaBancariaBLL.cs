using System;
using System.Collections.Generic;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsContaBancariaBLL
    {
        /// <summary>
        /// Método que insere uma conta bancária em um usuário.
        /// </summary>
        /// <param name="objInf">Objeto do tipo InformacoesBancarias.</param>
        /// <param name="idUsuario">Oid do usuário que vai ter uma conta adicionada.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void InserirConta(InformacoesBancarias objInf, Oid idUsuario)
        {
            //TODO: Procurar como valida os dados do objeto InformacoesBancarias
            ClsContaBancariaDAL contaBancDAL = new ClsContaBancariaDAL();
            contaBancDAL.InserirConta(objInf, idUsuario);
        }

        /// <summary>
        /// Método para editar uma conta bancária.
        /// </summary>
        /// <param name="objInf">Objeto do tipo InformacoesBancarias.</param>
        /// <param name="idUsuario">Oid do usuario que vai ter a conta editada.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void EditarConta(InformacoesBancarias objInf, Oid idUsuario)
        {
            //TODO: Procurar como valida os dados do objeto InformacoesBancarias
            ClsContaBancariaDAL contaBancDAL = new ClsContaBancariaDAL();
            contaBancDAL.EditarConta(objInf, idUsuario);
        }

        /// <summary>
        /// Exclui uma conta bancária do banco.
        /// </summary>
        /// <param name="idUsu">Oid do usuário que vai ter a conta bancária excluída.</param>
        /// <param name="idContaBancaria">Id da conta bancária.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void ExcluirConta(Oid idContaBancaria, Oid idUsu)
        {
            ClsContaBancariaDAL contaBanc = new ClsContaBancariaDAL();
            contaBanc.ExcluirConta(idContaBancaria, idUsu);
        }

        /// <summary>
        /// Busca a lista de contas bancárias de um usuário.
        /// </summary>
        /// <param name="idUsuario">Id do usuário, usado como filtro de busca.</param>
        /// <returns>Retorna uma lista de objetos do tipo ContaBancaria.</returns>
        public List<InformacoesBancarias> BuscarContasPorIdUsuario(Oid idUsuario)
        {
            throw new NotImplementedException("Não implementei este método ainda.");
        }

        /// <summary>
        /// Busca uma conta bancária pelo seu id.
        /// </summary>
        /// <param name="idContaBancaria">Id da conta bancária, usado como filtro para a busca.</param>
        /// <returns>Retorna um objeto do tipo ContaBancaria.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public InformacoesBancarias BuscarContaPorId(Oid idContaBancaria)
        {
            throw new NotImplementedException("Não implementei este método ainda.");
        }
    }
}
