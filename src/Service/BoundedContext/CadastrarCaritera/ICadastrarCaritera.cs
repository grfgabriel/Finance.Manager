namespace Service.BoundedContext.CadastrarCaritera
{
    public interface ICadastrarCaritera
    {
        Task<CadastrarCariteraOutput> Handle(CadastrarCariteraInput request);
    }
}
