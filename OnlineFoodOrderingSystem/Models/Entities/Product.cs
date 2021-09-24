using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int FoodPlaceId { get; set; }
        public FoodPlace Place { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }       
    }
}
