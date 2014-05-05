using System;
using MongoDB;

namespace Models.AtualizacaoEmDesuso
{
    /// <summary>
    /// Enum que contém todos os tipos de atualizações existentes.
    /// </summary>
    public enum TiposAtualizacao
    { 
        NovoContato,
        NovoServico,
        MudancaPerfil
    }

    /// <summary>
    /// Classe abstrata e genérica que contém dados comuns a todo tipo de atualização.
    /// </summary>
    /// <by>Thiago Vieira - t.vas@hotmail.com</by>
    [Obsolete("Esta classe so será usada se voltarmos a mecher com os feeds de atualizações.")]
    public abstract class Atualizacao
    {
        /// <summary>
        /// Data e hora em que a atualização foi feita.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        public string NomeUsuario { get; set; }

        //public string Mensagem { get; set; }

        public Oid OidUsuario { get; set; }
    }

    /// <summary>
    /// Classe que representa a atualização da adição de um novo contato ao network de um usuário.
    /// </summary>
    [Obsolete("Esta classe so será usada se voltarmos a mecher com os feeds de atualizações.")]
    public class AtualizacaoNovoContato : Atualizacao {
        public string NomeContato { get; set; }
        public Oid OidContato { get; set; }
    }

    /// <summary>
    /// Classe que representa a atualização da adição de um novo serviço por um usuário.
    /// </summary>
    [Obsolete("Esta classe so será usada se voltarmos a mecher com os feeds de atualizações.")]
    public class AtualizacaoNovoServico : Atualizacao {
        public string NomeServico { get; set; }
    }

    /// <summary>
    /// Classe que representa a atualização da mudança do perfil de um usuário.
    /// </summary>
    [Obsolete("Esta classe so será usada se voltarmos a mecher com os feeds de atualizações.")]
    public class AtualizacaoMudancaPerfil : Atualizacao {
        public string Mensagem { get; set; }
    }
}
