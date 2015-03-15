using System;
using System.ComponentModel.DataAnnotations;

namespace AcessoCard.Models
{
   public sealed class UserMod : Base.BaseMod
    {
       [Required(ErrorMessage = "Campo Obrigatório")]
       [EmailAddress(ErrorMessage = "Digite um Email Valido!")]
       public String Email { get; set; }

       [Required(ErrorMessage = "Campo Obrigatório")]
       public String Senha { get; set; }
    }
}
