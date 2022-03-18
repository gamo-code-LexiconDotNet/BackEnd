using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.ViewModels
{
  public class RoleCreateViewModel : IValidatableObject
  {
    public RoleCreateViewModel() { }

    public string UserId { get; set; }
    public string NewRoleName { get; set; }
    public string RoleName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      bool hasUserId = !string.IsNullOrWhiteSpace(UserId);
      bool hasNewRoleName = !string.IsNullOrWhiteSpace(NewRoleName);
      bool hasRoleName = !string.IsNullOrWhiteSpace(RoleName);

      // all empty
      if (!hasNewRoleName
        & !hasRoleName
        & !hasUserId)
        yield return new ValidationResult(
          "Nothing to do. You can add a new role, rename a role or add a user to a role.",
          new[] { nameof(NewRoleName) });

      // only role name option selected
      if (!hasNewRoleName
        & hasRoleName
        & !hasUserId)
        yield return new ValidationResult(
          "Enter a new role name to rename the role or chose a user to assign to the role to.",
          new[] { nameof(NewRoleName) });

      // user selected but no role
      if (!hasNewRoleName
        & !hasRoleName
        & hasUserId)
        yield return new ValidationResult(
          "Enter a new role name to create a new role and assign the user to or choose a role to assign the user to.",
          new[] { nameof(NewRoleName) });

    }
  }
}
