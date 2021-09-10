using Domain.ChildEntity;

namespace Service.BoundedContext.AtualizarValorDoAtivo
{
    public class AtualizarValorDoAtivoInput
    {
        public string Nome { get; set; }
        public decimal ValorUnitarioDoAtivoAtualizado { get; set; }
        public TipoCarteira TipoCarteira { get; set; }
    }
}
