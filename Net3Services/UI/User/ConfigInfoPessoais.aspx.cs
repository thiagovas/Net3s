using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB;
using Models;
using ClsLibBLL;

namespace UI.User
{
    public partial class ConfigInfoPessoais : System.Web.UI.Page
    {
        protected string id { get; set; }
        protected string rg { get; set; }
        protected string cpf { get; set; }
        protected string tel { get; set; }
        protected string cel { get; set; }
        protected string tel2 { get; set; }
        protected string cel2 { get; set; }
        protected string site { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    var usu = ((Usuario)Session["USUARIO"]);
                    id = usu._id.ToString();
                    tel2 = usu.telefone2;
                    tel = usu.telefone1;
                    cel2 = usu.celular2;
                    cel = usu.celular1;
                    cpf = usu.cpf_cnpj;
                    site = usu.site;
                    rg = usu.rg;
                }
                catch
                {
                    Response.Redirect("../Erros/403.html");
                }
            }
            else
            {
                // Atualiza a sessão com os novos valores dos campos
                var myId = ((Usuario)Session["USUARIO"])._id;
                ClsUsuarioBLL usuBLL = new ClsUsuarioBLL();
                var updateSession = usuBLL.BuscarUsuarioPorID(myId);
                Session["USUARIO"] = updateSession;
                id = updateSession._id.ToString();
                tel2 = updateSession.telefone2;
                cel2 = updateSession.celular2;
                tel = updateSession.telefone1;
                cel = updateSession.celular1;
                cpf = updateSession.cpf_cnpj;
                site = updateSession.site;
                rg = updateSession.rg;
            }
        }

        protected void atualizaSessao_Click(object sender, EventArgs e)
        {
            Oid id = ((Usuario)Session["USUARIO"])._id;

            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            var usu = usuarioBLL.BuscarUsuarioPorID(id);
            Session["USUARIO"] = usu;
        }

        [System.Web.Services.WebMethod]
        public static string EditarInfo(string id, string rg, string cpf, string tel, string tel2, string cel, string cel2, string site)
        {
            string retorno = string.Empty;

            try
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                var usu = usuarioBLL.BuscarUsuarioPorID(new Oid(id));
                usu.telefone2 = tel2;
                usu.celular2 = cel2;
                usu.celular1 = cel;
                usu.telefone1 = tel;
                usu.cpf_cnpj = cpf;
                usu.site = site;
                usu.rg = rg;

                string erros = string.Empty;
                var resposta = usuarioBLL.ValidarConfiguracoesInfoPessoais(usu);
                foreach (var item in resposta)
                {
                    if (item != "ok")
                        erros += item + "\n";
                }

                if (string.IsNullOrEmpty(erros))
                {
                    usuarioBLL.EditarUsuario(usu);
                    retorno = "Seu perfil foi atualizado com sucesso.";
                }
                else
                {
                    retorno = erros;
                }
            }
            catch (Exception x)
            {
                retorno = x.Message;
            }

            return retorno;
        }

    }
}