using System;
using MongoDB;

namespace Models
{
    public enum TipoDenuncia : short
    {
        FotoInadequada = 0,
        ServicosInaequados = 1,
        ConteudoIndevido = 2,
        Span = 3,
        ConteudoIlegal = 4,
        ConteudoPornografico= 5,
        Outros = 6
    }

    public class Denuncia
    {
        public Oid _id { get; set; }
        public string descricao { get; set; }
        public TipoDenuncia tipoDenuncia { get; set; }

        /// <summary>
        /// Determina o status do atendimento. Se true a denuncia já foi atendida, do contrário ela NÃO foi atendida atendida
        /// </summary>
        public bool? status { get; set; }
        
        /// <summary>
        /// Usuário que acusa o outro usuário de ter cometido um delito.
        /// </summary>
        public Oid denunciante { get; set; }
        
        /// <summary>
        /// Usuário acusado de ter cometido alguma infração
        /// </summary>
        public Oid acusado { get; set; }
        
        /// <summary>
        /// Oid do administrador que atendeu a denuncia
        /// </summary>
        public Oid atendente { get; set; }

        public string resposta { get; set; }
        public string punicao { get; set; }

        /// <summary>
        /// Data em que a denúncia foi feita
        /// </summary>
        public DateTime dataDenuncia { get; set; }

        /// <summary>
        /// Data em que a denuncia foi atendida por um dos administradores do site
        /// </summary>
        public DateTime dataAtendimento { get; set; }
    }
}
