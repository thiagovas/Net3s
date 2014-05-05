using System;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class SocilicarOrcamento : System.Web.UI.Page
    {
        Oid idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetServicos();
        }

        private void GetServicos()
        {
            try
            {
                idUsuario = ((Usuario)(Session["USUARIO"]))._id;
            }
            catch(NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }

            ClsServicoBLL servBll = new ClsServicoBLL();
            ddlServicos.DataSource = servBll.BuscarTodos(idUsuario);
            ddlServicos.DataTextField = "nome";
            ddlServicos.DataValueField = "_id";
            ddlServicos.DataBind();
        }
    }
}