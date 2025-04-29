using Application.Features.Industries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Industries.Commands.Update;

public class UpdateIndustryCommand : IRequest<UpdatedIndustryResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int? ParentIndustryId { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIndustries"];

    public class UpdateIndustryCommandHandler : IRequestHandler<UpdateIndustryCommand, UpdatedIndustryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndustryRepository _industryRepository;
        private readonly IndustryBusinessRules _industryBusinessRules;

        public UpdateIndustryCommandHandler(IMapper mapper, IIndustryRepository industryRepository,
                                         IndustryBusinessRules industryBusinessRules)
        {
            _mapper = mapper;
            _industryRepository = industryRepository;
            _industryBusinessRules = industryBusinessRules;
        }

        public async Task<UpdatedIndustryResponse> Handle(UpdateIndustryCommand request, CancellationToken cancellationToken)
        {
            Industry? industry = await _industryRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _industryBusinessRules.IndustryShouldExistWhenSelected(industry);
            industry = _mapper.Map(request, industry);

            await _industryRepository.UpdateAsync(industry!);

            UpdatedIndustryResponse response = _mapper.Map<UpdatedIndustryResponse>(industry);
            return response;
        }
    }
}