using System;

namespace Chrisimos
{
    public class CdateTime
    {
        /// <summary>
        /// Enum com estilos de formatação de datas.
        /// </summary>
        public enum estilosDatas
        {
            DiaMesAno,
            AnoMesDia,
            MesDiaAno,
            MesAno,
            DiaMes,
            Ano,
            Mes,
            Dia
        }

        /// <summary>
        /// Retorna a data atual.
        /// </summary>
        /// <param name="formatacao">Formato em que a data será retornada.</param>
        /// <param name="separator">Elemento usado para separar os elementos dia, mês e ano.</param>
        /// <returns>Retorna uma string com a data no formato escolhido.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static string GetHoje(estilosDatas formatacao, char separator)
        {
            string hj = GetHoje(formatacao);
            string retorno = string.Empty;
            switch (formatacao)
            {
                case estilosDatas.AnoMesDia:
                    retorno = hj.Insert(4, separator.ToString()).Insert(7, separator.ToString());
                    break;
                case estilosDatas.DiaMesAno:
                    retorno = hj.Insert(2, separator.ToString()).Insert(5, separator.ToString());
                    break;
                case estilosDatas.MesAno:
                    retorno = hj.Insert(2, separator.ToString());
                    break;
                case estilosDatas.MesDiaAno:
                    retorno = hj.Insert(2, separator.ToString()).Insert(5, separator.ToString());
                    break;
                case estilosDatas.DiaMes:
                    retorno = hj.Insert(2, separator.ToString());
                    break;
                case estilosDatas.Ano:
                case estilosDatas.Mes:
                case estilosDatas.Dia:
                    retorno = hj;
                    break;
                default:
                    throw new Exception("Não há como separar uma váriavel.");
            }
            return retorno;
        }

        /// <summary>
        /// Retorna a data atual.
        /// </summary>
        /// <param name="variavel">Variável que receberá a data atual.</param>
        /// <param name="formatacao">Formatação desejada da data.</param>
        public static void GetHoje(out string variavel, estilosDatas formatacao)
        {
            variavel = GetHoje(formatacao);
        }

        public static string GetHoje(estilosDatas formatacao)
        {
            string retorno = string.Empty;
            switch (formatacao)
            {
                case estilosDatas.DiaMesAno:
                    retorno = DateTime.Now.ToString("ddMMyyyy");
                    break;
                case estilosDatas.AnoMesDia:
                    retorno = DateTime.Now.ToString("yyyyMMdd");
                    break;
                case estilosDatas.MesDiaAno:
                    retorno = DateTime.Now.ToString("MMddyyyy");
                    break;
                case estilosDatas.MesAno:
                    retorno = DateTime.Now.ToString("MMdd");
                    break;
                case estilosDatas.DiaMes:
                    retorno = DateTime.Now.ToString("ddMM");
                    break;
                case estilosDatas.Ano:
                    retorno = DateTime.Now.ToString("yyyy");
                    break;
                case estilosDatas.Mes:
                    retorno = DateTime.Now.ToString("MM");
                    break;
                case estilosDatas.Dia:
                    retorno = DateTime.Now.ToString("dd");
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Retorna o dia da semana, sendo 0 Segunda-feira, 1 Terça-Feira e assim em diante.
        /// </summary>
        /// <param name="ano">Ano da data.</param>
        /// <param name="mes">Mês da data.</param>
        /// <param name="dia">Dia da data.</param>
        /// <returns>Retorna 0 para Segunda-Feira, 1 para Terça-Feira, 2 para Quarte-feira, assim em diante até 6 Domingo.</returns>
        public static int GetDiaSemana(int ano, int mes, int dia)
        {
            return (1461 * (ano + 4800 + (mes - 14) / 12)) / 4 
                    + (367 * (mes - 2 - 12 * ((mes - 14) / 12))) / 12 
                    - (3 * ((ano + 4900 + (mes - 14) / 12) / 100)) / 4 + dia - 32075;
        }

        public static void FormatarData(DateTime data, out string variavel, estilosDatas formatacao)
        {
            //Implementar método
            variavel = string.Empty;
        }

        public static bool ValidarDataNascimento(DateTime data, int idadeMinima, int idadeMaxima)
        {
            TimeSpan dif = new TimeSpan();
            dif = DateTime.Now - data;
            double diferencaAnos = dif.Days / 360;
            return (diferencaAnos >= idadeMinima && diferencaAnos <= idadeMaxima);
        }

        public static bool ValidarDataNascimento(string data, int idadeMinima, int idadeMaxima)
        {
            DateTime dt = new DateTime();
            try
            {
                dt = Convert.ToDateTime(data);
            }
            catch
            { throw new FormatException("Data inválida."); }
            return ValidarDataNascimento(dt, idadeMinima, idadeMaxima);
        }

        /// <summary>
        /// Função que verifica se o ano informado é bissexto ou não.
        /// </summary>
        /// <param name="ano">Ano a ser verificado se é bissexto.</param>
        /// <returns>Retorna um valor booleano sendo true se o ano for bissexto ou false se não for bissexto.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public bool EhBissexto(int ano)
        {
            return (ano % 4 == 0);
        }
    }
}