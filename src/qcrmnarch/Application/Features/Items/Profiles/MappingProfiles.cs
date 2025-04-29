using Application.Features.Items.Commands.Create;
using Application.Features.Items.Commands.Delete;
using Application.Features.Items.Commands.Update;
using Application.Features.Items.Queries.GetById;
using Application.Features.Items.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Items.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateItemCommand, Item>();
        CreateMap<Item, CreatedItemResponse>();

        CreateMap<UpdateItemCommand, Item>();
        CreateMap<Item, UpdatedItemResponse>();

        CreateMap<DeleteItemCommand, Item>();
        CreateMap<Item, DeletedItemResponse>();

        CreateMap<Item, GetByIdItemResponse>();

        CreateMap<Item, GetListItemListItemDto>().ForMember(dest => dest.ItemSpecifications, opt => opt.MapFrom(src => src.ItemSpecifications));
        CreateMap<IPaginate<Item>, GetListResponse<GetListItemListItemDto>>();
    }
}