using Entities.Models.Cart;
using Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public class CheckoutViewModel
    {
        public string PaymentType { get; set; }
        public string DeliverType { get; set; }
        public User User { get; set; }
        public IEnumerable<ProductCart> CartItems { get; set; }
    }
}
