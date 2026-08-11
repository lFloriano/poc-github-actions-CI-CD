namespace CalculoFrete.Domain.ValueObjects
{
    public class Cep
    {
        //Classe simplificada para evitar complexidade desnecessária
        public Cep(string numero)
        {
            Validar(numero);

            Numero = numero;
        }

        public string Numero { get; private set; }

        private void Validar(string numero)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(numero);
        }
    }
}
