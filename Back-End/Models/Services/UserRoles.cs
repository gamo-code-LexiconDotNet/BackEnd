using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public class UserRoles
  {
    public string Role { get; set; }
    public IEnumerable<AppUser> Users { get; set; }
  }
}
