using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using MongoDB;
using System.Web.Services;

namespace UI.User
{
    public partial class Pesquisa : System.Web.UI.Page
    {
        private static TipoPesquisa tipo { get; set; }
        
        #region === Eventos ===
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConfiguracoesIniciais();
                AlterarLinks();
                BuscarInfoUrl();
            }
        }

        protected void blListClassificacoes_Click(object sender, BulletedListEventArgs e)
        {
            informacao.FiltrarServicoPorClassificacao(blListClassificacoes.Items[e.Index].Text);
        }

        protected void blListCategorias_Click(object sender, BulletedListEventArgs e)
        {
            informacao.FiltrarServicoPorCategoria(blListCategorias.Items[e.Index].Text);
        }

        protected void blListGenero_Click(object sender, BulletedListEventArgs e)
        {
            informacao.FiltrarUsuarioPorGenero(blListGenero.Items[e.Index].Text);
        }

        protected void lbRemoverFiltroServ_Click(object sender, EventArgs e)
        {
            informacao.RemoverFiltrosServico();
        }

        protected void lbRemoverFiltroUsu_Click(object sender, EventArgs e)
        {
            informacao.RemoverFiltrosServico();
        }

        protected void lbPesquisar_Click(object sender, EventArgs e)
        {
            informacao.ExecutarPesquisa(tipo, lbOpcoesBusca.Text, txtFiltro.Text.Trim());

            if (tipo == TipoPesquisa.Servico)
                GerarFiltrosBuscaServico();
            else
                GerarFiltrosBuscaUsuario();
        }

        protected void lbUsuarios_Click(object sender, EventArgs e)
        {
            if (lbOpcoesBusca.Items.Count > 0)
                lbOpcoesBusca.Items.Clear();

            lbOpcoesBusca.Items.Add("Nome do usuário");
            lbOpcoesBusca.Items.Add("E-mail");
            lbOpcoesBusca.Items.Add("Login");

            imgIcone.ImageUrl = "../Imagens/usuarios.png";
            lblTitulo.Text = "Usuários";
            tipo = TipoPesquisa.Usuario;
            informacao.LimparListaServico();

            LimparFiltroServico();
        }

        protected void lbServicos_Click(object sender, EventArgs e)
        {
            if (lbOpcoesBusca.Items.Count > 0)
                lbOpcoesBusca.Items.Clear();

            lbOpcoesBusca.Items.Add("Nome do Serviço");
            lbOpcoesBusca.Items.Add("Descrição");

            imgIcone.ImageUrl = "../Imagens/servicos.png";
            lblTitulo.Text = "Serviços";
            tipo = TipoPesquisa.Servico;
            informacao.LimparListaUsuarios();

            LimparFiltroUsuario();
        }
        #endregion
        #region === Métodos ===
        private void GerarFiltrosBuscaUsuario()
        {
            LimparFiltroServico();
            LimparFiltroUsuario();

            var dadosGenero = informacao.GetFiltrosGeneroUsuario();
            
            if (dadosGenero != null)
            {
                foreach (var item in dadosGenero)
                {
                    blListGenero.Items.Add(item.ToString());
                }

                LiberarFiltroUsuario();
            }
        }

        private void GerarFiltrosBuscaServico()
        {
            LimparFiltroUsuario();
            LimparFiltroServico();

            var dadosCategoria = informacao.GetFiltrosCategoriaServico();
            var dadosClassificacao = informacao.GetFiltrosClassificacaoServico();

            if (dadosCategoria != null && dadosClassificacao != null)
            {
                foreach (var item in dadosCategoria)
                {
                    blListCategorias.Items.Add(item.ToString());
                }

                foreach (var item in dadosClassificacao)
                {
                    blListClassificacoes.Items.Add(item);
                }

                LiberarFiltroServico();
            }
        }

        private void ConfiguracoesIniciais()
        {
            lbOpcoesBusca.Items.Add("Nome do usuário");
            lbOpcoesBusca.Items.Add("E-mail");
            lbOpcoesBusca.Items.Add("Login");

            imgIcone.ImageUrl = "../Imagens/usuarios.png";
            lblTitulo.Text = "Usuários";
            tipo = TipoPesquisa.Usuario;
        }

        private void LiberarFiltroServico()
        {
            panelFiltrosServico.Visible = true;
        }

        private void LiberarFiltroUsuario()
        {
            panelFiltrosUsuario.Visible = true;
        }

        private void LimparFiltroServico()
        {
            panelFiltrosServico.Visible = false;
            blListClassificacoes.Items.Clear();
            blListCategorias.Items.Clear();
        }

        private void LimparFiltroUsuario()
        {
            panelFiltrosUsuario.Visible = false;
            blListGenero.Items.Clear();
        }

        private void BuscarInfoUrl()
        {
            string filtro = string.Empty;

            try
            {
                filtro = Request["paran"].ToString();
                txtFiltro.Text = filtro;
            }
            catch { /* Caso ocorra um erro siguinifica que o usuário pressionou a busca sem informar um parâmetro, então não se deve realizar a busca */}

            if (!string.IsNullOrEmpty(filtro))
            {
                informacao.ExecutarPesquisa(tipo, lbOpcoesBusca.Text, filtro);
                GerarFiltrosBuscaUsuario();
            }
        }

        private void AlterarLinks()
        {
            try
            {
                Oid idLogado = ((Usuario)Session["USUARIO"])._id;
                hlPerfil.NavigateUrl = string.Format("Perfil.aspx?t=0&id={0}", idLogado);
            }
            catch
            {
                Response.Redirect("");
            }
        }
        #endregion
    }
}