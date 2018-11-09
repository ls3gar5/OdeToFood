using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace OdeToFood
{
    public class Startup
    {


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //We register Greerter Service and ASP.CORE do injection dependeces
            services.AddSingleton<IGreeter, Greeter>();

            services.AddMvc();
        }

        // This method gets called by the runtime. 
        //Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app
                            , IHostingEnvironment env
                            , IConfiguration configuration
                            , IGreeter greeter
                            , ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseWelcomePage();

            app.UseWelcomePage(new WelcomePageOptions()
            {
                Path = "/wp"
            });


            //app.UseDefaultFiles(); //indicate that use file into wwwtoot that mach de name.
            //app.UseStaticFiles();
            //app.UseFileServer(); //this group both function

            app.UseMvcWithDefaultRoute(); //this means that have route configuration
            //app.UseMvc(ConfigureRoutes);

            //this methods is only invoke once and more frequebcy used.
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request incoming");

            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hits!!!");

            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };
            //});


            //SIMPLE RESPONSE
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay(); //configuration["Greeting"];
                var message = $"{ greeting} : {env.EnvironmentName}";
                //I configure contenct type if in the browser thas not apperar the text correctly. 
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(message);
            });

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            /// e.g. /Home/Index {controller} asp find class name HomeController and second {action} inside
            /// the controller a method name Iindex and the last parameter with ? indicate that is optional.
            /// If the controler name is empty by default take the name Home and the same for action.

            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
