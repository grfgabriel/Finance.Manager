using Domain;
using Domain.Data.Interface;
using Service.BoundedContext.CadastrarCaritera;

namespace Service.UseCase
{
    public class CadastrarCaritera : ICadastrarCaritera
    {
        public CadastrarCaritera(ICarteiraRepository carteiraRepository)
        => _carteiraRepository = carteiraRepository;
        private readonly ICarteiraRepository _carteiraRepository;

        public async Task<CadastrarCariteraOutput> Handle(CadastrarCariteraInput request)
        {
            Carteira carteira = new Carteira(request.TipoCarteira);
            await _carteiraRepository.CreateAsync(carteira);

            var result = new CadastrarCariteraOutput();
            return result;
        }
    }
}
