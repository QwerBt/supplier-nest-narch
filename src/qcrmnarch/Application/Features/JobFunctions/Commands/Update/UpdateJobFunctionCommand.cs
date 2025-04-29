using Application.Features.JobFunctions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobFunctions.Commands.Update;

public class UpdateJobFunctionCommand : IRequest<UpdatedJobFunctionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobFunctions"];

    public class UpdateJobFunctionCommandHandler : IRequestHandler<UpdateJobFunctionCommand, UpdatedJobFunctionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobFunctionRepository _jobFunctionRepository;
        private readonly JobFunctionBusinessRules _jobFunctionBusinessRules;

        public UpdateJobFunctionCommandHandler(IMapper mapper, IJobFunctionRepository jobFunctionRepository,
                                         JobFunctionBusinessRules jobFunctionBusinessRules)
        {
            _mapper = mapper;
            _jobFunctionRepository = jobFunctionRepository;
            _jobFunctionBusinessRules = jobFunctionBusinessRules;
        }

        public async Task<UpdatedJobFunctionResponse> Handle(UpdateJobFunctionCommand request, CancellationToken cancellationToken)
        {
            JobFunction? jobFunction = await _jobFunctionRepository.GetAsync(predicate: jf => jf.Id == request.Id, cancellationToken: cancellationToken);
            await _jobFunctionBusinessRules.JobFunctionShouldExistWhenSelected(jobFunction);
            jobFunction = _mapper.Map(request, jobFunction);

            await _jobFunctionRepository.UpdateAsync(jobFunction!);

            UpdatedJobFunctionResponse response = _mapper.Map<UpdatedJobFunctionResponse>(jobFunction);
            return response;
        }
    }
}