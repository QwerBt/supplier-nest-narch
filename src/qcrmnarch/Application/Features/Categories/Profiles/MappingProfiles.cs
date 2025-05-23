using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Commands.Update;
using Application.Features.Categories.Queries.GetById;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<Category, CreatedCategoryResponse>();

        CreateMap<UpdateCategoryCommand, Category>();
        CreateMap<Category, UpdatedCategoryResponse>();

        CreateMap<DeleteCategoryCommand, Category>();
        CreateMap<Category, DeletedCategoryResponse>();

        CreateMap<Category, GetByIdCategoryResponse>();

        CreateMap<Category, GetListCategoryListItemDto>()
            .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Products.Count))
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.Products.Sum(p => p.Items.Count)));

        CreateMap<IPaginate<Category>, GetListResponse<GetListCategoryListItemDto>>();
    }
}