using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.JobLevels.Queries.GetList;

public class GetListJobLevelQuery : IRequest<GetListResponse<GetListJobLevelListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListJobLevels({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetJobLevels";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListJobLevelQueryHandler : IRequestHandler<GetListJobLevelQuery, GetListResponse<GetListJobLevelListItemDto>>
    {
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly IMapper _mapper;

        public GetListJobLevelQueryHandler(IJobLevelRepository jobLevelRepository, IMapper mapper)
        {
            _jobLevelRepository = jobLevelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListJobLevelListItemDto>> Handle(GetListJobLevelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<JobLevel> jobLevels = await _jobLevelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListJobLevelListItemDto> response = _mapper.Map<GetListResponse<GetListJobLevelListItemDto>>(jobLevels);
            return response;
        }
    }
}