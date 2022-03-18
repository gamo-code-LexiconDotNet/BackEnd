using BackEnd.Models.Services;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
  public class GuessingGameController : Controller
  {
    private readonly IGuessingGameService guessingGame;

    public GuessingGameController(IGuessingGameService guessingGame)
    {
      this.guessingGame = guessingGame;
    }

    [HttpGet]
    public IActionResult Index()
    {
      guessingGame.SetupPlay();

      return View(new GuessingGameViewModel
      {
        Guessed = new List<int>(),
        HighScore = guessingGame.HighScore,
        Tries = 0,
        Message = "Guess a number between 1 and 100",
        Win = false
      });
    }

    [HttpPost]
    public IActionResult Index(int guess)
    {
      guessingGame.PlayRound(guess);

      return View(new GuessingGameViewModel
      {
        Guessed = guessingGame.GuessedNumbers,
        HighScore = guessingGame.HighScore,
        Tries = guessingGame.Tries,
        Message = guessingGame.Message,
        Win = guessingGame.Win
      });
    }
  }
}
