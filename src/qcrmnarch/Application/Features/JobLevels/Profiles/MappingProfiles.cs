using Application.Features.JobLevels.Commands.Create;
using Application.Features.JobLevels.Commands.Delete;
using Application.Features.JobLevels.Commands.Update;
using Application.Features.JobLevels.Queries.GetById;
using Application.Features.JobLevels.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.JobLevels.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateJobLevelCommand, JobLevel>();
        CreateMap<JobLevel, CreatedJobLevelResponse>();

        CreateMap<UpdateJobLevelCommand, JobLevel>();
        CreateMap<JobLevel, UpdatedJobLevelResponse>();

        CreateMap<DeleteJobLevelCommand, JobLevel>();
        CreateMap<JobLevel, DeletedJobLevelResponse>();

        CreateMap<JobLevel, GetByIdJobLevelResponse>();

        CreateMap<JobLevel, GetListJobLevelListItemDto>();
        CreateMap<IPaginate<JobLevel>, GetListResponse<GetListJobLevelListItemDto>>();
    }
}