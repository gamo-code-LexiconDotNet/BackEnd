namespace BackEnd.Models.Services
{
  public class DoctorService
  {
    private static double FahrenheitToCelcius(double temperature)
    {
      return (temperature - 32) * 5 / 9;
    }

    public static string[] FeverCheck(double temperature, string scale)
    {
      if (scale == "f")
        temperature = FahrenheitToCelcius(temperature);

      if (temperature >= 38)
        return new string[] { "You have a fever!", "alert-danger" };
      else if (temperature <= 35)
        return new string[] { "You have hypothermia!", "alert-info" };
      else
        return new string[] { "Normal Temperature", "alert-success" };
    }
  }
}
