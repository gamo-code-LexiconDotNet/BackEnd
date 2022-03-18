using BackEnd.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  public class DoctorController : Controller
  {
    [HttpPost]
    public IActionResult FeverCheck(double temperature, string scale)
    {
      string[] viewData = DoctorService.FeverCheck(temperature, scale);
      ViewBag.FeverCheckMessage = viewData[0];
      ViewBag.FeverCheckColor = viewData[1];

      return View();
    }

    public IActionResult FeverCheck()
    {
      return View();
    }
  }
}
