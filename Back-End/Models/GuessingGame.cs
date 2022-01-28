using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Back_End.Models
{
  public class GuessingGame : IGuessingGame
  {
    private readonly Random random = new Random();
    private readonly HttpContext httpContext = new HttpContextAccessor().HttpContext;

    public int HiddenNumber { get; set; }
    public int HighScore { get; set; }
    public string GuessedHidden { get; set; }
    public List<int> Guessed { get; set; }
    public int Tries { get; set; }
    public string Message { get; set; }
    public bool Win { get; set; }


    public int HiddenNumberInSession
    {
      get => httpContext.Session.GetInt32("GuessingGameHiddenNumber") ?? -1;
      set => httpContext.Session.SetInt32("GuessingGameHiddenNumber", value);
    }

    public int HighScoreInCookie
    {
      get
      {
        if (!int.TryParse(httpContext.Request.Cookies["GuessingGameHighScore"], out int highScore))
          highScore = 0;
        return highScore;
      }
      set => httpContext.Response.Cookies.Append("GuessingGameHighScore", value.ToString());
    }

    public void SetupPlay()
    {
      HiddenNumberInSession = random.Next(1, 101);
      Guessed = new List<int>();
      GuessedHidden = JsonSerializer.Serialize(new List<int>());
      HighScore = HighScoreInCookie;
      Tries = 0;
      Message = "Guess a number between 1 and 100";
      Win = false;
    }

    public void PlayRound(int guess, string guessedHidden, int tries)
    {
      Guessed = JsonSerializer.Deserialize<List<int>>(guessedHidden);
      HiddenNumber = HiddenNumberInSession;
      HighScore = HighScoreInCookie;
      Win = false;

      if (!Guessed.Contains(guess))
      {
        if (guess > HiddenNumber)
        {
          Message = "Your guess is too big";
        }
        else if (guess < HiddenNumber)
        {
          Message = "Your guess is too small";
        }
        else
        {
          Win = true;

          if (HighScore > (tries + 1) || HighScore == 0)
          {
            HighScoreInCookie = HighScore = tries + 1;
            Message = "You guessed it and got a new highscore!";
          }
          else
            Message = "You guessed it!";
        }

        Tries = tries + 1;
        Guessed.Add(guess);
      }
      else
      {
        if (guess > HiddenNumber)
          Message = $"You already tried {guess} (too big)";
        else
          Message = $"You already tried {guess} (too small)";

        Tries = tries;
      }

      GuessedHidden = JsonSerializer.Serialize(Guessed);
    }
  }
}
