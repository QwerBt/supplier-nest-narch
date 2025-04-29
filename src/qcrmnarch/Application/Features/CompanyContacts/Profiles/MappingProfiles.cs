using Application.Features.CompanyContacts.Commands.Create;
using Application.Features.CompanyContacts.Commands.Delete;
using Application.Features.CompanyContacts.Commands.Update;
using Application.Features.CompanyContacts.Queries.GetById;
using Application.Features.CompanyContacts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyContacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyContactCommand, CompanyContact>();
        CreateMap<CompanyContact, CreatedCompanyContactResponse>();

        CreateMap<UpdateCompanyContactCommand, CompanyContact>();
        CreateMap<CompanyContact, UpdatedCompanyContactResponse>();

        CreateMap<DeleteCompanyContactCommand, CompanyContact>();
        CreateMap<CompanyContact, DeletedCompanyContactResponse>();

        CreateMap<CompanyContact, GetByIdCompanyContactResponse>();

        CreateMap<CompanyContact, GetListCompanyContactListItemDto>();
        CreateMap<IPaginate<CompanyContact>, GetListResponse<GetListCompanyContactListItemDto>>();
    }
}