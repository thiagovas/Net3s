using System.Collections.Generic;
using MongoDB;

namespace Models
{
    public class CatalogoEndereco
    {
        public Pais pais { get; set; }
    }

    public class Pais
    {
        public Oid id { get; set; }
        public string nomePais { get; set; }
        public List<Estado> estados { get; set; }
    }

    public class Estado
    {
        public Oid id { get; set; }
        public string nomeEstado { get; set; }
        public List<Cidade> cidades { get; set; }
    }

    public class Cidade
    {
        public Oid id { get; set; }
        public string nomeCidade { get; set; }
    }
}
