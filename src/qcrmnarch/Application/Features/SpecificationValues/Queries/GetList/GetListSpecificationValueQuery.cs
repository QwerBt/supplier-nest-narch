using Application.Features.SpecificationValues.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.SpecificationValues.Constants.SpecificationValuesOperationClaims;

namespace Application.Features.SpecificationValues.Queries.GetList;

public class GetListSpecificationValueQuery : IRequest<GetListResponse<GetListSpecificationValueListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSpecificationValues({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSpecificationValues";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSpecificationValueQueryHandler : IRequestHandler<GetListSpecificationValueQuery, GetListResponse<GetListSpecificationValueListItemDto>>
    {
        private readonly ISpecificationValueRepository _specificationValueRepository;
        private readonly IMapper _mapper;

        public GetListSpecificationValueQueryHandler(ISpecificationValueRepository specificationValueRepository, IMapper mapper)
        {
            _specificationValueRepository = specificationValueRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSpecificationValueListItemDto>> Handle(GetListSpecificationValueQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SpecificationValue> specificationValues = await _specificationValueRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSpecificationValueListItemDto> response = _mapper.Map<GetListResponse<GetListSpecificationValueListItemDto>>(specificationValues);
            return response;
        }
    }
}