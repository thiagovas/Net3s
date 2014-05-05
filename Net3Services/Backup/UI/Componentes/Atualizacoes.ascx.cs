using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;

namespace NET3Services
{
    public partial class Atualizacoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                MontarPagina(new MongoDB.Oid(Request["id"]));
        }

        /// <summary>
        /// Monta o conteúdo da página de atualizações
        /// </summary>
        /// <param name="idUsuario">Id do usuário do qual se deve montar a página</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void MontarPagina(MongoDB.Oid idUsuario)
        {
            ClsAtualizacaoBLL atualizacaoBLL = new ClsAtualizacaoBLL();
            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            var contAtu = atualizacaoBLL.BuscarAtualizacoes(idUsuario, idUsuario == ((Usuario)Session["USUARIO"])._id);
            
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");
            
            var usu = usuarioBLL.BuscarUsuarioPorID(idUsuario);
            div.InnerHtml += "<h1>Atualizações</h1><br /><br />";

            if(contAtu == null || contAtu.Count == 0)
            {
                div.InnerHtml += string.Format("<div class='atualizacao'>");
                div.InnerHtml += "<article class='conteudo'>";
                div.InnerHtml += "<font class='icone'>&#101;</font>";
                div.InnerHtml += "<font class='nome'>Equipe Net3 Services</font>";
                div.InnerHtml += string.Format("<time pubdate class='data'>{0}</time>", DateTime.Now.ToString("dd/MM/yyyy"));
                div.InnerHtml += "<br /><br /><br />";
                div.InnerHtml += "<font class='mensagem'>Você não possui nenhuma atualização. Comece a interagir com outros usuários do sistema <a href='#'>cadastrado um serviço</a> ou <a href='#'>adicionando seus amigos ao seu networking</a>.</font>";
                div.InnerHtml += "</article>";
                div.InnerHtml += "</div>";
            }
            else
            {
                // Inverte a ordem da lista, para que as atualizações mais novas aparecem primeiro
                contAtu.Reverse();

                foreach (var atu in contAtu)
                {
                    div.InnerHtml += string.Format("<a href='Perfil.aspx?id={0}'><div class='atualizacao'>", atu.OidUsuario);
                    div.InnerHtml += "<article class='conteudo'>";

                    switch (atu.tipoAtualizacao)
                    {
                        case TipoAtualizacao.contato:
                            div.InnerHtml += "<font class='icone'>d</font>";
                            break;

                        case TipoAtualizacao.serviço:
                            div.InnerHtml += "<font class='icone2'>(</font>";
                            break;
                    }

                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", atu.NomeUsuario);
                    div.InnerHtml += string.Format("<time pubdate class='data'>{0}</time>", atu.CreatedTime.ToString("dd/MM/yyyy"));
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'>{0}</p>", atu.Mensagem);
                    div.InnerHtml += "</article>";                   
                    div.InnerHtml += "</div></a>";
                }
            }

            phConteudo.Controls.Add(div);
        }
    }
}