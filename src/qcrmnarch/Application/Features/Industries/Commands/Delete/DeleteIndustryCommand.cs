using Application.Features.Industries.Constants;
using Application.Features.Industries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Industries.Commands.Delete;

public class DeleteIndustryCommand : IRequest<DeletedIndustryResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIndustries"];

    public class DeleteIndustryCommandHandler : IRequestHandler<DeleteIndustryCommand, DeletedIndustryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _industryRepository;
        private readonly IndustryBusinessRules _industryBusinessRules;

        public DeleteIndustryCommandHandler(IMapper mapper, IIndustryRepository industryRepository,
                                         IndustryBusinessRules industryBusinessRules)
        {
            _mapper = mapper;
            _industryRepository = industryRepository;
            _industryBusinessRules = industryBusinessRules;
        }

        public async Task<DeletedIndustryResponse> Handle(DeleteIndustryCommand request, CancellationToken cancellationToken)
        {
            Industry? industry = await _industryRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _industryBusinessRules.IndustryShouldExistWhenSelected(industry);

            await _industryRepository.DeleteAsync(industry!);

            DeletedIndustryResponse response = _mapper.Map<DeletedIndustryResponse>(industry);
            return response;
        }
    }
}