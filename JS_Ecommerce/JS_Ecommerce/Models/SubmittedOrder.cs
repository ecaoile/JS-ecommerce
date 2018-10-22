using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Ecommerce.Models
{
    public class SubmittedOrder
    {
        public string MerchantId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int TaxTotal { get; set; }
        public int ShippingTotal { get; set; }
        public int DiscountTotal { get; set; }
        public Promo Promotion { get; set; }
        public string MerchantOrderReference { get; set; }
        public int OrderDate { get; set; }
        public string Signature { get; set; }
    }
}
