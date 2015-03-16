using System;
using System.ComponentModel.DataAnnotations;

namespace AcessoCard.Models
{
    public sealed class ContatoMod : Base.BaseMod
    { 
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }
    }
}
