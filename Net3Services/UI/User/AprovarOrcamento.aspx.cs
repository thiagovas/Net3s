using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using ClsLibBLL;
using MongoDB;

namespace UI.User
{
    public partial class AprovarOrçamento : System.Web.UI.Page
    {
        private static Oid idService{get;set;}
        private static Oid idRemetente { get; set; }
        private static Oid idNoti { get; set; }
        private static Oid idDestinatario { get; set; }

        protected System.Web.UI.HtmlControls.HtmlAnchor btnSolicitar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                idService = new Oid(Request["idServ"]);
                idRemetente = new Oid(Request["id"]);
                idNoti = new Oid(Request["idNoti"]);
                idDestinatario = ((Usuario)Session["USUARIO"])._id;
             
                CarregaDados();  
            }
        }

        private void CarregaDados()
        {
            ClsNotificacaoBLL notiBll = new ClsNotificacaoBLL();
            ClsServicoBLL servBll = new ClsServicoBLL();
            ClsUsuarioBLL usuBll = new ClsUsuarioBLL();
            var dadosUsuario = usuBll.BuscarUsuarioPorID(idDestinatario);
            var dadosNoti = notiBll.BuscarNotifPorOid(idNoti);

            lblNome.Text = dadosUsuario.nome;
            lblDesc.Text = dadosNoti.descricao;
            lblStatus.Text = dadosNoti.status.ToString();
            lblPrioridade.Text = dadosNoti.prioridade.ToString();
            lblQuantidade.Text = dadosNoti.qtdContratada.ToString();
            lblServico.Text = servBll.buscarServicoPorId(idService).nome;
            
            if (dadosNoti.status != StatusNotif.Pendente)
                btnSolicitar.Visible = false;   
        }

        [System.Web.Services.WebMethod]
        public static string CriarOrcamento(string dataInicio, string dataFim, string preco, string descricao)
        {
            try
            {
                ClsOrcamentoBLL orcbll = new ClsOrcamentoBLL();
                ClsNotificacaoBLL notifiBll = new ClsNotificacaoBLL();
                Orcamento orc = new Orcamento();
                Notificacao notifi = new Notificacao();

                orc.dataInicio = Convert.ToDateTime(dataInicio);
                orc.dataFim = Convert.ToDateTime(dataFim);
                orc.preco = double.Parse(preco.Replace(".", ","));
                orc.descricao = descricao;

                orc.prestador = idDestinatario;
                orc.contratante = idRemetente;
                orc.idServico = idService;

                orcbll.CriarOrcamento(orc);
                //Quando acabar de adicionar o orçamento, atualizar a notificação para ter  um controle sobre o Orçamento.
                #region Atualizando as notificações
                notifi = procuraNotificacaoId(idNoti);
                notifi.status = StatusNotif.Aceito;

                notifiBll.editarNotificacao(notifi);
                #endregion

                return "Orçamento foi criado com sucesso!";
            }
            catch(Exception ex)
            {
                return "Houve um erro ao criar orçamento: " + ex.Message;
            }
        }

        /// <summary>
        /// Procura uma notificação pelo seu id, para que quando responder o orçamento, atualizar para ja lida
        /// </summary>
        /// <param name="idNoti">id da  notificação em questão</param>
        /// <returns>Objeto com informações de notificação</returns>
        /// <by>Marcio Alfredo - marcio.alfredo1@gmail.com (09/08/2012)</by>
        private static Notificacao procuraNotificacaoId(Oid idNoti)
        {
            ClsNotificacaoBLL notifiBll = new ClsNotificacaoBLL();
            return notifiBll.BuscarNotifPorOid(idNoti);
        }
    }
}