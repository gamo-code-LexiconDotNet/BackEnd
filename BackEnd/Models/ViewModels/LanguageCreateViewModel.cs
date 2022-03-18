using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.ViewModels
{
  public class LanguageCreateViewModel
  {
    //[Required(ErrorMessage = "Language name is required.")]
    [StringLength(48)]
    public string LanguageName { get; set; }

    //[Required(ErrorMessage = "Person name is required.")]
    public int LanguageId { get; set; }

    //[Required(ErrorMessage = "Language name is required.")]
    public int PersonId { get; set; }
  }
}
