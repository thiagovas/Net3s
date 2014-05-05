using System;
using System.Web.Security;

namespace UI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            FormsAuthentication.SignOut();
            ClsLibBLL.ClsUsuLogado.LimparPropriedades();
            Response.Redirect("~/");
        }
    }
}