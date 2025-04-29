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

namespace Application.Features.Specifications.Commands.Update;

public class UpdateSpecificationCommand : IRequest<UpdatedSpecificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, SpecificationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSpecifications"];

    public class UpdateSpecificationCommandHandler : IRequestHandler<UpdateSpecificationCommand, UpdatedSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationRepository _specificationRepository;
        private readonly SpecificationBusinessRules _specificationBusinessRules;

        public UpdateSpecificationCommandHandler(IMapper mapper, ISpecificationRepository specificationRepository,
                                         SpecificationBusinessRules specificationBusinessRules)
        {
            _mapper = mapper;
            _specificationRepository = specificationRepository;
            _specificationBusinessRules = specificationBusinessRules;
        }

        public async Task<UpdatedSpecificationResponse> Handle(UpdateSpecificationCommand request, CancellationToken cancellationToken)
        {
            Specification? specification = await _specificationRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _specificationBusinessRules.SpecificationShouldExistWhenSelected(specification);
            specification = _mapper.Map(request, specification);

            await _specificationRepository.UpdateAsync(specification!);

            UpdatedSpecificationResponse response = _mapper.Map<UpdatedSpecificationResponse>(specification);
            return response;
        }
    }
}