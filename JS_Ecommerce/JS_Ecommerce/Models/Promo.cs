﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JS_Ecommerce.Models
{
    public class Promo
    {
        public double OrderSubTotal { get; set; }
        public double PromoAmt { get; set; }

        [Display(Name="ID")]
        public string PromoId { get; set; }

        [Display(Name="Promo Name")]
        public string PromotionName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        [Display(Name="Minimum Order Value")]
        public double MinimumOrderValue { get; set; }

        [Display(Name="Promotion Type")]
        public string PromotionType { get; set; }
    }
}
