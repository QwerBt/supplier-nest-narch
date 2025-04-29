using Application.Features.CompanyUsers.Commands.Create;
using Application.Features.CompanyUsers.Commands.Delete;
using Application.Features.CompanyUsers.Commands.Update;
using Application.Features.CompanyUsers.Queries.GetById;
using Application.Features.CompanyUsers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyUserCommand, CompanyUser>();
        CreateMap<CompanyUser, CreatedCompanyUserResponse>();

        CreateMap<UpdateCompanyUserCommand, CompanyUser>();
        CreateMap<CompanyUser, UpdatedCompanyUserResponse>();

        CreateMap<DeleteCompanyUserCommand, CompanyUser>();
        CreateMap<CompanyUser, DeletedCompanyUserResponse>();

        CreateMap<CompanyUser, GetByIdCompanyUserResponse>();

        CreateMap<CompanyUser, GetListCompanyUserListItemDto>();
        CreateMap<IPaginate<CompanyUser>, GetListResponse<GetListCompanyUserListItemDto>>();
    }
}