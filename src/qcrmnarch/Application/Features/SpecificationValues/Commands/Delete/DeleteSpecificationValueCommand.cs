using Application.Features.SpecificationValues.Constants;
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

namespace Application.Features.SpecificationValues.Commands.Delete;

public class DeleteSpecificationValueCommand : IRequest<DeletedSpecificationValueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, SpecificationValuesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSpecificationValues"];

    public class DeleteSpecificationValueCommandHandler : IRequestHandler<DeleteSpecificationValueCommand, DeletedSpecificationValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationValueRepository _specificationValueRepository;
        private readonly SpecificationValueBusinessRules _specificationValueBusinessRules;

        public DeleteSpecificationValueCommandHandler(IMapper mapper, ISpecificationValueRepository specificationValueRepository,
                                         SpecificationValueBusinessRules specificationValueBusinessRules)
        {
            _mapper = mapper;
            _specificationValueRepository = specificationValueRepository;
            _specificationValueBusinessRules = specificationValueBusinessRules;
        }

        public async Task<DeletedSpecificationValueResponse> Handle(DeleteSpecificationValueCommand request, CancellationToken cancellationToken)
        {
            SpecificationValue? specificationValue = await _specificationValueRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _specificationValueBusinessRules.SpecificationValueShouldExistWhenSelected(specificationValue);

            await _specificationValueRepository.DeleteAsync(specificationValue!);

            DeletedSpecificationValueResponse response = _mapper.Map<DeletedSpecificationValueResponse>(specificationValue);
            return response;
        }
    }
}