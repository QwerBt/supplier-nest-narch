using Application.Features.JobLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobLevels.Commands.Create;

public class CreateJobLevelCommand : IRequest<CreatedJobLevelResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobLevels"];

    public class CreateJobLevelCommandHandler : IRequestHandler<CreateJobLevelCommand, CreatedJobLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly JobLevelBusinessRules _jobLevelBusinessRules;

        public CreateJobLevelCommandHandler(IMapper mapper, IJobLevelRepository jobLevelRepository,
                                         JobLevelBusinessRules jobLevelBusinessRules)
        {
            _mapper = mapper;
            _jobLevelRepository = jobLevelRepository;
            _jobLevelBusinessRules = jobLevelBusinessRules;
        }

        public async Task<CreatedJobLevelResponse> Handle(CreateJobLevelCommand request, CancellationToken cancellationToken)
        {
            JobLevel jobLevel = _mapper.Map<JobLevel>(request);

            await _jobLevelRepository.AddAsync(jobLevel);

            CreatedJobLevelResponse response = _mapper.Map<CreatedJobLevelResponse>(jobLevel);
            return response;
        }
    }
}