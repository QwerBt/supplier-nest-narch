using Application.Features.Towns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Towns.Commands.Update;

public class UpdateTownCommand : IRequest<UpdatedTownResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int CityId { get; set; }
    public required City City { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTowns"];

    public class UpdateTownCommandHandler : IRequestHandler<UpdateTownCommand, UpdatedTownResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITownRepository _townRepository;
        private readonly TownBusinessRules _townBusinessRules;

        public UpdateTownCommandHandler(IMapper mapper, ITownRepository townRepository,
                                         TownBusinessRules townBusinessRules)
        {
            _mapper = mapper;
            _townRepository = townRepository;
            _townBusinessRules = townBusinessRules;
        }

        public async Task<UpdatedTownResponse> Handle(UpdateTownCommand request, CancellationToken cancellationToken)
        {
            Town? town = await _townRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _townBusinessRules.TownShouldExistWhenSelected(town);
            town = _mapper.Map(request, town);

            await _townRepository.UpdateAsync(town!);

            UpdatedTownResponse response = _mapper.Map<UpdatedTownResponse>(town);
            return response;
        }
    }
}