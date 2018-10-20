using System.ComponentModel.DataAnnotations;

namespace JS_Ecommerce.Models
{
    public class ShippingOpt
    {
        [Display(Name = "ID")]
        public string ShipOptionId { get; set; }

        [Display(Name = "Shipping Option Name")]
        public string ShipOptionName { get; set; }

        [Display(Name = "Carrier Name")]
        public string CarrierName { get; set; }

        [Display(Name = "Cost")]
        public int ShipCost { get; set; }
    }
}