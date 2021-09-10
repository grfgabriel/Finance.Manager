using Domain.Data.Interface;
using Service.BoundedContext.AtualizarValorDoAtivo;

namespace Service.UseCase
{
    public class AtualizarValorDoAtivo : IAtualizarValorDoAtivo
    {
        public AtualizarValorDoAtivo(ICarteiraRepository carteiraRepository)
            => _carteiraRepository = carteiraRepository;

        private readonly ICarteiraRepository _carteiraRepository;

        public async Task Handle(AtualizarValorDoAtivoInput input)
        {
            var carteira = await _carteiraRepository.GetAsync(input.TipoCarteira);
            carteira.AtualizarValorDaCarteira(input.ValorUnitarioDoAtivoAtualizado);

            await _carteiraRepository.UpdateAsync(carteira);
        }
    }
}
