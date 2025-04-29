using Application.Features.Items.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Items.Constants.ItemsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Items.Queries.GetList;

public class GetListItemQuery : IRequest<GetListResponse<GetListItemListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListItems({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetItems";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListItemQueryHandler : IRequestHandler<GetListItemQuery, GetListResponse<GetListItemListItemDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetListItemQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListItemListItemDto>> Handle(GetListItemQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Item> items = await _itemRepository.GetListAsync(
                include: p => 
                p.Include(x => x.ItemSpecifications)
                    .ThenInclude(x => x.Specification)
                    .ThenInclude(x => x.SpecificationValues), // Include related items
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListItemListItemDto> response = _mapper.Map<GetListResponse<GetListItemListItemDto>>(items);
            return response;
        }
    }
}