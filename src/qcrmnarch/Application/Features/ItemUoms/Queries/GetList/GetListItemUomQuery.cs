using Application.Features.ItemUoms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ItemUoms.Constants.ItemUomsOperationClaims;

namespace Application.Features.ItemUoms.Queries.GetList;

public class GetListItemUomQuery : IRequest<GetListResponse<GetListItemUomListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListItemUoms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetItemUoms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListItemUomQueryHandler : IRequestHandler<GetListItemUomQuery, GetListResponse<GetListItemUomListItemDto>>
    {
        private readonly IItemUomRepository _itemUomRepository;
        private readonly IMapper _mapper;

        public GetListItemUomQueryHandler(IItemUomRepository itemUomRepository, IMapper mapper)
        {
            _itemUomRepository = itemUomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListItemUomListItemDto>> Handle(GetListItemUomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ItemUom> itemUoms = await _itemUomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListItemUomListItemDto> response = _mapper.Map<GetListResponse<GetListItemUomListItemDto>>(itemUoms);
            return response;
        }
    }
}