using DotnetAuthAnother.Api.Models.Dtos;
using DotnetAuthAnother.Api.Repositories.TeamsRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAuthAnother.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamsCrudService _teamsCrudService;

    public TeamsController(ITeamsCrudService teamsCrudService)
    {
        _teamsCrudService = teamsCrudService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadTeamsDataDto>>> GetAllTeams([FromQuery] int page, [FromQuery] int pageSize)
    {
        var teams = _teamsCrudService.GetAllTeams(page, pageSize);

        return await Task.FromResult(Ok(teams));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadTeamsDataDto>> GetTeamById(int id)
    {
        var team = _teamsCrudService.GetTeamById(id);

        if (team is null)
        {
            return await Task.FromResult(NotFound("The team with id " + id + "was not found"));
        }

        return await Task.FromResult(Ok(team));
    }
}