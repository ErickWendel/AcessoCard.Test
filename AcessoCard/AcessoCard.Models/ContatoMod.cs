using System;
using System.ComponentModel.DataAnnotations;

namespace AcessoCard.Models
{
    public sealed class ContatoMod : Base.BaseMod
    {
        //        Nome do contato, e-mail e telefone.
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }
    }
}
