using Domain.ChildEntity;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Model
{
    public class CarteiraModel
    {
        public CarteiraModel(Guid id, List<LancamentoModel> lancamentos, TipoCarteira tipoCarteira, decimal porcentagemDeLucro, decimal valorTotalBruto, decimal valorTotalAtualizado, decimal valorUnitarioDaCarteiraAtualizada, decimal lucro, decimal quantidadeTotal)
        {
            _id = id;
            Lancamentos = lancamentos;
            TipoCarteira = tipoCarteira;
            PorcentagemDeLucro = porcentagemDeLucro;
            ValorTotalBruto = valorTotalBruto;
            ValorTotalAtualizado = valorTotalAtualizado;
            ValorUnitarioDaCarteiraAtualizada = valorUnitarioDaCarteiraAtualizada;
            Lucro = lucro;
            QuantidadeTotal = quantidadeTotal;
        }
        [BsonElement]
        public Guid _id { get; private set; }
        [BsonElement]
        public List<LancamentoModel> Lancamentos { get; private set; }
        
        [BsonElement]
        public TipoCarteira TipoCarteira { get; private set; }
        
        [BsonElement]
        public decimal PorcentagemDeLucro { get; private set; }
        
        [BsonElement]
        public decimal ValorTotalBruto { get; private set; }
        
        [BsonElement]
        public decimal ValorTotalAtualizado { get; private set; }
        
        [BsonElement]
        public decimal ValorUnitarioDaCarteiraAtualizada { get; private set; }
        
        [BsonElement]
        public decimal Lucro { get; private set; }
        
        [BsonElement]
        public decimal QuantidadeTotal { get; private set; }

    }
}
