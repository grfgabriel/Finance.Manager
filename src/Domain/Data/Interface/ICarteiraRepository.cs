using Domain.ChildEntity;

namespace Domain.Data.Interface
{
    public interface ICarteiraRepository
    {
        Task CreateAsync(Carteira carteira);
        Task<Carteira> GetAsync(TipoCarteira tipoCarteira);
        Task UpdateAsync(Carteira tipoCarteira);
    }
}