using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LsMapasNet.EntidadeConfig
{
    public class SurdoConfig : EntityTypeConfiguration<Surdo>
    {
        public SurdoConfig()
        {
            HasKey(x => x.id).Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.nome)
                .HasColumnName("nome")
                .HasMaxLength(100);

            Property(x => x.endereco)
                .HasColumnName("endereco")
                .HasMaxLength(100);

            Property(x => x.perimetro)
                .HasColumnName("perimetro")
                .HasMaxLength(100);

            Property(x => x.classe)
                .HasColumnName("classe")
                .HasMaxLength(1);

            Property(x => x.latitude)
                .HasColumnName("latitude")
                .HasMaxLength(15);

            Property(x => x.longitude)
                .HasColumnName("longitude")
                .HasMaxLength(15);

            Property(x => x.bairro)
                .HasColumnName("bairro")
                .HasMaxLength(30);
            Property(x => x.status)
                .HasColumnName("status")
                .HasMaxLength(1);

        }

    }
}