using Domain;
using Domain.ChildEntity;
using Domain.Data.Interface;
using Domain.ValueObject;
using Infrastructure.Model;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly IMongoCollection<CarteiraModel> _carteiraCollection;
        public CarteiraRepository()
        {
            //Todo: Pegar conection string do config. 
            var client = new MongoClient("mongodb://root:root_pwd!@localhost:27017/admin?serverSelectionTimeoutMS=5000&connectTimeoutMS=10000&authSource=admin&authMechanism=SCRAM-SHA-1");
            _carteiraCollection = client.GetDatabase("FinanceCripto").GetCollection<CarteiraModel>(nameof(Carteira));

        }
        public async Task CreateAsync(Carteira carteira)
        {

            var model = new CarteiraModel(carteira._id, carteira.Lancamentos.Select(x => new LancamentoModel(x._id, x.IdCarteira, x.NomeAtivo, x.TipoAtivo,x.Preco, x.Custo, x.Quantidade,x.DataDaCompra)).ToList(),
                carteira.TipoCarteira,carteira.PorcentagemDeLucro, carteira.ValorTotalBruto, carteira.ValorTotalAtualizado,
                carteira.ValorUnitarioDaCarteiraAtualizada, carteira.Lucro, carteira.QuantidadeTotal);  

            await _carteiraCollection.InsertOneAsync(model);
        }

        public async Task<Carteira> GetAsync(TipoCarteira tipoCarteira)
        {
            var model = await _carteiraCollection.FindAsync(carteira => carteira.TipoCarteira == tipoCarteira);
            var modelresult = model.FirstOrDefault();

            if (modelresult != null)
            {
                var result = new Carteira(modelresult._id, modelresult.Lancamentos.Select(x => new Lancamento(x._id, x.IdCarteira, x.NomeAtivo, x.TipoAtivo, x.Preco, x.Custo, x.Quantidade, x.DataDaCompra)).ToList(),
                modelresult.TipoCarteira, modelresult.PorcentagemDeLucro, modelresult.ValorTotalBruto, modelresult.ValorTotalAtualizado,
                modelresult.ValorUnitarioDaCarteiraAtualizada, modelresult.Lucro, modelresult.QuantidadeTotal);
                return result;
            }
            return default;
        }

        public async Task UpdateAsync(Carteira carteira)
        {
            var filter = Builders<CarteiraModel>.Filter.Eq("_id", carteira._id);
            var update = Builders<CarteiraModel>.Update
                .Set(it => it.Lucro, carteira.Lucro)
                .Set(it => it.Lancamentos, carteira.Lancamentos.Select(x => new LancamentoModel(x._id, x.IdCarteira, x.NomeAtivo, x.TipoAtivo, x.Preco, x.Custo, x.Quantidade, x.DataDaCompra)).ToList())
                .Set(it => it.PorcentagemDeLucro, carteira.PorcentagemDeLucro)
                .Set(it => it.QuantidadeTotal, carteira.QuantidadeTotal)
                .Set(it => it.TipoCarteira, carteira.TipoCarteira)
                .Set(it => it.ValorTotalAtualizado, carteira.ValorTotalAtualizado)
                .Set(it => it.ValorTotalBruto, carteira.ValorTotalBruto)
                .Set(it => it.ValorUnitarioDaCarteiraAtualizada, carteira.ValorUnitarioDaCarteiraAtualizada);

            await _carteiraCollection.UpdateOneAsync(filter, update);
        }
    }
}
