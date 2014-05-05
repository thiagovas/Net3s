using System;
using MongoDB;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Os status do orçamentos. O orçamento seguirá por 5 fases.
    /// Aberto, Visualizado, Respondido, aprovado ou rejeitado e finalizado.
    /// A explicação de cada um deles está em seus respectivos sumários.
    /// </summary>
    public enum StatusOrcam
    {
        /// <summary>
        /// Orçamentos que foram requisitados pelo contratante mas não foram visualizados pelo prestador ainda.
        /// </summary>
        aberto,
        /// <summary>
        /// Orçamentos que foram requisitados pelo contratante e foram visualizados pelo prestados.
        /// </summary>
        visualizado,
        /// <summary>
        /// Orçamentos que foram respondidos pelo prestador para o contratante.
        /// </summary>
        respondido,
        /// <summary>
        /// Orçamentos aprovados pelo contratante para o prestador fazer o serviço.
        /// </summary>
        aprovado,
        /// <summary>
        /// Orçamentos que não foram aprovados pelo contratante para o prestador fazer o serviço.
        /// </summary>
        rejeitado,
        /// <summary>
        /// Orçamentos que já tiveram
        /// </summary>
        finalizado
    }

    public class Orcamento
    {
        /// <summary>
        /// Id do orçamento
        /// </summary>
        public Oid id { get; set; }
        
        /// <summary>
        /// Id do prestador do serviço.
        /// </summary>
        public Oid prestador { get; set; }
        
        /// <summary>
        /// Id do contratante, ou seja, da pessoa que está interessada no serviço.
        /// </summary>
        public Oid contratante { get; set; }
        
        /// <summary>
        /// Id do serviço que está sendo contratado.
        /// </summary>
        public List<Oid> idServico { get; set; }
        
        /// <summary>
        /// Data da previsão do início do serviço.
        /// </summary>
        public DateTime dataInicio { get; set; }
        
        /// <summary>
        /// Data de previsão de término do serviço.
        /// </summary>
        public DateTime dataFim { get; set; }
        
        /// <summary>
        /// Preço proposto pelo prestador.
        /// </summary>
        public double preco { get; set; }
        
        /// <summary>
        /// Descrição do orçamento
        /// </summary>
        public string descricao { get; set; }
        
        /// <summary>
        /// Status em que o orçamento está, o enum Status Orcam tem todos os status.
        /// </summary>
        public StatusOrcam status { get; set; }
    }
}
/**********************************LOG***********************************************************************************************
 * Marcio Alfredo, marcio.alfredo1@gmail.com.
 * Alterações: retirada de dois campos para  colocar um no lugar, que seria status, é mais eficiente, e mais pratico de se trabalhar.
 * Como foi decidido na reunião do dia 02/08/2012,  com o Thiago Vieira e o Breno Pires.
 * Alterações aqui iram refletir na DAL, talvez também na BLL.
 */