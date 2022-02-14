using Back_End.Models.Data;
using Back_End.Models.Repositories;
using Back_End.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Back_End
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(Configuration.GetConnectionString("LexiconDevDatabase")));

      // services.AddSingleton<IPersonRepository, InMemoryPersonRepository>();
      services.AddScoped<IPersonRepository, PersonRepository>();
      services.AddScoped<IGuessingGameService, GuessingGameService>();
      services.AddScoped<IPersonService, PersonService>();

      services.AddControllersWithViews();

      services.AddHttpContextAccessor();
      services.AddMemoryCache();
      services.AddSession();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();

      app.UseSession();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "FeverCheck",
          pattern: "FeverCheck",
          defaults: new { controller = "Doctor", action = "FeverCheck" });

        endpoints.MapControllerRoute(
          name: "GuessingGame",
          pattern: "GuessingGame",
          defaults: new { controller = "GuessingGame", action = "index" });

        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
