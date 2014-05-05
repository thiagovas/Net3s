using System;
using MongoDB;

namespace Models
{
    /// <summary>
    /// Classe que representa um registro no array de pessoas dentro de uma conversa
    /// </summary>
    public class Pessoa
    {
        public Oid idPessoa { get; set; }
        public string Nome { get; set; }
    }
}
