using Application.Features.Towns.Commands.Create;
using Application.Features.Towns.Commands.Delete;
using Application.Features.Towns.Commands.Update;
using Application.Features.Towns.Queries.GetById;
using Application.Features.Towns.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Towns.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTownCommand, Town>();
        CreateMap<Town, CreatedTownResponse>();

        CreateMap<UpdateTownCommand, Town>();
        CreateMap<Town, UpdatedTownResponse>();

        CreateMap<DeleteTownCommand, Town>();
        CreateMap<Town, DeletedTownResponse>();

        CreateMap<Town, GetByIdTownResponse>();

        CreateMap<Town, GetListTownListItemDto>();
        CreateMap<IPaginate<Town>, GetListResponse<GetListTownListItemDto>>();
    }
}