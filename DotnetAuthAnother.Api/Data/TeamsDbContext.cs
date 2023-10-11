using Bogus;
using DotnetAuthAnother.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuthAnother.Api.Data;


public class TeamsDbContext : DbContext
{
    public TeamsDbContext(DbContextOptions<TeamsDbContext> options) : base(options)
    {
    }

    public DbSet<TeamModel> TeamModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var id = 1;

        var teams = new Faker<TeamModel>()
                            .RuleFor(m => m.Id, f => id++)
                            .RuleFor(m => m.Name, f => f.Company.CompanyName())
                            .RuleFor(m => m.Country, f => f.Address.Country())
                            .RuleFor(m => m.TeamPrinciple, f => f.Lorem.Paragraphs(1));

        modelBuilder
            .Entity<TeamModel>()
            .HasData(teams.Generate(10000));
    }
}