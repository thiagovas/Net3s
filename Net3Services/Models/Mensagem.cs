using System;
using System.Collections.Generic;
using MongoDB;

namespace Models
{
    public class Conversas
    {
        /// <summary>
        /// identificação da mensagem
        /// </summary>
        public Oid _id { get; set; }

        /// <summary>
        /// Array de pessoas que participam de uma conversa 
        /// </summary>
        public List<Pessoa> pessoaConversa = new List<Pessoa>();

        /// <summary>
        /// corpo da mensagem enviada do remetente ao destinatário
        /// </summary>
        public List<Conteudo> conteudoConversa = new List<Conteudo>();

        /// <summary>
        /// Data e hora do envio do conteúdo da conversa
        /// </summary>
        public DateTime DataDeEnvio { get; set; }
    }
}
