using System.Xml;

namespace ClsLibBLL
{
    /// <summary>
    /// Classe que serve para acessar o arquivo constantes.xml
    /// </summary>
    public class ClsConstantesBLL
    {
        /// <summary>
        /// Retorna o valor de uma tag.
        /// </summary>
        /// <param name="tag">Nome da tag principal, por exemplo: regexes</param>
        /// <param name="idTag">Id da tag que deseja acessar que fica dentro da tag principal, por exemplo: email</param>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static string LerTeste(string tag, string idTag)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string retorno = string.Empty;
            xmlDoc.Load("constantes.xml"); //Carregando o arquivo

            //Pegando elemento pelo nome da TAG
            XmlNodeList xnList = null;

            switch (tag)
            { 
                case "regex":
                    xnList = xmlDoc.GetElementsByTagName("regexes").Item(0).ChildNodes;
                    break;
                case "chave":
                    xnList = xmlDoc.GetElementsByTagName("chaves").Item(0).ChildNodes;
                    break;
            }
            

            foreach (XmlNode xn in xnList)
            {
                if (xn["id"].InnerText == idTag)
                {
                    retorno = xn["valor"].InnerText;
                    break;
                }
            }
            return retorno;
        }
    }
}
