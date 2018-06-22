using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Wishlist
    {
        public int IdList { get; set; }
        public string NmList { get; set; }
        public int IdProduct { get; set; }
        public short CdStatus { get; set; }
        public string NmProduct { get; set; }
        public short IdTypeProduct { get; set; }
        public long idItem { get; set; }
    }
}
