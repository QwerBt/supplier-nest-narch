using Application.Features.JobLevels.Constants;
using Application.Features.JobLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobLevels.Commands.Delete;

public class DeleteJobLevelCommand : IRequest<DeletedJobLevelResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobLevels"];

    public class DeleteJobLevelCommandHandler : IRequestHandler<DeleteJobLevelCommand, DeletedJobLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly JobLevelBusinessRules _jobLevelBusinessRules;

        public DeleteJobLevelCommandHandler(IMapper mapper, IJobLevelRepository jobLevelRepository,
                                         JobLevelBusinessRules jobLevelBusinessRules)
        {
            _mapper = mapper;
            _jobLevelRepository = jobLevelRepository;
            _jobLevelBusinessRules = jobLevelBusinessRules;
        }

        public async Task<DeletedJobLevelResponse> Handle(DeleteJobLevelCommand request, CancellationToken cancellationToken)
        {
            JobLevel? jobLevel = await _jobLevelRepository.GetAsync(predicate: jl => jl.Id == request.Id, cancellationToken: cancellationToken);
            await _jobLevelBusinessRules.JobLevelShouldExistWhenSelected(jobLevel);

            await _jobLevelRepository.DeleteAsync(jobLevel!);

            DeletedJobLevelResponse response = _mapper.Map<DeletedJobLevelResponse>(jobLevel);
            return response;
        }
    }
}