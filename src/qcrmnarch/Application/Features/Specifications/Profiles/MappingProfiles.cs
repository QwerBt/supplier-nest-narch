using Application.Features.Specifications.Commands.Create;
using Application.Features.Specifications.Commands.Delete;
using Application.Features.Specifications.Commands.Update;
using Application.Features.Specifications.Queries.GetById;
using Application.Features.Specifications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Specifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSpecificationCommand, Specification>();
        CreateMap<Specification, CreatedSpecificationResponse>();

        CreateMap<UpdateSpecificationCommand, Specification>();
        CreateMap<Specification, UpdatedSpecificationResponse>();

        CreateMap<DeleteSpecificationCommand, Specification>();
        CreateMap<Specification, DeletedSpecificationResponse>();

        CreateMap<Specification, GetByIdSpecificationResponse>();

        CreateMap<Specification, GetListSpecificationListItemDto>();
        ;
        CreateMap<IPaginate<Specification>, GetListResponse<GetListSpecificationListItemDto>>();
    }
}