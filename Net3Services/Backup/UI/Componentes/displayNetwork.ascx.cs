using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ClsLibBLL;
using MongoDB;
using Models;

namespace NET3Services
{
    public partial class displayNetwork : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                CriarNetwork();
        }

        /// <summary>
        /// Método que cria o componente do network dinamicamente de acordo com as informações recebidas do banco de dados.
        /// </summary>
        private void CriarNetwork()
        {
            HtmlGenericControl header = new HtmlGenericControl("header");
            HtmlGenericControl nav = new HtmlGenericControl("nav");
            ClsContatoBLL contBll = new ClsContatoBLL();
            string nomeFoto = string.Empty;
            Oid idUsuario = new Oid(Request["id"]);
            Usuario usuLogado = ((Usuario)Session["USUARIO"]);

            long qtdCont = contBll.BuscarQuantidadeContatos(idUsuario);
            header.Attributes.Add("class", "titulo");
            nav.Attributes.Add("class", "network");

            if (qtdCont <= 0)
            {
                if (idUsuario == usuLogado._id)
                {
                    header.InnerHtml += string.Format("<h3>Network <mark>({0})</mark></h3>", qtdCont);
                    nav.InnerHtml += "Você não possui usuários adicionados ao seu network. Encontre-os clicando <a href='../User/Pesquisa.aspx'>aqui</a>.";
                }
                else
                {
                    header.InnerHtml += string.Format("<h3>Network <mark>({0})</mark></h3>", qtdCont);
                    nav.InnerHtml += string.Format("O usuário {0} não possui usuários adicionados ao seu network.", usuLogado.nome);
                }
            }
            else
            {
                header.InnerHtml += string.Format("<h3><a href='Network.aspx?id={0}'>Network <mark>({1})</mark></a></h3>", idUsuario, qtdCont);
                ClsUsuarioBLL usuarioBLL = new ClsUsuarioBLL();
                nomeFoto = string.Empty;
                Int16 i = 1;

                var contUsu = contBll.BuscarTodosContatos(idUsuario);
                foreach (var cont in contUsu)
                {
                    //Aqui ele gera a imagem de acordo com a informação de nome
                    if (usuarioBLL.VerificarImagem(cont.idContato.ToString()))
                        nomeFoto = cont.idContato.ToString();
                    else
                        nomeFoto = "1";

                    nav.InnerHtml += string.Format("<a href='Perfil.aspx?id={0}' class='tooltip'><img src='../Componentes/BuscaImagens.ashx?id={1}' /><span>{2}</span></a>", cont.idContato.ToString(), nomeFoto, cont.NomeContato);

                    if (i % 3 == 0)
                        nav.InnerHtml += "<br />";

                    i++;
                }
            }

            phNetwork.Controls.Add(header);
            phNetwork.Controls.Add(nav);
        }

        protected string verificaImagem(Oid id)
        {
            ClsUsuarioBLL usu = new ClsUsuarioBLL();
            //se existir ele se não 1
            return usu.VerificarImagem(id.ToString()) ? id.ToString() : "1";
        }
    }
}