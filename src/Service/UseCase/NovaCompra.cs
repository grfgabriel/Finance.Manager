using Domain.Data.Interface;
using Domain.ValueObject;
using Service.BoundedContext.NovaCompra;

namespace Service.UseCase
{
    public class NovaCompra : INovaCompra
    {
        public NovaCompra(ICarteiraRepository carteiraRepository)
            => _carteiraRepository = carteiraRepository;

        private readonly ICarteiraRepository _carteiraRepository;

        public async Task Handle(NovaCompraInput input)
        {

            var carteira = await _carteiraRepository.GetAsync(input.TipoCarteira);

            Lancamento lancamento = new Lancamento(input.NomeDoAtivo, input.TipoAtivo,
            input.ValorUnitarioNaCompra, input.Quantidade, input.DataDaCompra);
            carteira.NovoLancamento(lancamento);

            await _carteiraRepository.UpdateAsync(carteira);
        }
    }
}
