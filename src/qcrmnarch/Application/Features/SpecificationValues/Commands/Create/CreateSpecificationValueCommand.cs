using Application.Features.SpecificationValues.Constants;
using Application.Features.SpecificationValues.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.SpecificationValues.Constants.SpecificationValuesOperationClaims;

namespace Application.Features.SpecificationValues.Commands.Create;

public class CreateSpecificationValueCommand : IRequest<CreatedSpecificationValueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required int SpecificationId { get; set; }

    public string[] Roles => [Admin, Write, SpecificationValuesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSpecificationValues"];

    public class CreateSpecificationValueCommandHandler : IRequestHandler<CreateSpecificationValueCommand, CreatedSpecificationValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationValueRepository _specificationValueRepository;
        private readonly SpecificationValueBusinessRules _specificationValueBusinessRules;

        public CreateSpecificationValueCommandHandler(IMapper mapper, ISpecificationValueRepository specificationValueRepository,
                                         SpecificationValueBusinessRules specificationValueBusinessRules)
        {
            _mapper = mapper;
            _specificationValueRepository = specificationValueRepository;
            _specificationValueBusinessRules = specificationValueBusinessRules;
        }

        public async Task<CreatedSpecificationValueResponse> Handle(CreateSpecificationValueCommand request, CancellationToken cancellationToken)
        {
            SpecificationValue specificationValue = _mapper.Map<SpecificationValue>(request);

            await _specificationValueRepository.AddAsync(specificationValue);

            CreatedSpecificationValueResponse response = _mapper.Map<CreatedSpecificationValueResponse>(specificationValue);
            return response;
        }
    }
}