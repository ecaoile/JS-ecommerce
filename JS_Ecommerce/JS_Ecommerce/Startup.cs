using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace JS_Ecommerce
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    namespace RazorPagesContacts
    {
        public class Startup
        {

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddMvc();
            }
            

            public void Configure(IApplicationBuilder app)
            {
                app.UseStaticFiles();
                app.UseMvcWithDefaultRoute();

                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Oops, something went wrong");
                });
            }
        }
    }
}
