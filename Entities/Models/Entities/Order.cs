using Entities.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string PaymentType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(256)]
        public string Adress { get; set; }
        public string DeliverType { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Total { get; set; }
        public Status Status { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
