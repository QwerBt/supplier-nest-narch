using Application.Features.Disciplines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Disciplines.Commands.Create;

public class CreateDisciplineCommand : IRequest<CreatedDisciplineResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }
    public required int JobFunctionId { get; set; }
    public required JobFunction JobFunction { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisciplines"];

    public class CreateDisciplineCommandHandler : IRequestHandler<CreateDisciplineCommand, CreatedDisciplineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly DisciplineBusinessRules _disciplineBusinessRules;

        public CreateDisciplineCommandHandler(IMapper mapper, IDisciplineRepository disciplineRepository,
                                         DisciplineBusinessRules disciplineBusinessRules)
        {
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _disciplineBusinessRules = disciplineBusinessRules;
        }

        public async Task<CreatedDisciplineResponse> Handle(CreateDisciplineCommand request, CancellationToken cancellationToken)
        {
            Discipline discipline = _mapper.Map<Discipline>(request);

            await _disciplineRepository.AddAsync(discipline);

            CreatedDisciplineResponse response = _mapper.Map<CreatedDisciplineResponse>(discipline);
            return response;
        }
    }
}