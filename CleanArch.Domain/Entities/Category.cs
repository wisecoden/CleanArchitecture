﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public class Category
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacionamento muitos-para-muitos com Product
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
