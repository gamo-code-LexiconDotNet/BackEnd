﻿using Back_End.Models;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
  public class DoctorController : Controller
  {
    [HttpPost]
    public IActionResult FeverCheck(double temperature, string scale)
    {
      string[] viewData = DoctorModel.FeverCheck(temperature, scale);
      ViewBag.FeverCheckMessage = viewData[0];
      ViewBag.FeverCheckColor = viewData[1];

      return View();
    }

    public IActionResult FeverCheck()
    {
      //if (ViewData.ContainsKey("FeverCheck"))
      //  ViewData.Remove("FeverCheck");

      return View();
    }
  }
}
