using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AcessoCard.DataBase;

namespace AcessoCard.Repository.Base
{
   public abstract class Crud<T> : Interfaces.ICrud<T> where T : class 
   {

       public void Cadastrar(T item)
       {
           using (var conexao = new BancoContext())
           {
               conexao.Set<T>().Add(item);
               conexao.SaveChanges();
           }
          
       }

       public void Atualizar(T item)
       {
           using (var conexao = new BancoContext())
           {
               conexao.Entry(item).State = EntityState.Modified;
               conexao.SaveChanges();
           }
           
          
       }

       public IEnumerable<T> Listar()
       {
           using (var conexao = new BancoContext())
           {
               var lista = conexao.Set<T>().ToList();
               return lista;
           }
           
       }

       public void Deletar(int id)
       {
           using (var conexao = new BancoContext())
           {
               var contato = GetById(id);
               if (contato == null) throw new Exception("Usuario Inexistente");
               conexao.Entry(contato).State = EntityState.Deleted;
               conexao.SaveChanges();
           }
           
       }

       public T GetById(int id)
       {
           using (var conexao = new BancoContext())
           {
               var contato = conexao.Set<T>().Find(id);
               return contato;
           }
           
       }
   }
}
