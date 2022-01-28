using System.Collections.Generic;

namespace Back_End.Models
{
  public interface IGuessingGame
  {
    public void SetupPlay();
    public void PlayRound(int guess);
    public List<int> GuessedNumbers { get; set; }
    public int HighScore { get; set; }
    public int Tries { get; set; }
    public string Message { get; set; }
    public bool Win { get; set; }
  }
}
