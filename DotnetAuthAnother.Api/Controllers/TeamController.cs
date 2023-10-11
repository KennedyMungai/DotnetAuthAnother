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

    [HttpPost]
    public async Task<IActionResult> CreateNewTeam(CreateTeamsDataDto teamModel)
    {
        var isSuccessful = await _teamsCrudService.CreateTeam(teamModel);

        if (!isSuccessful)
        {
            return await Task.FromResult(BadRequest("Failed to create the team"));
        }

        return await Task.FromResult(CreatedAtRoute("GetTeamById", new { id = teamModel.Id }, teamModel));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOneTeam(int id, UpdateTeamsDataDto teamModel)
    {
        var team = await _teamsCrudService.GetTeamById(id);

        if (team is null)
        {
            return await Task.FromResult(NotFound("The team with id " + id + "was not found"));
        }

        var isSuccessful = await _teamsCrudService.UpdateTeam(id, teamModel);

        if (!isSuccessful)
        {
            return await Task.FromResult(BadRequest("Failed to update the team"));
        }

        return await Task.FromResult(Accepted("Item Updated Successfully"));
    }
}