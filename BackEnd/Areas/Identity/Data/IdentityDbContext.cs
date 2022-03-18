using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
  public class IdentityDbContext : IdentityDbContext<AppUser>
  {
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      string adminRoleId = Guid.NewGuid().ToString("D");
      string adminId = Guid.NewGuid().ToString("D");

      builder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
          Id = adminRoleId,
          Name = "Admin",
          NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
          Id = Guid.NewGuid().ToString("D"),
          Name = "User",
          NormalizedName = "USER"
        });

      builder.Entity<AppUser>().HasData(new AppUser
      {
        Id = adminId,
        Email = "admin@admin.com",
        NormalizedEmail = "ADMIN@ADMIN.COM",
        UserName = "admin@admin.com",
        NormalizedUserName = "ADMIN@ADMIN.COM",
        PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "password"),
        FirstName = "Admin",
        LastName = "Nimda",
        BirthDate = DateTime.Now,
        EmailConfirmed = true
      });

      builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
      {
        UserId = adminId,
        RoleId = adminRoleId
      });
    }
  }
}
