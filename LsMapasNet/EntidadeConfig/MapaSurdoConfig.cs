using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LsMapasNet.EntidadeConfig
{
    public class MapaSurdoConfig : EntityTypeConfiguration<MapaSurdo>
    {
        public MapaSurdoConfig()
        {
            HasKey(x => x.id);

            HasRequired(c => c.id_mapa)
               .WithMany()
               .HasForeignKey(c => c.idMapa);

            HasRequired(c => c.id_surdo)
               .WithMany()

               .HasForeignKey(c => c.idSurdo);
        }
    }
}