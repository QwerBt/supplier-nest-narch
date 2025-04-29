using Application.Features.CompanyCategories.Commands.Create;
using Application.Features.CompanyCategories.Commands.Delete;
using Application.Features.CompanyCategories.Commands.Update;
using Application.Features.CompanyCategories.Queries.GetById;
using Application.Features.CompanyCategories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.CompanyCategories.Queries.GetListByDynamic;

namespace Application.Features.CompanyCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyCategoryCommand, CompanyCategory>().ReverseMap();
        CreateMap<CompanyCategory, CreatedCompanyCategoryResponse>().ReverseMap();

        CreateMap<UpdateCompanyCategoryCommand, CompanyCategory>().ReverseMap();
        CreateMap<CompanyCategory, UpdatedCompanyCategoryResponse>().ReverseMap();

        CreateMap<DeleteCompanyCategoryCommand, CompanyCategory>().ReverseMap();
        CreateMap<CompanyCategory, DeletedCompanyCategoryResponse>().ReverseMap();

        CreateMap<CompanyCategory, GetByIdCompanyCategoryResponse>().ReverseMap();

        CreateMap<CompanyCategory, GetListCompanyCategoryListItemDto>()
            .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Category.Products.Count))
            .ForMember(dest => dest.ItemsCount, opt => opt.MapFrom(src => src.Category.Products.Sum(p => p.Items.Count)))
            .ReverseMap();
        CreateMap<CompanyCategory, GetListByDynamicCompanyCategoryResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
            .ReverseMap();

        CreateMap<IPaginate<CompanyCategory>, GetListResponse<GetListCompanyCategoryListItemDto>>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ReverseMap();
        CreateMap<IPaginate<CompanyCategory>, GetListResponse<GetListByDynamicCompanyCategoryResponse>>().ReverseMap();

        //CreateMap<GroupedCompanyCategory, GetListCompanyCategoryListItemDto>()
        //    .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
        //    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
        //    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
        //    .ReverseMap();
    }
}

