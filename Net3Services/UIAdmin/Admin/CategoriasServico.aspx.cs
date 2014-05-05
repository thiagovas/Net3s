using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UIAdmin.Admin
{
    public partial class CategoriasServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsCategoriaServicoBLL categServicoBLL = new ClsCategoriaServicoBLL();
            List<CategoriaServico> lstCategorias = categServicoBLL.BuscarTodasCategorias();
            foreach (var item in lstCategorias)
            {
                ListCateg.Items.Add(new ListItem(item.nomeCategoria, item.idCategoria.ToString()));
            }
        }

        protected void ButExcluir_Click(object sender, EventArgs e)
        {
            ClsCategoriaServicoBLL categServicoBLL = new ClsCategoriaServicoBLL();
            categServicoBLL.Excluir(new Oid(ListCateg.SelectedValue));
        }

        protected void ButCadastrar_Click(object sender, EventArgs e)
        {
            ClsCategoriaServicoBLL categServicoBLL = new ClsCategoriaServicoBLL();
            categServicoBLL.Inserir(txtNome.Text.Trim());
        }
    }
}