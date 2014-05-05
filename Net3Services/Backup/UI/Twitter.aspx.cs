using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClsLibDAL;
using MongoDB;

namespace UI
{
	public partial class Twitter : System.Web.UI.Page
	{
        public static List<string> tweet = new List<string>();

        #region Nome dos campos

        public const string collec = "Twitter";
        public const string idT = "idTwitter";
        public const string idUsu = "idUsu";
        public const string foto = "foto";
        public const string desc = "descricao";
        public const string name = "nome";

        #endregion

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
                tweet.Clear();
		}

        [System.Web.Services.WebMethod]
        public static string verificaTweet(string idTweet, string idUser, string foto, string nome, string texto)
        {
            string retorno = string.Empty;

            Predicate<string> isso = new Predicate<string>(delegate(string o) {
                return idTweet == o ? true : false;
            });

            if (tweet.Find(isso) == null)
            {
                //se ja tiver twitado não salva se não salva para concorrer a premios
                if (!existeId(idUser))
                {
                    //se não existir salva o mesmo.
                    salva(idTweet, idUser, foto, nome, texto);
                }

                retorno += "<div name='tweet' class='tweet' style='display: none;'>";
                retorno += "<img src='" + foto + "' alt='' class='foto' />";
                retorno += "<label class='nome'>@" + nome + "</label>";
                retorno += "<p>" + texto + "</p>";
                retorno += "</div>";

                tweet.Add(idTweet);
                return retorno;
            }
            else
                return "";
        }

        /// <summary>
        /// Caso não exista ele salva no banco de dados o twitter, para concorrer a premios
        /// </summary>
        /// <param name="id">Id do twitter do camarada</param>
        /// <param name="foto">caminho da foto da pessoa</param>
        /// <param name="nome">nome que a pessoa utiliza no twitter</param>
        /// <param name="texto">texto que ela escreveu</param>
        private static void salva(string id, string idUser, string fotoUsu, string nome, string texto)
        {
            Document doc = new Document();
            try
            {
                doc[idT] = id;
                doc[idUsu] = idUser;
                doc[foto] = fotoUsu;
                doc[name] = nome;
                doc[desc] = texto;

                Repository rep = new Repository();
                    rep.Insert(doc, collec);
            }
            catch { throw new Exception("Erro ao inserir tweet"); }
        }

        /// <summary>
        /// Verifica  se já existe esse id salvo no banco, caso não exista, 
        /// </summary>
        /// <param name="id">id do twitter da pessoa</param>
        /// <returns>se true, existe, se false ainda não existe</returns>
        private static bool existeId(string id)
        {
            List<Document> resp = new List<Document>();

            Document doc = new Document();
            try
            {
                doc[idUsu] = id;

                Repository rep = new Repository();
                    resp = rep.procurarArquivo(collec, doc);
            }
            catch { throw new Exception("Erro ao buscar tweet"); }

            return resp.Count() != 0; 
        }
	}
}