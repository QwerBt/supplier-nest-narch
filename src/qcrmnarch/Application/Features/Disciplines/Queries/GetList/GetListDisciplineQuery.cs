using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Disciplines.Queries.GetList;

public class GetListDisciplineQuery : IRequest<GetListResponse<GetListDisciplineListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDisciplines({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDisciplines";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDisciplineQueryHandler : IRequestHandler<GetListDisciplineQuery, GetListResponse<GetListDisciplineListItemDto>>
    {
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly IMapper _mapper;

        public GetListDisciplineQueryHandler(IDisciplineRepository disciplineRepository, IMapper mapper)
        {
            _disciplineRepository = disciplineRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDisciplineListItemDto>> Handle(GetListDisciplineQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Discipline> disciplines = await _disciplineRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDisciplineListItemDto> response = _mapper.Map<GetListResponse<GetListDisciplineListItemDto>>(disciplines);
            return response;
        }
    }
}