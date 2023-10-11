using DotnetAuthAnother.Api.Models;
using DotnetAuthAnother.Api.Models.Dtos;

namespace DotnetAuthAnother.Api.Repositories.TeamsRepositories;


public interface ITeamsCrudService
{
    Task<IEnumerable<ReadTeamsDataDto>> GetAllTeams(int page = 1, int pageSize = 10);
    Task<ReadTeamsDataDto> GetTeamById(int id);
    Task<bool> CreateTeam(CreateTeamsDataDto team);
    Task<bool> UpdateTeam(UpdateTeamsDataDto team);
    Task<bool> DeleteTeam(int id);
}