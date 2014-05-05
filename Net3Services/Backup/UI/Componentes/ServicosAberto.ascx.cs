using System;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using Models;

namespace UI.Componentes
{
    public partial class ServicosAberto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetInfo();
            }
        }

        void GetInfo()
        {
            Usuario usu = (Usuario)Session["USUARIO"];
            Orcamento orc = new Orcamento();
            ClsOrcamentoBLL orcBll = new ClsOrcamentoBLL();
            
            //orc.finalizado = false;
            orc.prestador = usu._id;
            var orcamentos = orcBll.BuscarOrcamentoPorUsuario(usu._id, orc);
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuAtualizacoes");
            div.InnerHtml += "<h1>Serviços em Aberto</h1><br />";

            if (orcamentos.Count > 0)
            {
                string caminhoImg = string.Empty;
                string nomeserv = string.Empty;
                string descOrc = string.Empty;
                string contratante = string.Empty;
                ClsUsuarioBLL usuBll = new ClsUsuarioBLL();
                ClsServicoBLL servBll = new ClsServicoBLL();

                orcamentos.ForEach(delegate(Orcamento o)
                {
                    contratante = usuBll.BuscarUsuarioPorID(o.contratate).nome;
                    caminhoImg = ClsServicoBLL.BuscarImagemCategoria(servBll.buscarServicoPorId(o.idServico).nomeCategoriaServico);
                    nomeserv = servBll.buscarServicoPorId(o.idServico).nome;
                    descOrc = o.descricao.Length <= 140 ? o.descricao : o.descricao.Substring(0, 140) + "...";

                    //Gerar HTML
                    div.InnerHtml += string.Format("<a href='VisualizarOrcamento.aspx?id={0}'><div class='atualizacao'>", o.id);
                    div.InnerHtml += "<article class='conteudo'>";
                    div.InnerHtml += string.Format("<img src='{0}' class='img' />", caminhoImg);
                    div.InnerHtml += string.Format("<font class='nome'>{0}</font>", nomeserv);
                    div.InnerHtml += string.Format("<time pubdate class='data'>{0} - {1}</time>", o.dataInicio.ToString("dd/MM/yyyy"), o.dataFim.ToString("dd/MM/yyyy"));
                    div.InnerHtml += "<br /><br /><br />";
                    div.InnerHtml += string.Format("<p class='mensagem'>{0}</p>", descOrc);
                    div.InnerHtml += "</article>";
                    div.InnerHtml += "</div></a>";
                });
            }
            else
            {
                div.InnerHtml += "<h4>Você não possui nenhum serviço em aberto!</h4>";
            }

            VServicosAberto.Controls.Add(div);
        }
    }
}