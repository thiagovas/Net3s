using MongoDB;

namespace Models
{
    public class Endereco
    {
        public Oid id { get; set; }
        public string pais { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
    }
}
