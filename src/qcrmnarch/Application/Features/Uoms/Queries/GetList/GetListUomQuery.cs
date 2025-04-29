using Application.Features.Uoms.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Uoms.Constants.UomsOperationClaims;

namespace Application.Features.Uoms.Queries.GetList;

public class GetListUomQuery : IRequest<GetListResponse<GetListUomListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUoms({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUoms";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUomQueryHandler : IRequestHandler<GetListUomQuery, GetListResponse<GetListUomListItemDto>>
    {
        private readonly IUomRepository _uomRepository;
        private readonly IMapper _mapper;

        public GetListUomQueryHandler(IUomRepository uomRepository, IMapper mapper)
        {
            _uomRepository = uomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUomListItemDto>> Handle(GetListUomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Uom> uoms = await _uomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUomListItemDto> response = _mapper.Map<GetListResponse<GetListUomListItemDto>>(uoms);
            return response;
        }
    }
}