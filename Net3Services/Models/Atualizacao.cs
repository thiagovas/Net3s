using System;
using MongoDB;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Enum para que quando gerar uma atualização diferente o usuario, possa saber o tipo dela
    /// <by>Marcio Alfredo - marcio.alfredo1@gmail.com</by>
    /// </summary>
    public enum TipoAtualizacao
    {
        contato = 0,
        serviço = 1
    }

    /// <summary>
    /// Classe que representa as atualizações de usuários.
    /// </summary>
    public class Atualizacao
    {
        /// <summary>
        /// Data e hora em que a atualização foi feita.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Nome do usuário que fez a atualização.
        /// </summary>
        public string NomeUsuario { get; set; }

        /// <summary>
        /// Mensagem presente na atualização.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Oid do usuário que fez a atualização.
        /// </summary>
        public Oid OidUsuario { get; set; }

        /// <summary>
        /// Esta propriedade grava a informação que determina se a atualização pertence ao usuário que tem o Oid guardado na propriedade OidUsuario ou não.
        /// </summary>
        //public bool Eproprio { get; set; }

        /// <summary>
        /// Pega o tipo da atualização para ser tratada mais tarde.
        /// </summary>
        public TipoAtualizacao? tipoAtualizacao { get; set; }
    }
}
