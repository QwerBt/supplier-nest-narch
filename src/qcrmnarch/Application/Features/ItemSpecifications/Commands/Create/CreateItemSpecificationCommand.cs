using Application.Features.ItemSpecifications.Constants;
using Application.Features.ItemSpecifications.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ItemSpecifications.Constants.ItemSpecificationsOperationClaims;

namespace Application.Features.ItemSpecifications.Commands.Create;

public class CreateItemSpecificationCommand : IRequest<CreatedItemSpecificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int ItemId { get; set; }
    public required Item Item { get; set; }
    public required int SpecificationId { get; set; }
    public required Specification Specification { get; set; }

    public string[] Roles => [Admin, Write, ItemSpecificationsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemSpecifications"];

    public class CreateItemSpecificationCommandHandler : IRequestHandler<CreateItemSpecificationCommand, CreatedItemSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemSpecificationRepository _itemSpecificationRepository;
        private readonly ItemSpecificationBusinessRules _itemSpecificationBusinessRules;

        public CreateItemSpecificationCommandHandler(IMapper mapper, IItemSpecificationRepository itemSpecificationRepository,
                                         ItemSpecificationBusinessRules itemSpecificationBusinessRules)
        {
            _mapper = mapper;
            _itemSpecificationRepository = itemSpecificationRepository;
            _itemSpecificationBusinessRules = itemSpecificationBusinessRules;
        }

        public async Task<CreatedItemSpecificationResponse> Handle(CreateItemSpecificationCommand request, CancellationToken cancellationToken)
        {
            ItemSpecification itemSpecification = _mapper.Map<ItemSpecification>(request);

            await _itemSpecificationRepository.AddAsync(itemSpecification);

            CreatedItemSpecificationResponse response = _mapper.Map<CreatedItemSpecificationResponse>(itemSpecification);
            return response;
        }
    }
}