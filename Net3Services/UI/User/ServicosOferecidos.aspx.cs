using System;
using System.Web;
using System.Web.UI;

namespace UI.User
{
    public partial class Servicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    // Recebe a mensagem enviada via sessão por outra página, no caso VisualizarServiços
                    string msg = HttpContext.Current.Session["msg"].ToString();

                    if(!string.IsNullOrEmpty(msg))
                    {
                        Response.Write(string.Format("<script type='text/javascript'>alert('{0}')</script>", msg));
                        HttpContext.Current.Session["msg"] = null;
                    }
                }
                catch
                {
                    // Caso caia aqui não foi enviada nenhuma mensagem para esta atela
                }
            }
        }
    }
}