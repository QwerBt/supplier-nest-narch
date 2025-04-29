using Application.Features.CompanyServices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyServices.Constants.CompanyServicesOperationClaims;

namespace Application.Features.CompanyServices.Queries.GetList;

public class GetListCompanyServiceQuery : IRequest<GetListResponse<GetListCompanyServiceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyServices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyServices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyServiceQueryHandler : IRequestHandler<GetListCompanyServiceQuery, GetListResponse<GetListCompanyServiceListItemDto>>
    {
        private readonly ICompanyServiceRepository _companyServiceRepository;
        private readonly IMapper _mapper;

        public GetListCompanyServiceQueryHandler(ICompanyServiceRepository companyServiceRepository, IMapper mapper)
        {
            _companyServiceRepository = companyServiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyServiceListItemDto>> Handle(GetListCompanyServiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyService> companyServices = await _companyServiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyServiceListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyServiceListItemDto>>(companyServices);
            return response;
        }
    }
}