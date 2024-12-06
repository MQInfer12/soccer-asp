using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace asp_test.Models
{
  public class Banner
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Team 1 is required.")]
    public required int Club1Id { get; set; }
    [Required(ErrorMessage = "Team 2 is required.")]
    public required int Club2Id { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(100, ErrorMessage = "Description can be more than 100 characters.")]
    public required string Description { get; set; }

    [ValidateNever]
    public Club Club1 { get; set; } = null!;
    [ValidateNever]
    public Club Club2 { get; set; } = null!;
  }
}