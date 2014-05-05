using System;

namespace Models
{
    /// <summary>
    /// Este classe representa o Html de uma atualização - Esse modelo será usado no componente Atualizacoes.aspx
    /// </summary>
    public class HtmlAtualizacao
    {
        /// <summary>
        /// Titulo da atualização.
        /// </summary>
        public string Titulo { private get; set; }
        /// <summary>
        /// Link agregado ao titulo da atualização.
        /// </summary>
        public string Link { private get; set; }
        /// <summary>
        /// Html do titulo da atualização.
        /// </summary>
        public string HtmlTitulo { get { return string.Format("<a href='{0}'>{1}</a>", Link, Titulo); } }
        /// <summary>
        /// Objeto do tipo Avaliação em que guarda a avaliação do serviço prestado pelo usuário.
        /// </summary>
        public Avaliacao ObjAvaliacao { get; set; }
        //public string CssClassPanel { get; set; }
        /// <summary>
        /// Html do corpo da atualização.
        /// </summary>
        public string HtmlConteudoAtualizacao { get; set; }
        /*
            servicoBLL = new ClsServicoBLL();
            // Chamar método de busca de serviços prestados e fazer o código da atualização rodar em um loop

            string linkServico = "#", tituloTela = "teste", imgUsu = "", idPrestador = "123", nomePrestador = "Breno" , texto = "Faxinei direitinho direitinho";
            Int16 nota = 3;
            DateTime dataPost = DateTime.Now;

            Panel myPanel = new Panel();
            myPanel.CssClass = "post";
            
            HtmlGenericControl titulo = new HtmlGenericControl("h3");
            titulo.InnerHtml = string.Format("<a href='{0}'>{1}</a>", linkServico, tituloTela);
            myPanel.Controls.Add(titulo);

            Rating myRating= new Rating();
            myRating.ID = "teste";
            myRating.FilledStarCssClass = "filledRatingStar";
            myRating.EmptyStarCssClass = "emptyRatingStar";
            myRating.WaitingStarCssClass = "savedRatingStar";
            myRating.StarCssClass = "ratingStar";
            myRating.CssClass = "clasifiServ";
            myRating.ReadOnly = true;
            myRating.CurrentRating = nota;
            myPanel.Controls.Add(myRating);
            
            HtmlGenericControl conteudo = new HtmlGenericControl("div");
            ClsAtualizacaoBLL atualizacaoBLL = new ClsAtualizacaoBLL();
            //conteudo.InnerHtml += string.Format("<span class='data'>{0}</span>", dataPost.Day + " de " + dataPost.GetNomeMes() + " de " + dataPost.Year);
            //conteudo.InnerHtml += "<br /><br />";
            //conteudo.InnerHtml += string.Format("<img src='{0}' class='imgPost' align=left' />", imgUsu);
            //conteudo.InnerHtml += "<p class='meta'>";
            //conteudo.InnerHtml += string.Format("<span class='autor'>Prestador: <a href='~/Perfil.aspx?id={0}'>{1}</a></span></p>", idPrestador, nomePrestador);
            //conteudo.InnerHtml += string.Format("<p class='postTexto'>{0}</p>", texto);
            //conteudo.InnerHtml += string.Format("<a href='{0}' class=''>Ver Mais</a>", linkServico);
            //conteudo.InnerHtml += "<br /><br />";
            conteudo.InnerHtml = atualizacaoBLL.BuscarAtualizacoes(ClsUsuLogado.IdUsuario, false);
            myPanel.Controls.Add(conteudo);

            phConteudo.Controls.Add(myPanel);
        */
    }

    /// <summary>
    /// Classe que guarda informações que serão usadas para preencher objetos do tipo Rating na UI.
    /// </summary>
    public class Avaliacao
    {
        public string Id { get; set; }
        public string FilledStarCssClass { get; set; }
        public string EmptyStarCssClass { get; set; }
        public string WaitingStarCssClass { get; set; }
        public string StarCssClass { get; set; }
        public string CssClass { get; set; }
        public bool ReadOnly { get; set; }
        public Int16 CurrentRating { get; set; }
    }
}
