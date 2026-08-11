using CalculoFrete.Domain.Enums;
using CalculoFrete.Domain.ValueObjects;

public record FreteExpresso : Frete
{
    protected override decimal TaxaFixa => 10;

    public FreteExpresso(decimal pesoEmKg, decimal distanciaEmKm) : base(pesoEmKg, distanciaEmKm) { }

    public override PrazoEntrega PrazoEntrega => new PrazoEntrega(1, 3);

    public override decimal Valor => (PesoEmKg * 2M) + (DistanciaEmKm * 0.8M) + TaxaFixa;
}