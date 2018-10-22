using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Ecommerce.Models
{
    public class OrderItem
    {
        public int QtyOrdered { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ItemId { get; set; }
    }
}
