using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Userapp
    {
        [Key]
        public int IdUser { get; set; }
        public string NmUser { get; set; }
        public string NmEmail { get; set; }
        public string NmPassword { get; set; }
    }
}
