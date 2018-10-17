using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JS_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace JS_Ecommerce.Pages
{
    public class IndexModel : PageModel
    {
        public List<Promo> Promos { get; set; }
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // add the appropriate properties on top of the client base address.
                    client.BaseAddress = new Uri("http://jst.edchavez.com");

                    //the .Result is important for us to extract the result of the response from the call
                    var promosResponse = client.GetAsync("/api/promo/").Result;

                    if (promosResponse.EnsureSuccessStatusCode().IsSuccessStatusCode)
                    {
                        var promosStringResult = await promosResponse.Content.ReadAsStringAsync();

                        //TodoList datTodoList = JsonConvert.DeserializeObject<TodoList>(listStringResult);
                        Promos = JsonConvert.DeserializeObject<List<Promo>>(promosStringResult);

                        //List<TodoItem> matchedItems = demTodoItems.Where(i => i.DatListID == id).ToList();

                        //datTodoList.TodoItems = matchedItems;
                        //return View(datTodoList);
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