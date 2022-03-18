using BackEnd.Models.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.ViewModels
{
  public class RoleViewModel
  {
    public RoleViewModel() { }
    public IEnumerable<RoleUserRoles> Roles { get; set; }
    public IEnumerable<SelectListItem> RoleList { get; set; }
    public IEnumerable<SelectListItem> UserList { get; set; }
    public RoleCreateViewModel roleCreateViewModel;
  }
}
