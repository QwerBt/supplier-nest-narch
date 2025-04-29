using Application.Features.Disciplines.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Disciplines.Queries.GetById;

public class GetByIdDisciplineQuery : IRequest<GetByIdDisciplineResponse>
{
    public int Id { get; set; }

    public class GetByIdDisciplineQueryHandler : IRequestHandler<GetByIdDisciplineQuery, GetByIdDisciplineResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDisciplineRepository _disciplineRepository;
        private readonly DisciplineBusinessRules _disciplineBusinessRules;

        public GetByIdDisciplineQueryHandler(IMapper mapper, IDisciplineRepository disciplineRepository, DisciplineBusinessRules disciplineBusinessRules)
        {
            _mapper = mapper;
            _disciplineRepository = disciplineRepository;
            _disciplineBusinessRules = disciplineBusinessRules;
        }

        public async Task<GetByIdDisciplineResponse> Handle(GetByIdDisciplineQuery request, CancellationToken cancellationToken)
        {
            Discipline? discipline = await _disciplineRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _disciplineBusinessRules.DisciplineShouldExistWhenSelected(discipline);

            GetByIdDisciplineResponse response = _mapper.Map<GetByIdDisciplineResponse>(discipline);
            return response;
        }
    }
}