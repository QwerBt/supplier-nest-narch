using Application.Features.ItemSpecifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ItemSpecifications.Constants.ItemSpecificationsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ItemSpecifications.Queries.GetList;

public class GetListItemSpecificationQuery : IRequest<GetListResponse<GetListItemSpecificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListItemSpecifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetItemSpecifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListItemSpecificationQueryHandler : IRequestHandler<GetListItemSpecificationQuery, GetListResponse<GetListItemSpecificationListItemDto>>
    {
        private readonly IItemSpecificationRepository _itemSpecificationRepository;
        private readonly IMapper _mapper;

        public GetListItemSpecificationQueryHandler(IItemSpecificationRepository itemSpecificationRepository, IMapper mapper)
        {
            _itemSpecificationRepository = itemSpecificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListItemSpecificationListItemDto>> Handle(GetListItemSpecificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ItemSpecification> itemSpecifications = await _itemSpecificationRepository.GetListAsync(
                include:i=>i.Include(i=>i.Specification).Include(i=>i.SpecificationValue).Include(i => i.Item),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListItemSpecificationListItemDto> response = _mapper.Map<GetListResponse<GetListItemSpecificationListItemDto>>(itemSpecifications);
            return response;
        }
    }
}