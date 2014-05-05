using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace UIAdmin
{
    public partial class Perfil : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Administrador adm = (Administrador)Session["Administrador"];
                this.LblEmail.Text = adm.login;
            }
        }

        protected void LkSair_Click(object sender, EventArgs e)
        {
            //Remove a sessão
            Session.Remove("Administrador");
            //limpa os cookies
            Response.Cookies.Clear();
            Response.Redirect("~/LoginADM2.aspx");
        }
    }
}