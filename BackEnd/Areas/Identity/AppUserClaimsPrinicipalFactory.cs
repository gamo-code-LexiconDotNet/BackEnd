using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Areas.Identity
{
  public class AppUserClaimsPrinicipalFactory
    : UserClaimsPrincipalFactory<AppUser, IdentityRole>
  {
    public AppUserClaimsPrinicipalFactory(
      UserManager<AppUser> userManager,
      RoleManager<IdentityRole> roleManager,
      IOptions<IdentityOptions> options)
      : base(userManager, roleManager, options) { }

    protected override async Task<ClaimsIdentity> 
      GenerateClaimsAsync(AppUser user)
    {
      var identity = await base.GenerateClaimsAsync(user);

      identity.AddClaim(new Claim("FirstName", user.FirstName));
      identity.AddClaim(new Claim("LastName", user.LastName));
      identity.AddClaim(new Claim("BirthDate", user.BirthDate.ToShortDateString()));

      return identity;
    }
  }
}
