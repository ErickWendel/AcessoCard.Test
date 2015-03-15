using System;
using System.Collections.Generic;
using AcessoCard.Models;
using AcessoCard.Repository;

namespace AcessoCard.Business
{
    public sealed class ContatoBus : Contracts.Base.ICrud<ContatoMod>
    {


            public void Cadastrar(ContatoMod item)
            {
                new ContatoRep().Cadastrar(item);
            }

            public void Atualizar(ContatoMod item)
            {
                new ContatoRep().Atualizar(item); 
            }

            public IEnumerable<ContatoMod> Listar()
            {
                return new ContatoRep().Listar();
            }

            public void Deletar(int id)
            {
                new ContatoRep().Deletar(id);
            }

            public ContatoMod GetById(int id)
            {
                return new ContatoRep().GetById(id);
            }
    }
}
