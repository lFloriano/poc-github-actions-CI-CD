namespace CalculoFrete.Domain.ValueObjects
{
    public record PrazoEntrega
    {
        public PrazoEntrega(int numeroMinimoDias, int numeroMaximoDias)
        {
            Validar(numeroMinimoDias, numeroMaximoDias);

            NumeroMinimoDias = numeroMinimoDias;
            NumeroMaximoDias = numeroMaximoDias;
        }

        public int NumeroMinimoDias { get; set; }
        public int NumeroMaximoDias { get; set; }

        private void Validar(int numeroMinimoDias, int numeroMaximoDias)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(numeroMinimoDias);
            ArgumentOutOfRangeException.ThrowIfNegative(numeroMaximoDias);
            ArgumentOutOfRangeException.ThrowIfLessThan(numeroMaximoDias, numeroMinimoDias);
        }
    }
}
