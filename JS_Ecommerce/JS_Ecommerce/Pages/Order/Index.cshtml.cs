using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JS_Ecommerce.Pages.Order

{
    public class IndexModel : PageModel
    {
        public List<Item> Inventory { get; set; }

        public SubmittedOrder SubmittedOrder { get; set; }

        public CompletedOrder CompletedOrder { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://jst.edchavez.com");

                    var promosResponse = client.GetAsync("/api/inventory/getInventory/").Result;

                    if (promosResponse.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var promosStringResult = await promosResponse.Content.ReadAsStringAsync();

                        var inventoryArray = JsonConvert.DeserializeObject<ItemList>(promosStringResult);
                        Inventory = inventoryArray.Items;
                        return Page();
                    }

                    return RedirectToPage("/Index");
                }
                catch
                {
                    return RedirectToPage("/Error");
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Note: I am filling filling the OrderPost object with pre-determined data
            // due to time constraints. However, normally one would gather the data from the form
            // to calculate costs.
            SubmittedOrder = new SubmittedOrder
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

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://jst.edchavez.com");

                    var response = await client.PostAsJsonAsync($"/api/order/", SubmittedOrder);

                    if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var completedOrderStringResult = await response.Content.ReadAsStringAsync();
                        CompletedOrder = JsonConvert.DeserializeObject<CompletedOrder>(completedOrderStringResult);

                        return RedirectToPage("/Order/Complete", CompletedOrder);
                    }

                    return Page();
                }
            }
            catch
            {
                return RedirectToPage("/Error");
            }
        }
    }
}