using Application.Features.ItemUoms.Constants;
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

namespace Application.Features.ItemUoms.Commands.Delete;

public class DeleteItemUomCommand : IRequest<DeletedItemUomResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, ItemUomsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetItemUoms"];

    public class DeleteItemUomCommandHandler : IRequestHandler<DeleteItemUomCommand, DeletedItemUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemUomRepository _itemUomRepository;
        private readonly ItemUomBusinessRules _itemUomBusinessRules;

        public DeleteItemUomCommandHandler(IMapper mapper, IItemUomRepository itemUomRepository,
                                         ItemUomBusinessRules itemUomBusinessRules)
        {
            _mapper = mapper;
            _itemUomRepository = itemUomRepository;
            _itemUomBusinessRules = itemUomBusinessRules;
        }

        public async Task<DeletedItemUomResponse> Handle(DeleteItemUomCommand request, CancellationToken cancellationToken)
        {
            ItemUom? itemUom = await _itemUomRepository.GetAsync(predicate: iu => iu.Id == request.Id, cancellationToken: cancellationToken);
            await _itemUomBusinessRules.ItemUomShouldExistWhenSelected(itemUom);

            await _itemUomRepository.DeleteAsync(itemUom!);

            DeletedItemUomResponse response = _mapper.Map<DeletedItemUomResponse>(itemUom);
            return response;
        }
    }
}