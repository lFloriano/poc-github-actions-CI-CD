using CalculoFrete.Core.Domain;
using CalculoFrete.Domain.ValueObjects;

namespace CalculoFrete.Domain
{
    public class Produto : Entity
    {
        public Produto(string nome, decimal pesoEmKg, Cep cepCentroDistribuicao)
        {
            Nome = nome;
            PesoEmKg = pesoEmKg;
            CepCentroDistribuicao = cepCentroDistribuicao;
        }

        public string Nome { get; private set; }
        public decimal PesoEmKg { get; private set; }
        public Cep CepCentroDistribuicao { get; private set; }

        //Demais propriedades foram omitidas por não serem relevantes ao desafio tecnico
    }
}
