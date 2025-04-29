using Application.Features.ItemSpecifications.Commands.Create;
using Application.Features.ItemSpecifications.Commands.Delete;
using Application.Features.ItemSpecifications.Commands.Update;
using Application.Features.ItemSpecifications.Queries.GetById;
using Application.Features.ItemSpecifications.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ItemSpecifications.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateItemSpecificationCommand, ItemSpecification>();
        CreateMap<ItemSpecification, CreatedItemSpecificationResponse>();

        CreateMap<UpdateItemSpecificationCommand, ItemSpecification>();
        CreateMap<ItemSpecification, UpdatedItemSpecificationResponse>();

        CreateMap<DeleteItemSpecificationCommand, ItemSpecification>();
        CreateMap<ItemSpecification, DeletedItemSpecificationResponse>();

        CreateMap<ItemSpecification, GetByIdItemSpecificationResponse>();

        CreateMap<ItemSpecification, GetListItemSpecificationListItemDto>();
        CreateMap<IPaginate<ItemSpecification>, GetListResponse<GetListItemSpecificationListItemDto>>();
    }
}