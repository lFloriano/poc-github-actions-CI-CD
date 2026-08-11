namespace CalculoFrete.Domain.ValueObjects
{
    public record FreteAgendado : Frete
    {
        public FreteAgendado(
            decimal pesoEmKg,
            decimal distanciaEmKm,
            DateOnly? dataAgendamento) : base(pesoEmKg, distanciaEmKm)
        {
            ValidarData(dataAgendamento);
            DataAgendamento = dataAgendamento.Value;
        }

        protected override decimal TaxaFixa => 7;
        protected DateOnly DataAgendamento { get; set; }

        public override PrazoEntrega PrazoEntrega
        {
            get
            {
                var numeroDiasParaEntrega = DataAgendamento.ToDateTime(TimeOnly.MinValue) - DateTime.Now.Date;
                return new PrazoEntrega(numeroDiasParaEntrega.Days, numeroDiasParaEntrega.Days);
            }
        }

        public override decimal Valor => (PesoEmKg * 1.5M) + (DistanciaEmKm * 0.6M) + TaxaFixa;

        private void ValidarData(DateOnly? dataAgendamento)
        {
            var dataAtual = DateOnly.FromDateTime(DateTime.Now);
            ArgumentNullException.ThrowIfNull(dataAgendamento);
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(dataAgendamento.Value, dataAtual, "Data do Agendamento");
        }
    }
}


