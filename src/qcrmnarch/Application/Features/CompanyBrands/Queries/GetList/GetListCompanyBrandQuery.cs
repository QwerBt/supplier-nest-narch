using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CompanyBrands.Queries.GetList;

public class GetListCompanyBrandQuery : IRequest<GetListResponse<GetListCompanyBrandListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyBrands({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyBrands";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyBrandQueryHandler : IRequestHandler<GetListCompanyBrandQuery, GetListResponse<GetListCompanyBrandListItemDto>>
    {
        private readonly ICompanyBrandRepository _companyBrandRepository;
        private readonly IMapper _mapper;

        public GetListCompanyBrandQueryHandler(ICompanyBrandRepository companyBrandRepository, IMapper mapper)
        {
            _companyBrandRepository = companyBrandRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyBrandListItemDto>> Handle(GetListCompanyBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyBrand> companyBrands = await _companyBrandRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyBrandListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyBrandListItemDto>>(companyBrands);
            return response;
        }
    }
}