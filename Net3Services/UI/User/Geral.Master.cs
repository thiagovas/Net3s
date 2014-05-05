using System;
using System.Web.UI;
using ClsLibBLL;
using Models;
using MongoDB;

namespace UI.User
{
    public partial class Geral : System.Web.UI.MasterPage
    {
        ClsUsuarioBLL usuBll;
        protected string nomeFoto { get; set; }
        protected string idUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LiberarAcoes();
                AlterarLinks();
            }
        }

        private void AlterarLinks()
        {
            try
            {
                Oid idLogado = ((Usuario)Session["USUARIO"])._id;
                hlPerfil.NavigateUrl = string.Format("Perfil.aspx?id={0}", idLogado);
            }
            catch { Response.Redirect("../Erros/401.html"); }

            // Busca a imagem de perfil do usuário
            usuBll = new ClsUsuarioBLL();
            if (usuBll.VerificarImagem(Request["id"].ToString()))
                nomeFoto = Request["id"].ToString();
            else
                nomeFoto = "1";
        }

        /// <summary>
        /// Caso o usuário que esteja acessando a página seja diferente do usuário logado mostra o menu de ações
        /// </summary>
        private void LiberarAcoes()
        {
            Oid idLogado = ((Usuario)Session["USUARIO"])._id;
            Oid id = new Oid(Request["id"]);

            if (!string.IsNullOrEmpty(Request["id"]))
                idUrl = Request["id"];
            else
                idUrl = idLogado.ToString();

            if (id != idLogado)
            {
                lblAcoes.Visible = true;
                acoes.Visible = true;
            }
        }
    }
}