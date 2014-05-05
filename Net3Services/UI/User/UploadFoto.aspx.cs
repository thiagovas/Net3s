using System;
using System.IO;
using System.Web;
using ClsLibBLL;
using Models;

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