using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Towns.Queries.GetList;

public class GetListTownQuery : IRequest<GetListResponse<GetListTownListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTowns({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTowns";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTownQueryHandler : IRequestHandler<GetListTownQuery, GetListResponse<GetListTownListItemDto>>
    {
        private readonly ITownRepository _townRepository;
        private readonly IMapper _mapper;

        public GetListTownQueryHandler(ITownRepository townRepository, IMapper mapper)
        {
            _townRepository = townRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTownListItemDto>> Handle(GetListTownQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Town> towns = await _townRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTownListItemDto> response = _mapper.Map<GetListResponse<GetListTownListItemDto>>(towns);
            return response;
        }
    }
}