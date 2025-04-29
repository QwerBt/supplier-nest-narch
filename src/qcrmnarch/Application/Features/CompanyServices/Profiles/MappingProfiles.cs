using Application.Features.CompanyServices.Commands.Create;
using Application.Features.CompanyServices.Commands.Delete;
using Application.Features.CompanyServices.Commands.Update;
using Application.Features.CompanyServices.Queries.GetById;
using Application.Features.CompanyServices.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyServices.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyServiceCommand, CompanyService>();
        CreateMap<CompanyService, CreatedCompanyServiceResponse>();

        CreateMap<UpdateCompanyServiceCommand, CompanyService>();
        CreateMap<CompanyService, UpdatedCompanyServiceResponse>();

        CreateMap<DeleteCompanyServiceCommand, CompanyService>();
        CreateMap<CompanyService, DeletedCompanyServiceResponse>();

        CreateMap<CompanyService, GetByIdCompanyServiceResponse>();

        CreateMap<CompanyService, GetListCompanyServiceListItemDto>();
        CreateMap<IPaginate<CompanyService>, GetListResponse<GetListCompanyServiceListItemDto>>();
    }
}