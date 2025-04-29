using Application.Features.Specifications.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Specifications.Constants.SpecificationsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Specifications.Queries.GetList;

public class GetListSpecificationQuery : IRequest<GetListResponse<GetListSpecificationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSpecifications({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSpecifications";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSpecificationQueryHandler : IRequestHandler<GetListSpecificationQuery, GetListResponse<GetListSpecificationListItemDto>>
    {
        private readonly ISpecificationRepository _specificationRepository;
        private readonly IMapper _mapper;

        public GetListSpecificationQueryHandler(ISpecificationRepository specificationRepository, IMapper mapper)
        {
            _specificationRepository = specificationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSpecificationListItemDto>> Handle(GetListSpecificationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Specification> specifications = await _specificationRepository.GetListAsync(
                include: i => i.Include(i => i.SpecificationValues),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSpecificationListItemDto> response = _mapper.Map<GetListResponse<GetListSpecificationListItemDto>>(specifications);
            return response;
        }
    }
}