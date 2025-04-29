using Application.Features.Towns.Constants;
using Application.Features.Towns.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;

namespace Application.Features.Towns.Commands.Delete;

public class DeleteTownCommand : IRequest<DeletedTownResponse>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTowns"];

    public class DeleteTownCommandHandler : IRequestHandler<DeleteTownCommand, DeletedTownResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITownRepository _townRepository;
        private readonly TownBusinessRules _townBusinessRules;

        public DeleteTownCommandHandler(IMapper mapper, ITownRepository townRepository,
                                         TownBusinessRules townBusinessRules)
        {
            _mapper = mapper;
            _townRepository = townRepository;
            _townBusinessRules = townBusinessRules;
        }

        public async Task<DeletedTownResponse> Handle(DeleteTownCommand request, CancellationToken cancellationToken)
        {
            Town? town = await _townRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _townBusinessRules.TownShouldExistWhenSelected(town);

            await _townRepository.DeleteAsync(town!);

            DeletedTownResponse response = _mapper.Map<DeletedTownResponse>(town);
            return response;
        }
    }
}