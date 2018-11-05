﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mosh_Repository_Pattern.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
