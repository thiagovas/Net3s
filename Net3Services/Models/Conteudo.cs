using System;
using MongoDB;

namespace Models
{
    /// <summary>
    /// Classe que representa um registro do array de conteúdo na conversa
    /// </summary>
    public class Conteudo
    {
        public Oid idConteudo { get; set; }
        public string CorpoConteudo { get; set; }
    }
}