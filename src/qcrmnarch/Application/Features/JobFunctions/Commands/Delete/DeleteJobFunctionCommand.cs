using Application.Features.JobFunctions.Constants;
using Application.Features.JobFunctions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.JobFunctions.Commands.Delete;

public class DeleteJobFunctionCommand : IRequest<DeletedJobFunctionResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetJobFunctions"];

    public class DeleteJobFunctionCommandHandler : IRequestHandler<DeleteJobFunctionCommand, DeletedJobFunctionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobFunctionRepository _jobFunctionRepository;
        private readonly JobFunctionBusinessRules _jobFunctionBusinessRules;

        public DeleteJobFunctionCommandHandler(IMapper mapper, IJobFunctionRepository jobFunctionRepository,
                                         JobFunctionBusinessRules jobFunctionBusinessRules)
        {
            _mapper = mapper;
            _jobFunctionRepository = jobFunctionRepository;
            _jobFunctionBusinessRules = jobFunctionBusinessRules;
        }

        public async Task<DeletedJobFunctionResponse> Handle(DeleteJobFunctionCommand request, CancellationToken cancellationToken)
        {
            JobFunction? jobFunction = await _jobFunctionRepository.GetAsync(predicate: jf => jf.Id == request.Id, cancellationToken: cancellationToken);
            await _jobFunctionBusinessRules.JobFunctionShouldExistWhenSelected(jobFunction);

            await _jobFunctionRepository.DeleteAsync(jobFunction!);

            DeletedJobFunctionResponse response = _mapper.Map<DeletedJobFunctionResponse>(jobFunction);
            return response;
        }
    }
}