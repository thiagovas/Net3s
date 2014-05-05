using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.Componentes
{
    public partial class ListServOferecidos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MontarPagina();
        }

        /// <summary>
        /// Monta o conteúdo da página Listar Serviços
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void MontarPagina()
        {
            // ID do usuário cuja tela esta sendo visitada neste momento.
            Oid idUrl = new Oid(Request["id"]);
            // ID do usuário logado no momento.
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;

            ClsServicoBLL sericosBLL = new ClsServicoBLL();
            var servsUsuario = sericosBLL.BuscarTodos(idUrl);

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");
            div.InnerHtml += "<h1>Serviços Oferecidos</h1><br /><br />";

            if (servsUsuario.Count() > 0)
            {
                string caminhoImagem = string.Empty;
                string descServico = string.Empty;

                // Monta a página quando o usuário possui serviços
                foreach (var serv in servsUsuario)
                {
                    caminhoImagem = ClsServicoBLL.BuscarImagemCategoria(serv.nomeCategoriaServico);
                    descServico = serv.descricao.Length <= 140 ? serv.descricao : serv.descricao.Substring(0, 140) + "...";

                    div.InnerHtml += string.Format("<a href='VisualizarServico.aspx?id={0}&idServ={1}'><div class='atualizacao'>", idUrl, serv._id);
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += string.Format("<img src='{0}' class='img' />", caminhoImagem);
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", serv.nome);
                    div.InnerHtml += string.Format("<p class='estrelas'>{0}</p>", serv.getStrelasNota());
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'><b>Categoria: </b>{0}<br /><b>Descrição: </b>{1}</p>", serv.nomeCategoriaServico, descServico);
                    div.InnerHtml += "</article>";
                    div.InnerHtml += "</div></a>";
                }
            }
            else
            {
                if (idUrl != idLogado)
                {
                    div.InnerHtml += "<h4>O usuário não possui serviços cadastrados.</h4>";
                }
                else
                {
                    div.InnerHtml += "<h4>Você não possui serviços cadastrados. Para cadastrar um novo serviço clique no botão abaixo.</h4>";
                    div.InnerHtml += "<br /><br />";
                    div.InnerHtml += string.Format("<a class='button add' href='CadServicos.aspx?t=0&id={0}'>Novo Serviço</a>", idUrl.ToString());
                }
            }

            phMenu.Controls.Add(div);
        }

    }
}