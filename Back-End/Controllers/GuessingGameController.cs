using Back_End.Models;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Back_End.Controllers
{
  public class GuessingGameController : Controller
  {
    private readonly IGuessingGame guessingGame;

    public GuessingGameController(IGuessingGame guessingGame)
    {
      this.guessingGame = guessingGame;
    }

    public IActionResult Index()
    {
      guessingGame.SetupPlay();

      return View(new GuessingGameViewModel
      {
        Guessed = new List<int>(),
        GuessedHidden = JsonSerializer.Serialize(new List<int>()),
        HighScore = guessingGame.HighScore,
        Tries = 0,
        Message = "Guess a number between 1 and 100",
        Win = false
      });
    }

    [HttpPost]
    public IActionResult Index(int guess, string guessedHidden, int tries)
    {
      guessingGame.PlayRound(guess, guessedHidden, tries);

      return View(new GuessingGameViewModel
      {
        Guessed = guessingGame.Guessed,
        GuessedHidden = guessingGame.GuessedHidden,
        HighScore = guessingGame.HighScore,
        Tries = guessingGame.Tries,
        Message = guessingGame.Message,
        Win = guessingGame.Win
      });
    }
  }
}
