using Application.Features.JobFunctions.Commands.Create;
using Application.Features.JobFunctions.Commands.Delete;
using Application.Features.JobFunctions.Commands.Update;
using Application.Features.JobFunctions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.JobFunctions.Queries.GetById;

namespace Application.Features.JobFunctions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateJobFunctionCommand, JobFunction>();
        CreateMap<JobFunction, CreatedJobFunctionResponse>();

        CreateMap<UpdateJobFunctionCommand, JobFunction>();
        CreateMap<JobFunction, UpdatedJobFunctionResponse>();

        CreateMap<DeleteJobFunctionCommand, JobFunction>();
        CreateMap<JobFunction, DeletedJobFunctionResponse>();

        CreateMap<JobFunction, GetByIdJobFunctionResponse>();

        CreateMap<JobFunction, GetListJobFunctionListItemDto>();
        CreateMap<IPaginate<JobFunction>, GetListResponse<GetListJobFunctionListItemDto>>();
    }
}