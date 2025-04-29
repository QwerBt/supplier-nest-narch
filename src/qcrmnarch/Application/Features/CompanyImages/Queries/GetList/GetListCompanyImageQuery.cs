using Application.Features.CompanyImages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.CompanyImages.Constants.CompanyImagesOperationClaims;

namespace Application.Features.CompanyImages.Queries.GetList;

public class GetListCompanyImageQuery : IRequest<GetListResponse<GetListCompanyImageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCompanyImages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCompanyImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCompanyImageQueryHandler : IRequestHandler<GetListCompanyImageQuery, GetListResponse<GetListCompanyImageListItemDto>>
    {
        private readonly ICompanyImageRepository _companyImageRepository;
        private readonly IMapper _mapper;

        public GetListCompanyImageQueryHandler(ICompanyImageRepository companyImageRepository, IMapper mapper)
        {
            _companyImageRepository = companyImageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCompanyImageListItemDto>> Handle(GetListCompanyImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CompanyImage> companyImages = await _companyImageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCompanyImageListItemDto> response = _mapper.Map<GetListResponse<GetListCompanyImageListItemDto>>(companyImages);
            return response;
        }
    }
}