using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using ClsLibBLL;
using Models;

namespace UIAdmin
{
    public partial class LoginADM2 : System.Web.UI.Page
    {
        ClsAdministradorBLL adm = new ClsAdministradorBLL();
        Administrador AdmSession = new Administrador();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
        }

        protected void BtnEntrar1_Click(object sender, ImageClickEventArgs e)
        {
            List<Administrador> validado = adm.LogarViaLogin(Regex.Replace(this.TxtSenha.Text,"'",""), this.TxtLogin.Text);

            foreach (Administrador admin in validado)
            {
                AdmSession = admin;
            }

            if (validado.Count() == 1)
            {
                //inicializa a autenticação
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket tk = new FormsAuthenticationTicket(this.lblLogin.Text, true, 30);
                string hash = FormsAuthentication.Encrypt(tk);
                HttpCookie bisc = new HttpCookie(".ASPXAUTH", hash);
                bisc.Expires = DateTime.Now.AddMinutes(30);

                Response.Cookies.Add(bisc);
                Session.Add("Administrador", AdmSession);
                Response.Redirect("Admin/Perfil.aspx");
            }

            else this.LblLogado.Text = "Usuário ou Senha incorretos";
        }
    }
}