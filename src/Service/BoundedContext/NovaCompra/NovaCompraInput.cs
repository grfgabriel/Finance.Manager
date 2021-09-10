using Domain.ChildEntity;

namespace Service.BoundedContext.NovaCompra
{
    public class NovaCompraInput
    {
        public TipoCarteira TipoCarteira { get; set; }
        public string NomeDoAtivo { get; set; }
        public TipoAtivo TipoAtivo { get; set; }
        public decimal ValorUnitarioNaCompra { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataDaCompra { get; set; }
    }
}
