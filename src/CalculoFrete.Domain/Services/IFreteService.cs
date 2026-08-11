using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain.Services
{
    public interface IFreteService
    {
        public Task<decimal> CalcularDistanciaEmKm(Cep cepOrigem, Cep cepDestino);
    }
}
