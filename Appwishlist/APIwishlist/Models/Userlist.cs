using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class UserList
    {
        [Key]
        public int IdList { get; set; }
	    public int IdUser { get; set; }
	    public string NmList { get; set; }
    }
}
