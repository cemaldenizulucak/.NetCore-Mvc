﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOrnek.Models.ViewModels
{
    public class CategoryProduct
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
