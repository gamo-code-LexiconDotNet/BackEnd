using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace BackEnd.Models.Services
{
  public class GuessingGameService : IGuessingGameService
  {
    private readonly Random random = new Random();
    private readonly HttpContext httpContext = new HttpContextAccessor().HttpContext;

    public int HiddenNumber { get; set; }
    public int HighScore { get; set; }
    public List<int> GuessedNumbers { get; set; }
    public int Tries { get; set; }
    public string Message { get; set; }
    public bool Win { get; set; }


    public int HiddenNumberInSession
    {
      get => httpContext.Session.GetInt32("GuessingGameHiddenNumber") ?? -1;
      set => httpContext.Session.SetInt32("GuessingGameHiddenNumber", value);
    }

    public int TriesInSession
    {
      get => httpContext.Session.GetInt32("GuessingGameTries") ?? 0;
      set => httpContext.Session.SetInt32("GuessingGameTries", value);
    }

    public List<int> GuessedNumbersInSession
    {
      get
      {
        var numbers = httpContext.Session.Get("GuessingGameGuessedNumbers");
        return numbers == null ? new List<int>() : JsonSerializer.Deserialize<List<int>>(numbers);
      }
      set => httpContext.Session.SetString("GuessingGameGuessedNumbers", JsonSerializer.Serialize(value));
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
      Tries = 0;
      TriesInSession = Tries;
      GuessedNumbers = new List<int>();
      GuessedNumbersInSession = GuessedNumbers;
      HighScore = HighScoreInCookie;
      Message = "Guess a number between 1 and 100";
      Win = false;
    }

    public void PlayRound(int guess)
    {
      GuessedNumbers = GuessedNumbersInSession;
      HiddenNumber = HiddenNumberInSession;
      HighScore = HighScoreInCookie;
      Tries = TriesInSession;
      Win = false;

      if (!GuessedNumbers.Contains(guess))
      {
        Tries++;

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

          if (HighScore > Tries || HighScore == 0)
          {
            HighScoreInCookie = HighScore = Tries;
            Message = "You guessed it and got a new highscore!";
          }
          else
            Message = "You guessed it!";
        }

        TriesInSession = Tries;
        GuessedNumbers.Add(guess);
        GuessedNumbersInSession = GuessedNumbers;
      }
      else
      {
        if (guess > HiddenNumber)
          Message = $"You already tried {guess} (too big)";
        else
          Message = $"You already tried {guess} (too small)";
      }
    }
  }
}
