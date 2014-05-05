using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClsLibBLL;
using ClsLibDAL;
using MongoDB;

namespace UI.Componentes
{
    /// <summary>
    /// Summary description for BuscaImagens
    /// </summary>
    public class BuscaImagens : IHttpHandler
    {
        //tipo de imagem que será retornado
        string tipo = string.Empty;

        public void ProcessRequest(HttpContext context)
        {
            string nomeFoto = "1";
            ClsUsuarioBLL usuBll = new ClsUsuarioBLL();
            
            if (usuBll.VerificarImagem( context.Request.QueryString["id"]))
                nomeFoto = context.Request.QueryString["id"];
            
            //documento para a pesquisa
            Document pesq = new Document();
            //resposta da pesquisa
            List<Document> resp = new List<Document>();

            //Monta o documento onde irá buscar determinada imagem
            pesq = MontarObjDocumento(nomeFoto);

            //metodo que busca a determinada imagem citada
            Repository rep = new Repository();
                resp = rep.procurarArquivo(NomeCompBd.collecUsuarios, pesq);
            

            byte[] resposta = Imagem(resp);

            if (resposta != null)
            {
                context.Response.ContentType = "image/" + tipo;
                context.Response.OutputStream.Write(resposta, 0, resposta.Count());
            }
            //context.Response.Write(Imagem(resp));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Monta o documento de imagem com aquele determinado id
        /// </summary>
        /// <param name="OidImagem">id da imagem a ser buscada</param>
        /// <returns>retorna o documento pronto para a pesquisa</returns>
        protected Document MontarObjDocumento(string OidImagem)
        {
            Document doc = new Document();
            doc["filename"] = OidImagem;

            return doc;
        }

        /// <summary>
        /// Monta a imagem para que ela possa ser retornada no ashx
        /// </summary>
        /// <param name="documentada">Lista que contem a imagem em binario</param>
        /// <returns>retorna a imagem</returns>
        protected byte[] Imagem(List<Document> documentada)
        {
            byte[] bin = null;

            //fazendo com metodos anonimos
            documentada.ForEach(delegate(Document docum) {
                //joga valores para um array de bytes
                Binary f = (Binary)docum["metadata"];
                bin = f.Bytes;

                //salva o tipo do arquivo
                tipo = docum["ContentType"].ToString();
            });

            return bin;
        }
    }
}