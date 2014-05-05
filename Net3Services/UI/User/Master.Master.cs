using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using Models;
using MongoDB.Driver;

namespace UI.User
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected string nomeUsu { get; set; }
        protected string idUrl { get; set; }
        protected string idLog { get; set; }
        
        ClsUsuarioBLL usuBll;
        Usuario usu;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request["id"] !=  "" && Request.QueryString["id"] != null)
                        idUrl = Request["id"].ToString();
                    else
                        idUrl = (((Usuario)Session["USUARIO"])._id).ToString();
                    
                    idLog = (((Usuario)Session["USUARIO"])._id).ToString();
                    nomeUsu = ((Usuario)Session["USUARIO"]).login;
                }
                catch { Response.Redirect("../Erros/401.html"); }
            }
        }
    }
}