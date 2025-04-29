using Application.Features.CompanyBrands.Commands.Create;
using Application.Features.CompanyBrands.Commands.Delete;
using Application.Features.CompanyBrands.Commands.Update;
using Application.Features.CompanyBrands.Queries.GetById;
using Application.Features.CompanyBrands.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyBrands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyBrandCommand, CompanyBrand>();
        CreateMap<CompanyBrand, CreatedCompanyBrandResponse>();

        CreateMap<UpdateCompanyBrandCommand, CompanyBrand>();
        CreateMap<CompanyBrand, UpdatedCompanyBrandResponse>();

        CreateMap<DeleteCompanyBrandCommand, CompanyBrand>();
        CreateMap<CompanyBrand, DeletedCompanyBrandResponse>();

        CreateMap<CompanyBrand, GetByIdCompanyBrandResponse>();

        CreateMap<CompanyBrand, GetListCompanyBrandListItemDto>();
        CreateMap<IPaginate<CompanyBrand>, GetListResponse<GetListCompanyBrandListItemDto>>();
    }
}