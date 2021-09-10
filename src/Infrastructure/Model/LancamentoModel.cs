using Domain.ChildEntity;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Model
{
    public class LancamentoModel
    {
        public LancamentoModel(Guid id, Guid idCarteira, string nomeAtivo, TipoAtivo tipoAtivo, decimal preco, decimal custo, decimal quantidade, DateTime dataDaCompra)
        {
            _id = id;
            IdCarteira = idCarteira;
            NomeAtivo = nomeAtivo;
            TipoAtivo = tipoAtivo;
            Preco = preco;
            Custo = custo;
            Quantidade = quantidade;
            DataDaCompra = dataDaCompra;
        }

        [BsonElement]
        public Guid _id { get; private set; }
        
        [BsonElement]
        public Guid IdCarteira { get; private set; }
        
        [BsonElement]
        public string NomeAtivo { get; private set; }
        
        [BsonElement]
        public TipoAtivo TipoAtivo { get; private set; }
        
        [BsonElement]
        public decimal Preco { get; private set; }
        
        [BsonElement]
        public decimal Custo { get; private set; }
        
        [BsonElement]
        public decimal Quantidade { get; private set; }
        
        [BsonElement]
        public DateTime DataDaCompra { get; private set; }
    }
}
