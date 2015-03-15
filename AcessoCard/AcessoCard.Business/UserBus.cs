using System.Collections.Generic;
using AcessoCard.Models;
using AcessoCard.Repository;

namespace AcessoCard.Business
{
    public sealed class UserBus : Base.ICrud<UserMod>
    {
        public void Cadastrar(UserMod item)
        {
            new UserRep().Cadastrar(item);
        }

        public void Atualizar(UserMod item)
        {
            new UserRep().Atualizar(item);
        }

        public IEnumerable<UserMod> Listar()
        {
            return new UserRep().Listar();
        }

        public void Deletar(int id)
        {
            new UserRep().Deletar(id);
        }

        public UserMod GetById(int id)
        {
            return new UserRep().GetById(id);
        }
       
    }
}
