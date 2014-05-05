using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using ClsLibBLL;
using MongoDB;

namespace UI.User
{
    public partial class SocilicarOrcamento : System.Web.UI.Page
    {
        Oid idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetInfoOrcamento();
            GetServicos();
        }

        /// <summary>
        /// Pega as informações necessárias para se criar um orçamento
        /// </summary>
        /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
        public void GetInfoOrcamento()
        {
            //hdfIdLogado.Value = ((Usuario)Session["USUARIO"])._id.ToString();
            //hdfIdUsu.Value = Request.QueryString["id"];
        }

        private void GetServicos()
        {
            ClsServicoBLL servBll = new ClsServicoBLL();
            idUsuario = new Oid(Session["NOTIUSUARIO"].ToString());

            ddlServicos.DataSource = servBll.BuscarTodos(idUsuario);
            ddlServicos.DataTextField = "nome";
            ddlServicos.DataValueField = "_id";
            ddlServicos.DataBind();
        }
    }
}