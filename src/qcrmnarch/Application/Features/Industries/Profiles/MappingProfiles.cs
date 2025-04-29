using Application.Features.Industries.Commands.Create;
using Application.Features.Industries.Commands.Delete;
using Application.Features.Industries.Commands.Update;
using Application.Features.Industries.Queries.GetById;
using Application.Features.Industries.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Industries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateIndustryCommand, Industry>();
        CreateMap<Industry, CreatedIndustryResponse>();

        CreateMap<UpdateIndustryCommand, Industry>();
        CreateMap<Industry, UpdatedIndustryResponse>();

        CreateMap<DeleteIndustryCommand, Industry>();
        CreateMap<Industry, DeletedIndustryResponse>();

        CreateMap<Industry, GetByIdIndustryResponse>();

        CreateMap<Industry, GetListIndustryListItemDto>();
        CreateMap<IPaginate<Industry>, GetListResponse<GetListIndustryListItemDto>>();
    }
}