using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LsMapasNet.Entidade
{
    public class Mapas
    {
        public int id { get; set; }
        public string desc_mapa { get; set; }
        public string obs { get; set; }
        public string centromapa_lat { get; set; }
        public string centromapa_long { get; set; }
        public int id_surdo { get; set; }
        public decimal zoommapa { get; set; }
    }
}