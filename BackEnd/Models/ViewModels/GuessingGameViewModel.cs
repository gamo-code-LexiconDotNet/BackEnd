using System.Collections.Generic;

namespace BackEnd.Models.ViewModels
{
  public class GuessingGameViewModel
  {
    public List<int> Guessed { get; set; }
    public int HighScore { get; set; }
    public int Tries { get; set; }
    public string Message { get; set; }
    public bool Win { get; set; }
  }
}
