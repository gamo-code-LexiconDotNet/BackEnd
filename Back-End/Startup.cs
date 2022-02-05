using Back_End.Models.Repositories;
using Back_End.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Back_End
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<IGuessingGameService, GuessingGameService>();
      services.AddSingleton<IPersonRepository, InMemoryPersonRepository>();
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
