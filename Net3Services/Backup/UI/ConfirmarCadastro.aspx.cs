using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibBLL;
using MongoDB;
using Models;

namespace UI
{
    public partial class ConfirmarCadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                ValidarCadastro();
        }

        private void ValidarCadastro()
        {
            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            string codConf = Request["c"];

            if (!string.IsNullOrEmpty(codConf))
            {
                try
                {
                    Usuario usu = usuarioBLL.ConfirmarCadastro(codConf);
                    lblTituloMsg.Text = string.Format("{0}, seja bem-vindo ao Net 3 Services.", usu.login);
                    lblMsgResposta.Text = "A confirmação de seu cadastro foi realizada com sucesso. Para acessar seu perfil pressione o botão abaixo e realize o login.";
                }
                catch (Exception x)
                {
                    lblTituloMsg.Text = "Ocorreu um erro durante a confirmação de seu cadastro.";
                    lblMsgResposta.Text = x.Message;
                }
            }
            else
            {
                lblTituloMsg.Text = "Código de confirmação não localizado";
                lblMsgResposta.Text = "O código de verificação do seu cadastro não foi localizado. Para informar o código de confirmação de seu cadastro utilize o link enviado para seu e-mail.";
            }
        }
    }
}