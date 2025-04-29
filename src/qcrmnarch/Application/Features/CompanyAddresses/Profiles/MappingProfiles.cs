using Application.Features.CompanyAddresses.Commands.Create;
using Application.Features.CompanyAddresses.Commands.Delete;
using Application.Features.CompanyAddresses.Commands.Update;
using Application.Features.CompanyAddresses.Queries.GetById;
using Application.Features.CompanyAddresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyAddresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyAddressCommand, CompanyAddress>();
        CreateMap<CompanyAddress, CreatedCompanyAddressResponse>();

        CreateMap<UpdateCompanyAddressCommand, CompanyAddress>();
        CreateMap<CompanyAddress, UpdatedCompanyAddressResponse>();

        CreateMap<DeleteCompanyAddressCommand, CompanyAddress>();
        CreateMap<CompanyAddress, DeletedCompanyAddressResponse>();

        CreateMap<CompanyAddress, GetByIdCompanyAddressResponse>();

        CreateMap<CompanyAddress, GetListCompanyAddressListItemDto>();
        CreateMap<IPaginate<CompanyAddress>, GetListResponse<GetListCompanyAddressListItemDto>>();
    }
}