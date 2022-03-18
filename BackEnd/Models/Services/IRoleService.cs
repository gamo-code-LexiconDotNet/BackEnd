using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Models.Services
{
  public interface IRoleService
  {
    public IEnumerable<SelectListItem> UserList { get; }
    public IEnumerable<SelectListItem> RoleList { get; }
    public bool AddAndUpdate(RoleCreateViewModel wm);
    public IEnumerable<RoleUserRoles> AllRolesWithUsers();
    public bool DeleteRole(string roleName);
    public bool RemoveRoleFromUser(string userId, string roleName);


  }
}
