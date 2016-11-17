using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LsMapasNet.EntidadeConfig
{
    public class MapasConfig : EntityTypeConfiguration<Mapas>
    {
        public MapasConfig()
        {
            HasKey(x => x.id).Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.desc_mapa)
                .HasColumnName("desc_mapa");

            Property(x => x.obs)
                .HasColumnName("obs")
                .HasMaxLength(100);
            Property(x => x.centromapa_lat)
                .HasColumnName("centromapa_lat")
                .HasMaxLength(15);
            Property(x => x.centromapa_long)
                .HasColumnName("centromapa_long")
                .HasMaxLength(15);
            Property(x => x.id_surdo)
                .HasColumnName("id_surdo");
            Property(x => x.zoommapa)
               .HasColumnName("zoommapa")
               .HasPrecision(7, 2);
        }
        
    }
}