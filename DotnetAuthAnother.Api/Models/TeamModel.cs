using System.ComponentModel.DataAnnotations;

namespace DotnetAuthAnother.Api.Models;


public class TeamModel
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name must be input")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "The country value must be input")]
    public string Country { get; set; } = string.Empty;
    [Required(ErrorMessage = "The team principle must be input")]
    public string TeamPrinciple { get; set; } = string.Empty;
}