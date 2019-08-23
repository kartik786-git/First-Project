using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstdotnetcore.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace firtdotnetcore
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDBContext>(options =>
            options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDBContext>();

            #region custom password validation
            //    services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //    {
            //        options.Password.RequiredLength = 10;
            //        options.Password.RequiredUniqueChars = 3;
            //        options.Password.RequireNonAlphanumeric = false;
            //    })
            //.AddEntityFrameworkStores<AppDBContext>();

            //    services.Configure<IdentityOptions>(options =>
            //    {
            //        options.Password.RequiredLength = 10;
            //        options.Password.RequiredUniqueChars = 3;
            //        options.Password.RequireNonAlphanumeric = false;
            //    });
            #endregion


            // register the mvc service 
            // services.AddMvc(); // it's call add mvc core service as well
            //services.AddMvcCore(); // it's add only core services
            //services.AddMvc().AddXmlSerializerFormatters();// for api call responce as xml

            // [Authorize] attribute is applied globally for all controller
            services.AddMvc(config => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            #region to register with dependency injection container 

            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

            //services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();

            //Benifits
            // Loose coupling
            // easy to unit testing
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                #region Custom developer exceptoin page method
                // costomize develoer exception page.
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    // set count of line how many line need to show of error up and down
                //    SourceCodeLineCount = 10
                //};
                //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
                #endregion
                app.UseDeveloperExceptionPage();
            }
            #region check your inviroment
            //else if (env.IsStaging() && env.IsProduction() && env.IsEnvironment("UAT"))
            //{

            //}
            #endregion
            #region Handle error
            else
            {

                app.UseExceptionHandler("/Error");
                // it's simple print a text error on the screen
                // Status Code: 404; Not Found
                // app.UseStatusCodePages();
                // it's replace orginal url and show the status code 302
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                // it will not be replace any url same with real error code. 
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

            }
            #endregion


            #region use multiple middle ware by the use
            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Hello World!");
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);

            //    //await context.Response.WriteAsync(_config["MyKey"]);


            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("1 mw logging information request");
            //    await next();
            //    logger.LogInformation("1 mw logging information response");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("2 mw logging information request");
            //    await next();
            //    logger.LogInformation("2 mw logging information response");
            //});
            #endregion

            #region ordering default static page 
            //app.UseDefaultFiles(); // order 1
            //app.UseStaticFiles();  // order 2
            #endregion

            #region set custom default page 
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("kkp.html");
            //app.UseDefaultFiles(defaultFilesOptions);

            //app.UseStaticFiles();
            #endregion

            #region merge usedefault and usestatic method with usefileserver
            // merge two funcation in a one fucation that name is fileserver option
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("kkp.html");
            //app.UseFileServer(fileServerOptions); // instread of app.defaultoption and app.usestatic file

            //app.UseFileServer();
            #endregion

            app.UseStaticFiles();

            #region Defualt mvc route 
            // set default route '{controller=Home}/{action=Index}/{id?}'
            //app.UseMvcWithDefaultRoute();
            #endregion

            app.UseAuthentication();

            // Routing technique
            // Conventional routing
            // Attribute routing 
            #region Conventional Routing
            app.UseMvc(Route =>
            {
                Route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion

            #region Attribute routing on controller and action lebel
            //app.UseMvc();
            #endregion


            //app.Run(async (context) =>
            //{
            //    //throw new Exception("this is error force fully");
            //    await context.Response.WriteAsync("Hello kkp!");
            //});
        }
    }
}
