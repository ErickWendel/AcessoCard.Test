using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.DataBase.Mapping;
using AcessoCard.Models;

namespace AcessoCard.DataBase
{
    public class BancoContext : DbContext
    {
        public BancoContext() : base("BancoContext")
        {
        }
        public virtual DbSet<UserMod> Usuarios { get; set; }
        public virtual DbSet<ContatoMod> Contatos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
