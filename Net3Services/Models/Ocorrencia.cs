using System;
using MongoDB;

namespace Models
{
    public class Ocorrencia
    {
        /// <summary>
        /// Id da Ocorrencia.
        /// </summary>
        public Oid idOcorrencia { get; set; }
        /// <summary>
        /// Descrição da ocorrencia. Ex.: "O fulano de tal postou conteudo pornografico no link http://www.net3services.com.br/[o resto do link]."
        /// </summary>
        public string descricao { get; set; }
        /// <summary>
        /// Status da ocorrencia.
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// Id de quem fez a denuncia.
        /// </summary>
        public Oid denunciante { get; set; }
        /// <summary>
        /// Id do administrador que atendeu a denuncia feita para o acusado.
        /// </summary>
        public Oid atendente { get; set; }
        /// <summary>
        /// Acusado da denuncia.
        /// </summary>
        public Oid acusado { get; set; }
        /// <summary>
        /// Resposta dada pelo administrador da denuncia.
        /// </summary>
        public string resposta { get; set; }
        /// <summary>
        /// Data que a denuncia foi feita pelo usuario denunciante.
        /// </summary>
        public DateTime dataDenuncia { get; set; }
        /// <summary>
        /// Data que o administrador deu a resposta da denuncia.
        /// </summary>
        public DateTime dataResposta { get; set; }
        /// <summary>
        /// Tempo(se existir) que o usuario for ficar banido.
        /// </summary>
        public string tempoBanido { get; set; }
    }
}
