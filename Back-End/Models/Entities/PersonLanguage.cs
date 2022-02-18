namespace Back_End.Models.Entities
{
  public class PersonLanguage
  {
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int LanguageId { get; set; }
    public Language Langauge { get; set; }
  }
}
