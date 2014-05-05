using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.Componentes
{
    public partial class Acoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                GerarAcoes();
        }

        private void GerarAcoes()
        {
            Oid idUrl = new Oid(Request["id"]);
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;
            bool meuPerfil = idUrl == idLogado;            
 
            if (!meuPerfil)
            {
                HtmlGenericControl nav = new HtmlGenericControl("nav");
                ClsContatoBLL contatoBLL = new ClsContatoBLL();
                ClsServicoBLL servBll = new ClsServicoBLL();
                nav.Attributes.Add("class", "menu");
                
                nav.InnerHtml+= "<header class='titulo'><h3>Ações</h3></header><ul>";
                
                if (servBll.ContarQuantServicosAtivos(idUrl) > 0)
                {
                    nav.InnerHtml += string.Format("<li><a href='SocilicarOrcamento.aspx?id={0}' id='soliOrcamento'><i class='icon-money'></i>Solicitar Orçamento</a></li>", idUrl);
                }

                nav.InnerHtml += "<li><a href='#'><i class='icon-warning-sign'></i>Reportar Abuso</a></li>";
                
                if (contatoBLL.VerificarExistenciaContato(idUrl, idLogado))
                {
                    nav.InnerHtml += "<li><a href='#' id='removCont'><i class='icon-remove-sign'></i>Remover Contato</a></li>";
                }

                nav.InnerHtml += "</ul>";

                nav.InnerHtml = nav.InnerHtml.Replace("{0}", idUrl.ToString());
                phMenu.Controls.Add(nav);
            }
        }
    }
}