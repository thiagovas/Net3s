using System;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.Componentes
{
    public partial class Notificacoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetNotificacoes();
        }

        private void GetNotificacoes()
        {
            //Utilizaremos apenas o usuario logado na sessão
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;

            ClsNotificacaoBLL notiBll = new ClsNotificacaoBLL();
            var notiUsuario = notiBll.BuscarTodas(idLogado);
            notiUsuario.Reverse();

            if (notiUsuario != null)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                ClsServicoBLL servBll = new ClsServicoBLL();
                ClsUsuarioBLL usuBll = new ClsUsuarioBLL();
                string nomeFoto = string.Empty;

                foreach (Notificacao noti in notiUsuario)
	            {
                    if (noti.tipo == TipoNotificacao.Orcamento)
                    {
                        var usuRemetente = usuBll.BuscarUsuarioPorID(noti.idRemetente).nome;
                        var servico = servBll.buscarServicoPorId(noti.idServico).nome;
                        var idServico = noti.idServico;
                        nomeFoto = string.Empty;
                        if (usuBll.VerificarImagem(noti.idRemetente.ToString()))
                            nomeFoto = noti.idRemetente.ToString();
                        else
                            nomeFoto = "1";

                        div.InnerHtml += "<p>";
                        div.InnerHtml += string.Format("<a href='AprovarOrcamento.aspx?id={0}&idNoti={1}&idServ={2}'>", noti.idRemetente, noti._id, idServico);
                        div.InnerHtml += string.Format("<img src='../Componentes/BuscaImagens.ashx?id={0}' />{1} solicitou um orçamento para o serviço de {2}.", nomeFoto, usuRemetente, servico);
                        div.InnerHtml += "</a>";
                        div.InnerHtml += "</p>";
                    }
                    else if (noti.tipo == TipoNotificacao.Denuncia)
                    {
                        div.InnerHtml += "<p>";
                        div.InnerHtml += "<b>Você recebeu uma denuncia:</b><br />";
                        div.InnerHtml += noti.descricao;
                        div.InnerHtml += "</p>";
                    }
                    else if (noti.tipo == TipoNotificacao.Network)
                    {
                        var usuRemetente = usuBll.BuscarUsuarioPorID(noti.idRemetente);

                        if (usuBll.VerificarImagem(usuRemetente._id.ToString()))
                            nomeFoto = usuRemetente._id.ToString();
                        else
                            nomeFoto = "1";

                        div.InnerHtml += "<p>";
                        div.InnerHtml += string.Format("<a href='Perfil.aspx?id={0}'>", noti.idRemetente);
                        div.InnerHtml += string.Format("<img src='../Componentes/BuscaImagens.ashx?id={0}' />", nomeFoto);
                        div.InnerHtml += noti.descricao;
                        div.InnerHtml += "</a>";
                        div.InnerHtml += "</p>";
                    }

                    phNotificacao.Controls.Add(div);
	            }
            }
            else
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                
                div.InnerHtml += "<h4>Você não possui novas notificações</h4>";
                phNotificacao.Controls.Add(div);
            }
        }
    }
}