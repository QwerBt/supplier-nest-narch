using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CompanyAddresses.Queries.GetList;

public class GetListCompanyAddressQuery : IRequest<GetListResponse<GetListCompanyAddressListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyAddresses({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyAddresses";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyAddressQueryHandler : IRequestHandler<GetListCompanyAddressQuery, GetListResponse<GetListCompanyAddressListItemDto>>
    {
        private readonly ICompanyAddressRepository _companyAddressRepository;
        private readonly IMapper _mapper;

        public GetListCompanyAddressQueryHandler(ICompanyAddressRepository companyAddressRepository, IMapper mapper)
        {
            _companyAddressRepository = companyAddressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyAddressListItemDto>> Handle(GetListCompanyAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyAddress> companyAddresses = await _companyAddressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyAddressListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyAddressListItemDto>>(companyAddresses);
            return response;
        }
    }
}