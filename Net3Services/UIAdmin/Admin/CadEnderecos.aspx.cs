using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Models;
using ClsLibBLL;

namespace UIAdmin.Admin
{
    public partial class CadEnderecos : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile fileUpXml;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbUpload_Click(object sender, EventArgs e)
        {
            if ((fileUpXml.PostedFile != null) && (fileUpXml.PostedFile.ContentLength > 0))
            {
                Stream MyStream = fileUpXml.PostedFile.InputStream;
                
                ClsCatalogoEnderecosBLL catalogoBLL = new ClsCatalogoEnderecosBLL();
                var catalogo = catalogoBLL.lerXmlCatalogoEndereco(MyStream);
                
                catalogoBLL.Inserir(catalogo);
                Response.Write("<script type='text/javascript'>enviarAlerta('Upload realizado com sucesso.');</script>");
            }
            else
            {
                Response.Write("<script type='text/javascript'>enviarAlerta('Selecione um arquivo para realizar o upload.');</script>");
            }
        }
    }
}