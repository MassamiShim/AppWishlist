﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIwishlist.Models
{
    public class Listproduct
    {
        public int IdList { get; set; }
        public int IdProduct { get; set; }
        public short CdStatus { get; set; }
    }
}
