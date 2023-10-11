using AutoMapper;

namespace DotnetAuthAnother.Api.Models.Dtos.Profiles;


public class TeamsProfile : Profile
{
    public TeamsProfile()
    {
        CreateMap<TeamModel, CreateTeamsDataDto>().ReverseMap();
        CreateMap<TeamModel, UpdateTeamsDataDto>().ReverseMap();
        CreateMap<TeamModel, ReadTeamsDataDto>().ReverseMap();
    }
}