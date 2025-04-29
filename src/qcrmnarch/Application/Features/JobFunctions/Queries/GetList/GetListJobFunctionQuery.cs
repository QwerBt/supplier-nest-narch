using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.JobFunctions.Queries.GetList;

public class GetListJobFunctionQuery : IRequest<GetListResponse<GetListJobFunctionListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListJobFunctions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetJobFunctions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListJobFunctionQueryHandler : IRequestHandler<GetListJobFunctionQuery, GetListResponse<GetListJobFunctionListItemDto>>
    {
        private readonly IJobFunctionRepository _jobFunctionRepository;
        private readonly IMapper _mapper;

        public GetListJobFunctionQueryHandler(IJobFunctionRepository jobFunctionRepository, IMapper mapper)
        {
            _jobFunctionRepository = jobFunctionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListJobFunctionListItemDto>> Handle(GetListJobFunctionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<JobFunction> jobFunctions = await _jobFunctionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListJobFunctionListItemDto> response = _mapper.Map<GetListResponse<GetListJobFunctionListItemDto>>(jobFunctions);
            return response;
        }
    }
}