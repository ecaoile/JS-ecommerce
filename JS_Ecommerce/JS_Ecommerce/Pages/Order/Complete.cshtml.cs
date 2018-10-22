using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JS_Ecommerce.Pages.Order
{
    public class CompleteModel : PageModel
    {
        public CompletedOrder CompletedOrder { get; set; }

        public IActionResult OnGet(CompletedOrder completedOrder)
        {
            CompletedOrder = completedOrder;

            // I know this is hacky, but this is a workaround to transfer data since we aren't
            // using a server to hold the order data that we can grab again on a new page.
            CompletedOrder.SubmittedOrder = new SubmittedOrder
            {
                MerchantId = "sample string 1",
                OrderItems = new List<OrderItem>
                {
                    new OrderItem
                    {
                        QtyOrdered = 1,
                        Name = "Jon Snow Life 3",
                        Description = "This is Jon's life no. 3",
                        Price = 299,
                        ItemId = "Sku-02"
                    },

                    new OrderItem
                    {
                        QtyOrdered = 2,
                        Name = "Jon Snow Life 5",
                        Description = "sample string 3",
                        Price = 499,
                        ItemId = "Sku-04"
                    },
                },

                Promotion = new Promo
                {
                    OrderSubTotal = 1297,
                    PromoAmt = 20.0,
                    PromoId = "Promo-02",
                    PromotionName = "Percentage Value Promo",
                    Start = "09/01/2017",
                    End = "12/31/2017",
                    MinimumOrderValue = 1000.0,
                    PromotionType = "PercentOff"
                },

                TaxTotal = 200,
                ShippingTotal = 300,
                DiscountTotal = 259,
                MerchantOrderReference = "Some Reference",
                OrderDate = (int)Math.Floor((double)DateTime.Now.Ticks / 1000),
                Signature = "Unused. A digital signature for this object"
            };
            return Page();
        }
    }
}