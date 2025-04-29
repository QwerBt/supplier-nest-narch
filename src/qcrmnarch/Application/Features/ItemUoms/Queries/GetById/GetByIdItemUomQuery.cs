using Application.Features.ItemUoms.Constants;
using Application.Features.ItemUoms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ItemUoms.Constants.ItemUomsOperationClaims;

namespace Application.Features.ItemUoms.Queries.GetById;

public class GetByIdItemUomQuery : IRequest<GetByIdItemUomResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdItemUomQueryHandler : IRequestHandler<GetByIdItemUomQuery, GetByIdItemUomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IItemUomRepository _itemUomRepository;
        private readonly ItemUomBusinessRules _itemUomBusinessRules;

        public GetByIdItemUomQueryHandler(IMapper mapper, IItemUomRepository itemUomRepository, ItemUomBusinessRules itemUomBusinessRules)
        {
            _mapper = mapper;
            _itemUomRepository = itemUomRepository;
            _itemUomBusinessRules = itemUomBusinessRules;
        }

        public async Task<GetByIdItemUomResponse> Handle(GetByIdItemUomQuery request, CancellationToken cancellationToken)
        {
            ItemUom? itemUom = await _itemUomRepository.GetAsync(predicate: iu => iu.Id == request.Id, cancellationToken: cancellationToken);
            await _itemUomBusinessRules.ItemUomShouldExistWhenSelected(itemUom);

            GetByIdItemUomResponse response = _mapper.Map<GetByIdItemUomResponse>(itemUom);
            return response;
        }
    }
}