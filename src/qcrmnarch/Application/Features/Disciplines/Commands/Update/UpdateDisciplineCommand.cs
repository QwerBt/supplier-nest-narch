using Application.Features.Disciplines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Disciplines.Commands.Update;

public class UpdateDisciplineCommand : IRequest<UpdatedDisciplineResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required string Description { get; set; }
    public required int JobFunctionId { get; set; }
    public required JobFunction JobFunction { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisciplines"];

    public class UpdateDisciplineCommandHandler : IRequestHandler<UpdateDisciplineCommand, UpdatedDisciplineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly DisciplineBusinessRules _disciplineBusinessRules;

        public UpdateDisciplineCommandHandler(IMapper mapper, IDisciplineRepository disciplineRepository,
                                         DisciplineBusinessRules disciplineBusinessRules)
        {
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _disciplineBusinessRules = disciplineBusinessRules;
        }

        public async Task<UpdatedDisciplineResponse> Handle(UpdateDisciplineCommand request, CancellationToken cancellationToken)
        {
            Discipline? discipline = await _disciplineRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disciplineBusinessRules.DisciplineShouldExistWhenSelected(discipline);
            discipline = _mapper.Map(request, discipline);

            await _disciplineRepository.UpdateAsync(discipline!);

            UpdatedDisciplineResponse response = _mapper.Map<UpdatedDisciplineResponse>(discipline);
            return response;
        }
    }
}