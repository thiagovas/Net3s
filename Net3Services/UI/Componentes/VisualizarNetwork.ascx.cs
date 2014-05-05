using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using MongoDB;

namespace UI.Componentes
{
    public partial class VisualizarNetwork : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CriarNetwork();
            }
        }

        private void CriarNetwork()
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "visuNetwork");
            ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
            ClsContatoBLL contBll = new ClsContatoBLL();

            Oid idUsuario = new Oid(Request["id"]);

            var contUsu = contBll.BuscarTodosContatos(idUsuario);
            var usu = usuarioBLL.BuscarUsuarioPorID(idUsuario);
            string nomeFoto = string.Empty;
            Int16 i = 1;

            div.InnerHtml += string.Format("<h1>Network - {0}</h1><br /><br />", usu.nome);

            foreach (var cont in contUsu)
            {
                //Aqui ele gera a imagem de acordo com a informação de nome
                if (usuarioBLL.VerificarImagem(cont.idContato.ToString()))
                    nomeFoto = cont.idContato.ToString();
                else
                    nomeFoto = "1";

                div.InnerHtml += string.Format("<a href='Perfil.aspx?id={0}'><div class='contato'>", cont.idContato);
                div.InnerHtml += string.Format("<img src='../Componentes/BuscaImagens.ashx?id={0}' alt='' class='foto'/>", nomeFoto);
                div.InnerHtml += string.Format("<font class='nome'>{0}</font>", cont.NomeContato);
                div.InnerHtml += string.Format("<br /><br /><br /><font class='email'><font class='iconesDois'>@</font>{0}</font>", cont.EmailContato);
                div.InnerHtml += "</div></a>";

                i++;
            }

            phNetwork.Controls.Add(div);
        }
    }
}