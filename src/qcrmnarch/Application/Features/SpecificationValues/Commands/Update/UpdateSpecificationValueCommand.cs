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

namespace Application.Features.SpecificationValues.Commands.Update;

public class UpdateSpecificationValueCommand : IRequest<UpdatedSpecificationValueResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int SpecificationId { get; set; }

    public string[] Roles => [Admin, Write, SpecificationValuesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSpecificationValues"];

    public class UpdateSpecificationValueCommandHandler : IRequestHandler<UpdateSpecificationValueCommand, UpdatedSpecificationValueResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISpecificationValueRepository _specificationValueRepository;
        private readonly SpecificationValueBusinessRules _specificationValueBusinessRules;

        public UpdateSpecificationValueCommandHandler(IMapper mapper, ISpecificationValueRepository specificationValueRepository,
                                         SpecificationValueBusinessRules specificationValueBusinessRules)
        {
            _mapper = mapper;
            _specificationValueRepository = specificationValueRepository;
            _specificationValueBusinessRules = specificationValueBusinessRules;
        }

        public async Task<UpdatedSpecificationValueResponse> Handle(UpdateSpecificationValueCommand request, CancellationToken cancellationToken)
        {
            SpecificationValue? specificationValue = await _specificationValueRepository.GetAsync(predicate: sv => sv.Id == request.Id, cancellationToken: cancellationToken);
            await _specificationValueBusinessRules.SpecificationValueShouldExistWhenSelected(specificationValue);
            specificationValue = _mapper.Map(request, specificationValue);

            await _specificationValueRepository.UpdateAsync(specificationValue!);

            UpdatedSpecificationValueResponse response = _mapper.Map<UpdatedSpecificationValueResponse>(specificationValue);
            return response;
        }
    }
}