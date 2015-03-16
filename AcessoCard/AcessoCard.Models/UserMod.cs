using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessoCard.Models
{
   public sealed class UserMod : Base.BaseMod
    {

       [Required(ErrorMessage = "Campo Obrigatório")]
       //[Compare("ConfirmarSenha", ErrorMessage = "Digite Novamente sua senha")]
       public String Senha { get; set; }

       [NotMapped]
       public String ConfirmarSenha { get; set; }
        
    }
}
