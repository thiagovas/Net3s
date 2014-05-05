using System;
using MongoDB;
using System.Collections.Generic;

namespace Models
{
    public enum StatusServico
    { 
        Ativo,
        Desativo
    }

    /// <summary>
    /// Classe que representa a collection de serviços do banco de dados.
    /// </summary>
    public class Servico
    {
        /// <summary>
        /// ID do serviço
        /// </summary>
        public Oid _id { get; set; }

        /// <summary>
        /// Oid do usuário a quem pertence o serviço.
        /// </summary>
        public Oid idUsuario { get; set; }

        /// <summary>
        /// Nome do serviço
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Média do preço cobrada no serviço
        /// </summary>
        public double preco { get; set; }

        /// <summary>
        /// Tipo do serviço
        /// </summary>
        public Oid categoriaServico { get; set; }

        /// <summary>
        /// Nome da categoria em que o serviço se encaixa.
        /// </summary>
        public string nomeCategoriaServico { get; set; }

        /// <summary>
        /// Média das avaliações do serviço. A nota não é um double pois o componente que mostra a clasificação só 
        /// valores inteiros
        /// </summary>
        public int notaMedia { get; set; }

        /// <summary>
        /// Descrição do serviço
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// Marca se o serviço só pode ser atendido regionalmente ou se pode ser executado de várias localidades
        /// </summary>
        public bool regional { get; set; }

        /// <summary>
        /// Campo usado somente se o campo regional for true, e ele guardará o nome da regiao que o serviço será prestado.
        /// </summary>
        /// <example>Tocantins, Camaçari, Costa Rica</example>
        public string regiao { get; set; }

        /// <summary>
        /// Caso o serviço seja seja regional define para quais pessoas ele pode ser realizado
        /// </summary>
        public string nivelRegionalidade { get; set; }

        /// <summary>
        /// Unidade de medida em que o serviço é cobrado executado para se calcular o preço.
        /// </summary>
        public string unidadeMedida { get; set; }

        /// <summary>
        /// Data que o serviço foi inserido no banco de dados.
        /// </summary>
        public DateTime dataInsercao { get; set; }

        /// <summary>
        /// Guarda o status do serviço.
        /// </summary>
        public StatusServico statusServico { get; set; }

        /// <summary>
        /// Cria a string contendo as estrelas que mostram a avaliação média do serviço 
        /// </summary>
        /// <param name="nota">Nota média do serviço</param>
        /// <returns>String com os caracteres (da fonte de icones) contendo as estelas coorespondentes a nota informada </returns>
        /// <by>Breno Pires - breno_spires@hotmail.com</by>
        public string getEstrelasNota()
        {
            string estrelas = string.Empty;
            for (int i = 0; i < this.notaMedia; i++)
            {
                //icon-star   icon-star-empty
                estrelas += "<i class='icon-star'></i>";
            }

            for (int x = 0; x < (5 - this.notaMedia); x++)
            {
                estrelas += "<i class='icon-star-empty'></i>";
            }

            return estrelas;
        }
    }


   public class ServiceIDComparer : IEqualityComparer<Servico>
    {
        public bool Equals(Servico x, Servico y)
        {
            return x._id == y._id;
        }

        // If Equals() returns true for a pair of objects 
        // then GetHashCode() must return the same value for these objects.

        public int GetHashCode(Servico x)
        {
            return x._id.GetHashCode();
        }
    }
}