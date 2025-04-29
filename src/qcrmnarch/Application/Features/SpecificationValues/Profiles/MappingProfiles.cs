using Application.Features.SpecificationValues.Commands.Create;
using Application.Features.SpecificationValues.Commands.Delete;
using Application.Features.SpecificationValues.Commands.Update;
using Application.Features.SpecificationValues.Queries.GetById;
using Application.Features.SpecificationValues.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SpecificationValues.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSpecificationValueCommand, SpecificationValue>();
        CreateMap<SpecificationValue, CreatedSpecificationValueResponse>();

        CreateMap<UpdateSpecificationValueCommand, SpecificationValue>();
        CreateMap<SpecificationValue, UpdatedSpecificationValueResponse>();

        CreateMap<DeleteSpecificationValueCommand, SpecificationValue>();
        CreateMap<SpecificationValue, DeletedSpecificationValueResponse>();

        CreateMap<SpecificationValue, GetByIdSpecificationValueResponse>();

        CreateMap<SpecificationValue, GetListSpecificationValueListItemDto>();
        CreateMap<IPaginate<SpecificationValue>, GetListResponse<GetListSpecificationValueListItemDto>>();
    }
}