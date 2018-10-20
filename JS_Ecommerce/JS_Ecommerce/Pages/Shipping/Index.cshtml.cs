using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JS_Ecommerce.Pages.Shipping
{
    public class IndexModel : PageModel
    {
        public List<ShippingOpt> ShippingOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // add the appropriate properties on top of the client base address.
                    client.BaseAddress = new Uri("http://jst.edchavez.com");

                    //the .Result is important for us to extract the result of the response from the call
                    var shippingResponse = client.GetAsync("/api/shipping/").Result;

                    if (shippingResponse.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var shippingStringResult = await shippingResponse.Content.ReadAsStringAsync();

                        ShippingOptions = JsonConvert.DeserializeObject<List<ShippingOpt>>(shippingStringResult);
                    }

                    return Page();
                }
                catch
                {
                    return RedirectToPage("/Error");
                }
            }
        }
    }
}