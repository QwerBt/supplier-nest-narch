using Application.Features.CompanyImages.Commands.Create;
using Application.Features.CompanyImages.Commands.Delete;
using Application.Features.CompanyImages.Commands.Update;
using Application.Features.CompanyImages.Queries.GetById;
using Application.Features.CompanyImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CompanyImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCompanyImageCommand, CompanyImage>();
        CreateMap<CompanyImage, CreatedCompanyImageResponse>();

        CreateMap<UpdateCompanyImageCommand, CompanyImage>();
        CreateMap<CompanyImage, UpdatedCompanyImageResponse>();

        CreateMap<DeleteCompanyImageCommand, CompanyImage>();
        CreateMap<CompanyImage, DeletedCompanyImageResponse>();

        CreateMap<CompanyImage, GetByIdCompanyImageResponse>();

        CreateMap<CompanyImage, GetListCompanyImageListItemDto>();
        CreateMap<IPaginate<CompanyImage>, GetListResponse<GetListCompanyImageListItemDto>>();
    }
}