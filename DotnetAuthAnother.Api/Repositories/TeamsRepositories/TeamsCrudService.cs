using AutoMapper;
using DotnetAuthAnother.Api.Data;
using DotnetAuthAnother.Api.Models;
using DotnetAuthAnother.Api.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuthAnother.Api.Repositories.TeamsRepositories;


public class TeamsCrudService : ITeamsCrudService
{
    private readonly TeamsDbContext _context;
    private readonly Mapper _mapper;

    public TeamsCrudService(TeamsDbContext context, Mapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> CreateTeam(CreateTeamsDataDto team)
    {
        try
        {
            await _context.TeamModels.AddAsync(_mapper.Map<TeamModel>(team));
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
            throw;
        }
    }

    public async Task<bool> DeleteTeam(int id)
    {
        try
        {
            var team = await _context.TeamModels.FirstOrDefaultAsync(x => x.Id == id);

            _context.TeamModels.Remove(team!);

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
            throw;
        }
    }

    public async Task<IEnumerable<ReadTeamsDataDto>> GetAllTeams(int page = 1, int pageSize = 10)
    {
        var teams = await _context.TeamModels.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        return await Task.FromResult(_mapper.Map<IEnumerable<ReadTeamsDataDto>>(teams));
    }

    public async Task<ReadTeamsDataDto> GetTeamById(int id)
    {
        var team = await _context.TeamModels.FindAsync(id);

        return await Task.FromResult(_mapper.Map<ReadTeamsDataDto>(team));
    }

    public async Task<bool> UpdateTeam(int id, UpdateTeamsDataDto teamData)
    {
        try
        {
            var team = await _context.TeamModels.FirstOrDefaultAsync(x => x.Id == id);

            team!.Name = teamData.Name;
            team!.Country = teamData.Country;
            team!.TeamPrinciple = teamData.TeamPrinciple;

            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
            throw;
        }
    }
}