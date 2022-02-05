using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface IGuessingGameService
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
