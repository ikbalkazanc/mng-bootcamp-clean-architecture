using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Commands;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Models.Commands;
using AutoMapper;
using Core.Persistense.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    internal class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandDto>().ReverseMap();

            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<BrandListModel, IPaginate<Brand>>().ReverseMap();
        }
    }
}
