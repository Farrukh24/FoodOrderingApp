using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Models.Entities
{
    public class FoodPlace
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string SmallDescription { get; set; }
        public string FoodPictureUrlPath { get; set; }
        public string BrandPictureUrlPath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
