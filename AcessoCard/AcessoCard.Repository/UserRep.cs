using System.Linq;
using AcessoCard.DataBase;
using AcessoCard.Models;
using AcessoCard.Repository.Base;

namespace AcessoCard.Repository
{
    public sealed class UserRep : Crud<UserMod>
    {
        public UserMod GetUser(string email)
        {
            using (var conexao = new BancoContext())
            {
                var consulta = conexao.Usuarios.FirstOrDefault(m => m.Email == email);
                return consulta;
            }
        }

        public UserMod VerificarUsuario(UserMod usuario)
        {
            using (var conexao = new BancoContext())
            {
                var consulta = conexao.Usuarios.FirstOrDefault(m => m.Email == usuario.Email && m.Senha == usuario.Senha);
                return consulta ;
            }
        }
    }
}
