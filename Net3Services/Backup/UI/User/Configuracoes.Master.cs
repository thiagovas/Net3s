using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class Configuracoes : System.Web.UI.MasterPage
    {
        protected string nomeUsu { get; set; }
        protected string idLog { get; set; }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                try
                {
                    idLog = (((Usuario)Session["USUARIO"])._id).ToString();
                    nomeUsu = ((Usuario)Session["USUARIO"]).login;
                }
                catch { Response.Redirect("../Erros/401.aspx"); }
            }
        }
    }
}