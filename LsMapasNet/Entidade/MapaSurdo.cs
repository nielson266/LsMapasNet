using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LsMapasNet.Entidade
{
    public class MapaSurdo
    {
        public int id { get; set; }
        public int idMapa{get;set;}
        public virtual Mapas id_mapa { get; set; }
        public int idSurdo { get; set; }
        public virtual Surdo id_surdo { get; set; }
    }
}