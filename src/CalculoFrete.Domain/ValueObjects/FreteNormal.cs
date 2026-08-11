using CalculoFrete.Domain.Enums;

namespace CalculoFrete.Domain.ValueObjects
{
    public record FreteNormal : Frete
    {
        protected override decimal TaxaFixa => 5;

        public FreteNormal(decimal pesoEmKg, decimal distanciaEmKm) : base(pesoEmKg, distanciaEmKm) { }

        public override decimal Valor => (PesoEmKg * 1.2M) + (DistanciaEmKm * 0.5M) + TaxaFixa;

        public override PrazoEntrega PrazoEntrega => new PrazoEntrega(5, 8);
    }
}