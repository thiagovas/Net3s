using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Models;
using ClsLibBLL;

namespace UI.User
{
    public partial class UploadFoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile arquivo = context.Request.Files["fileToUpload"];

            if (arquivo != null)
            {
                string idUsu = string.Empty;
                try { idUsu = ((Usuario)Session["USUARIO"])._id.ToString(); }
                catch { Response.Redirect("../Erros/401.html"); }

                Stream MyStream = arquivo.InputStream;
                ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
                string msg = string.Empty;

                if (usuBLL.VerificarImagem(idUsu))
                {
                    usuBLL.EditarImagem(MyStream, idUsu);
                    msg = "Imagem alterada com sucesso.";
                }
                else
                {
                    usuBLL.AdicionarImagem(MyStream, idUsu);
                    msg = "Imagem adicionada com sucesso.";
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write(msg);
            }
        }
    }
}