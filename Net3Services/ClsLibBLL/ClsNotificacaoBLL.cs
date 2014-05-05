using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using Chrisimos.Net;
using ClsLibDAL;
using Models;
using MongoDB;

namespace ClsLibBLL
{
    public class ClsNotificacaoBLL
    {
        public string[] InserirNotificacao(Notificacao objNotif)
        {
            string[] resposta = new string[4];
            bool validade = true;

            #region === Assunto ===
            if (Regex.IsMatch(objNotif.assunto, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ /. , -]{2,40}$"))
            {
                resposta[0] = "Ok";
            }
            else
            {
                resposta[0] = "Assunto da notificação inválido. O assunto deve conter entre 2 e 40 caracteres alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Descricao ===
            if (Regex.IsMatch(objNotif.descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ /.!?' , -]{2,200}$"))
            {
                resposta[1] = "Ok";
            }
            else
            {
                resposta[1] = "Descrição da notificação inválida. A descrição deve conter entre 2 e 80 caracteres alfanuméricos.";
                validade = false;
            }
            #endregion
            #region === Destinatario ===
            if (clsUtilidades.ValidarOid(objNotif.idDestinatario))
            {
                resposta[2] = "Ok";
            }
            else
            {
                resposta[2] = "Por favor, informe o usuário que irá receber a notificação.";
                validade = false;
            }
            #endregion
            #region === Remetente ===
            if (clsUtilidades.ValidarOid(objNotif.idRemetente))
            {
                resposta[3] = "Ok";
            }
            else
            {
                resposta[3] = "Por favor, informe o usuário que irá enviar a notificação.";
                validade = false;
            }
            #endregion

            if (validade)
            {
                ClsNotificacaoDAL notifDAL = new ClsNotificacaoDAL();
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                
                objNotif.status = StatusNotif.Pendente;
                objNotif.dataNotificacao = DateTime.Now.Date;
                OidGen idNotif = new OidGen(); //Irá gerar o Oid da notificação.
                objNotif._id = new Oid(idNotif.Generate().ToString()); // Gera o Oid da notificacao e guarda o Oid gerado na propriedade _id.
                try
                {
                    notifDAL.InserirSolicitacao(objNotif);
                    Email e = new Email();

                    //TODO: Alterar a mensagem que mandaremos para o usuário.
                    e.enviarEmail(ConfigurationManager.AppSettings["EMAILNET3S"], ConfigurationManager.AppSettings["SENHAEMAILNET3S"], "smtp.gmail.com", 587, usuarioBLL.BuscarEmail(objNotif.idDestinatario), "Você recebeu um pedido de orçamento",
                        "Mensagem teste", true, true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return resposta;
        }

        /// <summary>
        /// Atualiza a notificação, a principio ira ser usado em orçamento
        /// </summary>
        /// <param name="notifi">Objeto com informações de notificacoes</param>
        /// <by>Marcio Alfredo - marcio.alfredo1@gamil.com (09/08/2012)</by>
        public void editarNotificacao(Notificacao notifi)
        {
            ClsNotificacaoDAL notifiDal;

            if (Regex.IsMatch(notifi.assunto, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ /. , -]{2,40}$"))
                if (Regex.IsMatch(notifi.descricao, @"^[a-zA-Z0-9 :Wh áàãâäÁÀÃÂÄéèëêÉÈËÊíìîïÍÌÎÏôõòóöÔÕÒÓÖüúùûÜÚÙÜçÇ /.!?' , -]{2,200}$"))
                    if (clsUtilidades.ValidarOid(notifi.idDestinatario))
                        if (clsUtilidades.ValidarOid(notifi.idRemetente))
                        {
                            notifiDal = new ClsNotificacaoDAL();
                            //atualizar
                            notifiDal.AtualizarNotifficacao(notifi);
                        }
                        else throw new Exception("Error, tente novamente mais tarde");
                    else throw new Exception("Error, tente novamente mais tarde");
                else throw new Exception("Error, tente novamente mais tarde");
            else throw new Exception("Error, tente novamente mais tarde");
        }

        #region === Buscas ===

        public List<Notificacao> BuscarTodas(Oid idUsuario)
        {
            if (clsUtilidades.ValidarOid(idUsuario))
            {
                ClsNotificacaoDAL notifDAL = new ClsNotificacaoDAL();
                return notifDAL.BuscarTodasNotificacoes(idUsuario);
            }
            else
            { throw new Exception("Ocorreu um erro ao buscar as notificações, por favor, recarregue a página."); }
        }

        /// <summary>
        /// Este método busca uma notificação a partir de seu Oid.
        /// </summary>
        /// <param name="idNoti">Oid da notificacao que deseja buscar do banco de dados.</param>
        /// <returns>Retorna um objeto do tipo Notificacao com os dados da notificação que tem o Oid informado.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public Notificacao BuscarNotifPorOid(Oid idNoti)
        {
            if (clsUtilidades.ValidarOid(idNoti))
            {
                ClsNotificacaoDAL notificacaoDAL = new ClsNotificacaoDAL();
                List<Document> lstNotificacoes = notificacaoDAL.BuscarNotifPorOid(idNoti);
                Predicate<Document> prdProcurarNotificacao = new Predicate<Document>(delegate(Document doc)
                    {
                        return (Oid)doc[NomeCompBd.usuNotif_id] == idNoti;
                    });
                Document notif = lstNotificacoes.Find(prdProcurarNotificacao);
                return notificacaoDAL.MontarObjeto(notif);
            }
            else
            {
                throw new Exception("Remetente inválido.");
            }
        }

        public List<Notificacao> BuscaTodasOrcamentarias(Oid idUsu)
        {
            if (clsUtilidades.ValidarOid(idUsu))
            {
                ClsNotificacaoDAL notifDAL = new ClsNotificacaoDAL();
                return notifDAL.BuscarTodasNotificacoesOrcamentarias(idUsu);
            }
            else
            { throw new Exception("Ocorreu um erro ao buscar as notificações, por favor, recarregue a página."); }
        }

        /// <summary>
        /// Conta quantas notificações tem um usuário.
        /// </summary>
        /// <param name="oidUsuario">Oid do usuário que deseja contar as suas notificações.</param>
        /// <returns>Retorna uma variavel do tipo int.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public int ContarNotificacoes(MongoDB.Oid oidUsuario)
        {
            if (clsUtilidades.ValidarOid(oidUsuario))
            {
                ClsNotificacaoDAL notificacaoDAL = new ClsNotificacaoDAL();
                return notificacaoDAL.ContarNotificacoes(oidUsuario);
            }
            else
            {
                throw new OidException();
            }
        }

        #endregion
    }
}
