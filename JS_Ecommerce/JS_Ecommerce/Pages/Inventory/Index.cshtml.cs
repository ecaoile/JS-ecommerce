using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JS_Ecommerce.Pages.Inventory
{
    public class IndexModel : PageModel
    {

        public List<Item> Inventory { get; set; }
        public async Task OnGetAsync()
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
                        //dynamic res = inventoryArray[0];
                        //var inventoryArray = JsonConvert.DeserializeObject<List<ItemList>>(promosStringResult);
                        //Inventory = inventoryArray[0];
                    }
                }
                catch
                {
                    //return NotFound();
                }
            }
        }
    }
}