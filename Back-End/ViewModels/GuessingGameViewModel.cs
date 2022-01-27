using System.Collections.Generic;

namespace Back_End.ViewModels
{
  public class GuessingGameViewModel
  {
    public string GuessedHidden { get; set; }
    public List<int> Guessed { get; set; }
    public int? HighScore { get; set; }
    public int Tries { get; set; }
    public string Message { get; set; }
    public bool Win { get; set; }
  }
}
