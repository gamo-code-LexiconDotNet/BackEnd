using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public class RoleUserRoles
  {
    public string Role { get; set; }
    public IEnumerable<AppUser> Users { get; set; }
  }
}
