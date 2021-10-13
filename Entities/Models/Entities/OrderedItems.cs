using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{
    public class OrderedItems
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
