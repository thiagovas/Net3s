using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using MongoDB;

namespace ClsLibDAL
{
    public class ClsNotificacaoDAL
    {
        #region === CRUD(VEIA) ===

        /// <summary>
        /// Este método tem a função de inserir uma notificação no usuário que enviou e no que recebeu a notificação.
        /// </summary>
        /// <param name="noti">Objeto do tipo Notificacao usado para inserir os dados no banco de dados.</param>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        public void InserirSolicitacao(Notificacao noti)
        {
            ClsUsuDAL usuDAL = new ClsUsuDAL();

            Usuario usuDestinatario = usuDAL.BuscarUsuarioPorId(noti.idDestinatario);

            usuDestinatario.notificacoesUsuario.Add(noti);
            Repository rep = new Repository();
                rep.Save(usuDAL.MontarDocumento(usuDestinatario), NomeCompBd.collecUsuarios);
            
        }

        /// <summary>
        /// Atualizando a notificação, criando inicialmente com intuito de ajudar em orçamento
        /// </summary>
        /// <param name="notifi">Objeto com info. de Notificacoes</param>
        /// <by>Marcio ALfredo - marcio.alfredo1@gmail.com (09/08/2012)</by>
        public void AtualizarNotifficacao(Notificacao notifi)
        {
            ClsUsuDAL usuDal = new ClsUsuDAL();
            Usuario usu = new Usuario();
                usu = usuDal.BuscarUsuarioPorId(notifi.idDestinatario);
                usu.notificacoesUsuario.Add(notifi);

            Repository rep = new Repository();
                //salvando, por isso a busca
                rep.Save(usuDal.MontarDocumento(usu), NomeCompBd.collecUsuarios);
        }

        #endregion

        #region === Buscas ===

