using Application.Features.Uoms.Commands.Create;
using Application.Features.Uoms.Commands.Delete;
using Application.Features.Uoms.Commands.Update;
using Application.Features.Uoms.Queries.GetById;
using Application.Features.Uoms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Uoms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUomCommand, Uom>();
        CreateMap<Uom, CreatedUomResponse>();

        CreateMap<UpdateUomCommand, Uom>();
        CreateMap<Uom, UpdatedUomResponse>();

        CreateMap<DeleteUomCommand, Uom>();
        CreateMap<Uom, DeletedUomResponse>();

        CreateMap<Uom, GetByIdUomResponse>();

        CreateMap<Uom, GetListUomListItemDto>();
        CreateMap<IPaginate<Uom>, GetListResponse<GetListUomListItemDto>>();
    }
}