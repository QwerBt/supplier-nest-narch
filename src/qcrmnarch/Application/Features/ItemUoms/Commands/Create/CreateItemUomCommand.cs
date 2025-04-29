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

namespace Application.Features.ItemUoms.Commands.Create;

public class CreateItemUomCommand : IRequest<CreatedItemUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required int ItemId { get; set; }
    public required Item Item { get; set; }
    public required int UomId { get; set; }
    public required Uom Uom { get; set; }
    public required decimal ConversionRate { get; set; }

    public string[] Roles => [Admin, Write, ItemUomsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemUoms"];

    public class CreateItemUomCommandHandler : IRequestHandler<CreateItemUomCommand, CreatedItemUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemUomRepository _itemUomRepository;
        private readonly ItemUomBusinessRules _itemUomBusinessRules;

        public CreateItemUomCommandHandler(IMapper mapper, IItemUomRepository itemUomRepository,
                                         ItemUomBusinessRules itemUomBusinessRules)
        {
            _mapper = mapper;
            _itemUomRepository = itemUomRepository;
            _itemUomBusinessRules = itemUomBusinessRules;
        }

        public async Task<CreatedItemUomResponse> Handle(CreateItemUomCommand request, CancellationToken cancellationToken)
        {
            ItemUom itemUom = _mapper.Map<ItemUom>(request);

            await _itemUomRepository.AddAsync(itemUom);

            CreatedItemUomResponse response = _mapper.Map<CreatedItemUomResponse>(itemUom);
            return response;
        }
    }
}