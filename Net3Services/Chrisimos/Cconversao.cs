using System;
using System.IO;

namespace Chrisimos
{
    public class Cconversao
    {
        /// <summary>
        /// Converte o texto passado como parâmetro para uma variável do tipo int. Retorna null se a conversão falhar
        /// </summary>
        /// <param name="text">Texto a ser convertido para int.</param>
        /// <returns>Retorna uma variável do tipo int?</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static int? ToInt(string texto)
        {
            int num;
            return int.TryParse(texto, out num) ? num : (int?)null;
        }
        
        /// <summary>
        /// Método que tem a função de guardar uma variável do tipo string em um MemoryStream.
        /// </summary>
        /// <param name="texto">Variável que será guardada em um MemoryStream.</param>
        /// <returns>Retorna um objeto do tipo MemoryStream.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static MemoryStream ToMemoryStream(string texto)
        {
            if (!string.IsNullOrEmpty(texto.Trim()))
            {
                byte[] ab = new byte[texto.Length];
                int cont = 0;
                try
                {
                    foreach (char item in texto.ToCharArray())
                    {
                        ab[cont] = Convert.ToByte(item);
                        cont++;
                    }
                    MemoryStream ms = new MemoryStream(ab);
                    return ms;
                }
                catch (OverflowException)
                { throw new OverflowException("Há caracteres inválidos no texto informado."); }
            }
            else
            { throw new ArgumentNullException("Informe o texto para que possa guardá-lo em um MemoryStream."); }
        }
    }
}
