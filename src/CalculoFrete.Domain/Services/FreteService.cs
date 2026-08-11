using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public class FreteService : IFreteService
    {
        public async Task<decimal> CalcularDistanciaEmKm(Cep cepOrigem, Cep cepDestino)
        {
            return await GerarNumeroAleatorioParaSimulacao();
        }

        private Task<decimal> GerarNumeroAleatorioParaSimulacao()
        {
            var random = new Random();
            return Task.FromResult((decimal)(random.Next(1, 51)));
        }
    }
}
