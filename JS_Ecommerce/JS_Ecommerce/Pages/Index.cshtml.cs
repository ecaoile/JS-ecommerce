﻿using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JS_Ecommerce.Pages
{
    public class IndexModel : PageModel
    {
        public List<Item> Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // add the appropriate properties on top of the client base address.
                    client.BaseAddress = new Uri("http://jst.edchavez.com");

                    //the .Result is important for us to extract the result of the response from the call
                    var promosResponse = client.GetAsync("/api/inventory/getInventory/").Result;

                    if (promosResponse.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var promosStringResult = await promosResponse.Content.ReadAsStringAsync();

                        var inventoryArray = JsonConvert.DeserializeObject<ItemList>(promosStringResult);
                        Inventory = inventoryArray.Items;
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