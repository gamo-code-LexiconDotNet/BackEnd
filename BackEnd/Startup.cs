using BackEnd.Models.Data;
using BackEnd.Models.Repositories;
using BackEnd.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackEnd
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
      services.AddScoped<ICityRepository, CityRepository>();
      services.AddScoped<ICountryRepository, CountryRepository>();
      services.AddScoped<ILanguageRepository, LanguageRepository>();

      services.AddScoped<IGuessingGameService, GuessingGameService>();

      services.AddScoped<IPersonService, PersonService>();
      services.AddScoped<ICityService, CityService>();
      services.AddScoped<ICountryService, CountryService>();
      services.AddScoped<ILanguageService, LanguageService>();
      
      services.AddScoped<Models.Services.Api.ICityService, Models.Services.Api.CityService>();
      services.AddScoped<Models.Services.Api.IPersonService, Models.Services.Api.PersonService>();
      services.AddScoped<Models.Services.Api.ICountryService, Models.Services.Api.CountryService>();
      services.AddScoped<Models.Services.Api.ILanguageService, Models.Services.Api.LanguageService>();
      
      services.AddScoped<IRoleService, RoleService>();
      services.AddScoped<IApiService, ApiService>(); 

      services.AddControllersWithViews();
      services.AddRazorPages();

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
      app.UseAuthentication();
      app.UseAuthorization();

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

        endpoints.MapRazorPages();
      });
    }
  }
}
