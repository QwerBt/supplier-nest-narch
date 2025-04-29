using Application.Features.Disciplines.Commands.Create;
using Application.Features.Disciplines.Commands.Delete;
using Application.Features.Disciplines.Commands.Update;
using Application.Features.Disciplines.Queries.GetById;
using Application.Features.Disciplines.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Disciplines.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDisciplineCommand, Discipline>();
        CreateMap<Discipline, CreatedDisciplineResponse>();

        CreateMap<UpdateDisciplineCommand, Discipline>();
        CreateMap<Discipline, UpdatedDisciplineResponse>();

        CreateMap<DeleteDisciplineCommand, Discipline>();
        CreateMap<Discipline, DeletedDisciplineResponse>();

        CreateMap<Discipline, GetByIdDisciplineResponse>();

        CreateMap<Discipline, GetListDisciplineListItemDto>();
        CreateMap<IPaginate<Discipline>, GetListResponse<GetListDisciplineListItemDto>>();
    }
}