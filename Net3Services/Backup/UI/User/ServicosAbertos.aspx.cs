using System;
using Models;
using ClsLibBLL;
using MongoDB;

namespace UI.User
{
    public partial class ServicosAbertos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]))
                Response.Redirect("ServicosAbertos.aspx?id=" + ((Usuario)Session["USUARIO"])._id.ToString(), true);
        }
    }
}