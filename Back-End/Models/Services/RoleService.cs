using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Services
{
  public class RoleService : IRoleService
  {
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<AppUser> userManager;

    public RoleService(RoleManager<IdentityRole> roleManager,
      UserManager<AppUser> userManager)
    {
      this.roleManager = roleManager;
      this.userManager = userManager;
    }

    public IEnumerable<RoleUserRoles> AllRolesWithUsers()
    {
      return new List<RoleUserRoles>(
        roleManager.Roles.Select(r =>
          new RoleUserRoles
          {
            Role = r.Name,
            Users = userManager.GetUsersInRoleAsync(r.Name).Result
          }).OrderBy(ur => ur.Role));
    }

    public bool AddAndUpdate(RoleCreateViewModel vm)
    {
      bool hasUserId = !string.IsNullOrEmpty(vm.UserId);
      bool hasNewRoleName = !string.IsNullOrEmpty(vm.NewRoleName);
      bool hasRoleName = !string.IsNullOrEmpty(vm.RoleName);

      // create role
      if (hasNewRoleName && !hasRoleName)
        if (!CreateRole(vm.NewRoleName))
          return false;

      // update role name
      if (hasNewRoleName && hasRoleName)
        if (!UpdateRole(vm.RoleName, vm.NewRoleName))
          return false;

      // add user to role
      if (hasUserId && (hasRoleName || hasNewRoleName))
        return AddRoleToUser(vm.UserId, hasNewRoleName ? vm.NewRoleName : vm.RoleName);

      return false;
    }

    public bool AddRoleToUser(string userId, string roleName)
    {
      AppUser user = userManager.FindByIdAsync(userId).Result;
      if (user == null)
        return false;
      if (!userManager.AddToRoleAsync(user, roleName).Result.Succeeded)
        return false;
      return true;
    }

    public bool RemoveRoleFromUser(string userId, string roleName)
    {
      AppUser user = userManager.FindByIdAsync(userId).Result;
      if (user == null)
        return false;
      if (!userManager.RemoveFromRoleAsync(user, roleName).Result.Succeeded)
        return false;
      return true;
    }

    public bool DeleteRole(string roleName)
    {
      IdentityRole roleToDelete = roleManager.FindByNameAsync(roleName).Result;

      if (roleToDelete == null)
        return false;

      return roleManager.DeleteAsync(roleToDelete).Result.Succeeded;
    }

    public bool CreateRole(string name)
    {
      IdentityResult role = roleManager.CreateAsync(new IdentityRole
      {
        Name = name,
        NormalizedName = name.ToUpper()
      }).Result;

      if (role != null || role.Succeeded == true)
        return true;

      return false;
    }

    public bool UpdateRole(string roleName, string newRoleName)
    {
      IdentityRole role = roleManager.FindByNameAsync(roleName).Result;
      if (role == null)
        return false;

      role.Name = newRoleName;
      role.NormalizedName = newRoleName.ToUpper();

      if (roleManager.UpdateAsync(role).Result.Succeeded)
        return true;

      return false;
    }

    public IEnumerable<SelectListItem> UserList
    {
      get
      {
        List<SelectListItem> ul = 
          new SelectList(userManager.Users, "Id", "UserName")
          .OrderBy(i => i.Text).ToList();
        ul.Insert(0, new SelectListItem { Value = "", Text = "Choose User" });
        return ul;
      }
    }

    public IEnumerable<SelectListItem> RoleList
    {
      get
      {
        List<SelectListItem> rl = 
          new SelectList(roleManager.Roles, "Name", "Name")
          .OrderBy(i => i.Text).ToList();
        rl.Insert(0, new SelectListItem { Value = "", Text = "Choose Role" });
        return rl;
      }
    }
  }
}
