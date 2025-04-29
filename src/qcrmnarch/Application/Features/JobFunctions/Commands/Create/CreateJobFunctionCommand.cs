using Application.Features.JobFunctions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobFunctions.Commands.Create;

public class CreateJobFunctionCommand : IRequest<CreatedJobFunctionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobFunctions"];

    public class CreateJobFunctionCommandHandler : IRequestHandler<CreateJobFunctionCommand, CreatedJobFunctionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobFunctionRepository _jobFunctionRepository;
        private readonly JobFunctionBusinessRules _jobFunctionBusinessRules;

        public CreateJobFunctionCommandHandler(IMapper mapper, IJobFunctionRepository jobFunctionRepository,
                                         JobFunctionBusinessRules jobFunctionBusinessRules)
        {
            _mapper = mapper;
            _jobFunctionRepository = jobFunctionRepository;
            _jobFunctionBusinessRules = jobFunctionBusinessRules;
        }

        public async Task<CreatedJobFunctionResponse> Handle(CreateJobFunctionCommand request, CancellationToken cancellationToken)
        {
            JobFunction jobFunction = _mapper.Map<JobFunction>(request);

            await _jobFunctionRepository.AddAsync(jobFunction);

            CreatedJobFunctionResponse response = _mapper.Map<CreatedJobFunctionResponse>(jobFunction);
            return response;
        }
    }
}