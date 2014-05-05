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
    public partial class ConfigGeral : System.Web.UI.Page
    {
        protected string id { get; set; }
        protected string nome { get; set; }
        protected string email { get; set; }
        protected string login { get; set; }
        protected string dataNasc { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    var usuario = ((Usuario)Session["USUARIO"]);
                    dataNasc = usuario.dataNasc.ToString("dd/MM/yyyy");
                    id = usuario._id.ToString();
                    email = usuario.email;
                    login = usuario.login;
                    nome = usuario.nome;
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

                dataNasc = updateSession.dataNasc.ToString("dd/MM/yyyy");
                id = updateSession._id.ToString();
                email = updateSession.email;
                login = updateSession.login;
                nome = updateSession.nome;
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
        public static string EditarGeral(string id, string nome, string login, string email, string dataNasc, string sexo)
        {
            string retorno = string.Empty;

            try
            {
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                var usu = usuarioBLL.BuscarUsuarioPorID(new Oid(id));

                try { usu.dataNasc = Convert.ToDateTime(dataNasc); }
                catch { throw new Exception(); }

                usu.nome = nome;
                usu.login = login;
                usu.email = email;
                var validade = usuarioBLL.ValidarConfiguracoesGerais(usu);
                string erros = string.Empty;
                foreach (var item in validade)
                {
                    if (item != "ok")
                        erros += item + "\n";
                }

                if (string.IsNullOrEmpty(erros))
                {
                    usuarioBLL.editarUsuario(usu);
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