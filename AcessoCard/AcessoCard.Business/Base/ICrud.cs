using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoCard.Business.Base
{
   public  interface ICrud<T> where T : class
   {
       void Cadastrar(T item);
       void Atualizar(T item);
       IEnumerable<T> Listar();
       void Deletar(int id);
       T GetById(int id);


   }
}
