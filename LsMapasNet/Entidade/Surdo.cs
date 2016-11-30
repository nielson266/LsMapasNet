using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LsMapasNet.Entidade
{
    public class Surdo
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string nome { get; set; }
        [Required]
        [StringLength(60)]
        public string endereco { get; set; }

        public string perimetro { get; set; }

        public string classe { get; set; }
        [Required]
        [StringLength(15)]
        public string latitude { get; set; }
        [Required]
        [StringLength(15)]
        public string longitude { get; set; }
        [Required]
        [StringLength(30)]
        public string bairro { get; set; }
        [Required]
        public string status { get; set; }
    }
}