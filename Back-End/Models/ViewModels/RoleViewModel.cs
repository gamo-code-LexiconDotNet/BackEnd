using Back_End.Models.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.ViewModels
{
  public class RoleViewModel
  {
    public RoleViewModel() { }
    public IEnumerable<UserRoles> Roles { get; set; }
    public IEnumerable<SelectListItem> RoleList { get; set; }
    public IEnumerable<SelectListItem> UserList { get; set; }
    public RoleCreateViewModel roleCreateViewModel;
  }
}
