using Domain;
using Domain.ChildEntity;
using Domain.ValueObject;
using FluentAssertions;
using Xunit;

namespace Unitteste
{
    public class TesteCarteira
    {
        [Theory]
        [InlineData(TipoCarteira.Acoes)]
        [InlineData(TipoCarteira.Cripto)]
        [InlineData(TipoCarteira.FundosImobiliarios)]
        public void DeveCriarCarteiraComOTipoEspecifico(TipoCarteira tipoCarteira)
        {
            Carteira carteira = new Carteira(tipoCarteira);

            carteira.Should().NotBeNull();
            carteira.Lancamentos.Should().BeEmpty();
            carteira.TipoCarteira.Should().Be(tipoCarteira);
        }
        [Fact]
        public void DeveAdicionarNovoAtivoNaCarteira()
        {
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, 40000.00M, 1, null);

            carteira.NovoLancamento(lancamento);

            carteira.Lancamentos.Should().NotBeNullOrEmpty();
            carteira.Lancamentos.Count.Should().Be(1);
        }

        [Fact]
        public void DeveRealizarOCalculoDaQuantidadeTotalQuandoAdicionarUmNovoAtivo()
        {
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento ativo = new Lancamento("BitCoin", TipoAtivo.Cripto, 40000.00M, 1, null);

            carteira.NovoLancamento(ativo);

            carteira.Lancamentos.Should().NotBeNullOrEmpty();
            carteira.Lancamentos.Count.Should().Be(1);
            carteira.QuantidadeTotal.Should().BeGreaterOrEqualTo(ativo.Quantidade);
        }


        [Fact]
        public void DeveRealizarOCalculoDoValorTotalBrutoQuandoAdicionarUmNovoAtivo()
        {
            decimal quantidade = 0.00208118M;
            decimal valorUnitarioDoAtivoNaCompra = 40000.00M;
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, valorUnitarioDoAtivoNaCompra, quantidade, null);

            carteira.NovoLancamento(lancamento);

            carteira.Lancamentos.Should().NotBeNullOrEmpty();
            carteira.Lancamentos.Count.Should().Be(1);
            carteira.QuantidadeTotal.Should().BeGreaterOrEqualTo(lancamento.Quantidade);

            decimal valorTotalBruto = valorUnitarioDoAtivoNaCompra * quantidade;
            carteira.ValorTotalBruto.Should().BeGreaterOrEqualTo(valorTotalBruto);
        }
        [Fact]
        public void DeveAtualizarOValorUnitarioDaCarteira()
        {
            decimal valorUnitarioDaCarteiraAtualizada = 45000M;
            Carteira carteira = new Carteira(TipoCarteira.Cripto);

            carteira.AtualizarValorDaCarteira(valorUnitarioDaCarteiraAtualizada);

            carteira.ValorUnitarioDaCarteiraAtualizada.Should().Be(valorUnitarioDaCarteiraAtualizada);
        }
        [Fact]
        public void DeveCalulcarOValorTotalDaCarteiraQuandoOValorForAtualizado()
        {
            decimal valorUnitarioDaCarteiraAtualizada = 45000M;
            decimal quantidade = 1;
            decimal valorUnitarioDoAtivoNaCompra = 40000.00M;
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, valorUnitarioDoAtivoNaCompra, quantidade, null);
            carteira.NovoLancamento(lancamento);

            carteira.AtualizarValorDaCarteira(valorUnitarioDaCarteiraAtualizada);

            carteira.ValorTotalAtualizado.Should().Be(45000);
        }

        [Fact]
        public void DeveRealizaroCalculoDoLucroQuandoOValorDaCarteiraForAtualizado()
        {
            decimal valorUnitarioDaCarteiraAtualizada = 45000M;
            decimal quantidade = 1;
            decimal valorUnitarioDoAtivoNaCompra = 40000.00M;
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, valorUnitarioDoAtivoNaCompra, quantidade, null);
            carteira.NovoLancamento(lancamento);

            carteira.AtualizarValorDaCarteira(valorUnitarioDaCarteiraAtualizada);

            carteira.Lucro.Should().Be(5000);
        }

        [Fact]
        public void DeveRealizarOCalculoDaPorcentagemQuandoOValorDaCarteiraForAtualizado()
        {
            decimal valorUnitarioDaCarteiraAtualizada = 45000M;
            decimal quantidade = 1;
            decimal valorUnitarioDoAtivoNaCompra = 40000.00M;
            Carteira carteira = new Carteira(TipoCarteira.Cripto);
            Lancamento lancamento = new Lancamento("BitCoin", TipoAtivo.Cripto, valorUnitarioDoAtivoNaCompra, quantidade, null);
            carteira.NovoLancamento(lancamento);

            carteira.AtualizarValorDaCarteira(valorUnitarioDaCarteiraAtualizada);

            carteira.PorcentagemDeLucro.Should().Be(12.50M);

        }


    }
}
