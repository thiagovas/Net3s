using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Chrisimos
{
    public class Cxml
    {
        /// <summary>
        /// Este método converte uma variável do tipo string que contém tags XML para uma variável do tipo XmlDocument.
        /// </summary>
        /// <param name="valor">Variável a ser convertida.</param>
        /// <returns>Retorna um objeto do tipo XmlDocument.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static XmlDocument Parse(string valor)
        {
            XmlDocument retorno = new XmlDocument();
            retorno.LoadXml(valor.Trim());
            return retorno;
        }

        /// <summary>
        /// Este método converte uma variável do tipo string contendo tags XML para uma variável do tipo XmlDocument, e retorna uma variável booleana mostrando se a conversão foi feita com sucesso.
        /// </summary>
        /// <param name="valor">Variável a ser convertida.</param>
        /// <param name="result">Variável que guardará o resultado.</param>
        /// <returns>Retorna uma variável booleana mostrando se a conversão foi feita com sucesso.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool TryParse(string valor, out XmlDocument result)
        {
            result = new XmlDocument();
            try
            {
                result.RemoveAll();
                result.LoadXml(valor.Trim());
                return true;
            }
            catch
            { return false; }
        }

        /// <summary>
        /// Este método converte uma variável do tipo string que contém tags XML para uma variável do tipo XmlDocument.
        /// </summary>
        /// <param name="valor">Variável a ser convertida.</param>
        /// <param name="preserveWhiteSpace">Se o objeto que guardará o XML preservará os espaços em branco contidos nele.</param>
        /// <returns>Retorna um objeto do tipo XmlDocument.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static XmlDocument Parse(string valor, bool preserveWhiteSpace)
        {
            XmlDocument retorno = new XmlDocument();
            retorno.PreserveWhitespace = preserveWhiteSpace;
            retorno.LoadXml(valor);
            return retorno;
        }

        /// <summary>
        /// Este método converte uma variável do tipo string contendo tags XML para uma variável do tipo XmlDocument, e retorna uma variável booleana mostrando se a conversão foi feita com sucesso.
        /// </summary>
        /// <param name="valor">Variável a ser convertida.</param>
        /// <param name="result">Variável que guardará o resultado.</param>
        /// <param name="preserveWhiteSpace">Se o objeto que guardará o XML preservará os espaços em branco contidos nele.</param>
        /// <returns>Retorna uma variável booleana mostrando se a conversão foi feita com sucesso.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool TryParse(string valor, out XmlDocument result, bool preserveWhiteSpace)
        {
            result = new XmlDocument();
            try
            {
                result.RemoveAll();
                result.PreserveWhitespace = preserveWhiteSpace;
                result.LoadXml(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Método responsável por validar um documento XML
        /// </summary>
        /// <returns>Retorna uma vazio se o documento for válido ou a mensagem de erro.</returns>
        public static string validarXml()
        {
            //Implementar método
            //Thiago Vieira
            throw new NotImplementedException();
        }
    }
}
