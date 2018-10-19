using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Ecommerce.Models
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [Display(Name="Item ID")]
        public string ItemId { get; set; }
        [Display(Name="In Stock")]
        public bool InStock { get; set; }
    }
}
