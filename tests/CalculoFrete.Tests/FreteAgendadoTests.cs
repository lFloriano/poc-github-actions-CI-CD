using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Tests
{
    public class FreteAgendadoTests
    {
        [Fact]
        [Trait("Teste Unitário", "Modalidade Agendada")]
        public void CalculoFrete_QuandoModalidadeAgendada_DeveRetornarValorEsperadoEEntregaApos5Dias()
        {
            //arrange
            var pesoEmKg = 10.0M;
            var distanciaEmKm = 20.0M;
            var valorEsperado = 34.0M;
            var data5DiasAFrente = DateOnly.FromDateTime(DateTime.Today.AddDays(5));

            //act
            var frete = new FreteAgendado(pesoEmKg, distanciaEmKm, data5DiasAFrente);

            //assert
            Assert.Equal(valorEsperado, frete.Valor);
            Assert.Equal(5, frete.PrazoEntrega.NumeroMinimoDias);
            Assert.Equal(5, frete.PrazoEntrega.NumeroMaximoDias);
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Agendada")]
        public void CalculoFrete_QuandoModalidadeAgendada_NaoDeveAceitarDataPassada()
        {
            //arrange
            var pesoEmKg = 10.0M;
            var distanciaEmKm = 20.0M;
            var ontem = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var frete = new FreteAgendado(pesoEmKg, distanciaEmKm, ontem);
            });
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Agendada")]
        public void CalculoFrete_QuandoPesoForNegativo_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = -100M;
            var distanciaEmKm = 20.0M;
            var dataAgendamento = DateOnly.FromDateTime(DateTime.Now.AddDays(5));

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var frete = new FreteAgendado(pesoEmKg, distanciaEmKm, dataAgendamento);
            });
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Agendada")]
        public void CalculoFrete_QuandoDistanciaForNegativa_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = 0.25M;
            var distanciaEmKm = -1M;
            var dataAgendamento = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var frete = new FreteAgendado(pesoEmKg, distanciaEmKm, dataAgendamento);
            });
        }
    }
}