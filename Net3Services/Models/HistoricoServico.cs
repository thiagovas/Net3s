using MongoDB;  

namespace Models
{
    public class HistoricoServico
    {
        public Oid id { get; set; }
        /// <summary>
        /// Oid do orçamento relativo ao serviço finalizado.
        /// </summary>
        public Oid idOrcamento { get; set; }
        /// <summary>
        /// Guardará se o serviço foi contratado ou prestado, sendo 0 para contratado e 1 para prestado.
        /// </summary>
        public int? tipoServico { get; set; }
        /// <summary>
        /// Avaliação dada pelo prestador em relação ao contratante.
        /// </summary>
        public AvaliacaoContratante avaliacaoContratante { get; set; }
        /// <summary>
        /// Avaliação dada pelo contratante em relação ao prestador.
        /// </summary>
        public AvaliacaoPrestador avaliacaoPrestador { get; set; }
    }

    /// <summary>
    /// Classe que guarda os dados da avaliação feita pelo prestador em relação ao contratante.
    /// </summary>
    public class AvaliacaoContratante
    {
        /// <summary>
        /// Avaliação sobre o compormisso do contratante com o pagamento
        /// </summary>
        public int? Pagamento { get; set; }
    }

    /// <summary>
    /// Classe que guarda os dados da avaliação feita pelo contratante em relação ao prestador.
    /// </summary>
    public class AvaliacaoPrestador
    {
        /// <summary>
        /// Avaliação do preço que o prestador cobrou.
        /// </summary>
        public int? Preco { get; set; }
        /// <summary>
        /// Avaliação do tempo de execução do serviço feito pelo prestador.
        /// </summary>
        public int? TempoExecucaoServico { get; set; }
        /// <summary>
        /// Avaliação da qualidade do serviço feito pelo prestador.
        /// </summary>
        public int? QualidadeServico { get; set; }
    }
}
