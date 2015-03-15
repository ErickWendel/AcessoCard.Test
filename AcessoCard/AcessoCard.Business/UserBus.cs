using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Models;
using AcessoCard.Service.Repository;

namespace AcessoCard.Business
{
    public sealed class UserBus : Contracts.Base.ICrud<UserMod>
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
