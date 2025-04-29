using Application.Features.ItemSpecifications.Constants;
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

namespace Application.Features.ItemSpecifications.Commands.Delete;

public class DeleteItemSpecificationCommand : IRequest<DeletedItemSpecificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ItemSpecificationsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemSpecifications"];

    public class DeleteItemSpecificationCommandHandler : IRequestHandler<DeleteItemSpecificationCommand, DeletedItemSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemSpecificationRepository _itemSpecificationRepository;
        private readonly ItemSpecificationBusinessRules _itemSpecificationBusinessRules;

        public DeleteItemSpecificationCommandHandler(IMapper mapper, IItemSpecificationRepository itemSpecificationRepository,
                                         ItemSpecificationBusinessRules itemSpecificationBusinessRules)
        {
            _mapper = mapper;
            _itemSpecificationRepository = itemSpecificationRepository;
            _itemSpecificationBusinessRules = itemSpecificationBusinessRules;
        }

        public async Task<DeletedItemSpecificationResponse> Handle(DeleteItemSpecificationCommand request, CancellationToken cancellationToken)
        {
            ItemSpecification? itemSpecification = await _itemSpecificationRepository.GetAsync(predicate: isp => isp.Id == request.Id, cancellationToken: cancellationToken);
            await _itemSpecificationBusinessRules.ItemSpecificationShouldExistWhenSelected(itemSpecification);

            await _itemSpecificationRepository.DeleteAsync(itemSpecification!);

            DeletedItemSpecificationResponse response = _mapper.Map<DeletedItemSpecificationResponse>(itemSpecification);
            return response;
        }
    }
}