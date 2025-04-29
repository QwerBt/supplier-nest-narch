using Application.Features.CompanyUsers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyUsers.Constants.CompanyUsersOperationClaims;

namespace Application.Features.CompanyUsers.Queries.GetList;

public class GetListCompanyUserQuery : IRequest<GetListResponse<GetListCompanyUserListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyUsers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyUsers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyUserQueryHandler : IRequestHandler<GetListCompanyUserQuery, GetListResponse<GetListCompanyUserListItemDto>>
    {
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly IMapper _mapper;

        public GetListCompanyUserQueryHandler(ICompanyUserRepository companyUserRepository, IMapper mapper)
        {
            _companyUserRepository = companyUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyUserListItemDto>> Handle(GetListCompanyUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyUser> companyUsers = await _companyUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyUserListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyUserListItemDto>>(companyUsers);
            return response;
        }
    }
}