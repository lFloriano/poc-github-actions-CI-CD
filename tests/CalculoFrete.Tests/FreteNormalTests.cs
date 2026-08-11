using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Tests
{
    public class FreteNormalTests
    {
        [Fact]
        [Trait("Teste Unitário", "Modalidade Normal")]
        public void CalculoFrete_QuandoModalidadeNormal_DeveRetornarValorEsperadoEPrazoEntre5e8Dias()
        {
            /* Regras:
             * Valor = (Peso × 1.2) + (Distância × 0.5) + TaxaFixaNormal = 5
             * Prazo estimado: 5 a 8 dias úteis
             */

            //arrange
            var pesoEmKg = 10.0M;
            var distanciaEmKm = 20.0M;
            var valorEsperado = 27.0M;

            //act
            var frete = new FreteNormal(pesoEmKg, distanciaEmKm);

            //assert
            Assert.Equal(valorEsperado, frete.Valor);
            Assert.InRange(frete.PrazoEntrega.NumeroMinimoDias, 5, 5);
            Assert.InRange(frete.PrazoEntrega.NumeroMaximoDias, 8, 8);
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Normal")]
        public void CalculoFrete_QuandoDistanciaForNegativa_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = 100M;
            var distanciaEmKm = -99M;

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>((Action)(() =>
            {
                var frete = new FreteNormal(pesoEmKg, distanciaEmKm);
            }));
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Normal")]
        public void CalculoFrete_QuandoPesoForNegativo_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = -100M;
            var distanciaEmKm = 20.0M;

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>((Action)(() =>
            {
                var frete = new FreteNormal(pesoEmKg, distanciaEmKm);
            }));
        }
    }
}
