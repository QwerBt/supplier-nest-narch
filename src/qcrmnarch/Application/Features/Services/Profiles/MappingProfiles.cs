using Application.Features.Services.Commands.Create;
using Application.Features.Services.Commands.Delete;
using Application.Features.Services.Commands.Update;
using Application.Features.Services.Queries.GetById;
using Application.Features.Services.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Services.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateServiceCommand, Service>();
        CreateMap<Service, CreatedServiceResponse>();

        CreateMap<UpdateServiceCommand, Service>();
        CreateMap<Service, UpdatedServiceResponse>();

        CreateMap<DeleteServiceCommand, Service>();
        CreateMap<Service, DeletedServiceResponse>();

        CreateMap<Service, GetByIdServiceResponse>();

        CreateMap<Service, GetListServiceListItemDto>();
        CreateMap<IPaginate<Service>, GetListResponse<GetListServiceListItemDto>>();
    }
}