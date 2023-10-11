namespace DotnetAuthAnother.Api.Models.Dtos;


public class CreateTeamsDataDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string TeamPrinciple { get; set; } = string.Empty;
}