using MongoDB;

namespace Models
{
    /// <summary>
    /// Model da collection CategoriasServico
    /// </summary>
    public class CategoriaServico
    {
        /// <summary>
        /// Campo que guarda o Oid da categoria de serviço.
        /// </summary>
        public Oid idCategoria { get; set; }
        /// <summary>
        /// Campo que guarda o nome da categoria de serviço.
        /// </summary>
        public string nomeCategoria { get; set; }
    }
}
