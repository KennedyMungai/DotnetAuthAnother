using DotnetAuthAnother.Api.Models;

namespace DotnetAuthAnother.Api.Repositories.TeamsRepositories;


public interface ITeamsCrudService
{
    Task<IEnumerable<TeamModel>> GetAllTeams(int page = 1, int pageSize = 10, string filter = "");
    Task<TeamModel> GetTeamById(int id);
    Task<TeamModel> CreateTeam(TeamModel team);
    Task<TeamModel> UpdateTeam(TeamModel team);
    Task<TeamModel> DeleteTeam(int id);
}