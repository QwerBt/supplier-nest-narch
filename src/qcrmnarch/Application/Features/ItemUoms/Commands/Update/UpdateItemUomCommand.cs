using Application.Features.ItemUoms.Constants;
using Application.Features.ItemUoms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ItemUoms.Constants.ItemUomsOperationClaims;

namespace Application.Features.ItemUoms.Commands.Update;

public class UpdateItemUomCommand : IRequest<UpdatedItemUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public required int ItemId { get; set; }
    public required Item Item { get; set; }
    public required int UomId { get; set; }
    public required Uom Uom { get; set; }
    public required decimal ConversionRate { get; set; }

    public string[] Roles => [Admin, Write, ItemUomsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemUoms"];

    public class UpdateItemUomCommandHandler : IRequestHandler<UpdateItemUomCommand, UpdatedItemUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemUomRepository _itemUomRepository;
        private readonly ItemUomBusinessRules _itemUomBusinessRules;

        public UpdateItemUomCommandHandler(IMapper mapper, IItemUomRepository itemUomRepository,
                                         ItemUomBusinessRules itemUomBusinessRules)
        {
            _mapper = mapper;
            _itemUomRepository = itemUomRepository;
            _itemUomBusinessRules = itemUomBusinessRules;
        }

        public async Task<UpdatedItemUomResponse> Handle(UpdateItemUomCommand request, CancellationToken cancellationToken)
        {
            ItemUom? itemUom = await _itemUomRepository.GetAsync(predicate: iu => iu.Id == request.Id, cancellationToken: cancellationToken);
            await _itemUomBusinessRules.ItemUomShouldExistWhenSelected(itemUom);
            itemUom = _mapper.Map(request, itemUom);

            await _itemUomRepository.UpdateAsync(itemUom!);

            UpdatedItemUomResponse response = _mapper.Map<UpdatedItemUomResponse>(itemUom);
            return response;
        }
    }
}