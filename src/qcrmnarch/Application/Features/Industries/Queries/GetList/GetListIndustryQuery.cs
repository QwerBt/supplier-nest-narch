using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Industries.Queries.GetList;

public class GetListIndustryQuery : IRequest<GetListResponse<GetListIndustryListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListIndustries({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetIndustries";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListIndustryQueryHandler : IRequestHandler<GetListIndustryQuery, GetListResponse<GetListIndustryListItemDto>>
    {
        private readonly IIndustryRepository _industryRepository;
        private readonly IMapper _mapper;

        public GetListIndustryQueryHandler(IIndustryRepository industryRepository, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIndustryListItemDto>> Handle(GetListIndustryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Industry> industries = await _industryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListIndustryListItemDto> response = _mapper.Map<GetListResponse<GetListIndustryListItemDto>>(industries);
            return response;
        }
    }
}