using Application.Features.Regions.Commands.Create;
using Application.Features.Regions.Commands.Delete;
using Application.Features.Regions.Commands.Update;
using Application.Features.Regions.Queries.GetById;
using Application.Features.Regions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Regions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRegionCommand, Region>();
        CreateMap<Region, CreatedRegionResponse>();

        CreateMap<UpdateRegionCommand, Region>();
        CreateMap<Region, UpdatedRegionResponse>();

        CreateMap<DeleteRegionCommand, Region>();
        CreateMap<Region, DeletedRegionResponse>();

        CreateMap<Region, GetByIdRegionResponse>();

        CreateMap<Region, GetListRegionListItemDto>();
        CreateMap<IPaginate<Region>, GetListResponse<GetListRegionListItemDto>>();
    }
}