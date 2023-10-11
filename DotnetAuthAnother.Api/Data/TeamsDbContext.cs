using DotnetAuthAnother.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuthAnother.Api.Data;


public class TeamsDbContext : DbContext
{
    public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
    {
    }

    public DbSet<TeamModel> TeamModels { get; set; }
}