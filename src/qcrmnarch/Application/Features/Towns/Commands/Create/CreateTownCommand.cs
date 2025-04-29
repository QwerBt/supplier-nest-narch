using Application.Features.Towns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Towns.Commands.Create;

public class CreateTownCommand : IRequest<CreatedTownResponse>, ICacheRemoverRequest
{
    public required string Name { get; set; }
    public required int CityId { get; set; }
    public required City City { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTowns"];

    public class CreateTownCommandHandler : IRequestHandler<CreateTownCommand, CreatedTownResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITownRepository _townRepository;
        private readonly TownBusinessRules _townBusinessRules;

        public CreateTownCommandHandler(IMapper mapper, ITownRepository townRepository,
                                         TownBusinessRules townBusinessRules)
        {
            _mapper = mapper;
            _townRepository = townRepository;
            _townBusinessRules = townBusinessRules;
        }

        public async Task<CreatedTownResponse> Handle(CreateTownCommand request, CancellationToken cancellationToken)
        {
            Town town = _mapper.Map<Town>(request);

            await _townRepository.AddAsync(town);

            CreatedTownResponse response = _mapper.Map<CreatedTownResponse>(town);
            return response;
        }
    }
}