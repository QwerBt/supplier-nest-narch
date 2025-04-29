using Application.Features.JobLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobLevels.Commands.Update;

public class UpdateJobLevelCommand : IRequest<UpdatedJobLevelResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobLevels"];

    public class UpdateJobLevelCommandHandler : IRequestHandler<UpdateJobLevelCommand, UpdatedJobLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly JobLevelBusinessRules _jobLevelBusinessRules;

        public UpdateJobLevelCommandHandler(IMapper mapper, IJobLevelRepository jobLevelRepository,
                                         JobLevelBusinessRules jobLevelBusinessRules)
        {
            _mapper = mapper;
            _jobLevelRepository = jobLevelRepository;
            _jobLevelBusinessRules = jobLevelBusinessRules;
        }

        public async Task<UpdatedJobLevelResponse> Handle(UpdateJobLevelCommand request, CancellationToken cancellationToken)
        {
            JobLevel? jobLevel = await _jobLevelRepository.GetAsync(predicate: jl => jl.Id == request.Id, cancellationToken: cancellationToken);
            await _jobLevelBusinessRules.JobLevelShouldExistWhenSelected(jobLevel);
            jobLevel = _mapper.Map(request, jobLevel);

            await _jobLevelRepository.UpdateAsync(jobLevel!);

            UpdatedJobLevelResponse response = _mapper.Map<UpdatedJobLevelResponse>(jobLevel);
            return response;
        }
    }
}