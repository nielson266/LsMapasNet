using LsMapasNet.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace LsMapasNet.EntidadeConfig
{
    public class MapasConfig : EntityTypeConfiguration<Mapas>
    {
        public MapasConfig()
        {
            HasKey(x => x.id);

            Property(x => x.desc_mapa)
                .HasColumnName("desc_mapa");

            Property(x => x.obs)
                .HasColumnName("obs");
            Property(x => x.centromapa_lat)
                .HasColumnName("centromapa_lat");
            Property(x => x.centromapa_lat)
                .HasColumnName("centromapa_long");
            Property(x => x.id_surdo)
                .HasColumnName("id_surdo");
            Property(x => x.zoommapa)
               .HasColumnName("zoommapa")
               .HasPrecision(7, 2);
        }
        
    }
}