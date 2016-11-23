using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LsMapasNet.Entidade
{
    public class Mapas
    {
        public int id { get; set; }
        [Required]
        public string desc_mapa { get; set; }
        [Required]
        public string obs { get; set; }
        public string centromapa_lat { get; set; }
        public string centromapa_long { get; set; }
        public int id_surdo { get; set; }
        [Required]
        [Range(0, 25, ErrorMessage = "O valor digitado pode ser 0 até 25")]
        [DataType(DataType.Currency)]
        [DisplayFormat(NullDisplayText = "n/a", ApplyFormatInEditMode = true, DataFormatString = "{0:n2}")]
        public decimal zoommapa { get; set; }
    }
}
