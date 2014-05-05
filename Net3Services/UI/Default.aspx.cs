using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Chrisimos.Seguranca.Criptografia.CriptografiaAssimetrica;
using ClsLibBLL;
using Models;

namespace UI
{
    public partial class NewDefault : System.Web.UI.Page
    {
        ClsUsuarioBLL objUsu = new ClsUsuarioBLL();
        MD5 hash;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session.Keys.Count > 0)
                    if (Session["USUARIO"] != null)
                        Response.Redirect(string.Format("~/User/Atualizacoes.aspx?id={0}", ClsUsuLogado.IdUsuario));

                // Pega informações dos cookies, caso elas existam, e preenche os campos de login e senha.
                if (Request.Cookies["Net3User"] != null && Request.Cookies["Net3UserPwd"] != null)
                {
                    chkLembrar.Checked = true;
                    txtLogin.Text = Request.Cookies["Net3User"].Value;

                    txtSenha.Attributes.Add("value", Request.Cookies["Net3UserPwd"].Value);
                }
            }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Usuario mUsu = new Usuario();
            hash = new MD5();
            mUsu.login = txtLogin.Text.Trim();
            mUsu.email = txtLogin.Text.Trim();
            mUsu.senha = hash.criptografar(txtSenha.Text.Trim());

            try
            {
                if (objUsu.Logar(ref mUsu))
                {
                    Status status = new Status();
                    
                    switch (status)
                    {
                        case Status.Ativado:
                            #region === Preenche as propriedades de ClsUsuLogado ===
                            ClsUsuLogado.IdUsuario = mUsu._id;
                            ClsUsuLogado.Login = mUsu.login;
                            ClsUsuLogado.CpfCnpj = mUsu.cpf_cnpj;
                            ClsUsuLogado.Rg = mUsu.rg;
                            ClsUsuLogado.Pais = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].pais : null;
                            ClsUsuLogado.Uf = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].uf : null;
                            ClsUsuLogado.Cidade = mUsu.enderecosUsuario.Count > 0 ? mUsu.enderecosUsuario[0].cidade : null;
                            #endregion

                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, mUsu.login, DateTime.Now, DateTime.Now.AddMinutes(20), chkLembrar.Checked, Session.SessionID, FormsAuthentication.FormsCookiePath);
                            string encryptTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);

                            Response.Cookies.Add(authCookie);
                            Session.Add("USUARIO", mUsu);
                            FormsAuthentication.RedirectFromLoginPage(mUsu.login, chkLembrar.Checked);

                            if (Response.Cookies["Net3User"].Value != txtLogin.Text.Trim())
                            {
                                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(-1);
                                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(-1);
                            }

                            Response.Redirect(string.Format("/User/Atualizacoes.aspx?id={0}", mUsu._id.ToString()));
                            break;

                        case Status.Banido:
                            throw new Exception("Sua conta foi excluída por infração dos termos de uso. Entre em contato com o Administrador.");
                        
                        case Status.Desativado:
                            throw new Exception("Sua conta foi suspensa ou ainda não está ativada, entre em contato com o administrador.");
                    }
                }
                else
                {
                    throw new Exception("Usuário não encontrado.");
                }
            }
            catch (Exception ex)
            {
                //string script = string.Format("var noty_id = noty({text: ' {0} ',theme: 'top'});", ex.Message);

                string script = "var n = noty({ text: '" + ex.Message + "', layout: 'top', type: 'error' });";
                ClientScript.RegisterStartupScript(GetType(), "Login Error", script, true);
            }
        }

        protected void chkLembrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLembrar.Checked)
            {
                Response.Cookies["Net3User"].Value = txtLogin.Text.Trim();
                Response.Cookies["Net3UserPwd"].Value = txtSenha.Text.Trim();
                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["Net3User"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["Net3UserPwd"].Expires = DateTime.Now.AddMonths(-1);
            }
        }

        protected void lbCadastrar_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.nome = txtNomeUsu.Text.Trim();
            usu.login = txtLoginUsu.Text.Trim();
            usu.email = txtEmailUsu.Text.Trim();
            usu.GerarCodigoVerificacao(); 
            usu.GerarSenha(8);
            
            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            string type = string.Empty;
            string resp = string.Empty;
            string senha = usu.senha;
            
            try
            {
                usuarioBLL.validaCadastroLogin(usu);
                usuarioBLL.InserirUsuario(usu);
                usuarioBLL.EnviarEmailConfirmacao(usu, senha);
            }
            catch(Exception x)
            {
                resp = x.Message;
                type = "error";
            }

            if (!rbPessoaFisica.Checked && !rbPessoaJuridica.Checked && string.IsNullOrEmpty(resp))
            {
                resp = "Marque a natureza da pessoa. Pessoa física ou jurídica.";
                type = "warning";
            }
            else if (string.IsNullOrEmpty(resp))
            {
                resp = string.Format("Usuário cadastrado com sucesso. Um e-mail de confirmação foi enviado para {0} contendo sua senha de acesso.", usu.email);
                type = "success";
            }

            string script = "var n = noty({ text: '" + resp + "', layout: 'top', type: '" + type + "' });";
            ClientScript.RegisterStartupScript(GetType(), "Login Error", script, true);
        }
        
        protected void btnEsqueciSenha_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text))
                ClsUsuLogado.Login = txtLogin.Text.Trim();
            Response.Redirect("RecuperarSenha.aspx");
        }


    }
}