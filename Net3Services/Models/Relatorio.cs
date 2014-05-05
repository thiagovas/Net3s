using System;
using MongoDB;

namespace Models
{
    //ele irá inserir no sistema no periodo de 24 horas usando um contador
    public class Relatorio
    {
        public Oid _id { get; set; }

        //Busca o intervalo de data que o usuário quer gerar
        public DateTime dataIni { get; set; }
        public DateTime dataFim { get; set; }

        //busca  os serviços mais contratados e prestado
        public Oid servMaisContrat { get; set; }
        public Oid serMaisPrest { get; set; }

        //Pega todos os usuários do sistema
        public int quantUsuario { get; set; }
        public int quantUsuarioInativ { get; set; }
        public int quantUsuPrest { get; set; }
        public int quantUsuContart { get; set; }

        //quantidade de Usuários prestadores e contratantes
        public int quantUsuCP { get; set; }

        //quantidade de ocorrencias feitas no sistema
        public int quantOcorr { get; set; }

        //quantidade de serviços fechados e cancelados
        public int quantServFech { get; set; }
        public int quantServCanc { get; set; }
    }
}
