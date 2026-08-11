namespace CalculoFrete.Tests
{
    public class FreteExpressoTests
    {
        [Fact]
        [Trait("Teste Unitário", "Modalidade Expressa")]
        public void CalculoFrete_QuandoModalidadeExpressa_DeveRetornarValorEsperadoEPrazoEntre1e3Dias()
        {
            /* Regras:
             * Valor = (Peso × 2.0) + (Distância × 0.8) + TaxaFixaExpressa 
             * Prazo estimado: 1 a 3 dias úteis
             */

            //arrange
            var pesoEmKg = 10.0M;
            var distanciaEmKm = 20.0M;
            var valorEsperado = 46.0M;

            //act
            var frete = new FreteExpresso(pesoEmKg, distanciaEmKm);

            //assert
            Assert.Equal(valorEsperado, frete.Valor);
            Assert.InRange(frete.PrazoEntrega.NumeroMinimoDias, 1, 1);
            Assert.InRange(frete.PrazoEntrega.NumeroMaximoDias, 3, 3);
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Expressa")]
        public void CalculoFrete_QuandoPesoForNegativo_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = -0.01M;
            var distanciaEmKm = 9M;

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var frete = new FreteExpresso(pesoEmKg, distanciaEmKm);
            });
        }

        [Fact]
        [Trait("Teste Unitário", "Modalidade Expressa")]
        public void CalculoFrete_QuandoDistanciaForNegativa_DeveLancarExcecao()
        {
            //arrange
            var pesoEmKg = -1000.2M;
            var distanciaEmKm = 0.5M;

            //act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var frete = new FreteExpresso(pesoEmKg, distanciaEmKm);
            });
        }
    }
}
