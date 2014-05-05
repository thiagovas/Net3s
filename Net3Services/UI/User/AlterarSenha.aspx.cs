using System;
using Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica;
using ClsLibBLL;
using Models;

namespace UI.User
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [System.Web.Services.WebMethod]
        private void EditarSenha(string senhaAntiga, string novaSenha, string confirmarNovaSenha)
        { 
            //Verificar se a novaSenha e o confirmarNovaSenha usando javascript
            if (novaSenha.Equals(confirmarNovaSenha))
            {
                string senhaCriptografada = new MD5().criptografar(senhaAntiga);
                if (((Usuario)Session["USUARIO"]).senha.Equals(senhaCriptografada))
                {
                    ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                    try
                    {
                        Usuario objUsu = usuarioBLL.BuscarUsuarioPorID(ClsUsuLogado.IdUsuario);
                        objUsu.senha = senhaCriptografada;
                        usuarioBLL.EditarUsuario(objUsu);
                    }
                    catch (Exception ex)
                    { Response.Write(ex.Message); }
                }
                else
                {
                    Response.Write("Senha atual inválida.");
                }
            }
            else
            {
                Response.Write("A nova senha não corresponde ao campo confirmar nova senha.");
            }
        }
    }
}