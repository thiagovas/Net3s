using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace NET3Services
{
    public partial class Menu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CriarMenu();
        }

        private void CriarMenu()
        {
            HtmlGenericControl nav = new HtmlGenericControl("nav");
            nav.Attributes.Add("class", "menu");
            ClsOrcamentoBLL orcBll = new ClsOrcamentoBLL();

            string id = string.Empty;
            Oid idUrl; // = new Oid(Request["id"]);
            Oid idLogado;
            
            if (Request["id"] != "" && Request.QueryString["id"] != null)
                idUrl = new Oid(Request["id"].ToString());
            else
                idUrl = ((Usuario)Session["USUARIO"])._id;
            
            idLogado = ((Usuario)Session["USUARIO"])._id;
            id = idUrl.ToString();

            // Variável utilizada para verificar se o usuário logado está acessando seu próprio perfil ou o de outro usuário.
            // A partir desta verificação será definida algumas opções do menu principal.
            bool meuPerfil = idUrl == idLogado;
            nav.InnerHtml += "<ul>";
            
            if (meuPerfil == true)
            {
                nav.InnerHtml += string.Format("<li><a href='MeusOrcamentos.aspx?i=1&id={0}'><i class='icon-inbox'></i>Pedidos de Orçamento</a></li>", id);
                nav.InnerHtml += "<li><a href='ServicosAbertos.aspx?id={0}'><i class='icon-tasks'></i>Orçamentos em aberto</a></li>";
                nav.InnerHtml += string.Format("<li><a href='MeusOrcamentos.aspx?i=2&id={0}'><i class='icon-download-alt'></i>Orçamentos Recebidos</a></li>", id);
                nav.InnerHtml += string.Format("<li><a href='MeusOrcamentos.aspx?i=3&id={0}'><i class='icon-upload-alt'></i>Orçamentos Enviados</a></li>", id);
                nav.InnerHtml += "<li><a href='ListarMensagens.aspx'><i class='icon-comments-alt'></i>Mensagens</a></li>";
                nav.InnerHtml += "<li><a href='CadServicos.aspx?id={0}'><i class='icon-plus'></i>Novo Serviço</a></li>";
            }

            nav.InnerHtml += "<li><a href='ServicosOferecidos.aspx?id={0}'><i class='icon-briefcase'></i>Serviços Oferecidos</a></li>";
            nav.InnerHtml += "<li><a href='VisualizarCurriculum.aspx?id={0}'><i class='icon-file-alt'></i>Currículo</a></li>";
            nav.InnerHtml += string.Format("<li><a href='Contato.aspx?id={0}'><i class='icon-phone-sign'></i>Contato</a></li>", id);
            nav.InnerHtml += "</ul>";
            
            nav.InnerHtml = nav.InnerHtml.Replace("{0}", idUrl.ToString());
            phMenu.Controls.Add(nav);
        }
    }
}