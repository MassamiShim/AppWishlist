using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Productstatus
    {
        [Key]
        public short CdStatus { get; set; }
        public string NmStatus { get; set; }
    }
}