        /// <summary>
        /// Método que busca todas as notifcações de um usuário.
        /// </summary>
        /// <param name="idUsuario">Id do usuário que vai ter as suas notificações retornadas.</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Notificacao> BuscarTodasNotificacoes(Oid idUsuario)
        {
            Document docNoti = new Document();
            List<Notificacao> lstRetorno = new List<Notificacao>();
            List<Document> lstResposta = new List<Document>(); //Esta variável ira guardar o resultado da busca feita no banco de dados.

            docNoti[NomeCompBd.usuario_id] = idUsuario;

            Repository rep = new Repository();
                lstResposta = rep.Procurar(docNoti, NomeCompBd.collecUsuarios);

                //Se tiver algum usuario com este id eu pego as notificações dele, senão retorno null.
                if (lstResposta.Count > 0)
                {
                    docNoti = lstResposta.First();

                    if (docNoti[NomeCompBd.usuArrayNotificacao] != null)
                    {
                        //Se o array de notificações for uma lista de documentos(um array, dã) eu monto a lista de objetos dele.
                        if (docNoti[NomeCompBd.usuArrayNotificacao].GetType() == lstResposta.GetType())
                            lstRetorno = MontarListaObjeto((List<Document>)docNoti[NomeCompBd.usuArrayNotificacao]);

                        Comparison<Notificacao> comp = new Comparison<Notificacao>(CompararDatasNotificacao);
                        
                        if (lstRetorno.Count > 0)
                        {
                            lstRetorno.Sort(comp);
                            return lstRetorno;
                        }
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { return null; }
        }

        private static int CompararDatasNotificacao(Notificacao x, Notificacao y)
        {
            if (x.dataNotificacao == y.dataNotificacao)
                return 0;
            else if (x.dataNotificacao > y.dataNotificacao) return 1;
            else return -1;
        }

        public List<Notificacao> BuscarTodasNotificacoesOrcamentarias(Oid idUsuario)
        {
            Document docNoti = new Document();
            List<Notificacao> lstRetorno = new List<Notificacao>();
            List<Document> lstResposta = new List<Document>(); //Esta variável ira guardar o resultado da busca feita no banco de dados.

            docNoti[NomeCompBd.usuario_id] = idUsuario;

            Repository rep = new Repository();
                lstResposta = rep.Procurar(docNoti, NomeCompBd.collecUsuarios);

                //Se tiver algum usuario com este id eu pego as notificações dele, senão retorno null.
                if (lstResposta.Count > 0)
                {
                    docNoti = lstResposta.First();

                    if (docNoti[NomeCompBd.usuArrayNotificacao] != null)
                    {
                        //Se o array de notificações for uma lista de documentos(um array, dã) eu monto a lista de objetos dele.
                        if (docNoti[NomeCompBd.usuArrayNotificacao].GetType() == lstResposta.GetType())
                            lstRetorno = MontarListaObjetoOrcam((List<Document>)docNoti[NomeCompBd.usuArrayNotificacao]);

                        Comparison<Notificacao> comp = new Comparison<Notificacao>(CompararDatasNotificacao);

                        if (lstRetorno.Count > 0)
                        { 
                            lstRetorno.Sort(comp);
                            return lstRetorno;
                        }
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                { return null; }
            
        }

        /// <summary>
        /// Conta quantas notificações um usuário tem.
        /// </summary>
        /// <param name="idUsuario">Oid do usuário.</param>
        /// <returns>Retorna uma variável do tipo int.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public int ContarNotificacoes(Oid idUsuario)
        {
            Document docUsuario = new Document();
            docUsuario.Add(NomeCompBd.usuario_id, idUsuario);

            Document docResposta = new Document();
            Repository rep = new Repository();
                docResposta = rep.ProcurarUm(docUsuario, NomeCompBd.collecUsuarios); //Busca o usuário que tem o oid informado.

            if (docResposta != null)
            {
                //Guardo a lista de notificações em lstNotificacoes.
                List<Document> lstNotificacoes = (List<Document>)docResposta[NomeCompBd.usuArrayNotificacao];
                return lstNotificacoes != null ? lstNotificacoes.Count : 0; //Retorno o numero de notificações que o usuário tem.
            }
            else
            {
                throw new Exception("Não foi encontrado um usuário com este Oid, por favor, recarregue a página e tente novamente.");
            }
        }

        /// <summary>
        /// Este método busca todas as notificações onde o remetente tem o Oid informado.
        /// </summary>
        /// <param name="idRemetente">Oid do remetente.</param>
        /// <returns>Retorna uma lista com as notificações.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Notificacao BuscarNotifPorIdRemetente(Oid idRemetente)
        {
            Document doc = new Document();
            List<Document> resposta = new List<Document>();
            Notificacao retorno = new Notificacao();

            doc[NomeCompBd.usuNotifIdRemetente] = idRemetente;

            Repository rep = new Repository();
                resposta = rep.Procurar(doc, NomeCompBd.collecUsuarios);

                if (doc[NomeCompBd.usuArrayNotificacao] != null)
                {
                    if (doc[NomeCompBd.usuArrayNotificacao].GetType() == resposta.GetType())
                        retorno = MontarObjeto((Document)doc[NomeCompBd.usuArrayNotificacao]);

                    return retorno;
                }
                else
                    return null;
        }

        /// <summary>
        /// Este método busca uma notificação pelo seu Oid
        /// </summary>
        /// <param name="idNoti">Oid da notificação, usado como filtro da busca.</param>
        /// <returns>Retorna um objeto do tipo Notificação ou null se nao foi encontrado nada no banco de dados.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public List<Document> BuscarNotifPorOid(Oid idNoti)
        {
            /*
             t.find( { x : { $elemMatch : { a : 1, b : { $gt : 1 } } } } )
             * 
            { "_id" : ObjectId("4b5783300334000000000aa9"),
                "x" : [ { "a" : 1, "b" : 3 }, 7, { "b" : 99 }, { "a" : 11 } ]
            }
             */
            Document doc = new Document();
            Document docUsu = new Document();
            Document docNotificacao = new Document();

            docNotificacao.Add(NomeCompBd.usuNotif_id, idNoti);
            doc.Add("$elemMatch", docNotificacao);
            docUsu[NomeCompBd.usuArrayNotificacao] = doc;
            
            List<Document> lstDoc = new List<Document>();
            Repository rep = new Repository();
                lstDoc = rep.Procurar(docUsu, NomeCompBd.collecUsuarios);
            
            if (lstDoc != null)
            {
                if (lstDoc.Count > 0)
                {
                    if (lstDoc[0][NomeCompBd.usuArrayNotificacao] != null)
                    {
                        if (lstDoc[0][NomeCompBd.usuArrayNotificacao].GetType() == typeof(List<Document>))
                        {
                            return (List<Document>)lstDoc[0][NomeCompBd.usuArrayNotificacao];
                        }
                    }
                }
            }
            return null;
        }

        #endregion

        #region === Montar objeto e documento ===
        public List<Notificacao> MontarListaObjeto(List<Document> lstDoc)
        {
            List<Notificacao> lstNoti = new List<Notificacao>();
            foreach (var item in lstDoc)
            {
                lstNoti.Add(MontarObjeto(item));
            }
            return lstNoti;
        }

        public List<Notificacao> MontarListaObjetoOrcam(List<Document> lstDoc)
        {
            List<Notificacao> lstNoti = new List<Notificacao>();
            foreach (var item in lstDoc)
            {
                if ((int)item[NomeCompBd.usuNotifTipo] == 1)
                    lstNoti.Add(MontarObjeto(item));
            }
            return lstNoti;
        }

        public Notificacao MontarObjeto(Document doc)
        {
            Notificacao not = new Notificacao();
            not._id = doc[NomeCompBd.usuNotif_id] != null ? new Oid(doc[NomeCompBd.usuNotif_id].ToString()) : null;
            not.assunto = doc[NomeCompBd.usuNotifAssunto] != null ? doc[NomeCompBd.usuNotifAssunto].ToString() : null;
            not.dataNotificacao = doc[NomeCompBd.usuNotifData] != null ? Convert.ToDateTime(doc[NomeCompBd.usuNotifData]) : DateTime.MinValue;
            not.descricao = doc[NomeCompBd.usuNotifDescricao] != null ? doc[NomeCompBd.usuNotifDescricao].ToString() : null;
            not.idDestinatario = doc[NomeCompBd.usuNotifIdDestinatario] != null ? new Oid(doc[NomeCompBd.usuNotifIdDestinatario].ToString()) : null;
            not.idRemetente = doc[NomeCompBd.usuNotifIdRemetente] != null ? new Oid(doc[NomeCompBd.usuNotifIdRemetente].ToString()) : null;
            not.idServico = doc[NomeCompBd.usuNotifIdServico] != null ? !doc[NomeCompBd.usuNotifIdServico].ToString().Equals(string.Empty) ? new Oid(doc[NomeCompBd.usuNotifIdServico].ToString()) : null : null;

            if (doc[NomeCompBd.usuNotifStatus] != null)
            {
                switch (Convert.ToInt16(doc[NomeCompBd.usuNotifStatus]))
                {
                    case 0:
                        not.status = StatusNotif.Aceito;
                        break;

                    case 1:
                        not.status = StatusNotif.Bloqueado;
                        break;

                    case 2:
                        not.status = StatusNotif.Pendente;
                        break;
                }
            }

            #region === Prioridade ===
            /*  Baixa = 0,
                Media = 1,
                Alta = 2,
                Urgente = 3
             */
            if (doc[NomeCompBd.usuNotifPrioridade] != null)
            {
                Int16 prior = Convert.ToInt16(doc[NomeCompBd.usuNotifPrioridade]);
                switch (prior)
                { 
                    case 0:
                        not.prioridade = Prioridade.Baixa;
                        break;

                    case 1:
                        not.prioridade = Prioridade.Media;
                        break;

                    case 2:
                        not.prioridade = Prioridade.Alta;
                        break;

                    case 3:
                        not.prioridade = Prioridade.Urgente;
                        break;
                }
            }
            #endregion
            if (doc[NomeCompBd.usuNotifQuantContratada] != null)
                if (!doc[NomeCompBd.usuNotifQuantContratada].ToString().Equals(string.Empty))
                    not.qtdContratada = Convert.ToDouble(doc[NomeCompBd.usuNotifQuantContratada]);

            #region === Tipo da notificacao ===
            if (doc[NomeCompBd.usuNotifTipo] != null)
            {
                Int16 tipo = Convert.ToInt16(doc[NomeCompBd.usuNotifTipo]);
                /*Network = 0,
                Orcamento = 1
                 */
                switch (tipo)
                { 
                    case 0:
                        not.tipo = TipoNotificacao.Network;
                        break;

                    case 1:
                        not.tipo = TipoNotificacao.Orcamento;
                        break;
                }
            }
            #endregion
            return not;
        }

        public List<Document> MontarListaDocumento(List<Notificacao> lstNotif)
        {
            List<Document> lstDoc = new List<Document>();
            foreach (var item in lstNotif)
            {
                lstDoc.Add(MontarDocumento(item));
            }
            return lstDoc;
        }

        public Document MontarDocumento(Notificacao notif)
        {
            Document doc = new Document();
            doc = MontarDocumentoSemId(notif);
            doc[NomeCompBd.usuNotif_id] = notif._id;
            return doc;
        }

        public Document MontarDocumentoSemId(Notificacao notif)
        {
            Document doc = new Document();
            doc[NomeCompBd.usuNotifAssunto] = notif.assunto;
            doc[NomeCompBd.usuNotifData] = notif.dataNotificacao;
            doc[NomeCompBd.usuNotifDescricao] = notif.descricao;
            doc[NomeCompBd.usuNotifIdDestinatario] = notif.idDestinatario;
            doc[NomeCompBd.usuNotifIdRemetente] = notif.idRemetente;
            doc[NomeCompBd.usuNotifIdServico] = notif.idServico;
            doc[NomeCompBd.usuNotifStatus] = (int)notif.status;
            doc[NomeCompBd.usuNotifPrioridade] = (int)notif.prioridade;
            doc[NomeCompBd.usuNotifQuantContratada] = notif.qtdContratada;
            doc[NomeCompBd.usuNotifTipo] = (int)notif.tipo;
            return doc;
        }
        #endregion
    }
}
