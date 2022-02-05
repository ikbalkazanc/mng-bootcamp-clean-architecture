using Application.Features.Colors.Commands;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Persistense.Paging;

namespace Application.Features.Colors.Profiles;

public class ColorMappingProfiles : Profile
{
    public ColorMappingProfiles()
    {
        CreateMap<Domain.Entities.Color, ColorDto>().ReverseMap();
        CreateMap<CreateColorCommand, Domain.Entities.Color>().ReverseMap();
        //CreateMap<DeleteColorCommand, Domain.Entities.Color>().ReverseMap();
        CreateMap<UpdateColorCommand, Domain.Entities.Color>().ReverseMap();
        CreateMap<UpdateColorCommand, Domain.Entities.Color>().ReverseMap();
        CreateMap<ColorListModel, IPaginate<Domain.Entities.Color>>().ReverseMap();
        CreateMap<Domain.Entities.Color, ColorListDto>().ReverseMap();
    }
}