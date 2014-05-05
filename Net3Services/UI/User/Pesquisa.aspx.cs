using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.User
{
    public partial class Pesquisa2 : System.Web.UI.Page
    {
        protected string idUrl { get; set; }
        protected string idLog { get; set; }
        protected string nomeUsu { get; set; }
        private static TipoPesquisa tipo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region === Id's ===
                try
                {
                    if (Request["id"] != "" && Request.QueryString["id"] != null)
                        idUrl = Request["id"].ToString();
                    else
                        idUrl = (((Usuario)Session["USUARIO"])._id).ToString();

                    idLog = (((Usuario)Session["USUARIO"])._id).ToString();
                    nomeUsu = ((Usuario)Session["USUARIO"]).login;
                }
                catch { Response.Redirect("../Erros/401.html"); }
                #endregion
                #region === Configurações Iniciais ===
                lblTitulo.Text = "<i class='icon-briefcase'></i>Serviços";
                tipo = TipoPesquisa.Servico;
                #endregion
                #region === Buscar Informações vindas da URL ===
                string strSearchFilter = string.Empty;

                try
                {
                    strSearchFilter = Request["paran"].ToString();
                    txtFiltro.Text = strSearchFilter;

                    if (!string.IsNullOrEmpty(strSearchFilter))
                    {
                        searchResult.ExecutarPesquisa(tipo, strSearchFilter);
                        GerarFiltros();
                    }
                }
                catch { /* Caso ocorra um erro siguinifica que o usuário pressionou a busca sem informar um parâmetro, então não se deve realizar a busca */}
                #endregion
            }
        }

        private void GerarFiltros()
        {
            blListCategorias.Items.Clear();
            blListClassificacoes.Items.Clear();

            if (tipo == TipoPesquisa.Servico)
            {
                panelFiltrosServico.Visible = true;
                var dadosCategoria = searchResult.GetFiltrosCategoriaServico();
                var dadosClassificacao = searchResult.GetFiltrosClassificacaoServico();

                if (dadosCategoria != null)
                {
                    foreach (var item in dadosCategoria)
                    {
                        blListCategorias.Items.Add(item.ToString());
                    }
                }

                if (dadosClassificacao != null)
                {
                    foreach (var item in dadosClassificacao)
                    {
                        blListClassificacoes.Items.Add(item);
                    }
                }
            }
            else
                panelFiltrosServico.Visible = false;
        }

        /// <summary>
        /// Executa a busca do usuário ao clicar no botão "buscar" na página principal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbPesquisar_Click(object sender, EventArgs e)
        {
            searchResult.ExecutarPesquisa(tipo, txtFiltro.Text.Trim());
            GerarFiltros();
        }

        /// <summary>
        /// Muda as configurações da busca, setando o tipo de busca como usuário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbUsuarios_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            lblTitulo.Text = "<i class='icon-user'></i>Usuários";
            tipo = TipoPesquisa.Usuario;
            searchResult.LimparListaServico();
            GerarFiltros();
        }

        /// <summary>
        /// Muda as configurações da busca, setando o tipo de busca como serviço
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbServicos_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            lblTitulo.Text = "<i class='icon-briefcase'></i>Serviços";
            tipo = TipoPesquisa.Servico;
            searchResult.LimparListaUsuarios();
            GerarFiltros();
        }

        protected void blListClassificacoes_Click(object sender, BulletedListEventArgs e)
        {
            searchResult.FiltrarServicoPorClassificacao(blListClassificacoes.Items[e.Index].Text);
        }

        protected void blListCategorias_Click(object sender, BulletedListEventArgs e)
        {
            searchResult.FiltrarServicoPorCategoria(blListCategorias.Items[e.Index].Text);
        }

        protected void lbRemoverFiltroServ_Click(object sender, EventArgs e)
        {
            searchResult.RemoverFiltrosServico();
        }        
    }
}