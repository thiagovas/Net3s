using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClsLibBLL
{
    class ClsValidaCpfCnpj
    {
        public static bool ValidarCpf(string cpf)
        {
            try
            {
                cpf = cpf.Replace("-", "");
                cpf = cpf.Replace(".", "");
            }
            catch
            {return false;}

            Regex reg = new Regex(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)");
            if (!reg.IsMatch(cpf))
                return false;

            int d1, d2;
            int soma = 0;
            string digitado = "";
            string calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] n = new int[11];

            bool retorno = false;

            // Limpa a string
            cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\\", "");

            // Se o tamanho for < 11 entao retorna como inválido
            if (cpf.Length != 11)
            {return false;}

            
            /*Os Seguintes CPFs existem:
             * 11111111111
             * 44444444444
             * 88888888888
             * Estes CPFs foram consultados no site da receita.fazenda.gov.br
             * e pertencem à alguém
             */
            // Caso coloque todos os numeros iguais
            switch (cpf)
            {
                case "22222222222":
                    return false;
                case "00000000000":
                    return false;
                case "33333333333":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(cpf.Substring(0, 1));
                n[1] = Convert.ToInt32(cpf.Substring(1, 1));
                n[2] = Convert.ToInt32(cpf.Substring(2, 1));
                n[3] = Convert.ToInt32(cpf.Substring(3, 1));
                n[4] = Convert.ToInt32(cpf.Substring(4, 1));
                n[5] = Convert.ToInt32(cpf.Substring(5, 1));
                n[6] = Convert.ToInt32(cpf.Substring(6, 1));
                n[7] = Convert.ToInt32(cpf.Substring(7, 1));
                n[8] = Convert.ToInt32(cpf.Substring(8, 1));
                n[9] = Convert.ToInt32(cpf.Substring(9, 1));
                n[10] = Convert.ToInt32(cpf.Substring(10, 1));

            }
            catch
            {
                return false;
            }


            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
            {
                soma += (peso1[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
            {
                d1 = 0;
            }
            else
            {
                d1 = 11 - resto;
            }

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
            {
                soma += (peso2[i] * Convert.ToInt32(n[i]));
            }

            // Pega o resto da divisao
            resto = soma % 11;

            if (resto == 1 || resto == 0)
            {
                d2 = 0;
            }
            else
            {
                d2 = 11 - resto;
            }

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length < 14)
                return false;

            int[] numero = new int[14];
            int digitoVer1 = 0;//Digito verificador 1
            int digitoVer2 = 0;//Digito Verificador 2
            int[] ValorConst1 = new int[12];//Constantes para o cálculo do primeiro dígito verificador
            int[] ValorConst2 = new int[13];//Constantes para o cálculo do segundo dígito verificador

            #region inicialização da variável ValorConst1
            ValorConst1[0] = 5;
            ValorConst1[1] = 4;
            ValorConst1[2] = 3;
            ValorConst1[3] = 2;
            ValorConst1[4] = 9;
            ValorConst1[5] = 8;
            ValorConst1[6] = 7;
            ValorConst1[7] = 6;
            ValorConst1[8] = 5;
            ValorConst1[9] = 4;
            ValorConst1[10] = 3;
            ValorConst1[11] = 2;
            #endregion

            #region inicialização da variável ValorConst2
            ValorConst2[0] = 6;
            ValorConst2[1] = 5;
            ValorConst2[2] = 4;
            ValorConst2[3] = 3;
            ValorConst2[4] = 2;
            ValorConst2[5] = 9;
            ValorConst2[6] = 8;
            ValorConst2[7] = 7;
            ValorConst2[8] = 6;
            ValorConst2[9] = 5;
            ValorConst2[10] = 4;
            ValorConst2[11] = 3;
            ValorConst2[12] = 2;
            #endregion

            #region inicialização da variável numero
            numero[0] = Convert.ToInt32(cnpj.Substring(0, 1));
            numero[1] = Convert.ToInt32(cnpj.Substring(1, 1));
            numero[2] = Convert.ToInt32(cnpj.Substring(2, 1));
            numero[3] = Convert.ToInt32(cnpj.Substring(3, 1));
            numero[4] = Convert.ToInt32(cnpj.Substring(4, 1));
            numero[5] = Convert.ToInt32(cnpj.Substring(5, 1));
            numero[6] = Convert.ToInt32(cnpj.Substring(6, 1));
            numero[7] = Convert.ToInt32(cnpj.Substring(7, 1));
            numero[8] = Convert.ToInt32(cnpj.Substring(8, 1));
            numero[9] = Convert.ToInt32(cnpj.Substring(9, 1));
            numero[10] = Convert.ToInt32(cnpj.Substring(10, 1));
            numero[11] = Convert.ToInt32(cnpj.Substring(11, 1));
            #endregion

            #region Cálculo do primeiro dígito verificador
            int soma = 0;

            for (int i = 0; i <= numero.Length-3; i++)
            {
                soma += ValorConst1[i] * numero[i];
            }

            if (soma % 11 > 2)
            {
                digitoVer1 = 11 - (soma % 11);
            }
            else
            {
                digitoVer1 = 0;
            }
            numero[12] = digitoVer1;
            #endregion

            #region Cálculo do segundo dígito verificador
            soma = 0;
            for (int c = 0; c <= 12; c++)
            {
                soma += ValorConst2[c] * numero[c];
            }

            if (soma % 11 > 2)
            {
                digitoVer2 = 11 - (soma % 11);
            }
            else
            {
                digitoVer2 = 0;
            }
            #endregion

            if ((digitoVer1.ToString() + digitoVer2.ToString()) == cnpj.Substring(12, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
