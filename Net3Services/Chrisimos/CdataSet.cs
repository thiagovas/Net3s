using System.Data;

namespace Chrisimos
{
    public class CdataSet
    {
        /// <summary>
        /// Este método verifica se o DataSet é nulo ou se ele é vazio.
        /// </summary>
        /// <param name="ds">DataSet a ser verificado.</param>
        /// <returns>Retorna uma variável booleana.</returns>
        /// <by>Thiago Vieira - t.vas@hotmail.com</by>
        public static bool IsNullOrEmpty(DataSet ds)
        {
            return (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0);
        }
    }
}
