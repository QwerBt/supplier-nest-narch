using Application.Features.JobLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobLevels.Queries.GetById;

public class GetByIdJobLevelQuery : IRequest<GetByIdJobLevelResponse>
{
    public int Id { get; set; }

    public class GetByIdJobLevelQueryHandler : IRequestHandler<GetByIdJobLevelQuery, GetByIdJobLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJobLevelRepository _jobLevelRepository;
        private readonly JobLevelBusinessRules _jobLevelBusinessRules;

        public GetByIdJobLevelQueryHandler(IMapper mapper, IJobLevelRepository jobLevelRepository, JobLevelBusinessRules jobLevelBusinessRules)
        {
            _mapper = mapper;
            _jobLevelRepository = jobLevelRepository;
            _jobLevelBusinessRules = jobLevelBusinessRules;
        }

        public async Task<GetByIdJobLevelResponse> Handle(GetByIdJobLevelQuery request, CancellationToken cancellationToken)
        {
            JobLevel? jobLevel = await _jobLevelRepository.GetAsync(predicate: jl => jl.Id == request.Id, cancellationToken: cancellationToken);
            await _jobLevelBusinessRules.JobLevelShouldExistWhenSelected(jobLevel);

            GetByIdJobLevelResponse response = _mapper.Map<GetByIdJobLevelResponse>(jobLevel);
            return response;
        }
    }
}