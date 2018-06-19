using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }
        public string NmProduct { get; set; }
        public short IdTypeProduct { get; set; }
        public long IdItem { get; set; }
    }
}
