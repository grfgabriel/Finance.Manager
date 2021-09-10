namespace Service.BoundedContext.AtualizarValorDoAtivo
{
    public interface IAtualizarValorDoAtivo
    {
        Task Handle(AtualizarValorDoAtivoInput input);
    }
}
