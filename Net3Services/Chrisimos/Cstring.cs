using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Chrisimos
{
    public class Cstring
    {
        /// <summary>
        /// Este método verifica se a string informada tem somente números inteiros.
        /// </summary>
        /// <param name="texto">Variável usada para verificar se ela contém somente números inteiros.</param>
        /// <returns>Retorna um valor booleano, true se o valor informado tem somente números inteiros e false se não tem somente números inteiros.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool IsInt(string texto)
        {
            int num = 0;
            return int.TryParse(texto, out num);
        }
        
        /// <summary>
        /// Este método retira todos os espaços encontrados no texto informado.
        /// </summary>
        /// <param name="texto">Texto em que será retirado todos os espaços.</param>
        /// <returns>Retorna o texto informado, mas sem os espaços.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static string RetirarTodosEspacos(string texto)
        { 
            return string.IsNullOrEmpty(texto) ? string.Empty : texto.Contains(" ") ? texto.Replace(" ", "") : texto;
        }

        /// <summary>
        /// Este método retira todos os acentos de um texto.
        /// </summary>
        /// <param name="texto">Texto que será retirado os acentos.</param>
        /// <returns>Retorna o texto mas sem os acentos.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static string RetirarAcentos(string texto)
        {
            string resultado = texto;
            resultado = Regex.Replace(resultado, "[áàâãä]", "a");
            resultado = Regex.Replace(resultado, "[éèêë]", "e");
            resultado = Regex.Replace(resultado, "[íìîï]", "i");
            resultado = Regex.Replace(resultado, "[óòõôö]", "o");
            resultado = Regex.Replace(resultado, "[úùûü]", "u");
            resultado = Regex.Replace(resultado, "[ÁÀÃÂÄ]", "A");
            resultado = Regex.Replace(resultado, "[ÉÈÊË]", "E");
            resultado = Regex.Replace(resultado, "[ÍÌÎIÏ]", "I");
            resultado = Regex.Replace(resultado, "[ÓÒÕÔÖ]", "O");
            resultado = Regex.Replace(resultado, "[ÚÙÛÜ]", "U");
            resultado = Regex.Replace(resultado, "[ç]", "c");
            resultado = Regex.Replace(resultado, "[Ç]", "C");
            resultado = Regex.Replace(resultado, "[ý]", "y");
            resultado = Regex.Replace(resultado, "[Ý]", "Y");
            return resultado;
        }
    }   
}
