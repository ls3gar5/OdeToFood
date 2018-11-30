using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Data;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //We register Greerter Service and ASP.CORE do injection dependeces
            services.AddSingleton<IGreeter, Greeter>();
            //AddScoped instance for each HTTP request, one single thread
            //AddSingleton one instance for all app "NOT USE for this case"
            services.AddScoped<IRestorantData, SqlRestaurantData>();
            services.AddDbContext<OdoToFoodDbContext>(options => 
                    options.UseSqlServer(_configuration.GetConnectionString("OdoToFood")));

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

            //app.UseWelcomePage(new WelcomePageOptions()
            //{
            //    Path = "/wp"
            //});


            //app.UseDefaultFiles(); //indicate that use file into wwwtoot that mach de name.
            //app.UseStaticFiles();
            //app.UseFileServer(); //this group both function

            //app.UseMvcWithDefaultRoute(); //this means that have route configuration
            app.UseMvc(ConfigureRoutes);

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


            ////SIMPLE RESPONSE
            //app.Run(async (context) =>
            //{
            //    //var greeting = greeter.GetMessageOfTheDay(); //configuration["Greeting"];
            //    //var message = $"{ greeting} : {env.EnvironmentName}";
            //    ////I configure contenct type if in the browser thas not apperar 
            //    ////the text correctly. 
            //    //context.Response.ContentType = "text/plain";
            //    //await context.Response.WriteAsync(message);
            //    context.Response.Redirect("badrequestresponse");
            //});

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
