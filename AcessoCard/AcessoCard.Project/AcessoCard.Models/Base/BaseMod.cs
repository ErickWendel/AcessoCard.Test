using System.ComponentModel.DataAnnotations;

namespace AcessoCard.Models.Base
{
    public abstract class BaseMod
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }
    }
}
