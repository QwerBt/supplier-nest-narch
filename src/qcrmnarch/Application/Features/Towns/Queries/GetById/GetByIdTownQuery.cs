using Application.Features.Towns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Towns.Queries.GetById;

public class GetByIdTownQuery : IRequest<GetByIdTownResponse>
{
    public int Id { get; set; }

    public class GetByIdTownQueryHandler : IRequestHandler<GetByIdTownQuery, GetByIdTownResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITownRepository _townRepository;
        private readonly TownBusinessRules _townBusinessRules;

        public GetByIdTownQueryHandler(IMapper mapper, ITownRepository townRepository, TownBusinessRules townBusinessRules)
        {
            _mapper = mapper;
            _townRepository = townRepository;
            _townBusinessRules = townBusinessRules;
        }

        public async Task<GetByIdTownResponse> Handle(GetByIdTownQuery request, CancellationToken cancellationToken)
        {
            Town? town = await _townRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _townBusinessRules.TownShouldExistWhenSelected(town);

            GetByIdTownResponse response = _mapper.Map<GetByIdTownResponse>(town);
            return response;
        }
    }
}