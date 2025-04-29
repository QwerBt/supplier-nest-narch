using Application.Features.ItemUoms.Commands.Create;
using Application.Features.ItemUoms.Commands.Delete;
using Application.Features.ItemUoms.Commands.Update;
using Application.Features.ItemUoms.Queries.GetById;
using Application.Features.ItemUoms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ItemUoms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateItemUomCommand, ItemUom>();
        CreateMap<ItemUom, CreatedItemUomResponse>();

        CreateMap<UpdateItemUomCommand, ItemUom>();
        CreateMap<ItemUom, UpdatedItemUomResponse>();

        CreateMap<DeleteItemUomCommand, ItemUom>();
        CreateMap<ItemUom, DeletedItemUomResponse>();

        CreateMap<ItemUom, GetByIdItemUomResponse>();

        CreateMap<ItemUom, GetListItemUomListItemDto>();
        CreateMap<IPaginate<ItemUom>, GetListResponse<GetListItemUomListItemDto>>();
    }
}