using System.Collections.Generic;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsHistoricoServicoBLL
    {
        /// <summary>
        /// Insere no historico de serviços um serviço finalizado.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <param name="histServ">Objeto do tipo HistoricoServico com os dados a serem inseridos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(Oid idUsuario, HistoricoServico histServ)
        {
            ClsHistoricoServicoDAL historicoServicoDAL = new ClsHistoricoServicoDAL();
            historicoServicoDAL.Inserir(idUsuario, histServ);
        }

        /// <summary>
        /// Edita um historico de serviço.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <param name="histServ">Objeto do tipo HistoricoServico com os dados a serem editados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Editar(Oid idUsuario, HistoricoServico histServ)
        {
            ClsHistoricoServicoDAL historicoServicoDAL = new ClsHistoricoServicoDAL();
            historicoServicoDAL.Editar(idUsuario, histServ);
        }

        /// <summary>
        /// Busca todo o conteúdo do array historico de serviços de um usuário.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna uma lista de objetos do tipo HistoricoServico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<HistoricoServico> BuscarHistoricoServicos(Oid idUsuario)
        {
            ClsHistoricoServicoDAL historicoServicoDAL = new ClsHistoricoServicoDAL();
            return historicoServicoDAL.BuscarHistoricoServicos(idUsuario);
        }
    }
}
