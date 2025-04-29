using Application.Features.Industries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Industries.Commands.Create;

public class CreateIndustryCommand : IRequest<CreatedIndustryResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public int? ParentIndustryId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIndustries"];

    public class CreateIndustryCommandHandler : IRequestHandler<CreateIndustryCommand, CreatedIndustryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _industryRepository;
        private readonly IndustryBusinessRules _industryBusinessRules;

        public CreateIndustryCommandHandler(IMapper mapper, IIndustryRepository industryRepository,
                                         IndustryBusinessRules industryBusinessRules)
        {
            _mapper = mapper;
            _industryRepository = industryRepository;
            _industryBusinessRules = industryBusinessRules;
        }

        public async Task<CreatedIndustryResponse> Handle(CreateIndustryCommand request, CancellationToken cancellationToken)
        {
            Industry industry = _mapper.Map<Industry>(request);

            await _industryRepository.AddAsync(industry);

            CreatedIndustryResponse response = _mapper.Map<CreatedIndustryResponse>(industry);
            return response;
        }
    }
}