using Domain.ChildEntity;
using Domain.ValueObject;

namespace Domain
{
    public class Carteira
    {
        public Carteira(TipoCarteira tipoCarteira)
        {
            _id = new Guid();
            Lancamentos = new List<Lancamento>();
            TipoCarteira = tipoCarteira;
        }

        public Carteira(Guid id, IList<Lancamento> lancamentos, TipoCarteira tipoCarteira, decimal porcentagemDeLucro, decimal valorTotalBruto, decimal valorTotalAtualizado, decimal valorUnitarioDaCarteiraAtualizada, decimal lucro, decimal quantidadeTotal)
        {
            _id = id;
            Lancamentos = lancamentos;
            TipoCarteira = tipoCarteira;
            PorcentagemDeLucro = porcentagemDeLucro;
            ValorTotalBruto = valorTotalBruto;
            ValorTotalAtualizado = valorTotalAtualizado;
            ValorUnitarioDaCarteiraAtualizada = valorUnitarioDaCarteiraAtualizada;
            Lucro = lucro;
            QuantidadeTotal = quantidadeTotal;
        }

        public Guid _id { get; private set; }
        public IList<Lancamento> Lancamentos { get; private set; }
        public TipoCarteira TipoCarteira { get; private set; }
        public decimal PorcentagemDeLucro { get; private set; }
        public decimal ValorTotalBruto { get; private set; }
        public decimal ValorTotalAtualizado { get; private set; }
        public decimal ValorUnitarioDaCarteiraAtualizada { get; private set; }
        public decimal Lucro { get; private set; }
        public decimal QuantidadeTotal { get; private set; }

        public void NovoLancamento(Lancamento lancamento)
        {
            Lancamentos.Add(lancamento);
            CalcularQuantidadeTotal(lancamento);
            CalcularValorTotalBruto(lancamento);
        }
        private void CalcularQuantidadeTotal(Lancamento lancamento)
        {
            QuantidadeTotal = QuantidadeTotal + lancamento.Quantidade;
        }

        private void CalcularValorTotalBruto(Lancamento lancamento)
        {
            ValorTotalBruto = ValorTotalBruto + lancamento.Custo;
            ValorTotalBruto = Decimal.Round(ValorTotalBruto, 2);

        }

        public void AtualizarValorDaCarteira(decimal valorUnitarioDaCarteiraAtualizada)
        {
            ValorUnitarioDaCarteiraAtualizada = valorUnitarioDaCarteiraAtualizada;
            CalculaValorTotalDaCarteira();
            CalcularLucro();
            CalcularPorcentagemDeLucro();
        }

        private void CalcularLucro()
        {
            Lucro = ValorTotalAtualizado - ValorTotalBruto;
        }

        private void CalculaValorTotalDaCarteira()
        {
            ValorTotalAtualizado = QuantidadeTotal * ValorUnitarioDaCarteiraAtualizada;
            ValorTotalAtualizado = Decimal.Round(ValorTotalAtualizado, 2);

        }

        private void CalcularPorcentagemDeLucro()
        {
            if (ValorTotalBruto > 0)
            {
                PorcentagemDeLucro = (ValorTotalAtualizado - ValorTotalBruto) / ValorTotalBruto * 100;
                PorcentagemDeLucro = Decimal.Round(PorcentagemDeLucro, 2);
            }
        }
    }
}