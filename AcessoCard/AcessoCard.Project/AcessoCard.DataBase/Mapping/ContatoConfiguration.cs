using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Models;

namespace AcessoCard.DataBase.Mapping
{
    public class ContatoConfiguration : EntityTypeConfiguration<ContatoMod>
    {
        public ContatoConfiguration()
        {
            ToTable("TB_CONTATO")
                .HasKey(x => x.Id);

            Property(m => m.Nome)
                .HasColumnName("NM_NOME")
                .HasMaxLength(200)
                .IsRequired();

            Property(m => m.Telefone)
                .HasColumnName("DS_TELEFONE")
                .HasMaxLength(200)
                .IsRequired();
            Property(m => m.Email)
                .HasColumnName("DS_EMAIL")
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
