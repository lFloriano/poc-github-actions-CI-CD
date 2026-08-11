using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Tests
{
    public class PrazoEntregaTests
    {
        [Fact]
        [Trait("Teste Unitário", "Prazo de Entrega")]
        public void PrazoDeEntrega_QuandoDataMinimaNegativa_DeveLancarException()
        {
            //act + arrange + assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new PrazoEntrega(-1, 5);
            });
        }

        [Fact]
        [Trait("Teste Unitário", "Prazo de entrega")]
        public void PrazoDeEntrega_QuandoDataMaximaNegativa_DeveLancarException()
        {
            //act + arrange + assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new PrazoEntrega(5, -8);
            });
        }

        [Fact]
        [Trait("Teste Unitário", "Prazo de Entrega")]
        public void PrazoDeEntrega_QuandoDataMinimaForMaiorQueDataMaxima_DeveLancarException()
        {
            //act + arrange + assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                new PrazoEntrega(10, 8);
            });
        }
    }
}
