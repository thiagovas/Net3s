using Norm;

namespace MongoDB.Models
{
    public class EstiloMusical
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}