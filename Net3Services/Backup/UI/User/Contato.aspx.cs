using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using MongoDB;
using ClsLibBLL;

namespace UI.User
{
    public partial class Contato : System.Web.UI.Page
    {
        protected string pgEmail;
        Oid idUsu;

        protected void Page_Load(object sender, EventArgs e)
        {
            try { idUsu = new Oid(Request["id"]); }
            catch { Response.Redirect("../Erros/404.aspx"); }

            try
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                var usu = usuarioBLL.BuscarUsuarioPorID(idUsu);
                lblEmail.Text = usu.email;
                pgEmail = usu.email;

                if (idUsu != ((Usuario)Session["USUARIO"])._id)
                    lblTexto.Text = string.Format("Deseja entrar em contato com o usuário '{0}'? Utilize nosso sistema de mensagens, o e-mail abaixo ou através de um dos telefones informados.", usu.nome);
                else
                    lblTexto.Visible = false;
                                
                // Telefones
                if (string.IsNullOrEmpty(usu.telefone1) && string.IsNullOrEmpty(usu.telefone2))
                    lblTelefones.Text = "O usuário não possui números de telefone cadastrados";
                else if (string.IsNullOrEmpty(usu.telefone2))
                    lblTelefones.Text = usu.telefone1;
                else if (string.IsNullOrEmpty(usu.telefone1))
                    lblTelefones.Text = usu.telefone2;
                else
                    lblTelefones.Text = usu.telefone1 + " e " + usu.telefone2;

                // Celulares
                if (string.IsNullOrEmpty(usu.celular1) && string.IsNullOrEmpty(usu.celular2))
                    lblCelulares.Text = "O usuário não possui números de celular cadastrados";
                else if (string.IsNullOrEmpty(usu.celular2))
                    lblCelulares.Text = usu.celular1;
                else if (string.IsNullOrEmpty(usu.celular1))
                    lblCelulares.Text = usu.celular2;
                else
                    lblTelefones.Text = usu.celular1 + " e " + usu.celular2;
            }
            catch { Response.Redirect("../Erros/401.aspx"); }
        }

    }
}