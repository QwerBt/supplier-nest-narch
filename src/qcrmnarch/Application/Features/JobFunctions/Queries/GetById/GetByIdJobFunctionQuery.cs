using Application.Features.JobFunctions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobFunctions.Queries.GetById;

public class GetByIdJobFunctionQuery : IRequest<GetByIdJobFunctionResponse>
{
    public int Id { get; set; }

    public class GetByIdJobFunctionQueryHandler : IRequestHandler<GetByIdJobFunctionQuery, GetByIdJobFunctionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobFunctionRepository _jobFunctionRepository;
        private readonly JobFunctionBusinessRules _jobFunctionBusinessRules;

        public GetByIdJobFunctionQueryHandler(IMapper mapper, IJobFunctionRepository jobFunctionRepository, JobFunctionBusinessRules jobFunctionBusinessRules)
        {
            _mapper = mapper;
            _jobFunctionRepository = jobFunctionRepository;
            _jobFunctionBusinessRules = jobFunctionBusinessRules;
        }

        public async Task<GetByIdJobFunctionResponse> Handle(GetByIdJobFunctionQuery request, CancellationToken cancellationToken)
        {
            JobFunction? jobFunction = await _jobFunctionRepository.GetAsync(predicate: jf => jf.Id == request.Id, cancellationToken: cancellationToken);
            await _jobFunctionBusinessRules.JobFunctionShouldExistWhenSelected(jobFunction);

            GetByIdJobFunctionResponse response = _mapper.Map<GetByIdJobFunctionResponse>(jobFunction);
            return response;
        }
    }
}

