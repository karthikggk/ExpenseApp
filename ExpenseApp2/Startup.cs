using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ServiceConfiguration;
using ExpensApp.Utilities;

namespace ExpenseApp2
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      var autoMapperCofig = new AutoMapper.MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new Business_RepoMapperProfileConfig());
        cfg.AddProfile(new View_BusinessMapperProfileConfig());
      });
      services.AddDbContext<ExpenseDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")));
      services.AddSingleton(_ => Configuration);
      services.AddSingleton(_ => autoMapperCofig.CreateMapper());
      services.AddMvc().AddJsonOptions(options => {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      });
      services.RegisterServices();
      services.RegisterRepositories();
      services.AddMvc();
    }

    public Startup(IConfiguration configuration)
    {
      //var builder = new ConfigurationBuilder()
      //  .SetBasePath(env.ContentRootPath)
      //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      //  .AddEnvironmentVariables();
      //Configuration = builder.Build();
      Configuration = configuration;
    }
    private IConfiguration Configuration { get; set; }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //app.Run(async (context) =>
      //{
      //    await context.Response.WriteAsync("Hello World!");
      //});
      app.UseMvc();
      //app.Use(async (context, next) =>
      //{
      //  await next();
      //  if (context.Response.StatusCode == 404 &&
      //        !Path.HasExtension(context.Request.Path.Value) &&
      //        !context.Request.Path.Value.StartsWith("/api/"))
      //  {
      //    context.Request.Path = "/index.html";
      //    await next();
      //  }


      //});
      //var mapPrefix = Configuration["RouteMapping:MapPrefix"];
      //app.Map($"/{mapPrefix}", a =>
      //{
      //  a.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      //  a.UseMvc(routes =>
      //  {
      //    routes.MapRoute(
      //        name: "default",
      //        template: "{controller=Home}/{action=Index}/{id?}");
      //  });
      //});
      app.UseMvcWithDefaultRoute();

      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
