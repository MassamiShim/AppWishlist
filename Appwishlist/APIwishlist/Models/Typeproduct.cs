using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Typeproduct
    {
        [Key]
        public short IdTypeProduct { get; set; }
        public string NmTypeProduct { get; set; }
        public string NmURL { get; set; }
    }
}
