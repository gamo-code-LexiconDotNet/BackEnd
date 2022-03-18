using Microsoft.AspNetCore.Identity;
using System;

namespace BackEnd
{
  public class AppUser : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}
