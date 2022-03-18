using System;
using BackEnd;
using BackEnd.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BackEnd.Areas.Identity.IdentityHostingStartup))]
namespace BackEnd.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
        services.AddDbContext<IdentityDbContext>(options =>
          options.UseSqlServer(
            context.Configuration
              .GetConnectionString("LexiconDevAuthenticationDatabase")));

        services.AddIdentity<AppUser, IdentityRole>(options =>
          options.SignIn.RequireConfirmedAccount = true)
          .AddEntityFrameworkStores<IdentityDbContext>()
          .AddDefaultUI()
          .AddDefaultTokenProviders();

        services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, 
          AppUserClaimsPrinicipalFactory>();
      });
    }
  }
}