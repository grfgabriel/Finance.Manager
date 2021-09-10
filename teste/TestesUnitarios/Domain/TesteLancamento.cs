using Domain.ChildEntity;
using Domain.ValueObject;
using FluentAssertions;
using Xunit;

namespace Unitteste.ValueObject
{
    public class TesteLancamento
    {
        [Fact]
        public void DeveCalcularOCustoComBaseNoPreco()
        {
            decimal preco = 10000M;
            decimal quantidade = 2;
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, preco, quantidade, null);

            lancamento.Custo.Should().Be(20000M);
        }
    }
}