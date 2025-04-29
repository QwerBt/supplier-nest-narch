using Application.Features.Services.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Services.Constants.ServicesOperationClaims;

namespace Application.Features.Services.Queries.GetList;

public class GetListServiceQuery : IRequest<GetListResponse<GetListServiceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListServices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetServices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListServiceQueryHandler : IRequestHandler<GetListServiceQuery, GetListResponse<GetListServiceListItemDto>>
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public GetListServiceQueryHandler(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListServiceListItemDto>> Handle(GetListServiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Service> services = await _serviceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListServiceListItemDto> response = _mapper.Map<GetListResponse<GetListServiceListItemDto>>(services);
            return response;
        }
    }
}