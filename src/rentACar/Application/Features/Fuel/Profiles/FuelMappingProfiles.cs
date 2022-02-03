using Application.Features.Fuel.Commands;
using Application.Features.Fuel.Dtos;
using Application.Features.Fuel.Models;
using AutoMapper;
using Core.Persistense.Paging;

namespace Application.Features.Fuel.Profiles;

internal class FuelMappingProfiles:Profile
{
    public FuelMappingProfiles()
    {
        CreateMap<Domain.Entities.Fuel, FuelDto>().ReverseMap();
        CreateMap<Domain.Entities.Fuel, CreateFuelCommand>().ReverseMap();
        CreateMap<Domain.Entities.Fuel, UpdateFuelCommand>().ReverseMap();
        CreateMap<Domain.Entities.Fuel, FuelListItem>().ReverseMap();

        CreateMap<FuelListModel, IPaginate<Domain.Entities.Fuel>>().ReverseMap();
    }
}