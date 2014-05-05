using System;
using System.Text.RegularExpressions;
using ClsLibBLL;
using Models;

namespace UI
{
    public partial class ReescreverSenha : System.Web.UI.Page
    {
        string chave = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                chave = Request["x"].ToString();
            }
            catch (NullReferenceException)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenha.Text))
            {
                if (txtSenha.Text.Trim() == txtNovaSenha.Text.Trim())
                {
                    ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
                    Usuario usu = null;
                    string username = usuBLL.RetornarUsernameRecuperacaoSenha(chave);
                    if (Regex.IsMatch(username, ClsConstantesBLL.Ler("regex", "usuarioEmail")))
                    {
                        
                        usu = usuBLL.BuscarUsuarioAtivoPorEmail(username);
                        if (usu == null)
                        {
                            //TODO: Mostrar mensagem de erro.
                            return;
                        }
                        usuBLL.AlterarSenha(usu, txtSenha.Text);
                    }
                    else
                    {
                        usu = usuBLL.BuscarUsuarioAtivoPorLogin(username);
                        if (usu == null)
                        { 
                            //TODO: Mostrar mensagem de erro.
                            return;
                        }
                        usuBLL.AlterarSenha(usu, txtSenha.Text);
                    }
                }
                else
                { 
                    //TODO: Mostrar mensagem de erro. Usar o noty.
                }
            }
            else
            { 
                //TODO: Mostrar mensagem de erro. Usar o noty.
            }
        }
    }
}