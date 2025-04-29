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

namespace Application.Features.ItemSpecifications.Commands.Update;

public class UpdateItemSpecificationCommand : IRequest<UpdatedItemSpecificationResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int ItemId { get; set; }
    public required Item Item { get; set; }
    public required int SpecificationId { get; set; }
    public required Specification Specification { get; set; }

    public string[] Roles => [Admin, Write, ItemSpecificationsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemSpecifications"];

    public class UpdateItemSpecificationCommandHandler : IRequestHandler<UpdateItemSpecificationCommand, UpdatedItemSpecificationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemSpecificationRepository _itemSpecificationRepository;
        private readonly ItemSpecificationBusinessRules _itemSpecificationBusinessRules;

        public UpdateItemSpecificationCommandHandler(IMapper mapper, IItemSpecificationRepository itemSpecificationRepository,
                                         ItemSpecificationBusinessRules itemSpecificationBusinessRules)
        {
            _mapper = mapper;
            _itemSpecificationRepository = itemSpecificationRepository;
            _itemSpecificationBusinessRules = itemSpecificationBusinessRules;
        }

        public async Task<UpdatedItemSpecificationResponse> Handle(UpdateItemSpecificationCommand request, CancellationToken cancellationToken)
        {
            ItemSpecification? itemSpecification = await _itemSpecificationRepository.GetAsync(predicate: isp => isp.Id == request.Id, cancellationToken: cancellationToken);
            await _itemSpecificationBusinessRules.ItemSpecificationShouldExistWhenSelected(itemSpecification);
            itemSpecification = _mapper.Map(request, itemSpecification);

            await _itemSpecificationRepository.UpdateAsync(itemSpecification!);

            UpdatedItemSpecificationResponse response = _mapper.Map<UpdatedItemSpecificationResponse>(itemSpecification);
            return response;
        }
    }
}