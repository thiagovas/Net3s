using System;
using System.Threading;
using ClsLibBLL;

namespace UI
{
    public partial class RecuperarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PreencherLabels();
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            ThreadStart tsRecSenha = new ThreadStart(delegate() {
                ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
                usuBLL.EnviarEmailRecuperarSenha(txtEmailLogin.Text);
            });
            Thread trdRecSenha = new Thread(tsRecSenha);
            trdRecSenha.Start();
            //TODO: Mostrar mensagem falando que mandei um e-mail para ele.
        }

        private void PreencherLabels()
        {
            lblTituloMsg.Text = "Recuperar senha";

            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            
            if(!string.IsNullOrEmpty(ClsUsuLogado.Login) && 
                (usuarioBLL.ExisteUsuarioAtivoPorEmail(ClsUsuLogado.Login) ||
                usuarioBLL.ExisteUsuarioAtivoPorLogin(ClsUsuLogado.Login)))
                txtEmailLogin.Text = ClsUsuLogado.Login;
        }
    }
}