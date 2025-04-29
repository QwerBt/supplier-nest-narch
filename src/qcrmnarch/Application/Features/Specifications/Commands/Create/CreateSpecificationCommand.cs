using Application.Features.Specifications.Constants;
using Application.Features.Specifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Specifications.Constants.SpecificationsOperationClaims;

namespace Application.Features.Specifications.Commands.Create;

public class CreateSpecificationCommand : IRequest<CreatedSpecificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, SpecificationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSpecifications"];

    public class CreateSpecificationCommandHandler : IRequestHandler<CreateSpecificationCommand, CreatedSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationRepository _specificationRepository;
        private readonly SpecificationBusinessRules _specificationBusinessRules;

        public CreateSpecificationCommandHandler(IMapper mapper, ISpecificationRepository specificationRepository,
                                         SpecificationBusinessRules specificationBusinessRules)
        {
            _mapper = mapper;
            _specificationRepository = specificationRepository;
            _specificationBusinessRules = specificationBusinessRules;
        }

        public async Task<CreatedSpecificationResponse> Handle(CreateSpecificationCommand request, CancellationToken cancellationToken)
        {
            Specification specification = _mapper.Map<Specification>(request);

            await _specificationRepository.AddAsync(specification);

            CreatedSpecificationResponse response = _mapper.Map<CreatedSpecificationResponse>(specification);
            return response;
        }
    }
}