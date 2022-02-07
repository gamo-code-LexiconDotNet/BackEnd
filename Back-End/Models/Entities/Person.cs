﻿using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.Entities
{
  public class Person
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string City { get; set; }
  }
}
