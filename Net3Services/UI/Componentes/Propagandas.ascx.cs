using System;
using System.Web.UI.HtmlControls;

namespace NET3Services.Componentes
{
    public partial class Propagandas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!Page.IsPostBack)
            //BuscarPropagandas();
        }

        private void BuscarPropagandas()
        {
            string[] arquivos = new string[3];

            for (int i = 0; i < 3; i++)
			{
               // arquivos[i] = clsUtilidades.GetArquiosAleatorios(@"D:/Aula/PCC/NET3Services/NET3Services/Propagandas");
			}

            GerarComponente(arquivos);
        }

        private void GerarComponente(string[] propagandas)
        {
            HtmlGenericControl div = new HtmlGenericControl();
            div.InnerHtml += "<ul id='propaganda'>";

            string nomeArquivo;

            int i = 0;
            foreach (var item in propagandas)
            {
                nomeArquivo = propagandas[i];
                nomeArquivo = nomeArquivo.Replace("\\", "/");
                nomeArquivo = nomeArquivo.Replace("D:/Aula/PCC/NET3Services/NET3Services", "");

                div.InnerHtml += "<li>";
                div.InnerHtml += string.Format("<img src='{0}' alt='Teste' height='100%' width='100%' />", nomeArquivo);
                div.InnerHtml += "</li>";
                i++;
            }
        
            div.InnerHtml += "</ul>";
            phConteudo.Controls.Add(div);
        }
    }
}