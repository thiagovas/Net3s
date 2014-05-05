using System;

namespace Chrisimos
{
    public class Cint
    {
        /// <summary>
        /// Função que verifica se o número informado é primo ou não.
        /// </summary>
        /// <param name="num">Número a ser verificado.</param>
        /// <returns>Retorna um valor booleano, sendo true se o número for primo ou false se não for.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool EhPrimo(int num)
        {
            int cont = 0, metade = num/2;
            for (int i = 1; i < metade; i++)
            {
                if (num % i == 0)
                    cont++;
            }
            return (cont == 1);
        }

        /// <summary>
        /// Método que verifica quantos algarismos tem uma variável do tipo int
        /// </summary>
        /// <param name="num">Variável que contém o valor numérico.</param>
        /// <returns>Retorna o número de algarismos que o parâmetro tinha.</returns>
        /// <by></by>
        public int ContarAlgarismos(int num)
        {
            string strNum = num.ToString();
            return strNum.Length;
        }
        
        /// <summary>
        /// Função que calcula o fatorial de um número.
        /// </summary>
        /// <param name="num">Número a ser calculado o seu fatorial.</param>
        /// <returns>Retorna o fatorial do parâmetro.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public long Fatorial(int num)
        {
            int retorno = 1;

            for (int i = 1; i <= num; i++)
            {
                retorno *= i;
            }

            return retorno;
        }
    }
}
