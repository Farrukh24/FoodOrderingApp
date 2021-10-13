using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Rate { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
