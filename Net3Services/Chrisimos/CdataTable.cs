using System.Data;

namespace Chrisimos
{
    public class CdataTable
    {
        /// <summary>
        /// Este método verifica se o DataTable informado é nulo ou se é vazio.
        /// </summary>
        /// <param name="dt">DataTable a ser verificado.</param>
        /// <returns>Retorna uma variável booleana.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool IsNullOrEmpty(DataTable dt)
        { 
            return (dt == null || dt.Rows.Count == 0);
        }
    }
}
