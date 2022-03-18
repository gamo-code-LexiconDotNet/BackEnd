using BackEnd.Models.Services;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  [Authorize(Roles = "Admin")]
  public class RoleController : Controller
  {
    private readonly IRoleService roleService;

    public RoleController(IRoleService roleService)
    {
      this.roleService = roleService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new RoleViewModel
      {
        Roles = roleService.AllRolesWithUsers(),
        RoleList = roleService.RoleList,
        UserList = roleService.UserList
      });
    }

    [HttpPost]
    public IActionResult CreateUpdate(RoleCreateViewModel roleCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        roleService.AddAndUpdate(roleCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new RoleViewModel
      {
        Roles = roleService.AllRolesWithUsers(),
        RoleList = roleService.RoleList,
        UserList = roleService.UserList,
        roleCreateViewModel = roleCreateViewModel
      });
    }

    [HttpGet]
    public IActionResult DeleteRole(string roleName)
    {
      if (roleService.DeleteRole(roleName))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }

    [HttpGet]
    public IActionResult RemoveUser(string userId, string roleName)
    {
      if (roleService.RemoveRoleFromUser(userId, roleName))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }
  }
}
