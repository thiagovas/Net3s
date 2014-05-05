using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class EditarServico : System.Web.UI.Page
    {
        protected string nomeServico { get; set; }
        protected string precoServico { get; set; }
        protected string tempoServico { get; set; }
        protected string descricao { get; set; }
        protected Oid idUsuario { get; set; }
        protected Oid idServ { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarCategoriasServico();
                GetInfoServico((Oid)Session["IDServicoEdicao"]);
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

        /// <summary>
        /// Busca as informações do serviço e as mostra na tela
        /// </summary>
        /// <param name="id">ID do serviço em que se deve buscar as informações</param>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        private void GetInfoServico(Oid id)
        {
            ClsServicoBLL servicoBLL = new ClsServicoBLL();
            var serv = servicoBLL.buscarServicoPorId(id);

            this.idServ = serv._id;
            this.idUsuario = serv.idUsuario;
            this.nomeServico = serv.nome;
            this.descricao = serv.descricao.Trim();
            ddlUnidadeMed.Text = serv.unidadeMedida;
            ddlCategoria.SelectedValue = serv.categoriaServico.ToString();
            //ddlCategoria.Text = serv.nomeCategoriaServico;
            this.precoServico = serv.preco.ToString("0.00").Replace(',', '.');

            if (serv.regional)
            {
                rbSim.Checked = true;
                ddlNivelRegionalidade.Enabled = true;
                ddlNivelRegionalidade.Text = serv.nivelRegionalidade;
            }
            else
            {
                rbNao.Checked = true;
                ddlNivelRegionalidade.Enabled = false;
            }
        }

        protected void linkBtnSalvar_Click(object sender, EventArgs e)
        {
            ClsServicoBLL servicoBLL = new ClsServicoBLL();
            Servico objServ = new Servico() 
            {
                _id = idServ,
                nomeCategoriaServico = ddlCategoria.Text,
                categoriaServico = new Oid(ddlCategoria.SelectedValue),
                descricao = descricao,
                idUsuario = idUsuario,
                nivelRegionalidade = ddlNivelRegionalidade.Text,
                nome = nomeServico,
                preco = double.Parse(precoServico),
                regional = rbSim.Checked,
                unidadeMedida = ddlUnidadeMed.Text
            };

            try
            {
                servicoBLL.EditarServico(objServ, idUsuario);
            }
            catch
            {}
        }
    }
}