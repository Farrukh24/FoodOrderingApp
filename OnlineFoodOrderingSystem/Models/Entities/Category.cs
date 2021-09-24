﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<FoodPlace> Places { get; set; }
    }
}
