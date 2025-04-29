using Application.Features.CompanyContacts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyContacts.Constants.CompanyContactsOperationClaims;

namespace Application.Features.CompanyContacts.Queries.GetList;

public class GetListCompanyContactQuery : IRequest<GetListResponse<GetListCompanyContactListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyContacts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyContacts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyContactQueryHandler : IRequestHandler<GetListCompanyContactQuery, GetListResponse<GetListCompanyContactListItemDto>>
    {
        private readonly ICompanyContactRepository _companyContactRepository;
        private readonly IMapper _mapper;

        public GetListCompanyContactQueryHandler(ICompanyContactRepository companyContactRepository, IMapper mapper)
        {
            _companyContactRepository = companyContactRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyContactListItemDto>> Handle(GetListCompanyContactQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyContact> companyContacts = await _companyContactRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyContactListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyContactListItemDto>>(companyContacts);
            return response;
        }
    }
}