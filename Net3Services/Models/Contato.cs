using System;
using MongoDB;

namespace Models
{
    /// <summary>
    /// Classe que representa um registro no array network da collection de usuarios.
    /// </summary>
    public class Contato
    {
        public Oid idContato { get; set; }
        public DateTime DataInsercao { get; set; }
        public string NomeContato { get; set; }
        public string EmailContato { get; set; }
    }
}
