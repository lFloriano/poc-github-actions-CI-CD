using System.ComponentModel.DataAnnotations;

namespace CalculoFrete.Domain.Enums
{
    public enum ModalidadeFrete
    {
        [Display(Name ="Normal")]
        Normal = 1,

        [Display(Name = "Expresso")]
        Expresso = 2,

        [Display(Name = "Agendado")]
        Agendado = 3
    }
}
