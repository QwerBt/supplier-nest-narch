using Application.Features.Disciplines.Constants;
using Application.Features.Disciplines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.Disciplines.Commands.Delete;

public class DeleteDisciplineCommand : IRequest<DeletedDisciplineResponse>, ICacheRemoverRequest, ILoggableRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDisciplines"];

    public class DeleteDisciplineCommandHandler : IRequestHandler<DeleteDisciplineCommand, DeletedDisciplineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly DisciplineBusinessRules _disciplineBusinessRules;

        public DeleteDisciplineCommandHandler(IMapper mapper, IDisciplineRepository disciplineRepository,
                                         DisciplineBusinessRules disciplineBusinessRules)
        {
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _disciplineBusinessRules = disciplineBusinessRules;
        }

        public async Task<DeletedDisciplineResponse> Handle(DeleteDisciplineCommand request, CancellationToken cancellationToken)
        {
            Discipline? discipline = await _disciplineRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disciplineBusinessRules.DisciplineShouldExistWhenSelected(discipline);

            await _disciplineRepository.DeleteAsync(discipline!);

            DeletedDisciplineResponse response = _mapper.Map<DeletedDisciplineResponse>(discipline);
            return response;
        }
    }
}