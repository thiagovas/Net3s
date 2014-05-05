using System;
using System.Collections.Generic;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsHistoricoServicoDAL
    {
        /// <summary>
        /// Insere no historico de serviços um serviço finalizado.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <param name="histServ">Objeto do tipo HistoricoServico com os dados a serem inseridos.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Inserir(Oid idUsuario, HistoricoServico histServ)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario usu = usuarioDAL.BuscarUsuarioPorId(idUsuario);
            usu.historicoServicoUsuario.Add(histServ);
            usuarioDAL.EditarUsu(usu);
        }

        /// <summary>
        /// Edita um historico de serviço.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <param name="histServ">Objeto do tipo HistoricoServico com os dados a serem editados.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public void Editar(Oid idUsuario, HistoricoServico histServ)
        {
            ClsUsuDAL usuarioDAL = new ClsUsuDAL();
            Usuario usu = usuarioDAL.BuscarUsuarioPorId(idUsuario);

            Predicate<HistoricoServico> prdRemoverHistServ = new Predicate<HistoricoServico>(delegate(HistoricoServico x)
                {
                    return x.id.Equals(histServ.id);
                });
            usu.historicoServicoUsuario.RemoveAll(prdRemoverHistServ);
            usu.historicoServicoUsuario.Add(histServ);

            usuarioDAL.EditarUsu(usu);
        }

        /// <summary>
        /// Busca todo o conteúdo do array historico de serviços de um usuário.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna uma lista de objetos do tipo HistoricoServico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<HistoricoServico> BuscarHistoricoServicos(Oid idUsuario)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuario_id] = idUsuario;
            Repository rep = new Repository();
            Document resposta = rep.ProcurarUm(doc, NomeCompBd.collecUsuarios);
            if (resposta != null)
            {
                if (resposta[NomeCompBd.usuArrayOrcamento] != null)
                {
                    if (resposta[NomeCompBd.usuArrayOrcamento].GetType() == typeof(List<Document>))
                    {
                        return MontarListaObjeto(((List<Document>)resposta[NomeCompBd.usuArrayOrcamento]));
                    }
                }
            }
            return new List<HistoricoServico>();
        }

        /// <summary>
        /// Monta um objeto do tipo HistoricoServico usando como base o documento recebido.
        /// </summary>
        /// <param name="docHistServ">Documento de Historico de serviço.</param>
        /// <returns>Retorna um objeto do tipo HistoricoServico</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public HistoricoServico MontarObjeto(Document docHistServ)
        {
            HistoricoServico objRetorno = new HistoricoServico();
            objRetorno.avaliacaoContratante = new AvaliacaoContratante();
            objRetorno.avaliacaoPrestador = new AvaliacaoPrestador();
            objRetorno.id = docHistServ[NomeCompBd.usuHistServId] != null ? new Oid(docHistServ[NomeCompBd.usuHistServId].ToString()) : null;
            objRetorno.idOrcamento = docHistServ[NomeCompBd.usuHistServIdOrcam] != null ? new Oid(docHistServ[NomeCompBd.usuHistServIdOrcam].ToString()) : null;

            if (docHistServ[NomeCompBd.usuHistServTipoServico] != null)
                objRetorno.tipoServico = Convert.ToInt32(docHistServ[NomeCompBd.usuHistServTipoServico]);

            if (docHistServ[NomeCompBd.usuHistServAvaliaPreco] != null)
                objRetorno.avaliacaoPrestador.Preco = Convert.ToInt32(docHistServ[NomeCompBd.usuHistServAvaliaPreco]);

            if(docHistServ[NomeCompBd.usuHistServavaliaQualidadeServ] != null)
                objRetorno.avaliacaoPrestador.QualidadeServico = Convert.ToInt32(docHistServ[NomeCompBd.usuHistServavaliaQualidadeServ]);

            if (docHistServ[NomeCompBd.usuHistServAvaliaTempo] != null)
                objRetorno.avaliacaoPrestador.TempoExecucaoServico = Convert.ToInt32(docHistServ[NomeCompBd.usuHistServAvaliaTempo]);
            return objRetorno;
        }

        /// <summary>
        /// Monta uma lista de objetos do tipo HistoricoServico a partir de uma lista de documentos.
        /// </summary>
        /// <param name="lstDocHistServ">Lista de documentos usada como base para montar a lista de objetos do tipo HistoricoServico.</param>
        /// <returns>Retorna uma lista de objetos do tipo HistoricoServico.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<HistoricoServico> MontarListaObjeto(List<Document> lstDocHistServ)
        {
            if (lstDocHistServ == null)
                return null;

            List<HistoricoServico> lstRetorno = new List<HistoricoServico>();
            Action<Document> actMontarObjeto = new Action<Document>(delegate(Document x)
                {
                    lstRetorno.Add(MontarObjeto(x));
                });
            lstDocHistServ.ForEach(actMontarObjeto);
            return lstRetorno;
        }

        /// <summary>
        /// Monta um documento a partir de um objeto do tipo HistoricoServico.
        /// </summary>
        /// <param name="histServ">Objeto do tipo HistoricoServico usado como base para montar o documento.</param>
        /// <returns>Retorna um documento montado usando como base o objeto recebido.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Document MontarDocumento(HistoricoServico histServ)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuHistServId] = histServ.id;
            doc[NomeCompBd.usuHistServIdOrcam] = histServ.idOrcamento;
            doc[NomeCompBd.usuHistServTipoServico] = histServ.tipoServico;
            if (histServ.avaliacaoPrestador != null)
            {
                doc[NomeCompBd.usuHistServAvaliaTempo] = histServ.avaliacaoPrestador.TempoExecucaoServico;
                doc[NomeCompBd.usuHistServavaliaQualidadeServ] = histServ.avaliacaoPrestador.QualidadeServico;
                doc[NomeCompBd.usuHistServAvaliaPreco] = histServ.avaliacaoPrestador.Preco;
            }
            else
            {
                doc[NomeCompBd.usuHistServAvaliaTempo] = null;
                doc[NomeCompBd.usuHistServavaliaQualidadeServ] = null;
                doc[NomeCompBd.usuHistServAvaliaPreco] = null;
            }
            return doc;
        }

        /// <summary>
        /// Monta uma lista de documentos usando como base uma lista de objetos do tipo HistoricoServico.
        /// </summary>
        /// <param name="lstHistServ">Lista de objetos do tipo HistoricoServico.</param>
        /// <returns>Retorna uma lista de documentos.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> MontarListaDocumento(List<HistoricoServico> lstHistServ)
        {
            if (lstHistServ == null)
                return null;

            List<Document> lstRetorno = new List<Document>();
            Action<HistoricoServico> actMontarObjeto = new Action<HistoricoServico>(delegate(HistoricoServico x)
                {
                    lstRetorno.Add(MontarDocumento(x));
                });
            lstHistServ.ForEach(actMontarObjeto);
            return lstRetorno;
        }
    }
}