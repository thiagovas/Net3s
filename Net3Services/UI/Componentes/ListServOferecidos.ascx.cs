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

                    div.InnerHtml += "<div class='atualizacao'><article class='conteudo'>";
                    div.InnerHtml += string.Format("<div class='left'><img src='{0}' class='img' /></div>", caminhoImagem);
                    div.InnerHtml += "<div class='right'>";
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", serv.nome);
                    div.InnerHtml += "<div class='info'>";
                    div.InnerHtml += string.Format("<p class='estrelas'>{0}</p>", serv.getEstrelasNota());
                    div.InnerHtml += string.Format("<p class='price'>{0:C}</p>", serv.preco);
                    div.InnerHtml += "</div>";
                    div.InnerHtml += string.Format("<p class='mensagem'>{0}</p>", descServico);

                    if (idLogado != idUrl)
                        div.InnerHtml += string.Format("<a class='nbutton' href='SocilicarOrcamento.aspx?t=0&id={0}&idServ={1}'><i class='icon-file-alt'></i>Contratar</a>&nbsp;", serv.idUsuario, serv._id);



                    div.InnerHtml += string.Format("<a class='nbutton' href='VisualizarServico.aspx?t=0&id={0}&idServ={1}'><i class='icon-info-sign'></i>Ver Detalhes</a><br />", serv.idUsuario, serv._id);

                    div.InnerHtml += "</div>";
                    div.InnerHtml += "</article></div>";
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