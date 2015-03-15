using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Models;

namespace AcessoCard.DataBase.Mapping
{
    public class UserConfiguration : EntityTypeConfiguration<UserMod>
    {
        public UserConfiguration()
        {
            ToTable("TB_USER")
                .HasKey(m => m.Id);

            Property(m => m.Email)
                .HasColumnName("DS_EMAIL")
                .HasMaxLength(200)
                .IsRequired();

            Property(m => m.Senha)
                .HasColumnName("DS_SENHA")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
