using System;
using MongoDB;

namespace Models
{
    //Se mudar alguma coisa neste enum, lembre-se de mudar nos metodos de montar objeto e documento na classe ClsNotificacaoDAL.
    //Cria um elemento enum TipoNotificacao pra controlar o tipo da notificação. O tipo da notificação informa a classe de cadastro a
    // necessidade (ou a falta dela) de se ler alguns campos.
    //Junior - adicionei o tipo de notificação de denuncia, caso seje para aviso
    public enum TipoNotificacao : short
    {
        Network = 0,
        Orcamento = 1,
        Denuncia = 2
    }

    //Se mudar alguma coisa neste enum, lembre-se de mudar nos metodos de montar objeto e documento na classe ClsNotificacaoDAL.
    /// <summary>
    /// Verifica qual a prioridade daquela notificação
    /// </summary>
    /// <by>Marcio Mansur - marciorabelom@hotmail.com</by>
    public enum Prioridade : short
    { 
        Baixa = 0,
        Media = 1,
        Alta = 2,
        Urgente = 3
    }

    /// <summary>
    /// Enum que serve para ajudar a identificar o status atual de uma notificação.
    /// </summary>
    public enum StatusNotif : short
    { 
        Aceito,
        Bloqueado, //Usado em notificações que o seu objetivo é pedir a outro usuario que ele seja adicionado a um network de outro usuário.
        Pendente
    }

    /// <summary>
    /// Classe que representa o model da notificação.
    /// </summary>
    /// <by>Breno Pires - breno_spires@hotmail.com</by>
    public class Notificacao
    {
        private TipoNotificacao internalTipo;

        /// <summary>
        /// Oid da notificação. Variavel de controle interno
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public MongoDB.Oid _id { get; set; }

        /// <summary>
        /// Usuário que gerou a notificação ao ter requisitado um pedido de amizade ou uma solicitação de orçamento
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public Oid idRemetente { get; set; }
        
        /// <summary>
        /// Usuário que recebe a notificaçõe
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public Oid idDestinatario { get; set; }

        /// <summary>
        /// Titulo que aparecerá na notificação
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public string assunto { get; set; }

        /// <summary>
        /// Breve descrição escrita pelo remetente sobre a notificação gerada.
        /// Pode ser uma mensagem escrita ao se adicionar o usuário ao network ou a
        /// descrição da solicitação de orçameto.
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public string descricao { get; set; }

        /// <summary>
        /// Indica se a notificação já foi respondida ou se ainda deve ser respondida (ou ignorada).
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public StatusNotif status { get; set; }

        /// <summary>
        /// Define o tipo da notificação. O tipo será utilizado no cadastro da notificação para saber quais campos devem ou não
        /// ser lidos
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public TipoNotificacao tipo 
        {
            get { return internalTipo; }
            set
            {
                internalTipo = value;

                if (value != TipoNotificacao.Orcamento)
                {
                    idServico = null;
                    qtdContratada = null;
                }
            }
        }

        //Propriedade de prioridade
        public Prioridade prioridade { get; set; }

        /// <summary>
        /// Data em que a notificação foi gerada
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public DateTime dataNotificacao { get; set; }

        /* Tudo a partir desta linha só deve ser utilizado caso a otificação seja do tipo Orcamento(1) */
        /// <summary>
        /// Oid do serviço que deseja ser contratado
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public Oid idServico { get; set; }

        /// <summary>
        /// Quantidade do serviço que será solicitada. A quantidade está de acordo com a unidade de medida informada no 
        /// cadastro do serviço.
        /// </summary>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public double? qtdContratada { get; set; }
    }
}
