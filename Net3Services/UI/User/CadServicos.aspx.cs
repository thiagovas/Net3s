using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class CadServicos : System.Web.UI.Page
    {
        private Color cor;
        
        private static Oid idUser { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try { idUser = ((Usuario)Session["USUARIO"])._id; }
                catch { Response.Redirect("../Erros/401.html"); }

                ClsUsuarioBLL userBLL = new ClsUsuarioBLL();
                if (userBLL.VerificarCompCadastro(((Usuario)Session["USUARIO"])))
                {
                    rbNao.Checked = true;
                    cor = txtPreco.BorderColor;
                    CarregarCategoriasServico();
                    ddlNivelRegionalidade.Enabled = false;
                }
                else
                {
                    panelConteudo.Visible = false;

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.InnerHtml += "<h2>Você não possui permissão para acessar esta páginas.</h2>";
                    div.InnerHtml += "<br /><p>";
                    div.InnerHtml += "Para cadastrar um serviço é necessário que você informe seu CPF/CNPJ em seu cadastro. ";
                    div.InnerHtml += "Para complementar as informações do seu cadastro vá até o painel de configurações ou clique <a href='ConfigInfoPessoais.aspx' id='compCadastro'>aqui</a>.";
                    div.InnerHtml += "</p>";

                    PlaceHolderSemPermisao.Controls.Add(div);
                }
            }
        }

        /// <summary>
        /// Carrega o drop down list ddlCategoria, onde as categorias de serviços ficam.
        /// </summary>
        /// <by>Thiago Vieira - t.vas@Hotmail.com</by>
        protected void CarregarCategoriasServico()
        {
            ClsCategoriaServicoBLL categServicoBLL = new ClsCategoriaServicoBLL();
            List<CategoriaServico> lstCategorias = categServicoBLL.BuscarTodasCategorias();
            foreach (var item in lstCategorias)
            {
                ddlCategoria.Items.Add(new ListItem(item.nomeCategoria, item.idCategoria.ToString()));
            }
        }

        protected void rbSim_CheckedChanged(object sender, EventArgs e)
        {
            rbSim.Checked = true;
            rbNao.Checked = false;
            ddlNivelRegionalidade.Enabled = true;
        }

        protected void rbNao_CheckedChanged(object sender, EventArgs e)
        {
            rbNao.Checked = true;
            rbSim.Checked = false;
            ddlNivelRegionalidade.Enabled = false;
        }

        /// <summary>
        /// Faz com que os campos que possuam informações corretas fiquem com a borda normal, e as que possuam informações erradas fiquem com a 
        /// borda vermelha
        /// </summary>
        /// <param name="campos">Array de strings que contém as informações dos campos que estão errados e dos que estão corretos</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void ValidarCampos(string[] campos)
        {
            if (campos[0] == "Ok")
                clsUtilidades.CampoCorreto(txtNome, cor);
            else
                clsUtilidades.CampoErrado(txtNome, campos[0]);

            if (campos[2] == "Ok")
                clsUtilidades.CampoCorreto(txtPreco, cor);
            else
                clsUtilidades.CampoErrado(txtPreco, campos[2]);

            if (campos[3] == "Ok")
                clsUtilidades.CampoCorreto(txtDescricao, cor);
            else
                clsUtilidades.CampoErrado(txtDescricao, campos[3]);

            bool validade = true;
            foreach (var item in campos)
            {
                if (item != "Ok")
                    validade = false;
            }

            if (validade)
                LimparCamposCadastro();
        }

        private void LimparCamposCadastro()
        {
            txtDescricao.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
        }

        [System.Web.Services.WebMethod]
        public static string CadastrarServico(string nome, string categoria, double preco, string descricao, bool regional, string nivelRegionalidade, string uniMedida)
        {
            try
            {
                Servico serv = new Servico();
                serv.nome = nome;
                serv.categoriaServico = new Oid(categoria);
                serv.preco = preco;
                serv.descricao = descricao;
                serv.regional = regional;
                serv.nivelRegionalidade = regional == true ? nivelRegionalidade : string.Empty;
                serv.unidadeMedida = uniMedida;

                ClsServicoBLL servicoBLL = new ClsServicoBLL();
                var resposta = servicoBLL.InserirServico(serv, idUser);
                string erros = string.Empty;

                foreach (var item in resposta)
                {
                    if(item != null)
                        if (item.ToUpper() != "OK")
                            erros += item + "\n";
                }

                if (!string.IsNullOrEmpty(erros))
                    throw new Exception(erros);
                else
                    return "Serviço cadastrado com sucesso!";
            }
            catch (Exception x)
            {
                return x.Message;
            }
        }
    }
}