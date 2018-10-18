using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JS_Ecommerce.Pages.Promotions
{
    public class DetailsModel : PageModel
    {
        public Promo DetailedPromo { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("/Promotions");
            }

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri($"http://jst.edchavez.com/");

                    var promosResponse = client.GetAsync($"/api/promo/{id}").Result;

                    if (promosResponse.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var promosStringResult = await promosResponse.Content.ReadAsStringAsync();

                        DetailedPromo = JsonConvert.DeserializeObject<Promo>(promosStringResult);
                    }

                    return Page();
                }

                catch
                {
                    return RedirectToAction("/Error");
                }
            }
        }
    }
}