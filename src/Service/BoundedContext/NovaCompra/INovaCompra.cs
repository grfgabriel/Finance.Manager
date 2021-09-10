namespace Service.BoundedContext.NovaCompra
{
    public interface INovaCompra
    {
        Task Handle(NovaCompraInput input);
    }
}
